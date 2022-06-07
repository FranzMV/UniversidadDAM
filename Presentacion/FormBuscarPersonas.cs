using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Entidades;
using CapaNegocio;

/// <author> Francisco David Manzanedo Valle.</author>
namespace Presentacion
{
    public partial class FormBuscarPersonas : Form
    {
        private readonly Universidad _universidad;
        private List<Persona> _listaPersonas;
        private List<Persona> _listaPersonas_Alumnos;
        private DataTable _tabla;
        private DataView _vistaTabla;
        private ToolTip _toolTip;
        private FormMatricula _formMatricula;

        private string _modoFormulario;

        #region Constantes
        //Mdos del formulario para la búsqueda de personas
        private const string MODO_BUSQUEDA_ELIMINAR_PERSONAS = "eliminar";
        private const string MODO_BUSQUEDA_EDITAR_PERSONAS = "editar";
        //Modos del formulario para búsqueda de alumnos correspondiente a una matrícula
        private const string MODO_BUSQUEDA_CREAR_MATRICULA = "crear_matricula";
        private const string MODO_BUSQUEDA_ELIMINAR_MATRICULA = "eliminar_matricula";
        private const string MODO_BUSQUEDA_CONSULTAR_EDITAR_MATRICULA = "consultar_editar_matricula";
        //Tipos de persona  
        private const string TIPO_PERSONA_PROFESOR = "profesor";
        private const string TIPO_PERSONA_ALUMNO = "alumno";
        #endregion

        public FormBuscarPersonas(string modoFormulario)
        {
            InitializeComponent();
            _universidad = new Universidad();
            _modoFormulario = modoFormulario;

            _listaPersonas = new List<Persona>();
            _listaPersonas_Alumnos = new List<Persona>();
            _vistaTabla = new DataView();
            _toolTip = new ToolTip();

            _formMatricula = new FormMatricula();
        }

        //Evento Load del formulario
        private void FormBuscarPersonas_Load(object sender, EventArgs e) 
        {
            _toolTip.SetToolTip(BtnCancelarBusqueda, "Cerrar formulario");

            if (_modoFormulario.Equals(MODO_BUSQUEDA_CREAR_MATRICULA) 
                || _modoFormulario.Equals(MODO_BUSQUEDA_ELIMINAR_MATRICULA) 
                || _modoFormulario.Equals(MODO_BUSQUEDA_CONSULTAR_EDITAR_MATRICULA))
            {
                MostrarAlumnos();
            }

            else MostrarPersonas();
        } 
       
        //Evento sobre el checkBox para aplicar el filtro de búsqueda NIF
        private void CheckBoxNomApell_CheckedChanged(object sender, EventArgs e) => CheckBoxNIF.Checked = false;

        //Evento sobre el checkBox para aplicar el filtro de búsqueda Nombre y Apellidos
        private void CheckBoxNIF_CheckedChanged(object sender, EventArgs e) => CheckBoxNomApell.Checked = false;
      
        //Evento que realiza la búsqueda incremental y muestra las coincidencias en el DataGridView de Personas.
        private void TxtBoxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtBoxBuscar.Text))
            {
                if (CheckBoxNomApell.Checked)
                {
                    _vistaTabla.RowFilter = string.Format("Nombre+Apellido1+Apellido2 LIKE '%{0}%'", TxtBoxBuscar.Text);
                    DGVPersonas.DataSource = _vistaTabla;
                    QuitarAviso(panelBarraBusqueda);
                    e.Handled = false;
                }
                else if (CheckBoxNIF.Checked)
                {
                    _vistaTabla.RowFilter = string.Format("NIF LIKE '%{0}%'", TxtBoxBuscar.Text);
                    DGVPersonas.DataSource = _vistaTabla;
                    QuitarAviso(panelBarraBusqueda);
                    e.Handled = false;
                }
                else
                {
                    MostrarAviso(panelBarraBusqueda, "Seleccione un filtro de búsqueda.");
                    e.Handled = false;
                }

            }
            else DGVPersonas.Refresh();
        }

        //Evento doble click sobre los registros del dataViewPersonas
        private void DGVPersonas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult resultado;
            if (DGVPersonas.SelectedRows.Count == 0)
            {
                int rowIndex = DGVPersonas.SelectedCells[0].RowIndex;
                int idPersona = Convert.ToInt32(DGVPersonas.Rows[rowIndex].Cells[0].Value);
                Persona alumnoAux = _universidad.LeerPersona(idPersona);//-------> Para el caso de búsqueda de alumnos
                Persona personaAux = _universidad.LeerPersona(idPersona);//-------> Para el caso de búsqueda de alumnos y personas
                switch (_modoFormulario)
                {
                    //MODO FORMULARIO CORRESPONDIENTES A LA BÚSQUEDA DE PROFESORES Y ALUMNOS
                    case MODO_BUSQUEDA_EDITAR_PERSONAS:
                        FormAnyadirPersonas formModificarPersona = new FormAnyadirPersonas(idPersona, MODO_BUSQUEDA_EDITAR_PERSONAS);
                        formModificarPersona.MdiParent = this.MdiParent;
                        formModificarPersona.Text = "Editar Persona";
                        formModificarPersona.Show();
                        VaciarCampos();
                        MostrarPersonas();
                        break;

                    case MODO_BUSQUEDA_ELIMINAR_PERSONAS:
                        //Persona personaAux = _universidad.LeerPersona(idPersona);
                        if (personaAux.Tipo.Equals(TIPO_PERSONA_PROFESOR))//--------> Si el registro seleccionado es de tipo profesor
                        {
                            resultado = MostrarConfirmacion(personaAux);
                            if (resultado == DialogResult.Yes)
                            {
                                _universidad.EliminarPersona(idPersona);
                                _universidad.EliminarProfesor(idPersona);
                                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                VaciarCampos();
                                MostrarPersonas();
                            }
                        }
                        else if (personaAux.Tipo.Equals(TIPO_PERSONA_ALUMNO))//-------> Si es de tipo alumno
                        {
                            resultado = MostrarConfirmacion(personaAux);
                            if (resultado == DialogResult.Yes)
                            {
                                _universidad.EliminarPersona(idPersona);
                                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                VaciarCampos();
                                MostrarPersonas();
                            }
                        }
                        break;

                    //MODO FORMULARIO CORRESPONDIENTES A UNA MATRÍCULA
                    case MODO_BUSQUEDA_CREAR_MATRICULA:
                        LanzarFormularioMatricula(alumnoAux, MODO_BUSQUEDA_CREAR_MATRICULA);
                        break;

                    case MODO_BUSQUEDA_CONSULTAR_EDITAR_MATRICULA:
                        LanzarFormularioMatricula(alumnoAux, MODO_BUSQUEDA_CONSULTAR_EDITAR_MATRICULA);                       
                        break;

                    case MODO_BUSQUEDA_ELIMINAR_MATRICULA:
                        LanzarFormularioMatricula(alumnoAux, MODO_BUSQUEDA_ELIMINAR_MATRICULA);
                        break;

                }
            }
        }

        //Envento de click de botón para cerrar el formulario
        private void BtnCancelarBusqueda_Click(object sender, EventArgs e) => this.Close();


        ///-------------------------------------- Funciones Auxiliares ----------------------------------------------------------------///

        ///<summary>
        ///Carga todos los datos en DataGridView de Personas
        /// </summary>
        private void MostrarPersonas()
        { 
            _listaPersonas = _universidad.ListarPersonas();
            _tabla = new DataTable();

            _tabla.Columns.Add("ID");
            _tabla.Columns.Add("Nombre");
            _tabla.Columns.Add("Apellido1");
            _tabla.Columns.Add("Apellido2");
            _tabla.Columns.Add("NIF");
            _tabla.Columns.Add("Telefono");
            _tabla.Columns.Add("Ciudad");
            _tabla.Columns.Add("Direccion");
            _tabla.Columns.Add("Fecha Nacimiento");
            _tabla.Columns.Add("Sexo");
            _tabla.Columns.Add("Tipo");
            _tabla.Columns.Add("Ruta Foto");

            foreach (Persona p in _listaPersonas)
            {
                DataRow row = _tabla.NewRow();
                row["ID"] = p.Id_Persona;
                row["Nombre"] = p.Nombre;
                row["Apellido1"] = p.Apellido1;
                row["Apellido2"] = p.Apellido2;
                row["NIF"] = p.Nif;
                row["Telefono"] = p.Telefono;
                row["Ciudad"] = p.Ciudad;
                row["Direccion"] = p.Direccion;
                row["Fecha Nacimiento"] = p.Fecha_Nacimiento;
                row["Sexo"] = p.Sexo;
                row["Tipo"] = p.Tipo;
                row["Ruta Foto"] = p.Ruta_Foto;

                _tabla.Rows.Add(row);
            }

            DGVPersonas.DataSource = _tabla;
            _vistaTabla = new DataView(_tabla);
        }

        /// <summary>
        /// Carga los alumnos en el Dataview de búsqueda
        /// </summary>
        private void MostrarAlumnos()
        {
            _listaPersonas_Alumnos = _universidad.ListarAlumnos();
            _tabla = new DataTable();

            _tabla.Columns.Add("ID");
            _tabla.Columns.Add("Nombre");
            _tabla.Columns.Add("Apellido1");
            _tabla.Columns.Add("Apellido2");
            _tabla.Columns.Add("NIF");
            _tabla.Columns.Add("Telefono");
            _tabla.Columns.Add("Ciudad");
            _tabla.Columns.Add("Direccion");
            _tabla.Columns.Add("Fecha Nacimiento");
            _tabla.Columns.Add("Sexo");
            _tabla.Columns.Add("Tipo");
            _tabla.Columns.Add("Ruta Foto");

            foreach (Persona p in _listaPersonas_Alumnos)
            {
                DataRow row = _tabla.NewRow();
                row["ID"] = p.Id_Persona;
                row["Nombre"] = p.Nombre;
                row["Apellido1"] = p.Apellido1;
                row["Apellido2"] = p.Apellido2;
                row["NIF"] = p.Nif;
                row["Telefono"] = p.Telefono;
                row["Ciudad"] = p.Ciudad;
                row["Direccion"] = p.Direccion;
                row["Fecha Nacimiento"] = p.Fecha_Nacimiento;
                row["Sexo"] = p.Sexo;
                row["Tipo"] = p.Tipo;
                row["Ruta Foto"] = p.Ruta_Foto;

                _tabla.Rows.Add(row);
                
                DGVPersonas.DataSource = _tabla;
                _vistaTabla = new DataView(_tabla);
                DGVPersonas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        /// <summary>
        /// Muestra una ventana emergente de confirmación.
        /// </summary>
        /// <param name="p">Objeto de tipo <see cref="Persona"/></param>
        /// <returns>DialogResult con el resultado de la acción del usuario.</returns>
        private DialogResult MostrarConfirmacion(Persona p)
        {
           DialogResult resultado = MessageBox.Show("¿Está usted seguro que desea eliminar el "+p.Tipo+": " + Environment.NewLine
                          + p.NombreCompleto + " con NIF: " + p.Nif + "?", "Confirmación",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);
            return resultado;
        }

        /// <summary>
        /// Muestra un <see cref="ToolTip" y <see cref="ErrorProvider"/> cuando se produce un error en un control.
        /// </summary>
        /// <param name="control">Control sobre el que se produce el error.</param>
        /// <param name="mensajeError">String correspondiente al mensaje de error a mostrar.</param>
        /// <returns>bool siempre a false para establecer que el valor del control no es correcto.</returns>
        private void MostrarAviso(Control control, string mensajeError)
        {
            _toolTip.SetToolTip(control, mensajeError);
            errorProvider.SetError(control, mensajeError);
        }

        /// <summary>
        /// Quita el aviso mostrado en la barra de búsqueda en caso de que el usuario ya tenga seleccionado el filtro
        /// para la misma.
        /// </summary>
        /// <param name="control">Barra de búsqueda</param>
        private void QuitarAviso(Control control)
        {
            _toolTip.SetToolTip(control, "");
            errorProvider.Clear();
            _toolTip.Active = false;
        }

        /// <summary>
        /// Lanza el formulario de Matrícula
        /// </summary>
        /// <param name="alumno">Objeto de tipo <see cref="Persona"/> alumno</param>
        /// <param name="modoFormulario">String correspondiente al modo de formulario</param>
        private void LanzarFormularioMatricula(Persona alumno, string modoFormulario)
        {
            _formMatricula.Close();
            _formMatricula = new FormMatricula(alumno, modoFormulario);
            _formMatricula.MdiParent = this.MdiParent;
            _formMatricula.ControlBox = false;
            _formMatricula.WindowState = FormWindowState.Maximized;
            _formMatricula.Show();
        }

        /// <summary>
        /// Vacía los campos del formulario
        /// </summary>
        private void VaciarCampos()
        {
            TxtBoxBuscar.Clear();
            CheckBoxNIF.Checked = false;
            CheckBoxNomApell.Checked = false;
        }
    }
}
