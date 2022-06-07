using CapaNegocio;
using Entidades;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PresentacionWPF
{
    /// <summary>
    /// Interaction logic for Buscador.xaml
    /// </summary>
    public partial class Buscador : Window
    { 
        private Universidad _universidad;
        private readonly string FILTRO_NIF = "NIF";
        private readonly string FILTRO_NOMBRE = "Nombre completo";
        private ObservableCollection<Persona> _listaAlumnos;

        public Persona AlumnoSeleccionado { get ; set ; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Buscador()
        {
            InitializeComponent();
            _universidad = new Universidad();
            LoadComboBoxFilters();
            LoadAlumnos();
        }

        /// <summary>
        /// Funcion que se ejecuta al cargar la ventana.
        /// </summary>
        private void LoadAlumnos() 
        {
            List<Persona> alumnosAux = _universidad.ListarAlumnos();
            _listaAlumnos = new ObservableCollection<Persona>(alumnosAux);
            this.ListaAlumnos.DataContext = _listaAlumnos; 
        }

        /// <summary>
        /// Carga los diferentes filtros para realizar la busqueda de alumnos.
        /// </summary>
        private void LoadComboBoxFilters()
        {
            comboBoxFiltrar.Items.Insert(0, FILTRO_NIF);
            comboBoxFiltrar.Items.Insert(1, FILTRO_NOMBRE);
        }

        /// <summary>
        /// Realiza la busqueda de alumnos dependiendo del filtro seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBuscarAlumno_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (comboBoxFiltrar.SelectedIndex == 1)//Filtra por nombre completo
            {
                var filtroNombre = from Alum in _listaAlumnos
                                   let nombre = Alum.NombreCompleto
                                   where
                                    nombre.StartsWith(TxtBuscarAlumno.Text.ToLower())
                                    || nombre.StartsWith(TxtBuscarAlumno.Text.ToUpper())
                                    || nombre.Contains(TxtBuscarAlumno.Text)
                                   select Alum;

                ListaAlumnos.ItemsSource = filtroNombre;

            }else if(comboBoxFiltrar.SelectedIndex == 0)//Filtra por NIF
            {
                var filtroNif = from Alum in _listaAlumnos
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
        /// Evento doble click sobre los registros en la lista de alumnos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListaAlumnos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CancelEventArgs arg = new CancelEventArgs();

            if (ListaAlumnos != null)
            {
                if (ListaAlumnos.Items.Count > 0)
                {
                    AlumnoSeleccionado = (Persona)ListaAlumnos.SelectedItem;
                    Window_Closing(sender, arg);
                }
            }
        }

        /// <summary>
        /// Funcion que evita que la ventana del buscador se cierre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
