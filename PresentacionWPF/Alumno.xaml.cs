using CapaNegocio;
using Entidades;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

/// <summary>
/// Autor Francisco David Manzanedo Valle.
/// </summary>
namespace PresentacionWPF
{
    /// <summary>
    /// Interaction logic for Alumno.xaml
    /// </summary>
    public partial class Alumno : UserControl, INotifyPropertyChanged
    {
        #region CONSTANTES
        private const byte VALOR_MAX_CADENA_RUTA_FOTO = 50;
        private const string SEXO_HOMBRE = "H";
        private const string SEXO_MUJER = "M";
        private const string TIPO_PERSONA_ALUMNO = "alumno";
        private readonly string FILTRO_NIF = "NIF";
        private readonly string FILTRO_NOMBRE = "Nombre completo";
        //Rutas para la imagen del usuario
        private const string RUTA_FOTO_POR_DEFECTO = "SIN_FOTO.PNG";
        private const string RUTA_ESTABLECER_FOTO_POR_DEFECTO = "pack://application:,,,/PresentacionWPF;component/Resources/camera.jpg";
        private const string RUTA_FOTO_CARPETA_IMAGENES = @"../../../../imagenes/";
        #endregion

        private readonly Universidad _universidad;
        private readonly int _modo;

        private OpenFileDialog _openFileDialog;
        private string _rutaFoto;
        private string _sexo;
        private string _erroresFromulario;
        private bool _fechaCorrecta;
        private ObservableCollection<Persona> _listaAlumnos;

        public Persona AlumnoSeleccionado { get; set; }


        #region Propiedades VALIDATION RULES
        private string _nif;
        private string _nombre;
        private string _primerApellido;
        private string _ciudad;
        private string _direccion;
        private string _telefono;

        public string NIF
        {
            get { return _nif; }
            set
            {
                _nif = value; NotifyPropertyChanged(_nif);
            }
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value; NotifyPropertyChanged(_nombre);
            }
        }
       
        public string PrimerApellido
        {
            get => _primerApellido;
            set
            {
                _primerApellido = value; NotifyPropertyChanged(_primerApellido);
            }
        }

        public string Ciudad
        {
            get => _ciudad;
            set
            {
                _ciudad = value; NotifyPropertyChanged(_ciudad);
            }
        }

        public string Direccion
        {
            get => _direccion;
            set
            {
                _direccion = value; NotifyPropertyChanged(_direccion);
            }
        }

        public string Telefono
        {
            get => _telefono;
            set
            {
                _telefono = value; NotifyPropertyChanged(_telefono);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        /// <summary>
        /// Constructor de la vista Alumno. 
        /// Dependiendo del modo que reciba como parámentro, muestras las vistas de forma diferente.
        /// </summary>
        /// <param name="modo">int correspondiente al modo: 1-Insertar, 2-Modificar, 3-Eliminar.</param>
        public Alumno(int modo)
        {
            InitializeComponent();
            _universidad = new Universidad();
            _modo = modo;
            switch (_modo)
            {
                case 1: SetUpInsertarAlumno(); break;
                case 2: SetUpEditarAlumno(); break;
                case 3: SetUpEliminarAlumno(); break;
                default: break;
            }
        }


        /// <summary>
        /// Metodo Load del userControl Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboBoxFilters();
            LoadAlumnos();
            _openFileDialog = new OpenFileDialog();
            _rutaFoto = RUTA_FOTO_POR_DEFECTO;
            _fechaCorrecta = false;
            _erroresFromulario = "Errores presentes en el fromulario: " + Environment.NewLine;
            DataContext = this;

        }

        /// <summary>
        /// Se encarga de comprobar si el valor de una propiedad ha cambiado.
        /// </summary>
        /// <param name="property">Propiedad a comprobar</param>
        public void NotifyPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        /// <summary>
        /// Evento doble click sobre la imagen de perfíl del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectImgAlumno_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _openFileDialog.Filter = "Image Files(*.png) | *.png";//---> Sólo admite imágenes con extensión .png
            if (e.ClickCount == 2)
            {
                if (_openFileDialog.ShowDialog() == true)
                {
                    int codigoError = ValidarPathImagen(_openFileDialog.FileName, VALOR_MAX_CADENA_RUTA_FOTO);
                    switch (codigoError)
                    {
                        case 0:// -----> La ruta de la foto es correcta.
                            selectImgAlumno.Source = new BitmapImage(new Uri(_openFileDialog.FileName));
                            _rutaFoto = _openFileDialog.FileName;
                            GuardarImagen(_openFileDialog);
                            break;
                        case 1: // ------> La ruta sobrepasa los 250 caracteres.
                            MessageBox.Show("La ruta de la imagen no puede tener más de " + VALOR_MAX_CADENA_RUTA_FOTO
                                + " caracteres." + Environment.NewLine, "Error al cargar la imagen.");
                            CargarImagen(RUTA_FOTO_POR_DEFECTO);
                            break;
                        case 2: // ------> La ruta de la foto está vacía
                            _rutaFoto = RUTA_FOTO_POR_DEFECTO;
                            break;
                    }
                }
            }
        }

        #region FUNCIONES AUXILIARES IMAGEN DE PREFIL
        /// <summary>
        /// Valida que la ruta de la imagen sea correcta.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="tamanyo"></param>
        /// <returns></returns>
        private static byte ValidarPathImagen(string texto, byte tamanyo)
        {
            byte resultado = 0; //-----> Si devuelve 0, la cadena es correcta.

            if (texto.Length > tamanyo)
                resultado = 1;
            else if (texto.Length < 1 && string.IsNullOrEmpty(texto))
                resultado = 2;

            return resultado;
        }


        /// <summary>
        /// Guarda una imagen seleccionada por el usuario en la ruta:Presentacion\bin\Debug\net5.0-windows\imagenes
        /// </summary>
        /// <param name="openFile"></param>
        private static void GuardarImagen(OpenFileDialog openFile)
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
                selectImgAlumno.Source =  new BitmapImage(new Uri(RUTA_ESTABLECER_FOTO_POR_DEFECTO, UriKind.Absolute));
            else
            {

                BitmapImage bitmapImage = new BitmapImage();
                Uri uri = new(RUTA_FOTO_CARPETA_IMAGENES + nombreImagen, UriKind.Relative);
                bitmapImage.BeginInit();
                bitmapImage.UriSource = uri;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                selectImgAlumno.Source = bitmapImage;
            }
        }

        #endregion IMAGEN_DE_PERFIL


        /// <summary>
        /// Evento click sobre el radiobutton Hombre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnHombre_Checked(object sender, RoutedEventArgs e)
        {
            rbtnMujer.IsChecked = false;
            _sexo = SEXO_HOMBRE;
        }

        /// <summary>
        /// Evento de botón sobre el radiobutton Mujer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnMujer_Checked(object sender, RoutedEventArgs e)
        {
            rbtnHombre.IsChecked = false;
            _sexo = SEXO_MUJER;
        }

        /// <summary>
        /// Evento sobre el calendario para seleccionar la fecha de nacimiento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DPFechaNac_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DPFechaNac.SelectedDate >= DateTime.Now)
            {
                _erroresFromulario += "La fecha seleccionada no es válida." + Environment.NewLine;
                _fechaCorrecta = false;
            }
            else
            {
                _fechaCorrecta = true;
            }
        }

        /// <summary>
        /// Evento de botón para insertar un nuevo alumno o actualizarlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            bool resultado = ComprobarCamposVacios();
            //Insertar Alumno
            if (_modo == 1)
            {
                if (!resultado)
                    MessageBox.Show(_erroresFromulario);
                else
                {
                    Persona p1 = new(TxtBoxNif.Text, TxtBoxNombre.Text,
                        TxtBoxPriApellido.Text, TxtBoxSegApellido.Text,
                        TxtBoxCiudad.Text, TxtBoxDireccion.Text,
                        TxtBoxTelefono.Text, (DateTime)DPFechaNac.SelectedDate,
                        _sexo, TIPO_PERSONA_ALUMNO, _rutaFoto);

                    Persona aux = _universidad.InsertarPersona(p1);
                    if (aux != null)
                    {
                        MessageBox.Show("Alumno creado: " + Environment.NewLine +
                            "NIF: " + aux.Nif + " Nombre Completo: " + aux.NombreCompleto);
                        LimpiarCampos();
                        LoadAlumnos();
                    }
                    else MessageBox.Show("Ha ocurrido un problema." + Environment.NewLine + aux.ToString());
                }

            //Editar Alumno
            }else if(_modo == 2)
            {
                if(AlumnoSeleccionado != null)
                {
                    if (!resultado)
                        MessageBox.Show(_erroresFromulario);
                    else
                    {
                        string sexo = (bool)rbtnHombre.IsChecked ? "H" : "M";
                        Persona editarAlumno = new(AlumnoSeleccionado.Id_Persona, TxtBoxNif.Text, TxtBoxNombre.Text,
                            TxtBoxPriApellido.Text, TxtBoxSegApellido.Text, TxtBoxCiudad.Text,
                            TxtBoxDireccion.Text, TxtBoxTelefono.Text,(DateTime)DPFechaNac.SelectedDate,
                            sexo, TIPO_PERSONA_ALUMNO, selectImgAlumno.Source.ToString());

                        Persona aux = _universidad.ActualizarPersona(editarAlumno);
                        if (aux != null)
                        {
                            MessageBox.Show("Alumno actualizado");
                            LimpiarCampos();
                            LoadAlumnos();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Evento click sobre el botón Cancelar. Limpia todos los campos del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            bool borrarCampos = MostrarMensajeConfirmacion("¿Seguro que desea borrar los campos del formulario?", "Información");
            if (borrarCampos)
            {
                LimpiarCampos();
            }
        }

        /// <summary>
        /// Modifica la vista para mostrar únicamente el formulario de alumnos.
        /// </summary>
        private void SetUpInsertarAlumno()
        {
            PanelBusqueda.Margin = new Thickness(0, 200, 0, 0);
            PanelBusqueda.Visibility = Visibility.Collapsed;
            PanelFromulario.Height = 520;
            PanelBotones.Margin = new Thickness(570, 435, 0, 0);
        }

        /// <summary>
        /// Modifica la vista para mostrar tanto el formulario y el buscador.
        /// </summary>
        private void SetUpEditarAlumno()
        {
            lblFormAlumnos.Content = "Editar Alumno";
            lblBtnAcpetar.Content = "Editar";
            lblEliminarInfo.Visibility = Visibility.Collapsed;        
        }

        /// <summary>
        /// Modifica la vista de alumno para mostrar únicamente el buscador.
        /// </summary>
        private void SetUpEliminarAlumno()
        {
            PanelFromulario.Visibility = Visibility.Collapsed;
            PanelBusqueda.Height = 520;
            PanelPrincipalBusqueda.Height = 520;
            PanelAvisoEliminar.Margin = new Thickness(0, 280, 0, 0);
        }

        #region Funciones Formulario Busqueda
        /// <summary>
        /// Carga los filtros a aplicar en el formulario.
        /// </summary>
        private void LoadComboBoxFilters()
        {
            comboBoxFiltrar.Items.Insert(0, FILTRO_NIF);
            comboBoxFiltrar.Items.Insert(1, FILTRO_NOMBRE);
        }


        /// <summary>
        /// Carga los alumnos el el ListView ListaAlumnos.
        /// </summary>
        private void LoadAlumnos()
        {
            List<Persona> alumnosAux = _universidad.ListarAlumnos();
            _listaAlumnos = new ObservableCollection<Persona>(alumnosAux);
            this.ListaAlumnos.DataContext = _listaAlumnos;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBuscarAlumno_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (comboBoxFiltrar.SelectedIndex == 1)//Filtra por nombre completo
            {
                IEnumerable<Persona> filtroNombre = from Alum in _listaAlumnos
                                   let nombre = Alum.NombreCompleto
                                   where
                                    nombre.StartsWith(TxtBuscarAlumno.Text.ToLower())
                                    || nombre.StartsWith(TxtBuscarAlumno.Text.ToUpper())
                                    || nombre.Contains(TxtBuscarAlumno.Text)
                                   select Alum;

                ListaAlumnos.ItemsSource = filtroNombre;

            }
            else if (comboBoxFiltrar.SelectedIndex == 0)//Filtra por NIF
            {
                IEnumerable<Persona> filtroNif = from Alum in _listaAlumnos
                                let nif = Alum.Nif
                                where
                                 nif.StartsWith(TxtBuscarAlumno.Text.ToLower())
                                 || nif.StartsWith(TxtBuscarAlumno.Text.ToUpper())
                                 || nif.Contains(TxtBuscarAlumno.Text)
                                select Alum;

                ListaAlumnos.ItemsSource = filtroNif;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el tipo de filtro", "Información");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListaAlumnos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AlumnoSeleccionado = new Persona();
            AlumnoSeleccionado = (Persona)ListaAlumnos.SelectedItem;

            if (_modo == 2)
            {
                TxtBoxNif.Text = AlumnoSeleccionado.Nif;
                TxtBoxNombre.Text = AlumnoSeleccionado.Nombre;
                TxtBoxPriApellido.Text = AlumnoSeleccionado.Apellido1;
                TxtBoxSegApellido.Text = AlumnoSeleccionado.Apellido2;
                DPFechaNac.SelectedDate = AlumnoSeleccionado.Fecha_Nacimiento;
                TxtBoxCiudad.Text = AlumnoSeleccionado.Ciudad;
                TxtBoxDireccion.Text = AlumnoSeleccionado.Direccion;
                TxtBoxTelefono.Text = AlumnoSeleccionado.Telefono;
                if (AlumnoSeleccionado.Sexo.Equals(SEXO_HOMBRE, StringComparison.Ordinal))
                    rbtnHombre.IsChecked = true;
                else
                    rbtnMujer.IsChecked = true;
                
                if(AlumnoSeleccionado.Ruta_Foto == RUTA_FOTO_POR_DEFECTO)
                    CargarImagen(RUTA_FOTO_POR_DEFECTO);
                else
                {
                    string nombreImagen = Path.GetFileName(AlumnoSeleccionado.Ruta_Foto);
                    CargarImagen(nombreImagen);
                }

            }
            else if (_modo == 3)
            {
                //Modo eliminar
                bool confirmarEliminar = MostrarMensajeConfirmacion("Seguro que desea eliminar al alumno: " 
                    + Environment.NewLine +
                    "Nif: "+ AlumnoSeleccionado.Nif+" con nombre: "
                    +AlumnoSeleccionado.NombreCompleto, "Confirmación");

                if (confirmarEliminar)
                {
                    _universidad.EliminarPersona(AlumnoSeleccionado.Id_Persona);
                    MessageBox.Show("Alumno eliminado.");
                    LimpiarCampos();
                    LoadAlumnos();
                }
                    
            }
        }

        #endregion

        #region Funciones Auxiliares

        /// <summary>
        /// Comprueba si los campos obligatorios se han dejado vacíos por el usuario.
        /// </summary>
        /// <returns></returns>
        private bool ComprobarCamposVacios()
        {
            bool resultado = true;

            if (string.IsNullOrEmpty(TxtBoxNif.Text))
            {
                _erroresFromulario += "El campo NIF es obligatorio y no puede quedar vacío." + Environment.NewLine;
                resultado = false;
            }

            if (string.IsNullOrEmpty(TxtBoxNombre.Text))
            {
                _erroresFromulario += "El campo Nombre es obligatorio y no puede quedar vacío." + Environment.NewLine;
                resultado = false;
            }

            if (string.IsNullOrEmpty(TxtBoxPriApellido.Text))
            {
                _erroresFromulario += "El campo Primer Apellido es obligatorio y no puede quedar vacío." + Environment.NewLine;
                resultado = false;
            }

            if (string.IsNullOrEmpty(TxtBoxCiudad.Text))
            {
                _erroresFromulario += "El campo Ciudad es obligatorio y no puede quedar vacío." + Environment.NewLine;
                resultado = false;
            }

            if (string.IsNullOrEmpty(TxtBoxDireccion.Text))
            {
                _erroresFromulario += "El campo Dirección es obligatorio y no puede quedar vacío." + Environment.NewLine;
                resultado = false;
            }

            if (rbtnHombre.IsChecked == false && rbtnMujer.IsChecked == false)
            {
                _erroresFromulario += "El campo Sexo es obligatorio y debe seleccionar una opción." + Environment.NewLine;
                resultado = false;
            }

            if (DPFechaNac.SelectedDate.ToString() == "")
            {
                resultado = false;
                _fechaCorrecta = false;
                _erroresFromulario += "El campo Fecha de nacimiento es obligatorio y no puede quedar vacío." + Environment.NewLine;
            }

            if (!_fechaCorrecta)
            {
                resultado = false;
                _erroresFromulario += "La fecha de nacimiento seleccionada no es válida." + Environment.NewLine;
            }

            return resultado;
        }



        /// <summary>
        /// Función adicional que muestra un mensaje de confirmación al derrar la ventana.
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="caption"></param>
        private static bool MostrarMensajeConfirmacion(string msj, string caption)
        {
            bool confirmacion = false;
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage image = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(msj, caption, button, image);
            if (result == MessageBoxResult.Yes)
                confirmacion = true;

            return confirmacion;
        }


        /// <summary>
        /// Limpia los campos del formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            TxtBoxNif.Text = "";
            TxtBoxNombre.Text = "";
            TxtBoxPriApellido.Text = "";
            TxtBoxSegApellido.Text = "";
            TxtBoxCiudad.Text = "";
            TxtBoxDireccion.Text = "";
            TxtBoxTelefono.Text = "";
            rbtnHombre.IsChecked = false;
            rbtnMujer.IsChecked = false;
            DPFechaNac.SelectedDate = DateTime.Now;
            selectImgAlumno.Source = new BitmapImage(new Uri(RUTA_ESTABLECER_FOTO_POR_DEFECTO, UriKind.Absolute));
            _erroresFromulario = "";
            _sexo = "";
            _rutaFoto = RUTA_FOTO_POR_DEFECTO;
        }

        #endregion

      
    }
}
