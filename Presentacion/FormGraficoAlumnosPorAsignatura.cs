using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CapaNegocio;
using Entidades;
/// <author> Francisco David Manzanedo Valle.</author>
namespace Presentacion
{
    public partial class FormGraficoAlumnosPorAsignatura : Form
    {
        private readonly Universidad _universidad;
        private readonly List<CursoEscolar> _listaCursosEscolares;
        private readonly List<AlumnoSeMatriculaAsignatura> _listaAlumnosMatriculadosPorAsignatura;

        public FormGraficoAlumnosPorAsignatura()
        {
            InitializeComponent();
            _universidad = new Universidad();
            _listaCursosEscolares = _universidad.ListarCursosEscolares();
            _listaAlumnosMatriculadosPorAsignatura = _universidad.ListarAlumnoSeMatriculaAsignatura();
    
            CargarCursos();
        }

        //Evento load del formulario
        private void FormGraficoAlumnosPorAsignatura_Load(object sender, EventArgs e) => chartBarras.Series.Clear();
       

        //Evento correspondiente al comboBox CursoEscolar
        private void comboBoxCursoEscolar_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Asignatura> asignaturas = new List<Asignatura>();
            CursoEscolar cursoEscolar = _universidad.LeerCursoEscolar(comboBoxCursoEscolar.SelectedIndex + 1);

            foreach(AlumnoSeMatriculaAsignatura a in _listaAlumnosMatriculadosPorAsignatura)
            {
                if(a.Id_Curso_Escolar == cursoEscolar.Id_Curso_Escolar)
                    asignaturas.Add(_universidad.LeerAsignatura(a.Id_Asignatura));
            }

            MostrarGrafica(asignaturas);
        }

        /// <summary>
        /// Carga los cursos en el ComboBox de Cursos
        /// </summary>
        private void CargarCursos()
        {
            foreach (CursoEscolar c in _listaCursosEscolares)
                comboBoxCursoEscolar.Items.Add(c.Anyo_Inicio + "/" + c.Anyo_Fin);
        }

        /// <summary>
        /// Muestra la gráfica Alumnos por asignatura
        /// </summary>
        /// <param name="asignaturas">Lista de asignaturas</param>
        private void MostrarGrafica(List<Asignatura> asignaturas)
        {
            chartBarras.Series.Clear();
            chartBarras.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Series1"));
            chartBarras.Series["Series1"].LegendText = "Alumnos matriculados por asignatura";
            chartBarras.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
            if (asignaturas.Count > 0)
            {
                var alumnosPorAsig =
                from asig in asignaturas
                group asig by asig.Nombre into g
                select new { Asig = g.Key, Count = g.Count() };
               
                foreach (var alumnos in alumnosPorAsig)
                {
                    Series seriesBarras = chartBarras.Series.Add(alumnos.Asig + ":" + alumnos.Count);
                    seriesBarras.Label = alumnos.Count.ToString();
                    seriesBarras.Points.Add(alumnos.Count);
                }
            }
            else
                MessageBox.Show("No se han encontrado registros para el curso seleccionado", "Información");
        }
    }
}
