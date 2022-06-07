using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PresentacionWPF
{
    /// <summary>
    /// Interaction logic for Matriculas.xaml
    /// </summary>
    public partial class Matriculas : UserControl
    {
        private Universidad _universidad;
        private Persona _alumnoSeleccionado;
        private Buscador _formBuscador;
        private List<AlumnoSeMatriculaAsignatura> _listaAlumnoSeMatriculaAsignatura;
        private List<Asignatura> _listaAsignaturas;
        private List<Asignatura> _listaAsignaturasMatriculadasAlumno;
        private List<Asignatura> _listaAsignaturasUpdate;
        private List<Grado> _listaGrados;
        private const int ID_CURSO_ACTUAL = 8;
        private int _modo;

        private ObservableCollection<Asignatura> _vistaAsignaturasMatriculadasAlumno;
        private ObservableCollection<Grado> _vistaGrados;
        private ObservableCollection<Asignatura> _vistaAsignaturasDeUnGrado;


        /// <summary>
        /// Constructor.
        /// </summary>
        public Matriculas()
        {
            InitializeComponent();
            _universidad = new();
            _formBuscador = new();
            _alumnoSeleccionado = new();
            _listaAsignaturasMatriculadasAlumno = new();
            _listaAsignaturasUpdate = new();
            _modo = 0;
        }


        /// <summary>
        /// Metodo load de la vista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e) => CargarDatos();

        /// <summary>
        /// Evento click sobre el boton para abrir el buscador de alumnos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbrirBuscador_Click(object sender, RoutedEventArgs e)
        {
            _formBuscador.Width = 1040;
            _formBuscador.Height = 550;
            _formBuscador.ResizeMode = ResizeMode.NoResize;
            _formBuscador.ShowDialog();
            _alumnoSeleccionado = _formBuscador.AlumnoSeleccionado;
            if(_alumnoSeleccionado != null)
            {
                TxtNif.Text = _alumnoSeleccionado.Nif;
                TxtNombre.Text = _alumnoSeleccionado.NombreCompleto;
                //Si el alumno esta matriculado
                if (ExisteAlumnoMatriculado(_alumnoSeleccionado))
                {
                     CargarDatos();
                    _modo = 1;//Alumno matriculado
                    //Carga las asignaturas de la matricula en el ListView de Asignaturas matriculadas
                    List<Asignatura> aux = CargarAsignaturasMatricula();
                    //Obtiene el grado del alumno seleccionado y lo carga en el ListView de grados
                    List<Grado> grados =  ObtenerGradoAlumno(aux);
                    //Carga las asignaturas de dicho grado en el ListView de asignaturas
                    CargarAsignaturasDeUnGrado(grados);
                    Trace.WriteLine("Alumno seleccionado: " + _alumnoSeleccionado);
                }
                //Si no esta matriculado
                else
                {
                    _modo = 2;
                    LimpiarDatos();
                    Trace.WriteLine("Alumno seleccido NO MATRICULADO: " + _alumnoSeleccionado);
                }
            }
            else
            {
                Trace.WriteLine("El alumno es null");
            }
        }

        /// <summary>
        /// Carga las asignaturas del grado seleccionado en la ListView de Asignaturas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewGrados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Grado> listaGrados = new();
            if (ListViewGrados.Items.Count > 0)
            {
                Grado aux = (Grado)ListViewGrados.SelectedItem;
                listaGrados.Add(aux);
                if (aux != null)
                    CargarAsignaturasDeUnGrado(listaGrados);
            }
        }

        /// <summary>
        /// Añade una asignatura a la matríxula actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewAsignaturas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(ListViewAsignaturas.Items.Count > 0)
            {
                Asignatura asignaturaSeleccionada = (Asignatura)ListViewAsignaturas.SelectedItem;
                if(asignaturaSeleccionada != null)
                {
                    AnyadirNuevaMatricula(asignaturaSeleccionada);
                    _listaAsignaturasUpdate.Add(asignaturaSeleccionada);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCrearMatricula_Click(object sender, RoutedEventArgs e)
        {
            string matriculas = "";
            if (_modo == 1)//Actualizar 
            {
               if(_listaAsignaturasUpdate.Count > 0)
                {
                    _listaAsignaturasUpdate.ForEach(a => matriculas += a.Nombre + Environment.NewLine);
                  
                    bool confirmarMatriculacion = MostrarMensajeConfirmacion("¿Dese añadir matrícula de alumno " +
                   _alumnoSeleccionado.NombreCompleto + " en las siguientes asignaturas?: "
                   + Environment.NewLine + matriculas + Environment.NewLine, "Confirmación");

                    if (confirmarMatriculacion)
                    {
                        _listaAsignaturasUpdate.ForEach(a => _universidad.InsertarAlumnoMatriculado(_alumnoSeleccionado.Id_Persona, a.Id_Asignatura, ID_CURSO_ACTUAL));
                        MessageBox.Show("Matrícula actualizada correctamente.", "Información");
                    }
                }
            }
            else if(_modo == 2)//Nueva Matricula
            {
                _listaAsignaturasMatriculadasAlumno.ForEach(a => matriculas += a.Nombre+Environment.NewLine);
  
                bool confirmarMatriculacion = MostrarMensajeConfirmacion("Crear matrícula de alumno " +
                    _alumnoSeleccionado.NombreCompleto + " en las siguientes asignaturas: " 
                    + Environment.NewLine+matriculas+ Environment.NewLine, "Confirmación");

                if (confirmarMatriculacion)
                {
                    _listaAsignaturasMatriculadasAlumno.ForEach(a => _universidad.InsertarAlumnoMatriculado(_alumnoSeleccionado.Id_Persona, a.Id_Asignatura, ID_CURSO_ACTUAL));
                    MessageBox.Show("Matrícula creada correctamente.", "Información");
                    LimpiarDatos();
                }
            }
        }

        /// <summary>
        /// Evento click sobre el botón para eliminar una matrícula de una asignatura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelarMatricula_Click(object sender, RoutedEventArgs e)
        {
            if(ListViewMatriculas.SelectedItem == null)
                MessageBox.Show("Debe seleccionar la asignatura a eliminar de la matrícula", "Información");
            else
            {
                Asignatura asignaturaAEliminar = (Asignatura)ListViewMatriculas.SelectedItem;
                bool confirmacionEliminar = MostrarMensajeConfirmacion("¿Seguro que desea eliminar la matrícula de la asignatura: " + asignaturaAEliminar.Nombre + "? ", "Confirmación");
                if (confirmacionEliminar)
                {
                    _universidad.EliminarAlumnoMatriculado(_alumnoSeleccionado.Id_Persona, asignaturaAEliminar.Id_Asignatura, ID_CURSO_ACTUAL);
                    _listaAsignaturasMatriculadasAlumno.Remove(asignaturaAEliminar);
                    ActualizarListViewMatriculas(_listaAsignaturasMatriculadasAlumno);
                    MessageBox.Show("Asignatura " + asignaturaAEliminar.Nombre + " eliminada de la matrícula: ", "Información");
                }
            }
        }


        /// <summary>
        /// Carga todas las lista iniciales de datos.
        /// </summary>
        private void CargarDatos()
        {
            _listaAlumnoSeMatriculaAsignatura = _universidad.ListarAlumnoSeMatriculaAsignatura();
            _listaAsignaturas = _universidad.ListarAsignaturas();
            _listaGrados = _universidad.ListarGrados();
        }


        /// <summary>
        /// Limpia las listas y los ListView del formulario.
        /// </summary>
        private void LimpiarDatos()
        {
            //Carga todos los grados
            CargarTodosLosGrados();
            //Limpia la lista de asignaturas
            _listaAsignaturas.Clear();
            _listaGrados.Clear();
            _listaAsignaturasMatriculadasAlumno.Clear();
            CargarAsignaturasDeUnGrado(_listaGrados);
            //Vacia la lista de matriculas
            _ = CargarAsignaturasMatricula();
        }


        /// <summary>
        /// Carga las asignaturas pertenecientes a un Grado.
        /// </summary>
        private List<Asignatura> CargarAsignaturasMatricula()
        {
            if(_modo == 1)
            {
                _listaAsignaturasMatriculadasAlumno = ObtenerAsignaturasAlumno(_alumnoSeleccionado);
                _vistaAsignaturasMatriculadasAlumno = new ObservableCollection<Asignatura>(_listaAsignaturasMatriculadasAlumno);
                ListViewMatriculas.ItemsSource = _vistaAsignaturasMatriculadasAlumno;
                return _listaAsignaturasMatriculadasAlumno;
            }
            else
            {
                _listaAsignaturasMatriculadasAlumno.Clear();
                _vistaAsignaturasMatriculadasAlumno = new ObservableCollection<Asignatura>(_listaAsignaturasMatriculadasAlumno);
                ListViewMatriculas.ItemsSource = _vistaAsignaturasMatriculadasAlumno;
                return _listaAsignaturasMatriculadasAlumno;
            }
        }


        /// <summary>
        /// Obtiene el grado en el que esta matriculado el alumno seleccionado.
        /// </summary>
        /// <param name="asignaturas"></param>
        private List<Grado> ObtenerGradoAlumno(List<Asignatura> asignaturas)
        {
            List<Grado> gradoAsignaturas = new();
            foreach (Asignatura a in asignaturas)
            {
                Grado grado = _universidad.LeerGrado(a.Id_Grado);
                gradoAsignaturas.Add(grado);
            }
            List<Grado> unique = gradoAsignaturas.GroupBy(x => x.Id_Grado)
                .Select(x => x.First())
                .ToList();
            //unique.ForEach(x => Trace.WriteLine(x));
            _vistaGrados = new ObservableCollection<Grado>(unique);
            ListViewGrados.ItemsSource = unique;
            return unique;
        }



        /// <summary>
        /// Comprueba si el alumno está matriculado en el curso actual y devuelve una lista con las asignaturas 
        /// en las que está matriculado.
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        private List<Asignatura> ObtenerAsignaturasAlumno(Persona alumno)
        {
            List<Asignatura> resultado = new();
            List<AlumnoSeMatriculaAsignatura> alumnoSeMatriculaAsignaturas = new();
            if(_modo == 1)
            {
                foreach (AlumnoSeMatriculaAsignatura asa in _listaAlumnoSeMatriculaAsignatura)
                {
                    //Si el alumno está matriculado en el curso actual (idCursoEscolar = 8)
                    if (alumno.Id_Persona == asa.Id_Alumno && asa.Id_Curso_Escolar == ID_CURSO_ACTUAL)
                        alumnoSeMatriculaAsignaturas.Add(asa);
                }
                foreach (AlumnoSeMatriculaAsignatura asa in alumnoSeMatriculaAsignaturas)
                {
                    foreach (Asignatura a in _listaAsignaturas)
                    {
                        if (asa.Id_Asignatura == a.Id_Asignatura)
                            resultado.Add(a);
                    }
                }
                return resultado;
            }
            else
            {
                resultado.Clear();
                return resultado;
            }
        }


        /// <summary>
        /// Carga todos los grados en el ListView de Grados.
        /// </summary>
        private void CargarTodosLosGrados()
        {
            _vistaGrados = new ObservableCollection<Grado>(_listaGrados);
            ListViewGrados.ItemsSource = _vistaGrados;
            this.ListViewGrados.DataContext = _vistaGrados;
        }

        /// <summary>
        /// Método adicional para cargar las asignaturas una vez se hace click sobre un registro en la lista de grados.
        /// </summary>
        /// <param name="idGrado"></param>
        private void CargarAsignaturasDeUnGrado(List<Grado> grados)
        {
            List<Asignatura> asignaturasAux = new();
            grados.ForEach(g => asignaturasAux = _universidad.LeerAsignaturasDeUnGrado(g.Id_Grado));
            _vistaAsignaturasDeUnGrado = new ObservableCollection<Asignatura>(asignaturasAux);
            ListViewAsignaturas.ItemsSource = _vistaAsignaturasDeUnGrado;
            this.ListViewAsignaturas.DataContext = _vistaAsignaturasDeUnGrado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="asignatura"></param>
        private void AnyadirNuevaMatricula(Asignatura asignatura)
        {
            if(_modo == 1) 
            {
                if (asignatura != null)
                {
                    if (!ExisteMatriculaAsignatura(asignatura))
                    {
                        _listaAsignaturasMatriculadasAlumno.Add(asignatura);
                        ActualizarListViewMatriculas(_listaAsignaturasMatriculadasAlumno);
                        _vistaAsignaturasMatriculadasAlumno = new ObservableCollection<Asignatura>(_listaAsignaturasMatriculadasAlumno);
                       ListViewMatriculas.ItemsSource = _vistaAsignaturasMatriculadasAlumno;
                    }
                    else MessageBox.Show("La asignatura que intenta añadir ya existe.", "Información");
                }
            }
            else if(_modo == 2)
            {
                lblBtnAcpetar.Content = "Crear";
                if (!ExisteMatriculaAsignatura(asignatura))
                {
                    _listaAsignaturasMatriculadasAlumno.Add(asignatura);
                    _vistaAsignaturasMatriculadasAlumno = new ObservableCollection<Asignatura>(_listaAsignaturasMatriculadasAlumno);
                    ListViewMatriculas.ItemsSource = _vistaAsignaturasMatriculadasAlumno;
                    Trace.WriteLine("Modo crear matricula");
                }
                else MessageBox.Show("La asignatura que intenta añadir ya existe.", "Información");
            }
        }


        /// <summary>
        /// Comprueba si al añadir una asignatura a la matrícula ésta ya existe.
        /// </summary>
        /// <param name="asignatura"></param>
        /// <returns></returns>
        private bool ExisteMatriculaAsignatura(Asignatura asignatura)
        {
            bool resultado = false;
            foreach(Asignatura a in _listaAsignaturasMatriculadasAlumno)
            {
                if (a.Id_Asignatura == asignatura.Id_Asignatura)
                    resultado = true;
            }

            return resultado;
        }


        /// <summary>
        /// Actualiza el ListView de matrículas al eliminar un registro.
        /// </summary>
        /// <param name="asignaturas"></param>
        private void ActualizarListViewMatriculas(List<Asignatura> asignaturas)
        {
            _vistaAsignaturasMatriculadasAlumno = new ObservableCollection<Asignatura>(asignaturas);
            ListViewMatriculas.ItemsSource = _vistaAsignaturasMatriculadasAlumno;
        }


        /// <summary>
        /// Comprueba si un alumno está matriculado.
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        private bool ExisteAlumnoMatriculado(Persona alumno)
        {
            bool resultado = false;
            foreach (AlumnoSeMatriculaAsignatura asa in _listaAlumnoSeMatriculaAsignatura)
            {
                if (asa.Id_Alumno == alumno.Id_Persona && asa.Id_Curso_Escolar == ID_CURSO_ACTUAL)
                    resultado = true;
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
    }
}
