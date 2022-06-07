using System;
using System.Windows;
using System.Windows.Input;
using CapaNegocio;
using Entidades;

namespace PresentacionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Universidad _universidad;
        private byte _intentos;
        private MenuPrincipal _menuPrincipal;


        /// <summary>
        /// Contructor vacío que instancia el componente inicial de la ventana.
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Evento de ventana Initialize. Istancia los variables y objetos necesarios.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Parámetros del evento</param>
        private void Window_Initialized(object sender, EventArgs e)
        {
            _universidad = new Universidad();
            _intentos = 3;
            lblResultado.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// Evento sobre el TextBlock Email cuando recibe el foco oculta el label TetxTEmail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextEmail_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextEmail.Visibility = Visibility.Collapsed;
            TxtEmail.Focus();
        }


        /// <summary>
        ///  Evento sobre el TextBlock Password cuando recibe el foco oculta el label TextPasword.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextPassword.Visibility = Visibility.Collapsed;
            TxTPass.Focus();
        }


        /// <summary>
        /// Evento click sobre el botón Login.
        /// Permite 3 intentos de login al usuario. Al tercer intento fallido, se cierra la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            bool resultado = _universidad.LoginUsuario(TxtEmail.Text, TxTPass.Password.ToString());
            if (resultado)
            {
                lblResultado.Visibility = Visibility.Visible;
                _menuPrincipal = new(TxtEmail.Text)
                {
                    Owner = this
                };
                _menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                _intentos--;
                lblResultado.Visibility = Visibility.Visible;
                lblResultado.Content = "Acceso denegado. Quedan: " + _intentos + " intentos.";
                TxtEmail.Text = "";
                TxTPass.Clear();
            }

            if (_intentos == 0)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Evento que permite mover la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// Cierra la ventana actual cuando el usuario pulsa sobre el botón.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseLogin_Click(object sender, RoutedEventArgs e) 
            => MostrarMensajeConfirmacion("¿Seguro que desea cerrar la aplicación?", "Confirmación");


        /// <summary>
        /// Función adicional que muestra un mensaje de confirmación al derrar la ventana.
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="caption"></param>
        private static void MostrarMensajeConfirmacion(string msj, string caption)
        {
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage image = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(msj, caption, button, image);
            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}