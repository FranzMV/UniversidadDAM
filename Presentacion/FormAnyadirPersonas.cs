using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using CapaNegocio;
using System.Drawing;
using System.IO;

/// <author> Francisco David Manzanedo Valle.</author>
namespace Presentacion
{
    public partial class FormAnyadirPersonas : Form
    {
        private readonly Universidad _universidad;
        private List<Departamento> _listaDepartamentos;
        private List<Persona> _listaPersonas;
        private OpenFileDialog _openFileDialog;

        private readonly ToolTip _toolTip;
        private string _rutaFoto;
        private string _telefono;
        private string _sexo;
        private string _tipo;
        private bool _datoValido;
        private bool _NIFvalido;
        private int _IdPersonaAeditar;
        private string _modoFormulario;

        #region Constantes
        //Rango de valores
        private const byte VALOR_MAX_CADENA_NIF = 9;
        private const byte VALOR_MAX_CADENA_NOMBRE = 25;
        private const byte VALOR_MAX_CADENA_APELLIDOS = 50;
        private const byte VALOR_MAX_CADENA_CIUDAD = 25;
        private const byte VALOR_MAX_CADENA_DIRECCION = 50;
        private const byte VALOR_MAX_CADENA_RUTA_FOTO = 50;
        private const string SEXO_HOMBRE = "H";
        private const string SEXO_MUJER = "M";
        private const string TIPO_PERSONA_PROFESOR = "profesor";
        private const string TIPO_PERSONA_ALUMNO = "alumno";

        //Rutas para la imagen del usuario
        private const string RUTA_FOTO_POR_DEFECTO = "SIN_FOTO.PNG";
        private const string RUTA_FOTO_CARPETA_IMAGENES = @"../../../../imagenes/";

        //Modo del formulario
        private const string MODO_FORMULARIO_INSERTAR = "insertar";
        private const string MODO_FORMULARIO_EDITAR = "editar";
        #endregion

        //Constructor sin parámetros para el modo Inserción
        public FormAnyadirPersonas()
        {
            InitializeComponent();
            this._IdPersonaAeditar = 0;
            this._modoFormulario = MODO_FORMULARIO_INSERTAR;
            _universidad = new Universidad();
            _listaDepartamentos = new List<Departamento>();
            
            _toolTip = new ToolTip();
            _rutaFoto = RUTA_FOTO_POR_DEFECTO;
            _datoValido = false;
            _datoValido = false;
            _telefono = "";
            _sexo = "";
            _tipo = "";

            this._openFileDialog = new OpenFileDialog();
            MostrarDepartamento(false);
        }

        //Constructor con parámetros para el modo Edición
        public FormAnyadirPersonas(int idPersonaEditar, string modoFormulario)
        {
            InitializeComponent();
            this._IdPersonaAeditar = idPersonaEditar;
            this._modoFormulario = modoFormulario;
            _universidad = new Universidad();
            _listaDepartamentos = _universidad.ListarDepartamentos();

            _toolTip = new ToolTip();
            _rutaFoto = RUTA_FOTO_POR_DEFECTO;
            _datoValido = false;
            _telefono = "";
            _sexo = "";
            _tipo = "";

            MostrarDepartamento(false);

            BtnAnyadirPersona.Text = "Modificar";
            if(_IdPersonaAeditar > 0)
            {
                VaciarCampos();
                RellenarCampos(_IdPersonaAeditar);
            }
            this._openFileDialog = new OpenFileDialog();
        }

        //Evento Load del formulario
        private void FormAnyadirPersonas_Load(object sender, EventArgs e)
        {
            _listaPersonas = _universidad.ListarPersonas();
            _toolTip.SetToolTip(PictureBoxImagenPersona, "Doble click para cargar una imagen (.png)");
            _toolTip.SetToolTip(BtnCancelarPersona, "Cerrar formulario.");
            CargarDepartamentos();  
        }

        //Evento Correspondiente al CheckBox Alumno
        private void CheckBoxAlumno_CheckedChanged(object sender, EventArgs e)
        {
            MostrarDepartamento(false);
            CheckBoxProfesor.Checked = false;
            _tipo = TIPO_PERSONA_ALUMNO;
        }

        //Evento correspondiente al CheckBox Profesor
        private void CheckBoxProfesor_CheckedChanged(object sender, EventArgs e)
        {
            MostrarDepartamento(true);
            CheckBoxAlumno.Checked = false;
            _tipo = TIPO_PERSONA_PROFESOR;
            if (!CheckBoxProfesor.Checked)
                MostrarDepartamento(false);
        }

        //Evento doble click para seleccionar la imagen de la persona.
        private void PictureBoxImagenPersona_DoubleClick(object sender, EventArgs e)
        {
            
            _openFileDialog.Filter = "Image Files(*.png) | *.png";//---> Sólo admite imágenes con extensión .png
            _datoValido = false;
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int codigoError = ValidarCadenaDeTexto(_openFileDialog.FileName, VALOR_MAX_CADENA_RUTA_FOTO);
                switch (codigoError)
                {
                    case 0:// -----> La ruta de la foto es correcta.
                        PictureBoxImagenPersona.Image = new Bitmap(_openFileDialog.FileName);
                        _rutaFoto = _openFileDialog.FileName;
                        DatoCorrecto(PictureBoxImagenPersona);
                        _datoValido = true;
                        GuardarImagen(_openFileDialog);
                        break;
                    case 1: // ------> La ruta sobrepasa los 50 caracteres.
                        MostrarMessageBox("La ruta de la imagen no puede tener más de "+VALOR_MAX_CADENA_RUTA_FOTO
                            +" caracteres." + Environment.NewLine,"Error al cargar la imagen.", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        CargarImagen(RUTA_FOTO_POR_DEFECTO);
                        
                        _datoValido = false;
                        break;
                    case 2: // ------> La ruta de la foto está vacía
                        DatoCorrecto(PictureBoxImagenPersona);
                        _datoValido = true;
                        _rutaFoto = RUTA_FOTO_POR_DEFECTO;
                        break;
                }
            }
        }

        //Evento Leave correspondiente al comboBox NIF.
        private void TxtbNIF_Leave(object sender, EventArgs e)
        {
            byte codigoError = ValidarCadenaNIF(TxtbNIF.Text, VALOR_MAX_CADENA_NIF);
            _datoValido = false;
            switch (codigoError)
            {
                case 0: //-----> La cadena no está vacía
                    bool nifValido = ValidarNIF(TxtbNIF);
                    if (nifValido)
                    {
                        DatoCorrecto(TxtbNIF);
                        _datoValido = true;
                        _NIFvalido = true;
                    }
                    else
                    {
                        DatoIncorrecto(TxtbNIF, "El NIF introducido no es válido." + Environment.NewLine);
                        _datoValido = false; ;
                        _NIFvalido = false;
                    }
                    break;
                case 1: //----> Texto Incorrecto. Supera tamaño máximo de caracteres.
                    DatoIncorrecto(TxtbNIF, "El DNI no puede tener más de " + VALOR_MAX_CADENA_NIF + "caracteres." + Environment.NewLine);
                    _datoValido = false;
                    _NIFvalido = false;
                    break;
                case 2:// ----> Texto Incorrecto. La cadena está vacía.
                    DatoIncorrecto(TxtbNIF, "El campo DNI no puede quedar vacío." + Environment.NewLine);
                    _datoValido = false;
                    _NIFvalido = false;
                    break;
            }
            
        }

        //Evento Leave correspondiente al textBox Nombre.
        private void TxtbNombre_Leave(object sender, EventArgs e)
        {
            _datoValido = false;
            byte codigoError = ValidarCadenaDeTexto(TxtbNombre.Text, VALOR_MAX_CADENA_NOMBRE);
            switch (codigoError)
            {
                case 0: // ----> Texto correcto.
                    DatoCorrecto(TxtbNombre);
                    _datoValido = true;
                    break;
                case 1:// ----> Texto Incorrecto. Supera tamaño máximo de caracteres.
                    DatoIncorrecto(TxtbNombre, "El nombre no puede contener más de " 
                        + VALOR_MAX_CADENA_NOMBRE + " caracteres."+Environment.NewLine);
                    _datoValido = false;
                    break;
                case 2:   // ----> Texto Incorrecto. La cadena está vacía.
                    DatoIncorrecto(TxtbNombre, "El campo nombre no puede quedar vacío."+Environment.NewLine);
                    _datoValido = false;
                    break;
            }
        }

        //Evento Leave correspondiente al textBox primer apellido.
        private void TxtbPrimerApell_Leave(object sender, EventArgs e)
        {
            _datoValido = false;
            byte codigoError = ValidarCadenaDeTexto(TxtbPrimerApell.Text, VALOR_MAX_CADENA_APELLIDOS);
            switch (codigoError)
            {
                case 0:  // ----> Texto correcto.
                    DatoCorrecto(TxtbPrimerApell);
                    _datoValido = true;
                    break;
                case 1: // ----> Texto Incorrecto. Supera tamaño máximo de caracteres.
                    DatoIncorrecto(TxtbPrimerApell, "El primer apellido no puede contener más de "
                        + VALOR_MAX_CADENA_APELLIDOS + " caracteres." + Environment.NewLine);
                    _datoValido = false;
                    break;
                case 2: // ----> Texto Incorrecto. La cadena está vacía.
                    DatoIncorrecto(TxtbPrimerApell, "El campo primer apellido no puede quedar vacío." + Environment.NewLine);
                    _datoValido = false;
                    break;
            }
        }

        //Evento Leave correspondiente al textBox segundo apellido.
        private void TxtbSegundoApell_Leave(object sender, EventArgs e)
        {
            _datoValido = false;
            if (TxtbSegundoApell.TextLength > VALOR_MAX_CADENA_APELLIDOS)
            {
                DatoIncorrecto(TxtbSegundoApell, "El segundo apellido no puede contener más de "
                       + VALOR_MAX_CADENA_APELLIDOS + " caracteres." + Environment.NewLine);
                _datoValido = false;
            }
            else
            {
                DatoCorrecto(TxtbSegundoApell);
                _datoValido = true;
            }
        }

        //Evento Leave correspondiente al textBox ciudad.
        private void TxtbCiudad_Leave(object sender, EventArgs e)
        {
            _datoValido = false;
            byte codigoError = ValidarCadenaDeTexto(TxtbCiudad.Text, VALOR_MAX_CADENA_CIUDAD);
            switch (codigoError)
            {
                case 0:// ----> Texto correcto.
                    DatoCorrecto(TxtbCiudad);
                    _datoValido = true;
                    break;
                case 1:// ----> Texto Incorrecto. Supera tamaño máximo de caracteres.
                    DatoIncorrecto(TxtbCiudad, "La ciudad no puede contener más de "
                        + VALOR_MAX_CADENA_CIUDAD+ " caracteres."+Environment.NewLine);
                    _datoValido = false;
                    break;
                case 2:// ----> Texto Incorrecto. La cadena está vacía.
                    DatoIncorrecto(TxtbCiudad, "El campo ciudad no puede quedar vacío."+Environment.NewLine);
                    _datoValido = false;
                    break;
            }
        }

        //Evento Leave correspondiente al textBox dirección.
        private void TxtbDireccion_Leave(object sender, EventArgs e)
        {
            _datoValido = false;
            byte codigoError = ValidarCadenaDeTexto(TxtbDireccion.Text, VALOR_MAX_CADENA_DIRECCION);
            switch (codigoError)
            {
                case 0:// ----> Texto correcto.
                    DatoCorrecto(TxtbDireccion);
                    _datoValido = true;
                    break;
                case 1:// ----> Texto Incorrecto. Supera tamaño máximo de caracteres.
                    DatoIncorrecto(TxtbDireccion, "La dirección no puede contener más de "
                        + VALOR_MAX_CADENA_DIRECCION + " caracteres." + Environment.NewLine);
                    _datoValido = false;
                    break;
                case 2:// ----> Texto Incorrecto. La cadena está vacía.
                    DatoIncorrecto(TxtbDireccion, "El campo dirección no puede quedar vacío."+Environment.NewLine);
                    _datoValido = false;
                    break;
            }
        }

        //Evento que valida el formato de Teléfono
        private void MaskedTextBoxTelef_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            DatoIncorrecto(MaskedTextBoxTelef, "El número de teléfono no tiene el formato correcto." + Environment.NewLine);
            _datoValido = false;
        }

        //Evento Leave correspondiente a la fecha de nacimiento.
        private void DtpFechaNacimiento_Leave(object sender, EventArgs e)
        {
            _datoValido = false;
           if(DtpFechaNacimiento.Value < DateTime.Now)
            {
               DatoCorrecto(DtpFechaNacimiento);
                _datoValido = true;
            }
            else
            {
                DatoIncorrecto(DtpFechaNacimiento, "La fecha seleccionada no puede ser la actual");
                _datoValido = false;
            }
        }

        //Evento Leave correspondiente al departamento de profesor.
        private void CmbDepartamento_Leave(object sender, EventArgs e)
        {
            _datoValido = false;
            if (CmbDepartamento.SelectedIndex == -1)
            {
                DatoIncorrecto(CmbDepartamento, "El campo departamento no puede quedar vacío" + Environment.NewLine);
                _datoValido = false;
            }
            else
            {
                DatoCorrecto(CmbDepartamento);
                _datoValido = true;
            }
        }

        //Evento click para añadir una nueva persona.
        private void BtnAnyadirPersona_Click(object sender, EventArgs e)
        {
            if (_datoValido)
            {
                if (rdbHombre.Checked || rdbMujer.Checked)
                {
                    _sexo = rdbHombre.Checked ? SEXO_HOMBRE : SEXO_MUJER;
                    _telefono = MaskedTextBoxTelef.Text.Replace("-", "").Trim();

                    if (_NIFvalido)
                    {
                        switch (_modoFormulario)
                        {
                            case MODO_FORMULARIO_EDITAR:

                                if (_tipo.Equals(TIPO_PERSONA_PROFESOR))
                                {
                                    if (CmbDepartamento.SelectedIndex == -1)
                                        MostrarMessageBox("El campo Departamento es obligatorio." + Environment.NewLine, "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        int idDepartamento = ObtenerIdDepartamento();
                                        Persona profesorEditar = new Profesor(_IdPersonaAeditar, TxtbNIF.Text, TxtbNombre.Text, TxtbPrimerApell.Text,
                                                TxtbSegundoApell.Text, TxtbCiudad.Text, TxtbDireccion.Text, _telefono,
                                                DtpFechaNacimiento.Value, _sexo, _tipo, _rutaFoto, idDepartamento);
                                        Profesor profEditar = new Profesor(_IdPersonaAeditar, idDepartamento);
                                        profesorEditar = _universidad.ActualizarPersona(profesorEditar);
                                        profEditar = _universidad.ActualizarProfesor(profEditar);
                                        if (profesorEditar != null && profEditar != null)
                                        {
                                            MostrarMessageBox(profesorEditar.Tipo.ToUpper() + ": " + profesorEditar.NombreCompleto +
                                                     " actualizado correctamente." + Environment.NewLine,
                                                     "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            VaciarCampos();
                                        }
                                        else
                                            MostrarMessageBox("Ha ocurrido un error actualizando: " + profesorEditar.NombreCompleto + Environment.NewLine,
                                                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else if (_tipo.Equals(TIPO_PERSONA_ALUMNO))
                                {
                                    Persona alumnoEditar = new Persona(_IdPersonaAeditar, TxtbNIF.Text, TxtbNombre.Text, TxtbPrimerApell.Text,
                                           TxtbSegundoApell.Text, TxtbCiudad.Text, TxtbDireccion.Text, _telefono,
                                           DtpFechaNacimiento.Value, _sexo, _tipo, _rutaFoto);
                                    alumnoEditar = _universidad.ActualizarPersona(alumnoEditar);
                                    if (alumnoEditar != null)
                                    {
                                        MostrarMessageBox(alumnoEditar.Tipo.ToUpper() + ": " + alumnoEditar.NombreCompleto + " actualizado correctamente." + Environment.NewLine,
                                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        VaciarCampos();
                                    }
                                    else
                                        MostrarMessageBox("Ha ocurrido un error actualizando: " + alumnoEditar.NombreCompleto + Environment.NewLine,
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                break;

                            case MODO_FORMULARIO_INSERTAR:


                                switch (_tipo)
                                {
                                    case TIPO_PERSONA_ALUMNO:
                                        Persona alumno = new(TxtbNIF.Text, TxtbNombre.Text, TxtbPrimerApell.Text,
                                            TxtbSegundoApell.Text, TxtbCiudad.Text, TxtbDireccion.Text, _telefono,
                                            DtpFechaNacimiento.Value, _sexo, _tipo, _rutaFoto);
                                        if (!NIFrepetido(alumno))
                                        {
                                            alumno = _universidad.InsertarPersona(alumno);
                                            if (alumno != null)
                                            {
                                                MostrarMessageBox(alumno.Tipo.ToUpper() + ": " + alumno.NombreCompleto + 
                                                    " añadido correctamente." + Environment.NewLine,
                                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                VaciarCampos();
                                            }
                                            else
                                                MostrarMessageBox(alumno.Tipo.ToUpper() + ": " + alumno.NombreCompleto
                                                    + " no se ha podido añadir." + Environment.NewLine,
                                                    "Error añadiendo Alumno.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                            MostrarMessageBox("El NIF: " + alumno.Nif + " Ya existe." + Environment.NewLine, 
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        break;

                                    case TIPO_PERSONA_PROFESOR:
                                        int idDepartamento = ObtenerIdDepartamento();
                                        if (idDepartamento > -1)
                                        {
                                            Persona p1 = new Profesor(TxtbNIF.Text, TxtbNombre.Text, TxtbPrimerApell.Text,
                                                TxtbSegundoApell.Text, TxtbCiudad.Text, TxtbDireccion.Text, _telefono,
                                                DtpFechaNacimiento.Value, _sexo, _tipo, _rutaFoto, idDepartamento);

                                            if (!NIFrepetido(p1))
                                            {
                                                p1 = _universidad.InsertarPersona(p1);
                                                if (p1 != null)
                                                {
                                                    // Obtiene el ID del profesor como Persona para añadirlo a la tabla Profesor
                                                    int idProfesor = ObtenerIdPersona(p1);
                                                    if (idProfesor > -1)
                                                    {
                                                        Profesor profesor2 = new(idProfesor, idDepartamento);
                                                        profesor2 = _universidad.InsertarProfesor(profesor2);
                                                        if (profesor2 != null)
                                                        {
                                                            MostrarMessageBox(p1.Tipo.ToUpper() + ": " + p1.NombreCompleto + " añadido correctamente."
                                                                + Environment.NewLine, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            VaciarCampos();
                                                            MostrarDepartamento(false);
                                                        }
                                                        else
                                                            MostrarMessageBox(p1.Tipo.ToUpper() + ": " + p1.NombreCompleto + " no se ha podido añadir."
                                                                + Environment.NewLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                }
                                                else
                                                    MostrarMessageBox(p1.Tipo + ": " + p1.NombreCompleto + " no se ha podido añadir."
                                                        + Environment.NewLine, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else MostrarMessageBox("El NIF" + p1.Nif + " Ya existe." + Environment.NewLine, "Error", 
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                            MostrarMessageBox("El campo Departamento es obligatorio." + Environment.NewLine, "Error",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;

                                    default://----> No ha seleccionado Tipo de persona
                                        MostrarMessageBox("El campo Tipo de persona es obligatorio." + Environment.NewLine, "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                }//Fin switch TIPO_PERSONA
                                break;
                        }//Fin swith ModoFormulario
                    }else
                        MostrarMessageBox("El NIF no es correcto" + Environment.NewLine, 
                            "Error. Campo requerido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                    MostrarMessageBox("El campo sexo no puede quedar vacío " + Environment.NewLine, "Error. Campo requerido.",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MostrarMessageBox("El formulario contiene errores.Por favor, revíselos." + Environment.NewLine,
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Evento para limpiar los campos del formulario
        private void BtnCancelarPersona_Click(object sender, EventArgs e) => this.Close();


        //------------------------------------ FUNCIONES AUXILIARES -------------------------------------------//

        /// <summary>
        /// Función auxiliar para rellenar los campos del formulario
        /// cuando éste está en modo edición.
        /// </summary>
        /// <param name="persona">Objeto de tipo <see cref="Persona"/></param>
        private void RellenarCampos(int idPersonaEditar)
        {
            Persona p = _universidad.LeerPersona(idPersonaEditar);
            switch (p.Tipo)
            {
                case TIPO_PERSONA_PROFESOR:
                    Profesor profesor = _universidad.LeerProfesor(idPersonaEditar);
                    CheckBoxProfesor.Checked = true;
                    MostrarDepartamento(true);
                    Departamento d = _universidad.LeerDepartamento(profesor.Id_Departamento);
                    CmbDepartamento.Text = d.Nombre;
                    break;

                case TIPO_PERSONA_ALUMNO:
                    CheckBoxAlumno.Checked = true;
                    MostrarDepartamento(false);
                    break;
            }
            if (p.Ruta_Foto.Equals(RUTA_FOTO_POR_DEFECTO))
            {
                _rutaFoto = RUTA_FOTO_POR_DEFECTO;
                CargarImagen(RUTA_FOTO_POR_DEFECTO);
            }
            else
            {
                string nombreImagen = Path.GetFileName(p.Ruta_Foto);
                CargarImagen(nombreImagen);
            }
            TxtbNIF.Text = p.Nif;
            TxtbNombre.Text = p.Nombre;
            TxtbPrimerApell.Text = p.Apellido1;
            TxtbSegundoApell.Text = p.Apellido2;
            DtpFechaNacimiento.Value = p.Fecha_Nacimiento;
            TxtbCiudad.Text = p.Ciudad;
            TxtbDireccion.Text = p.Direccion;
            MaskedTextBoxTelef.Text = p.Telefono;
            if (p.Sexo.Equals(SEXO_HOMBRE))
                rdbHombre.Checked = true;
            else
                rdbMujer.Checked = true;
        }

        /// <summary>
        /// Obtiene el Id de una Persona filtrando por su NIF.
        /// </summary>
        /// <param name="p">Objeto de tipo Persona.</param>
        /// <returns>Integer correspondiente al ID de la persona a buscar.</returns>
        private int ObtenerIdPersona(Persona p)
        {
            Persona aux = _universidad.LeerPersona(p.Id_Persona);
            return p.Nif.Equals(aux.Nif) ? aux.Id_Persona : -1;
        }

        /// <summary>
        /// Obtiene el Id del departamento seleccionado por el usuario.
        /// </summary>
        /// <returns>Integer correspondiente al id de departamento.</returns>
        private int ObtenerIdDepartamento()
        { 
            foreach (Departamento d in _listaDepartamentos)
            {
                if (d.Nombre.Equals(CmbDepartamento.Text))
                    return d.Id_Departamento; 
            }
            return -1;
        }

        /// <summary>
        /// Comprueba si un NIF ya existe en la BD antes de insertar un nuevo registro
        /// </summary>
        /// <param name="persona">Objeto de tipo <see cref="Persona"/></param>
        /// <returns>Boolean: true si el NIF existe, false si no.</returns>
        private bool NIFrepetido(Persona persona)
        {
            bool resultado = false;
            foreach(Persona p in _listaPersonas)
            {
                if (p.Nif.Equals(persona.Nif))
                    resultado = true;
            }

            return resultado;
        }

        /// <summary>
        /// Oculta el ComboBox y Label correspondiente al Departamento de un profesor.
        /// </summary>
        /// <param name="mostrar">boolean que determina si los campos serán mostrados o no.</param>
        private void MostrarDepartamento(bool mostrar)
        {
            lblDepartamento.Visible = mostrar;
            CmbDepartamento.Visible = mostrar;
        }

        /// <summary>
        /// Carga todos los <see cref="Departamento.Nombre"/> registrados en la BD en un Combobox.
        /// </summary>
        private void CargarDepartamentos()
        {
            _listaDepartamentos = _universidad.ListarDepartamentos();
            foreach (Departamento d in _listaDepartamentos)
                CmbDepartamento.Items.Add(d.Nombre);
        }

        /// <summary>
        /// Guarda una imagen seleccionada por el usuario en la ruta:Presentacion\bin\Debug\net5.0-windows\imagenes
        /// </summary>
        /// <param name="openFile"></param>
        private void GuardarImagen(OpenFileDialog openFile)
        {
            string pathImagenOrigen = openFile.FileName;
            string nombreImagen = openFile.SafeFileName;
         
            if (!Directory.Exists(RUTA_FOTO_CARPETA_IMAGENES))
                Directory.CreateDirectory(RUTA_FOTO_CARPETA_IMAGENES);
            //Si la imagen ya existe, la sobrescribe
            File.Copy(pathImagenOrigen, RUTA_FOTO_CARPETA_IMAGENES + nombreImagen, true);
        }

        /// <summary>
        /// Carga la imagen almacenada en la carpeta imágenes en el pictureBox
        /// </summary>
        /// <param name="nombreImagen">String correspondiente al nombre de la imagen.</param>
        private void CargarImagen(string nombreImagen)
        {
            if (nombreImagen.Equals(RUTA_FOTO_POR_DEFECTO))
                PictureBoxImagenPersona.Image = new Bitmap(Properties.Resources.camera);
            else
                PictureBoxImagenPersona.Image = Image.FromFile(RUTA_FOTO_CARPETA_IMAGENES + nombreImagen);
        }

        /// <summary>
        /// Valida si la cadena de texto del NIF es correcta
        /// </summary>
        /// <param name="texto">String correspondiente al NIF</param>
        /// <param name="tamanyo">Integer correspondiente al tamaño máximo y mínimo</param>
        /// <returns></returns>
        private byte ValidarCadenaNIF(string texto, byte tamanyo)
        {
            byte resultado = 0; //-----> Si devuelve 0, la cadena es correcta.

            if (texto.Length > tamanyo || texto.Length < tamanyo)
                resultado = 1;
            else if (texto.Length < 1 && String.IsNullOrEmpty(texto))
                resultado = 2;

            return resultado;
        }


        /// <summary>
        /// Valida una cadena de texto introducida por el usuario.
        /// </summary>
        /// <param name="texto">String correspondiente a la cadena de texto introducida por el usuario.</param>
        /// <param name="tamanyo">Integer correspondiente al tamaño máximo permitido para la cadena de texto.</param>
        /// <returns></returns>
        private byte ValidarCadenaDeTexto(string texto, byte tamanyo)
        {
            byte resultado = 0; //-----> Si devuelve 0, la cadena es correcta.

            if (texto.Length > tamanyo) 
                resultado = 1;
            else if (texto.Length < 1 && String.IsNullOrEmpty(texto)) 
                resultado = 2;

            return resultado;
        }

        /// <summary>
        /// Valida un NIF a través de expresiones regulares para DNI y NIE.
        /// </summary>
        /// <param name="control">Control que contiene la cadena de texto introducida por el usuario.</param>
        /// <returns>bool true si el NIF es correcto, false si no lo es. </returns>
        private bool ValidarNIF(Control control)
        {
            int numero;
            bool resultado;

            //NIE Extranjeros
            if (control.Text.Substring(0, 1) == "X")
                numero = Convert.ToInt32("0" + control.Text.Substring(1, 8));
            else if (control.Text.Substring(0, 1) == "Y")
                numero = Convert.ToInt32("1" + control.Text.Substring(1, 8));
            else if (control.Text.Substring(0, 1) == "Z")
                numero = Convert.ToInt32("2" + control.Text.Substring(1, 8));
            else
                numero = Convert.ToInt32(control.Text.Substring(0, 8));

            string letraAux = control.Text.Substring(8).ToUpper();
            string letra = "";

            switch (numero % 23)
            {
                case 0: letra = "T"; break;
                case 1: letra = "R"; break;
                case 2: letra = "W"; break;
                case 3: letra = "A"; break;
                case 4: letra = "G"; break;
                case 5: letra = "M"; break;
                case 6: letra = "Y"; break;
                case 7: letra = "F"; break;
                case 8: letra = "P"; break;
                case 9: letra = "D"; break;
                case 10: letra = "X"; break;
                case 11: letra = "B"; break;
                case 12: letra = "N"; break;
                case 13: letra = "J"; break;
                case 14: letra = "Z"; break;
                case 15: letra = "S"; break;
                case 16: letra = "Q"; break;
                case 17: letra = "V"; break;
                case 18: letra = "H"; break;
                case 19: letra = "L"; break;
                case 20: letra = "C"; break;
                case 21: letra = "K"; break;
                case 22: letra = "E"; break;
            }

            if (!letra.Equals(letraAux)) resultado = false;
            else resultado = true;

            return resultado;
        }

        /// <summary>
       /// Restablece los valores por defecto de un <see cref="ToolTip" y <see cref="ErrorProvider"/> a su valor incial./>
       /// </summary>
       /// <param name="control">Control a restableces.</param>
       /// <returns>bool que devuelve siempre true para establecer que el valor es correcto.</returns>
        private void DatoCorrecto(Control control)
        {
            _toolTip.SetToolTip(control, "");
            errorProvider.SetError(control, "");
            _toolTip.Active = false;
        }

        /// <summary>
        /// Muestra un <see cref="ToolTip" y <see cref="ErrorProvider"/> cuando se produce un error en un control.
        /// </summary>
        /// <param name="control">Control sobre el que se produce el error.</param>
        /// <param name="mensajeError">String correspondiente al mensaje de error a mostrar.</param>
        /// <returns>bool siempre a false para establecer que el valor del control no es correcto.</returns>
        private void DatoIncorrecto(Control control, string mensajeError)
        {
            _toolTip.SetToolTip(control, mensajeError);
            errorProvider.SetError(control, mensajeError);
        }

        /// <summary>
        /// Limpia los controles del formulario.
        /// 
        /// </summary>
        private void VaciarCampos()
        {
            TxtbNIF.Clear();
            TxtbNombre.Clear();
            TxtbPrimerApell.Clear();
            TxtbSegundoApell.Clear();
            TxtbCiudad.Clear();
            TxtbDireccion.Clear();
            MaskedTextBoxTelef.Clear();
            DtpFechaNacimiento.Value = DateTime.Now;
            rdbHombre.Checked = false;
            rdbMujer.Checked = false;
            CheckBoxAlumno.CheckState = CheckState.Unchecked;
            CheckBoxProfesor.CheckState = CheckState.Unchecked;
            CmbDepartamento.SelectedIndex = -1;
            PictureBoxImagenPersona.Image = new Bitmap(Properties.Resources.camera);
            _tipo = "";
            _sexo = "";
            _rutaFoto = RUTA_FOTO_POR_DEFECTO;
            _telefono = "";
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

    }
}
