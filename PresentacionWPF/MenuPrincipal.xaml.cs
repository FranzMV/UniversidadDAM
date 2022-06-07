using Entidades;
using System.Windows;
using System.Windows.Input;

namespace PresentacionWPF
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        private Alumno _formularioAlumno;
        private Asiganturas _formularioAsigatruas;
        private Matriculas _formularioMatriculas;
        private Informe _formularioInforme;
        private Buscador _formularioBuscador;

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        public MenuPrincipal(string usuario)
        {
            InitializeComponent();
            LblUsuario.Content = "Hola " + usuario;
            PanelCentral.Children.Add(new ContenedorPrincipal());
        }

        private void tog_bn_Click(object sender, RoutedEventArgs e) { }

        /// <summary>
        /// Evento que permite mover la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// Evento click sobre el boton cerrar que cierra la ventana actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWindow_Click(object sender, RoutedEventArgs e) 
            => MostrarMensajeConfirmacion("¿Está seguro de que desea cerrar la aplicación?", "Confirmación");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertarAlumno(object sender, RoutedEventArgs e)
        {
            _formularioAlumno = new Alumno(1);
            PanelCentral.Children.Clear();
            PanelCentral.Children.Add(_formularioAlumno);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditarAlumno(object sender, RoutedEventArgs e)
        {
            _formularioAlumno = new Alumno(2);
            PanelCentral.Children.Clear();
            PanelCentral.Children.Add(_formularioAlumno);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EliminarAlumno(object sender, RoutedEventArgs e)
        {
            _formularioAlumno = new Alumno(3);
            PanelCentral.Children.Clear();
            PanelCentral.Children.Add(_formularioAlumno);
        }

        /// <summary>
        /// Evento de botón para mostrar la vista de Asignaturas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Asignaturas(object sender, RoutedEventArgs e)
        {
            _formularioAsigatruas = new Asiganturas();
            PanelCentral.Children.Clear();
            PanelCentral.Children.Add(_formularioAsigatruas);
        }

        /// <summary>
        /// Evento de botón para mostrar la vista de Matrículas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Matricula(object sender, RoutedEventArgs e)
        {
            _formularioMatriculas = new Matriculas();
            PanelCentral.Children.Clear();
            PanelCentral.Children.Add(_formularioMatriculas);
        }

        /// <summary>
        /// Evento de botón para mostrar la vista de informes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Informes(object sender, RoutedEventArgs e)
        {
            Persona alumnoSeleccionado = new();
            _formularioBuscador = new Buscador();
            _formularioBuscador.ResizeMode = ResizeMode.NoResize;
            _formularioBuscador.ShowDialog();
            alumnoSeleccionado = _formularioBuscador.AlumnoSeleccionado;

            _formularioInforme = new Informe();
            _formularioInforme.AlumnoSeleccionado = alumnoSeleccionado;
            PanelCentral.Children.Clear();
            PanelCentral.Children.Add(_formularioInforme);
        }

        /// <summary>
        /// Evento de botón para volver a la vista principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolverMenuPrincipal(object sender, RoutedEventArgs e)
        {
            PanelCentral.Children.Clear();
            PanelCentral.Children.Add(new ContenedorPrincipal());
        }


        /// <summary>
        /// Función adicional que muestra un mensaje de confirmación al derrar la ventana.
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="caption"></param>
        private void MostrarMensajeConfirmacion( string msj, string caption)
        {
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage image = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(msj, caption, button, image);
            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}