using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using CapaNegocio;
using System.Windows.Forms.DataVisualization.Charting;
/// <author> Francisco David Manzanedo Valle.</author>
namespace Presentacion
{
    public partial class FormGraficoTotalAlumnosPorGrado : Form
    {
        private readonly Universidad _universidad;
        private readonly List<CursoEscolar> _listaCursosEscolares;
        private readonly List<AlumnoSeMatriculaAsignatura> _listaAlumnosMatriculados;

        public FormGraficoTotalAlumnosPorGrado()
        {
            InitializeComponent();
            _universidad = new Universidad();
            _listaCursosEscolares = _universidad.ListarCursosEscolares();
            _listaAlumnosMatriculados = _universidad.ListarAlumnoSeMatriculaAsignatura();
            CargarCursos();
        }

        //Método load del formulario
        private void FormGraficoTotalAlumnosPorGrado_Load(object sender, EventArgs e) => chartBarras.Series.Clear();
       

        //Evento click sobre el comboBox de cursos escolares
        private void comboBoxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Asignatura> listaAsignaturasCursoEscolar = new List<Asignatura>();
            List<Grado> listaGrados = new List<Grado>();
            CursoEscolar cursoEscolar = _universidad.LeerCursoEscolar(comboBoxCursos.SelectedIndex + 1);
            foreach(AlumnoSeMatriculaAsignatura a in _listaAlumnosMatriculados)
            {
                if(a.Id_Curso_Escolar == cursoEscolar.Id_Curso_Escolar)
                    listaAsignaturasCursoEscolar.Add(_universidad.LeerAsignatura(a.Id_Alumno));
            }

            foreach (Asignatura a in listaAsignaturasCursoEscolar)
                listaGrados.Add(_universidad.LeerGrado(a.Id_Grado));

            MostrarGrafica(listaGrados);
                
        }

        /// <summary>
        /// Muestra la gráfica de total de alumnos por grado
        /// </summary>
        /// <param name="grados">lista de grados en un curso escolar</param>
        private void MostrarGrafica(List<Grado> grados)
        {
            chartBarras.Series.Clear();
            chartBarras.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Series1"));
            chartBarras.Series["Series1"].LegendText = "Total alumnos por grado";
            if (grados.Count > 0)
            {
                var alumnosGrado =
                    from gr in grados
                    group gr by gr.Nombre into g
                    select new { GR = g.Key, Count = g.Count() };

                foreach (var g in alumnosGrado)
                {
                    //chartBarras.Series["Series1"].Points.AddXY(g.GR.ToString(), g.Count);
                    Series seriesBarras = chartBarras.Series.Add(g.GR.ToString() + ": " + g.Count);
                    seriesBarras.Label = g.Count.ToString();
                    seriesBarras.Points.Add(g.Count);
                }
            }else
                MessageBox.Show("No se han encontrado registros para el curso seleccionado", "Información");
        }


        /// <summary>
        /// Carga todos los cursos en el comboBox de cursos.
        /// </summary>
        private void CargarCursos()
        {
            foreach(CursoEscolar c in _listaCursosEscolares)
                comboBoxCursos.Items.Add(c.Anyo_Inicio + "/" + c.Anyo_Fin);
        }
    }
}
