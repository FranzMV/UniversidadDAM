using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;
using System.Windows.Forms.DataVisualization.Charting;

/// <author> Francisco David Manzanedo Valle.</author>
namespace Presentacion
{
    public partial class FormGraficoAlumnosMatriculados : Form
    {
        private readonly Universidad _universidad;
        private List<AlumnoSeMatriculaAsignatura> _listaAlumnosMatriculados;
        private readonly List<CursoEscolar> _listaCursosEscolares;
        private readonly List<Asignatura> _listaAsignaturas;

        public FormGraficoAlumnosMatriculados()
        {
            InitializeComponent();
            _universidad = new Universidad();
            _listaCursosEscolares = _universidad.ListarCursosEscolares();
            _listaAsignaturas = _universidad.ListarAsignaturas();
            _listaAlumnosMatriculados = _universidad.ListarAlumnoSeMatriculaAsignatura();
            CargarAsignaturas();
        }

        private void FormGraficoAlumnosMatriculados_Load(object sender, EventArgs e)
        {
            chartBarras.Series[0].Points.Clear();
            chartBarras.Series["Series1"].LegendText = "Alumnos matriculados últimos 10 años";
        }

        //Eventos sobre el comboBox the Asignaturas
        private void comboBoxAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Asignatura asignatura = _universidad.LeerAsignatura(comboBoxAsignaturas.SelectedIndex + 1);
            Asignatura asignaturaAux = new Asignatura();
            Dictionary<CursoEscolar, Asignatura> diccionario = new Dictionary<CursoEscolar, Asignatura>();
            foreach(AlumnoSeMatriculaAsignatura a in _listaAlumnosMatriculados)
            {
                if(a.Id_Asignatura == asignatura.Id_Asignatura)
                {
                    foreach(CursoEscolar c in _listaCursosEscolares)
                    {
                        if(c.Id_Curso_Escolar == a.Id_Curso_Escolar && c.Anyo_Inicio >= (DateTime.Now.Year - 10))
                        {
                            asignaturaAux = _universidad.LeerAsignatura(a.Id_Asignatura);
                            diccionario.Add(new CursoEscolar(a.Id_Curso_Escolar, c.Anyo_Inicio, c.Anyo_Fin), asignaturaAux);
                        }
                    }
                    
                }
            }

            MostrarGrafica(diccionario, asignaturaAux);
        }

        /// <summary>
        /// Carga las asignaturas en el comboBox
        /// </summary>
        private void CargarAsignaturas()
        {
            foreach (Asignatura a in _listaAsignaturas)
                comboBoxAsignaturas.Items.Add(a.Nombre);
        }

        //Muestra la gráfica
        private void MostrarGrafica(IDictionary<CursoEscolar, Asignatura> diccionario, Asignatura asignatura)
        {
            List<string> fechas = new List<string>();
            //chartBarras.Series[0].Points.Clear();
            chartBarras.Series.Clear();
            chartBarras.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Series1"));
            if (diccionario.Count > 0)
            {
                //int contador = diccionario.Count(a => a.Value.Id_Asignatura == asignatura.Id_Asignatura);
                foreach (KeyValuePair<CursoEscolar, Asignatura> kvp in diccionario)
                {
                    if(kvp.Value.Id_Asignatura == asignatura.Id_Asignatura)
                        fechas.Add(kvp.Key.Anyo_Inicio.ToString() + "/" + kvp.Key.Anyo_Fin.ToString());
                }
                
                var resultadoFechas = fechas.GroupBy(x => x);
                foreach(var grp in resultadoFechas)
                {
                    Series series = chartBarras.Series.Add(grp.Key.ToString() + ": " + asignatura.Nombre + ": " + grp.Count().ToString());
                    //chartBarras.Series["Series1"].Points.AddXY(grp.Key, grp.Count());
                    series.Label = grp.Count().ToString();
                    series.Points.Add(grp.Count());
                }

            }
            else
                MessageBox.Show("No se han encontrado registros para la asignatura seleccionada");
        }
    }
}
