using System;
using System.Windows.Forms;
/// <author> Francisco David Manzanedo Valle.</author>
namespace Presentacion
{
    public partial class FormMDIMenuPrincipal : Form
    {
        private FormAnyadirPersonas _formAnyadirPersonas;
        private FormBuscarPersonas _formBuscarPersonas;
        private FormAcercaDe _formAcercaDe;
        private FormMatricula _formMatricula;
        private FormGraficoAlumnosPorAsignatura _formGrafAlumnPorAsign;
        private FormGraficoAlumnosMatriculados _formGrafAlumnosMatriculados;
        private FormGraficoTotalAlumnosPorGrado _formGrafAlumnosPorGrado;
        private string _usuarioActual;
        private DateTime _tiempo;
        private double _segundos;
        private string _cadenaTiempoConectado;

        private const string MODO_BUSQUEDA_PERSONA_ELIMINAR = "eliminar";
        private const string MODO_BUSQUEDA_PERSONA_EDITAR = "editar";
        private const string MODO_CREAR_MATRICULA = "crear_matricula";
        private const string MODO_CONSULTAR_EDITAR_MATRICULA = "consultar_editar_matricula";
        private const string MODO_ELIMINAR_MATRICULA = "eliminar_matricula";
      

        public FormMDIMenuPrincipal(string usuarioActual)
        {
            InitializeComponent();
            _formAnyadirPersonas = new FormAnyadirPersonas();
            _formAcercaDe = new FormAcercaDe();
            _formBuscarPersonas = new FormBuscarPersonas("");
            _formMatricula = new FormMatricula();
            _formGrafAlumnPorAsign = new FormGraficoAlumnosPorAsignatura();
            _formGrafAlumnosMatriculados = new FormGraficoAlumnosMatriculados();
            _formGrafAlumnosPorGrado = new FormGraficoTotalAlumnosPorGrado();
            this._usuarioActual = usuarioActual;
            iconoNotificacion.Visible = true;
            TimerUsuarioConectado.Enabled = true;
            TimerUsuarioConectado.Start();
            _tiempo = new DateTime();
            _segundos = 0;
        }

       //Evento load del formulario
        private void FormMDIMenuPrincipal_Load(object sender, EventArgs e)
        {
            ToolStripInsertarPersona.ToolTipText = "Insertar nueva persona";
            ToolStripImprimirMatricula.ToolTipText = "Imprimir matrícula";
            ToolStripNuevaMatricula.ToolTipText = "Nueva matrícula";
            lblHoraSistema.Text = DateTime.Now.ToString("HH:mm");
            lblUsuarioConectado.Text = _usuarioActual;
        }

        //Timer correspondiente al tiempo conectado del usuario
        private void TimerUsuarioConectado_Tick(object sender, EventArgs e)
        {
            _segundos++;
            _cadenaTiempoConectado = _tiempo.AddSeconds(_segundos).ToString("HH:mm:ss");
        }

        //Lanza el formulario Insertar Persona
        private void OpcionMenuPersonasInsertar_Click(object sender, EventArgs e)
        {
            _formAnyadirPersonas.Close();
            _formAnyadirPersonas = new FormAnyadirPersonas();
            _formAnyadirPersonas.MdiParent = this;
            _formAnyadirPersonas.ControlBox = false;
            _formAnyadirPersonas.WindowState = FormWindowState.Maximized;
            _formAnyadirPersonas.Show();
            panelPrincipal.Visible = false;
            lblFormulariosAbiertos.Text = "Nº de formularios abiertos: " + this.MdiChildren.Length.ToString();
        }
        
        //Lanza el formulario Búsqueda de personas en modo edición
        private void OpcionMenuModificarPersona_Click(object sender, EventArgs e)
        {
            _formBuscarPersonas.Close();
            _formBuscarPersonas = new(MODO_BUSQUEDA_PERSONA_EDITAR);
            _formBuscarPersonas.MdiParent = this;
            _formBuscarPersonas.ControlBox = false;
            _formBuscarPersonas.WindowState = FormWindowState.Maximized;
            _formBuscarPersonas.Show();
            panelPrincipal.Visible = false;
            lblFormulariosAbiertos.Text = "Nº de formularios abiertos: " + this.MdiChildren.Length.ToString();  
        }

        //Lanza el formulario en búsqueda de personas en modo eliminar
        private void OpcionMenuEliminarPersona_Click(object sender, EventArgs e)
        {
            _formBuscarPersonas.Close();
            _formBuscarPersonas = new (MODO_BUSQUEDA_PERSONA_ELIMINAR);
            _formBuscarPersonas.MdiParent = this;
            _formBuscarPersonas.ControlBox = false;
            _formBuscarPersonas.WindowState = FormWindowState.Maximized;
            _formBuscarPersonas.Show();
            panelPrincipal.Visible = false;
            lblFormulariosAbiertos.Text = "Nº de formularios abiertos: " + this.MdiChildren.Length.ToString();
        }

        //Lanza el formulario nueva matrícula en modo inserción
        private void OpcionMenuNuevaMatricula_Click(object sender, EventArgs e)
        {
            _formMatricula.Close();
            _formMatricula = new FormMatricula(null, MODO_CREAR_MATRICULA);
            _formMatricula.MdiParent = this;
            _formMatricula.ControlBox = false;
            _formMatricula.WindowState = FormWindowState.Maximized;
            _formMatricula.Show();
            panelPrincipal.Visible = false;
            lblFormulariosAbiertos.Text = "Nº de formularios abiertos: " + this.MdiChildren.Length.ToString();
        }

        //Lanza el formulario matricula en modo consulta/modificación
        //Evento click para la opción de menú consultar/modificar matrícula
        private void OpcionMenuConsultaYModificacion_Click(object sender, EventArgs e)
        {
            _formMatricula.Close();
            _formMatricula = new FormMatricula(null, MODO_CONSULTAR_EDITAR_MATRICULA);
            _formMatricula.MdiParent = this;
            _formMatricula.ControlBox = false;
            _formMatricula.WindowState = FormWindowState.Maximized;
            _formMatricula.Show();
            panelPrincipal.Visible = false;
            lblFormulariosAbiertos.Text = "Nº de formularios abiertos: " + this.MdiChildren.Length.ToString();
        }

        //Evento click para la opción de menú consultar/modificar matrícula
        private void OpcionMenuEliminarMatricula_Click(object sender, EventArgs e)
        {
            _formMatricula.Close();
            _formMatricula = new FormMatricula(null, MODO_ELIMINAR_MATRICULA);
            _formMatricula.MdiParent = this;
            _formMatricula.ControlBox = false;
            _formMatricula.WindowState = FormWindowState.Maximized;
            _formMatricula.Show();
            panelPrincipal.Visible = false;
            lblFormulariosAbiertos.Text = "Nº de formularios abiertos: " + this.MdiChildren.Length.ToString();
        }

        //Evento click para la opcón gráficos Alumnos por asignatura
        private void OpcionMenuGraficaAlumnosPorAsignatura_Click(object sender, EventArgs e)
        {
            _formGrafAlumnPorAsign.Close();
            _formGrafAlumnPorAsign = new FormGraficoAlumnosPorAsignatura();
            _formGrafAlumnPorAsign.MdiParent = this;
            _formGrafAlumnPorAsign.ControlBox = false;
            _formGrafAlumnPorAsign.WindowState = FormWindowState.Maximized;
            _formGrafAlumnPorAsign.Show();
            panelPrincipal.Visible = false;
            lblFormulariosAbiertos.Text = "Nº de formularios abiertos: " + this.MdiChildren.Length.ToString();
        }

        //Evento click para la opcón gráficos Alumnos matriculados
        private void OpcionMenuGraficaAlumnosMatriculados_Click(object sender, EventArgs e)
        {
            _formGrafAlumnosMatriculados.Close();
            _formGrafAlumnosMatriculados = new FormGraficoAlumnosMatriculados();
            _formGrafAlumnosMatriculados.MdiParent = this;
            _formGrafAlumnosMatriculados.ControlBox = false;
            _formGrafAlumnosMatriculados.WindowState = FormWindowState.Maximized;
            _formGrafAlumnosMatriculados.Show();
            panelPrincipal.Visible = false;
            lblFormulariosAbiertos.Text = "Nº de formularios abiertos: " + this.MdiChildren.Length.ToString();
        }

        //Evento click para la opcón gráficos Alumnos matriculados por grado
        private void OpcionMenuGraficaAlumnosPorGrado_Click(object sender, EventArgs e)
        {
            _formGrafAlumnosPorGrado.Close();
            _formGrafAlumnosPorGrado = new FormGraficoTotalAlumnosPorGrado();
            _formGrafAlumnosPorGrado.MdiParent = this;
            _formGrafAlumnosPorGrado.ControlBox = false;
            _formGrafAlumnosPorGrado.WindowState = FormWindowState.Maximized;
            _formGrafAlumnosPorGrado.Show();
            panelPrincipal.Visible = false;
            lblFormulariosAbiertos.Text = "Nº de formularios abiertos: " + this.MdiChildren.Length.ToString();
        }

        //Evento click para la opción del menú Acerca de
        private void OpcionMenuAcercaDe_Click(object sender, EventArgs e)
        {
            _formAcercaDe.Close();
            _formAcercaDe = new FormAcercaDe();
            _formAcercaDe.ShowDialog();
        }

        //Evento click para cerrar la aplicación
        private void OpcionMenuSalir_Click(object sender, EventArgs e)
        {
            DialogResult salir = MessageBox.Show("¿Está usted seguro que desea salir?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (salir == DialogResult.Yes)
                Application.Exit();
        }

        private void MostrarUsurioToolStripMenuItem_MouseHover(object sender, EventArgs e) =>
            MostrarUsurioToolStripMenuItem.ToolTipText = "Usuario: " + _usuarioActual + Environment.NewLine + "Tiempo conectado: "
                + _cadenaTiempoConectado;
        
    }
}
