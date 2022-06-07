using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using CapaNegocio;
using Entidades;
using System;
using System.Globalization;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows;
using System.Threading.Tasks;

/// <summary>
/// <author>Francisco David Manzanedo Valle</author>
/// </summary>
namespace PresentacionWPF
{
    /// <summary>
    /// Interaction logic for ContenedorPrincipal.xaml
    /// </summary>
    public partial class ContenedorPrincipal : UserControl
    {
        private readonly Universidad _universidad = new();
        private IEnumerable<Persona> _listaAlumnos;
        private IEnumerable<Persona> _listaProfesores;
        private IEnumerable<AlumnoSeMatriculaAsignatura> _listaAlumnosMatriculados;
        private IEnumerable<Persona> _alumnosSinMatricula;
        private const int ID_CURSO_ACTUAL = 8;
        private IEnumerable<CursoEscolar> _listaCursoEscolar;
       
        /// <summary>
        /// Constructor encargado de inicializar la vista.
        /// </summary>
        public ContenedorPrincipal()
        {
            InitializeComponent();
            _listaCursoEscolar = _universidad.ListarCursosEscolares();
            ActualizarDatos();
        }

        /// <summary>
        /// Actualiza los datos correspondientes al total de alumnos, total profesores, total alumnos sin matricular y total matriculas realizadas 
        /// en el curso actual, asi como los datos correspondientes a las graficas.
        /// </summary>
        private void ActualizarDatos()
        {
            _listaAlumnos = _universidad.ListarAlumnos();
            _listaProfesores = _universidad.ListarProfesores();
            _listaAlumnosMatriculados = _universidad.ListarAlumnoSeMatriculaAsignatura();

            int totalMatriculasCursoEscolar =  _listaAlumnosMatriculados.Count(x => x.Id_Curso_Escolar == ID_CURSO_ACTUAL);
            _alumnosSinMatricula = _listaAlumnos.Where(alumnos => !_listaAlumnosMatriculados.Any(alumnosMatriculados => alumnosMatriculados.Id_Alumno == alumnos.Id_Persona));

            totalAlumnos.Content = _listaAlumnos.Count().ToString();
            totalProfesores.Content = _listaProfesores.Count().ToString();
            totalAlumosSinMatricular.Content = _alumnosSinMatricula.Count().ToString();
            totalMatriculas.Content = totalMatriculasCursoEscolar.ToString();

            fechaActualizacionAlumnos.Content = "Actualizado: " + ObtenerFechaActual();
            fechaActualizacionProfesores.Content = "Actualizado: " + ObtenerFechaActual();
            fechaActualizacionAlumSinMatricular.Content = "Actualizado: " + ObtenerFechaActual();
            fechaActualizacionMatriculas.Content = "Actualizado: " + ObtenerFechaActual();

            CargarCursosEscolares();
            MostrarGraficaTotalAlumnosPorGradoCursoActual();
        }


        /// <summary>
        /// Obtiene la fecha actual en formato "dd/MM/yyyy HH:mm:ss".
        /// </summary>
        /// <returns>string con la fecha actual en formato "dd/MM/yyyy HH:mm:ss"</returns>
        private static string ObtenerFechaActual() => DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);


        /// <summary>
        /// Muestra los datos en la gráfica de Total de alumnos por grado matriculados en el curso actual IdCursoActual = 8.
        /// </summary>
        private void MostrarGraficaTotalAlumnosPorGradoCursoActual()
        {
            List<Asignatura> listaAsignaturas = new();
            List<Grado> listaGrados = new();
            SeriesCollection seriePieChart = new();

            //List<Grado> grados = _listaGrados.Where(g => 
            //    _listaAsignaturas.Any(asig => _listaAlumnosMatriculados.Any(alumMatr => _listaCursoEscolar.Any(
            //      cursoEsc => g.Id_Grado == asig.Id_Grado
            //      && alumMatr.Id_Asignatura == asig.Id_Asignatura
            //      && cursoEsc.Id_Curso_Escolar == ID_CURSO_ACTUAL
            //      && cursoEsc.Id_Curso_Escolar == alumMatr.Id_Curso_Escolar))))
            //    .ToList();

            foreach (AlumnoSeMatriculaAsignatura a in _listaAlumnosMatriculados)
            {
                if (a.Id_Curso_Escolar == ID_CURSO_ACTUAL)
                    listaAsignaturas.Add(_universidad.LeerAsignatura(a.Id_Alumno));
            }

            foreach (Asignatura a in listaAsignaturas)
                listaGrados.Add(_universidad.LeerGrado(a.Id_Grado));

            var alumnosGrado =
                    from gr in listaGrados
                    group gr by gr.Nombre into g
                    select new { GR = g.Key, Count = g.Count() };

            foreach (var g in alumnosGrado)
            {
                seriePieChart.Add(new PieSeries
                {
                    Title = g.GR,
                    Values = new ChartValues<int> { g.Count }
                });
                graficaAlumnosPorGrado.Series = seriePieChart;
            }
        }


        /// <summary>
        /// Carga los diferentes cursos escolares en el ComboBox.
        /// </summary>
        private  void CargarCursosEscolares()
        {
            int contador = 0;
            foreach(CursoEscolar c in _listaCursoEscolar)
            {
                ComboCursoEscolar.Items.Insert(contador, c.Anyo_Inicio + "/" + c.Anyo_Fin);
                contador++;
            }
            ComboCursoEscolar.SelectedIndex = 7;
            MostrarGraficaAlumnosMatriculadosPorCursoEscolarActual(ID_CURSO_ACTUAL);//Gáfica para el curso actual

        }

        /// <summary>
        /// Evento sobre el combobox de cursos escolares.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboCursoEscolar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Asignatura> asignaturas = new();
            CursoEscolar cursoEscolar = _universidad.LeerCursoEscolar(ComboCursoEscolar.SelectedIndex + 1);
            foreach(AlumnoSeMatriculaAsignatura a in _listaAlumnosMatriculados)
            {
                if (a.Id_Curso_Escolar == cursoEscolar.Id_Curso_Escolar)
                    asignaturas.Add(_universidad.LeerAsignatura(a.Id_Asignatura));
            }

            MostrarGraficaAlumnosMatriculadosPorCursoEscolar(asignaturas);
        }


        /// <summary>
        /// Carga la gráfica para los alumnos matriculados en el curso actual, idCursoActual = 8.
        /// </summary>
        /// <param name="idCursoEscolar"></param>
        private void MostrarGraficaAlumnosMatriculadosPorCursoEscolarActual(int idCursoEscolar)
        {
            List<Asignatura> asignaturas = new();
            foreach (AlumnoSeMatriculaAsignatura a in _listaAlumnosMatriculados)
            {
                if (a.Id_Curso_Escolar == idCursoEscolar)
                    asignaturas.Add(_universidad.LeerAsignatura(a.Id_Asignatura));
            }

            MostrarGraficaAlumnosMatriculadosPorCursoEscolar(asignaturas);
        }

        /// <summary>
        /// Función auxiliar para cargar los datos en la gráfica Alumnos matriculados por curso escolar.
        /// </summary>
        /// <param name="asignaturas"></param>
        private void MostrarGraficaAlumnosMatriculadosPorCursoEscolar(List<Asignatura> asignaturas)
        {
            SeriesCollection serieBarras = new();
            if (asignaturas.Count > 0)
            {
                var alumnosPorAsig =
                from asig in asignaturas
                group asig by asig.Nombre into g
                select new { Asig = g.Key, Count = g.Count() };

                foreach (var alumnos in alumnosPorAsig)
                {
                    serieBarras.Add(new ColumnSeries
                    {
                        Title = alumnos.Asig.ToString(),
                        Values = new ChartValues<int> { alumnos.Count }
                    });
                  
                    graficaAlumnosPorAsignatura.Series = serieBarras;
                }
            }
            else
            {
                MostrarMensaje("No se han encontrado resultados", "Información");
            }
        }

        /// <summary>
        /// Muestra un mensaj
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="caption"></param>
        private static void MostrarMensaje(string msj, string caption)
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage image = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(msj, caption, button, image);
        }
    }
}
