using CapaNegocio;
using Entidades;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

/// <summary>
/// Autor Francisco David Manzanedo
/// </summary>
namespace PresentacionWPF
{
    /// <summary>
    /// Interaction logic for Asiganturas.xaml
    /// </summary>
    public partial class Asiganturas : UserControl
    {
        private readonly Universidad _universidad = new();
        private ObservableCollection<Grado> _listaGrados;
        private ObservableCollection<Asignatura> _listaAsignaturas;
        private List<Persona> _personas;


        public Asignatura AsignaturaSeleccionada {get; set;}


        /// <summary>
        /// Contructor de la vista.
        /// </summary>
        public Asiganturas()
        {
            InitializeComponent();
            ListaResultadoGrados.ItemsSource = _universidad.ListarGrados();
            _personas = _universidad.ListarPersonas();
        }

        /// <summary>
        /// Método Load de la vista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e) => CargarGrados();
        

        /// <summary>
        /// Evento click sobre la lista de Grados. Al seleccionar un registro, se muestra las asignaturas correspondientes en la Lista de asignaturas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListResultadoGrados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaResultadoGrados.Items.Count > 0)
            {
                Grado aux = (Grado)ListaResultadoGrados.SelectedItem;
                if (aux != null)
                    CargarAsignaturas(aux.Id_Grado);
            }
        }


        /// <summary>
        /// Buscador de grados por nombre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBuscarGrado_TextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<Grado> filtrarNomGrado = from grado in _listaGrados
                                                 let nombre = grado.Nombre
                                                 where
                                                 nombre.StartsWith(TxtBuscarGrado.Text.ToLower())
                                                 || nombre.StartsWith(TxtBuscarGrado.Text.ToUpper())
                                                 || nombre.Contains(TxtBuscarGrado.Text)
                                                 select grado;
            ListaResultadoGrados.ItemsSource = filtrarNomGrado;
        }

        /// <summary>
        ///  Evento click sobre la lista de Asignaturas. Al seleccionar un registro, se muestra los detalles de la asignatura en el panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewAsignaturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LimpiarEtiquetas();
            if (ListViewAsignaturas.Items.Count > 0)
            {
                AsignaturaSeleccionada = (Asignatura)ListViewAsignaturas.SelectedItem;
                if (AsignaturaSeleccionada != null)
                {
                    lblNombre.Content = "Nombre: " + AsignaturaSeleccionada.Nombre;
                    lblCreditos.Content = "Créditos: " + AsignaturaSeleccionada.Creditos;
                    lblTipo.Content = "Tipo: " + AsignaturaSeleccionada.Tipo;
                    lblCurso.Content = "Curso: " + AsignaturaSeleccionada.Curso;
                    lblCuatri.Content = "Cuatrimestre: " + AsignaturaSeleccionada.Cuatrimestre;

                    int? idProfesor = AsignaturaSeleccionada.Id_Profesor;
                    if (idProfesor != null)
                    {
                        int aux = (int)idProfesor;
                        Persona profesor = _universidad.LeerPersona(aux);
                        if (profesor != null)
                            lblProfesor.Content = "Profesor: " + profesor.NombreCompleto;
                    }
                }
            }
        }

        /// <summary>
        /// Método adicional para cargar los grados en un ListView.
        /// </summary>
        private void CargarGrados()
        {
            List<Grado> gradosAux = _universidad.ListarGrados();
            _listaGrados = new ObservableCollection<Grado>(gradosAux);
            this.ListaResultadoGrados.DataContext = _listaGrados;
        }


        /// <summary>
        /// Método adicional para cargar las asignaturas una vez se hace click sobre un registro en la lista de grados.
        /// </summary>
        /// <param name="idGrado"></param>
        private void CargarAsignaturas(int idGrado)
        {
            List<Asignatura> asignaturasAux = _universidad.LeerAsignaturasDeUnGrado(idGrado);
            _listaAsignaturas = new ObservableCollection<Asignatura>(asignaturasAux);
            ListViewAsignaturas.ItemsSource = _listaAsignaturas;
            this.ListViewAsignaturas.DataContext = _listaAsignaturas;
        }

        /// <summary>
        /// Limpia las etiquetas de los detalles de las asignaturas.
        /// </summary>
        private void LimpiarEtiquetas()
        {
            lblNombre.Content = "Nombre: ";
            lblCreditos.Content = "Créditos: ";
            lblTipo.Content = "Tipo: ";
            lblCurso.Content = "Curso: ";
            lblCuatri.Content = "Cuatrimestre: ";
            lblProfesor.Content = "Profesor: ";
        }
    }
}
