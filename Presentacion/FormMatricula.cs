using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Entidades;
using CapaNegocio;
using System.Windows.Forms;

/// <author>Francisco David Manzanedo Valle.</author>
namespace Presentacion
{

    public partial class FormMatricula : Form
    {
        private readonly Universidad _univeridad;
        private Grado _grado;
        private Persona _alumno;
        private CursoEscolar _cursoEscolar;

        private readonly List<Grado> _listaGrados;
        private readonly List<CursoEscolar> _listaCursoEscolar;
        private List<AlumnoSeMatriculaAsignatura> _listaAlumnosMatriculadosAsignaturas;
        private List<Asignatura> _listaAsignaturas;

        private int _idGrado;
        private int _idAsignatura;
        private int _idCursoEscolar;

        private DataTable _tablaAsignaturas;
        private DataTable _tablaGrados;
        private DataTable _tablaResultadoMatricula;
        private readonly ToolTip _toolTip;
        private FormBuscarPersonas _formBuscarPersonas;

        private string _modoFormulario;
       
        private const string MODO_FORMULARIO_CREAR_MATRICULA = "crear_matricula";
        private const string MODO_FORMULARIO_CONSULTAR_EDITAR_MATRICULA = "consultar_editar_matricula";
        private const string MODO_FORMULARIO_ELIMINAR_MATRICULA = "eliminar_matricula";

        /// <summary>
        /// Constructor sin parámetros al que llama el formulario menú principal
        /// </summary>
        public FormMatricula()
        {
            InitializeComponent();
            _univeridad = new Universidad();
            _toolTip = new ToolTip();
            _listaGrados = _univeridad.ListarGrados();
            _listaCursoEscolar = _univeridad.ListarCursosEscolares();
            _listaAlumnosMatriculadosAsignaturas = _univeridad.ListarAlumnoSeMatriculaAsignatura();
            lblResultadoAsignaturas.Visible = false;
        }

        /// <summary>
        /// Constructor con parámetros al que llama el formulario de búsqueda de alumnos
        /// </summary>
        /// <param name="alumno">Alumno seleccionado en el buscador</param>
        /// <param name="modoFormulario">Modo del formulario: Crear, Modifica o Eliminar</param>
        public FormMatricula(Persona alumno, string modoFormulario)
        {
            InitializeComponent();

            _univeridad = new Universidad();
            _toolTip = new ToolTip();

            this._alumno = alumno;
            this._modoFormulario = modoFormulario;

            _listaGrados = _univeridad.ListarGrados();
            _listaCursoEscolar = _univeridad.ListarCursosEscolares();
            _listaAlumnosMatriculadosAsignaturas = _univeridad.ListarAlumnoSeMatriculaAsignatura();

            _formBuscarPersonas = new FormBuscarPersonas("");
            _idGrado = 0;
            _idAsignatura = 0;
            _idCursoEscolar = 0;
            lblResultadoAsignaturas.Visible = false;
            lblGradoSeleccionado.Visible = false;

            CrearTablaResultadoMatricula();
            RellenarCamposAlumno(alumno);
        }


        private void FormMatricula_Load(object sender, EventArgs e)
        {
            switch (_modoFormulario)
            {
                case MODO_FORMULARIO_CREAR_MATRICULA:
                    _toolTip.SetToolTip(BtnSelecionarAlumno, "Buscar alumno");
                    _toolTip.SetToolTip(BtnCrearMatricula, "Crear una nueva matrícula");
                    _toolTip.SetToolTip(BtnCancelarMatricula, "Cerrar formulario.");
                     BtnCrearMatricula.Enabled = false;
                    if (!string.IsNullOrEmpty(TxtbNIF.Text)) MostrarGrados();
                    break;

                case MODO_FORMULARIO_CONSULTAR_EDITAR_MATRICULA:
                    _toolTip.SetToolTip(BtnSelecionarAlumno, "Buscar alumno");
                    _toolTip.SetToolTip(BtnCrearMatricula, "Modificar matrícula");
                    _toolTip.SetToolTip(BtnCancelarMatricula, "Cerrar formulario.");
                    BtnCrearMatricula.Text = "Modificar";
                    BtnCrearMatricula.Enabled = false;
                    if (!string.IsNullOrEmpty(TxtbNIF.Text))
                    {
                        BtnCrearMatricula.Enabled = true;
                        MostrarResultadoMatricula(_alumno);
                    }
                    break;

                case MODO_FORMULARIO_ELIMINAR_MATRICULA:
                    _toolTip.SetToolTip(BtnCrearMatricula, "Eliminar matrícula");
                    _toolTip.SetToolTip(BtnCancelarMatricula, "Cerrar formulario.");
                    if (!string.IsNullOrEmpty(TxtbNIF.Text)) 
                    {
                        BtnCrearMatricula.Enabled = false;
                        groupBoxAsigSeleccionadas.Text = "Selecciona matricula a eliminar";
                        MostrarResultadoMatricula(_alumno);
                    } 
                    break;
            }
        }

        //Evento click sobre el botón seleccionar alumno que abre el formulario de búsqueda, en modo "Solo alumnos"
        private void BtnSelecionarAlumno_Click(object sender, EventArgs e)
        {
            switch (_modoFormulario)
            {
                case MODO_FORMULARIO_CREAR_MATRICULA:
                    LanzarFormularioBusquedaAlumno(MODO_FORMULARIO_CREAR_MATRICULA);
                    break;
                case MODO_FORMULARIO_CONSULTAR_EDITAR_MATRICULA:
                    LanzarFormularioBusquedaAlumno(MODO_FORMULARIO_CONSULTAR_EDITAR_MATRICULA);
                    break;
                case MODO_FORMULARIO_ELIMINAR_MATRICULA:
                    LanzarFormularioBusquedaAlumno(MODO_FORMULARIO_ELIMINAR_MATRICULA);
                    break;
            }
        }

        //Selecciona el grado para crear la matrícula.
        private void DGVGrados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_modoFormulario.Equals(MODO_FORMULARIO_ELIMINAR_MATRICULA) || _modoFormulario.Equals(MODO_FORMULARIO_CONSULTAR_EDITAR_MATRICULA))
                DGVGrados.ReadOnly = true;
            else
            {
                int rowIndex = DGVGrados.SelectedCells[0].RowIndex;
                _idGrado = Convert.ToInt32(DGVGrados.Rows[rowIndex].Cells[0].Value);
                _grado = _univeridad.LeerGrado(_idGrado);
                _grado.ListaAsignaturas = _univeridad.LeerAsignaturasDeUnGrado(_idGrado);

                MostrarAsignaturas(_grado.ListaAsignaturas);
            }
        }

        //Añade asignatuas en el DataaGridView Matriculas al hacer doble click sobre un registro.
        private void DGVAsignaturas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_modoFormulario.Equals(MODO_FORMULARIO_ELIMINAR_MATRICULA))
                DGVAsignaturas.ReadOnly = true;

            else
            {
                int rowIndex = DGVAsignaturas.SelectedCells[0].RowIndex;
                _idAsignatura = Convert.ToInt32(DGVAsignaturas.Rows[rowIndex].Cells[0].Value);
                _grado.ListaAsignaturas = _univeridad.LeerAsignaturasDeUnGrado(_idGrado);
                if (ComprobarAsignaturaAnyadida(_idAsignatura))
                {
                    foreach (Asignatura a in _grado.ListaAsignaturas)
                    {
                        if (a.Id_Asignatura == _idAsignatura)
                        {
                            DataRow row = _tablaResultadoMatricula.NewRow();
                            row["ID"] = a.Id_Asignatura;
                            row["Asignatura"] = a.Nombre;
                            row["Créditos"] = a.Creditos;
                            row["Tipo"] = a.Tipo;
                            row["Curso"] = a.Curso;
                            row["Cuatrimestre"] = a.Cuatrimestre;
                            _tablaResultadoMatricula.Rows.Add(row); 
                        }
                    }

                    DGVResultadoMatricula.DataSource = _tablaResultadoMatricula;

                    if (DGVResultadoMatricula.RowCount == 0)
                        BtnCrearMatricula.Enabled = false;
                    else
                        BtnCrearMatricula.Enabled = true;
                }
                else
                    MostrarMessageBox("La asignatura ya ha sido añadida previamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void DGVResultadoMatricula_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = DGVResultadoMatricula.SelectedCells[0].RowIndex;
            _idAsignatura = Convert.ToInt32(DGVResultadoMatricula.Rows[rowIndex].Cells[0].Value);

            Asignatura asignatura = _univeridad.LeerAsignatura(_idAsignatura);

            switch (_modoFormulario)
            {
                case MODO_FORMULARIO_ELIMINAR_MATRICULA:
                    DialogResult resultadoEliminar = MessageBox.Show("Curso escolar: " + _cursoEscolar.Anyo_Inicio + "/" + _cursoEscolar.Anyo_Fin + Environment.NewLine +
                            "Alumno: " + _alumno.NombreCompleto + Environment.NewLine +"Grado: " + _grado.Nombre + Environment.NewLine 
                            + "Asignatura: " + asignatura.Nombre + Environment.NewLine + "¿Eliminar matrícula?", "Confimación",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);

                    if (resultadoEliminar == DialogResult.Yes)
                    {
                        bool eliminarMatricula = _univeridad.EliminarAlumnoMatriculado(_alumno.Id_Persona, _idAsignatura, _idCursoEscolar);
                        if (eliminarMatricula)
                        {
                            MostrarMessageBox("Matrícula eliminada", "Inforcación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            foreach(DataGridViewCell elemento in this.DGVResultadoMatricula.SelectedCells)
                                DGVResultadoMatricula.Rows.RemoveAt(elemento.RowIndex);
                            DGVResultadoMatricula.Refresh();
                        }
                    }
                    break;

                case MODO_FORMULARIO_CONSULTAR_EDITAR_MATRICULA:
                    DialogResult resultadoEditar = MessageBox.Show("¿Eliminar matrícula de la asignatura "+asignatura.Nombre+"?", "Confimación",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);

                    if (resultadoEditar == DialogResult.Yes)
                    {
                        bool eliminarMatricula = _univeridad.EliminarAlumnoMatriculado(_alumno.Id_Persona, _idAsignatura, _idCursoEscolar);
                        if (eliminarMatricula)
                        {
                            MostrarMessageBox("Matrícula eliminada", "Inforcación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            foreach (DataGridViewCell elemento in this.DGVResultadoMatricula.SelectedCells)
                                DGVResultadoMatricula.Rows.RemoveAt(elemento.RowIndex);
                            DGVResultadoMatricula.Refresh();
                        }
                    }

                    break;
            }
        }

        //Evento click sobre el botón de CrearMatrícula
        private void BtnCrearMatricula_Click(object sender, EventArgs e)
        {
            AlumnoSeMatriculaAsignatura a = null;
            List<Asignatura> listaAsignaturasAux = new List<Asignatura>();
            //Obtengo id del curso actual a través del año
            foreach (CursoEscolar c in _listaCursoEscolar)
            {
                if (c.Anyo_Inicio == DateTime.Now.Year)
                    _idCursoEscolar = c.Id_Curso_Escolar;
            }

            _cursoEscolar = _univeridad.LeerCursoEscolar(_idCursoEscolar);
            switch (_modoFormulario)
            {
                case MODO_FORMULARIO_CREAR_MATRICULA:
                    if (_cursoEscolar != null)
                    {
                        for (int i = 0; i < DGVResultadoMatricula.Rows.Count - 1; i++)
                        {
                            _idAsignatura = Convert.ToInt32(DGVResultadoMatricula.Rows[i].Cells["ID"].Value);
                            a = _univeridad.InsertarAlumnoMatriculado(_alumno.Id_Persona, _idAsignatura, _idCursoEscolar);
                            listaAsignaturasAux.Add(_univeridad.LeerAsignatura(_idAsignatura));
                        }

                        if (a != null)
                        {
                            DialogResult resultado = MostrarConfirmacion(_alumno, _grado, _cursoEscolar, listaAsignaturasAux, "¿Realizar matrícula?");
                            if (resultado == DialogResult.Yes)
                            {
                                MostrarMessageBox("Matrícula creada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                VaciarCampos();
                            }

                        }
                        else
                            MostrarMessageBox("Ha ocurrido un error al crear la matrícula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case MODO_FORMULARIO_CONSULTAR_EDITAR_MATRICULA:
                    if (_cursoEscolar != null)
                    {
                        for (int i = 0; i < DGVResultadoMatricula.Rows.Count - 1; i++)
                        {
                            _idAsignatura = Convert.ToInt32(DGVResultadoMatricula.Rows[i].Cells["ID"].Value);
                            a = _univeridad.ActualizarAlumnoMatriculado(_alumno.Id_Persona, _idAsignatura, _idCursoEscolar);
                            listaAsignaturasAux.Add(_univeridad.LeerAsignatura(_idAsignatura));
                        }

                        if (a != null)
                        {
                            DialogResult resultado = MostrarConfirmacion(_alumno, _grado, _cursoEscolar, listaAsignaturasAux, "¿Modificar matrícula?");
                            if (resultado == DialogResult.Yes)
                            {
                                MostrarMessageBox("Matrícula modificada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                VaciarCampos();
                            }
                        }
                        else
                            MostrarMessageBox("Ha ocurrido un error al crear la matrícula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
           
        }

        //Evento click sobre el botón cancelar para cerrar el formulario
        private void BtnCancelarMatricula_Click(object sender, EventArgs e) => this.Close();


        ///-------------------------------------- Funciones Auxiliares ----------------------------------------------------------------///        



        /// <summary>
        /// Lanza el formulario de búsque de alumnos indicando el modo de formulario.
        /// </summary>
        /// <param name="modoFormulario">String correspondiente al modo de formulario</param>
        private void LanzarFormularioBusquedaAlumno(string modoFormulario)
        {
            _formBuscarPersonas.Close();
            _formBuscarPersonas = new(modoFormulario);
            _formBuscarPersonas.MdiParent = this.MdiParent;
            _formBuscarPersonas.ControlBox = false;
            _formBuscarPersonas.WindowState = FormWindowState.Maximized;
            _formBuscarPersonas.Show();
        }

        /// <summary>
        /// Rellena los textBox con los datos del alumno resultado de la búsqueda.
        /// </summary>
        /// <param name="alumno"><see cref="Persona"/> de tipo Alumno.</param>
        private void RellenarCamposAlumno(Persona alumno)
        {
            if (alumno != null)
            {
                TxtbNIF.Text = alumno.Nif;
                TxtbNombre.Text = alumno.Nombre;
                TxtbPrimerApell.Text = alumno.Apellido1;
            }
        }

        /// <summary>
        /// Crea las cabeceras del DataGridView resultado de la matrícula
        /// </summary>
        private void CrearTablaResultadoMatricula()
        {
            _tablaResultadoMatricula = new DataTable();
            _tablaResultadoMatricula.Columns.Add("ID");
            _tablaResultadoMatricula.Columns.Add("Asignatura");
            _tablaResultadoMatricula.Columns.Add("Créditos");
            _tablaResultadoMatricula.Columns.Add("Tipo");
            _tablaResultadoMatricula.Columns.Add("Curso");
            _tablaResultadoMatricula.Columns.Add("Cuatrimestre");
        }

        /// <summary>
        /// Muestra los grados en el DateGridView Grados.
        /// </summary>
        private void MostrarGrados()
        {
            _tablaGrados = new DataTable();
            _tablaGrados.Columns.Add("ID");
            _tablaGrados.Columns.Add("Nombre");

            foreach (Grado g in _listaGrados)
            {
                DataRow row = _tablaGrados.NewRow();
                row["ID"] = g.Id_Grado;
                row["Nombre"] = g.Nombre;
                _tablaGrados.Rows.Add(row);
            }
            DGVGrados.DataSource = _tablaGrados;
            DataView vista = new(_tablaGrados);
            DGVGrados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        /// <summary>
        /// Muestra un grado en el tableView de grados
        /// </summary>
        /// <param name="grado"></param>
        private void MostrarGrado(Grado grado)
        {
            _tablaGrados = new DataTable();
            _tablaGrados.Columns.Add("ID");
            _tablaGrados.Columns.Add("Nombre");

            DataRow row = _tablaGrados.NewRow();
            row["ID"] = grado.Id_Grado;
            row["Nombre"] = grado.Nombre;
            _tablaGrados.Rows.Add(row);

            DGVGrados.DataSource = _tablaGrados;
            lblGradoSeleccionado.Text = "Grado: "+grado.Nombre;
        }

        /// <summary>
        /// Muestra las asignaturas en el DataGridView Asignaturas-
        /// </summary>
        private void MostrarAsignaturas(List<Asignatura> listaAsignaturas)
        {
            _tablaAsignaturas = new DataTable();
            _tablaAsignaturas.Columns.Add("ID");
            _tablaAsignaturas.Columns.Add("Nombre");
            _tablaAsignaturas.Columns.Add("Creditos");
            _tablaAsignaturas.Columns.Add("Tipo");
            _tablaAsignaturas.Columns.Add("Curso");
            _tablaAsignaturas.Columns.Add("Cuatrimestre");

            if (listaAsignaturas.Count > 0)
            {
                foreach (Asignatura a in listaAsignaturas)
                {
                    DataRow row = _tablaAsignaturas.NewRow();
                    row["ID"] = a.Id_Asignatura;
                    row["Nombre"] = a.Nombre;
                    row["Creditos"] = a.Creditos;
                    row["Tipo"] = a.Tipo;
                    row["Curso"] = a.Curso;
                    row["Cuatrimestre"] = a.Cuatrimestre;

                    _tablaAsignaturas.Rows.Add(row);
                }

                DGVAsignaturas.DataSource = _tablaAsignaturas;
                lblGradoSeleccionado.Visible = true;
                lblGradoSeleccionado.ForeColor = Color.Green;
                lblGradoSeleccionado.Text = "Grado: " + _grado.Nombre;
                lblResultadoAsignaturas.Visible = false;
            }
            else
            {
                DGVAsignaturas.DataSource = null;
                lblResultadoAsignaturas.Visible = true;
                lblGradoSeleccionado.Visible = false;
            }
        }

        /// <summary>
        /// Elimina la matrícula correspondiente a un alumno
        /// </summary>
        /// <param name="alumno"></param>
        private void MostrarResultadoMatricula(Persona alumno)
        {
            _listaAsignaturas = new List<Asignatura>();
           
            foreach (AlumnoSeMatriculaAsignatura a in _listaAlumnosMatriculadosAsignaturas)
            {
                if (a.Id_Alumno == alumno.Id_Persona)
                {
                    _listaAsignaturas.Add(_univeridad.LeerAsignatura(a.Id_Asignatura));
                    _idCursoEscolar = a.Id_Curso_Escolar;
                }
            }

            _cursoEscolar = _univeridad.LeerCursoEscolar(_idCursoEscolar);

            foreach (Asignatura a in _listaAsignaturas)
            {
                _idGrado = a.Id_Grado;

                DataRow row = _tablaResultadoMatricula.NewRow();
                row["ID"] = a.Id_Asignatura;
                row["Asignatura"] = a.Nombre;
                row["Créditos"] = a.Creditos;
                row["Tipo"] = a.Tipo;
                row["Curso"] = a.Curso;
                row["Cuatrimestre"] = a.Cuatrimestre;
                _tablaResultadoMatricula.Rows.Add(row);
            }

            DGVResultadoMatricula.DataSource = _tablaResultadoMatricula;

            _grado = _univeridad.LeerGrado(_idGrado);
            MostrarGrado(_grado);

            List<Asignatura> listaAsignaturasGradoAux = new List<Asignatura>();
            if (_modoFormulario.Equals(MODO_FORMULARIO_CONSULTAR_EDITAR_MATRICULA))
            {
                List<Asignatura> listaAsignaturasGrado = _univeridad.ListarAsignaturas();
                foreach(Asignatura a in listaAsignaturasGrado)
                {
                    if(a.Id_Grado == _grado.Id_Grado)
                        listaAsignaturasGradoAux.Add(_univeridad.LeerAsignatura(a.Id_Asignatura));
                }
                MostrarAsignaturas(listaAsignaturasGradoAux);
            }
        }

        /// <summary>
        /// Comprueba si se intenta añadir una segunda vez la misma asignatura al DataGridView de Matriculas
        /// </summary>
        /// <param name="idAsignatura">Integer correspondiente al id de la asignatura añadida</param>
        /// <returns>Boolean: true si ya se ha añadido, false si no</returns>
        private bool ComprobarAsignaturaAnyadida(int idAsignatura)
        {
            bool resultado = true;
            for(int i = 0; i<DGVResultadoMatricula.Rows.Count; i++)
            {
                if(idAsignatura == Convert.ToInt32(DGVResultadoMatricula.Rows[i].Cells["ID"].Value))
                    resultado = false;
            }

            return resultado;
        }

        /// <summary>
        /// Muestra una ventana emergente de confirmación.
        /// </summary>
        /// <param name="p">Objeto de tipo <see cref="Persona"/></param>
        /// <returns>DialogResult con el resultado de la acción del usuario.</returns>
        private DialogResult MostrarConfirmacion(Persona alumno, Grado grado, CursoEscolar cursoEscolar, List<Asignatura> asignaturas, string acción)
        {
            string resultadoAsignaturas = "Lista de asignaturas: " + Environment.NewLine;
            foreach (Asignatura a in asignaturas)
            {
                resultadoAsignaturas += a.Nombre + Environment.NewLine+
                    "Tipo: " + a.Tipo + Environment.NewLine+"Curso: " + a.Curso +Environment.NewLine+ 
                    "Créditos" + a.Creditos + Environment.NewLine+"Cuatrimestre" + a.Cuatrimestre + Environment.NewLine+Environment.NewLine;
            }

            DialogResult resultado = MessageBox.Show("Curso escolar: "+cursoEscolar.Anyo_Inicio+"/"+cursoEscolar.Anyo_Fin+Environment.NewLine+
                "Alumno: "+alumno.NombreCompleto+ Environment.NewLine+
                "Grado: "+grado.Nombre +Environment.NewLine+
                resultadoAsignaturas+Environment.NewLine+
                acción, "Confimación",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);
            return resultado;
        }

        /// <summary>
        /// Muestra una MessageBox contextual.
        /// </summary>
        /// <param name="mensaje">string correspondiente al mensaje de error.</param>
        /// <param name="contexto">string contexto del error.</param>
        /// <param name="btn">Botón a seleccionar por el usuario.</param>
        /// <param name="icono">Tipo de icono de la ventana.</param>
        private void MostrarMessageBox(string mensaje, string contexto, MessageBoxButtons btn, MessageBoxIcon icono) =>
         MessageBox.Show(mensaje + Environment.NewLine, contexto, btn, icono);

        /// <summary>
        /// Vacía los campos del formulario o los establece a su valor por defecto.
        /// </summary>
        private void VaciarCampos()
        {
            TxtbNIF.Clear();
            TxtbNombre.Clear();
            TxtbPrimerApell.Clear();
            lblGradoSeleccionado.Visible = false;
            BtnCrearMatricula.Enabled = false;
            DGVAsignaturas.DataSource = null;
            DGVGrados.DataSource = null;
            DGVResultadoMatricula.DataSource = null;
        }

    }
}
