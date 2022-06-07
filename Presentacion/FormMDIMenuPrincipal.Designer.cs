
namespace Presentacion
{
    partial class FormMDIMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMDIMenuPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.OpcionMenuPersonas = new System.Windows.Forms.ToolStripMenuItem();
            this.OpcionMenuPersonasInsertar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.OpcionMenuModificarPersona = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.OpcionMenuEliminarPersona = new System.Windows.Forms.ToolStripMenuItem();
            this.OpcionMenuMatricula = new System.Windows.Forms.ToolStripMenuItem();
            this.OpcionMenuNuevaMatricula = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.OpcionMenuConsultaYModificacion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.OpcionMenuEliminarMatricula = new System.Windows.Forms.ToolStripMenuItem();
            this.OpcionMenuGraficas = new System.Windows.Forms.ToolStripMenuItem();
            this.OpcionMenuGraficaAlumnosMatriculados = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.OpcionMenuGraficaAlumnosPorAsignatura = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.OpcionMenuGraficaAlumnosPorGrado = new System.Windows.Forms.ToolStripMenuItem();
            this.OpcionMenuInformes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpcionMenuAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.OpcionMenuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBarraTareas = new System.Windows.Forms.ToolStrip();
            this.ToolStripInsertarPersona = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripNuevaMatricula = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripImprimirMatricula = new System.Windows.Forms.ToolStripLabel();
            this.lblUsuarioConectado = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripInferior = new System.Windows.Forms.ToolStrip();
            this.lblHoraSistema = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblFormulariosAbiertos = new System.Windows.Forms.ToolStripLabel();
            this.TimerUsuarioConectado = new System.Windows.Forms.Timer(this.components);
            this.ContextMenuStripUsuario = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MostrarUsurioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.iconoNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStripBarraTareas.SuspendLayout();
            this.toolStripInferior.SuspendLayout();
            this.ContextMenuStripUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpcionMenuPersonas,
            this.OpcionMenuMatricula,
            this.OpcionMenuGraficas,
            this.OpcionMenuInformes,
            this.OpcionMenuAcercaDe,
            this.OpcionMenuSalir});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // OpcionMenuPersonas
            // 
            this.OpcionMenuPersonas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpcionMenuPersonasInsertar,
            this.toolStripSeparator5,
            this.OpcionMenuModificarPersona,
            this.toolStripSeparator6,
            this.OpcionMenuEliminarPersona});
            this.OpcionMenuPersonas.Name = "OpcionMenuPersonas";
            this.OpcionMenuPersonas.Size = new System.Drawing.Size(66, 20);
            this.OpcionMenuPersonas.Text = "Personas";
            // 
            // OpcionMenuPersonasInsertar
            // 
            this.OpcionMenuPersonasInsertar.Name = "OpcionMenuPersonasInsertar";
            this.OpcionMenuPersonasInsertar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.OpcionMenuPersonasInsertar.Size = new System.Drawing.Size(180, 22);
            this.OpcionMenuPersonasInsertar.Text = "&Insertar";
            this.OpcionMenuPersonasInsertar.Click += new System.EventHandler(this.OpcionMenuPersonasInsertar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // OpcionMenuModificarPersona
            // 
            this.OpcionMenuModificarPersona.Name = "OpcionMenuModificarPersona";
            this.OpcionMenuModificarPersona.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.OpcionMenuModificarPersona.Size = new System.Drawing.Size(180, 22);
            this.OpcionMenuModificarPersona.Text = "&Modificar";
            this.OpcionMenuModificarPersona.Click += new System.EventHandler(this.OpcionMenuModificarPersona_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            // 
            // OpcionMenuEliminarPersona
            // 
            this.OpcionMenuEliminarPersona.Name = "OpcionMenuEliminarPersona";
            this.OpcionMenuEliminarPersona.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.OpcionMenuEliminarPersona.Size = new System.Drawing.Size(180, 22);
            this.OpcionMenuEliminarPersona.Text = "&Eliminar";
            this.OpcionMenuEliminarPersona.Click += new System.EventHandler(this.OpcionMenuEliminarPersona_Click);
            // 
            // OpcionMenuMatricula
            // 
            this.OpcionMenuMatricula.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpcionMenuNuevaMatricula,
            this.toolStripSeparator7,
            this.OpcionMenuConsultaYModificacion,
            this.toolStripSeparator8,
            this.OpcionMenuEliminarMatricula});
            this.OpcionMenuMatricula.Name = "OpcionMenuMatricula";
            this.OpcionMenuMatricula.Size = new System.Drawing.Size(69, 20);
            this.OpcionMenuMatricula.Text = "Matrícula";
            // 
            // OpcionMenuNuevaMatricula
            // 
            this.OpcionMenuNuevaMatricula.Name = "OpcionMenuNuevaMatricula";
            this.OpcionMenuNuevaMatricula.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.OpcionMenuNuevaMatricula.Size = new System.Drawing.Size(280, 22);
            this.OpcionMenuNuevaMatricula.Text = "&Nueva";
            this.OpcionMenuNuevaMatricula.Click += new System.EventHandler(this.OpcionMenuNuevaMatricula_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(277, 6);
            // 
            // OpcionMenuConsultaYModificacion
            // 
            this.OpcionMenuConsultaYModificacion.Name = "OpcionMenuConsultaYModificacion";
            this.OpcionMenuConsultaYModificacion.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.OpcionMenuConsultaYModificacion.Size = new System.Drawing.Size(280, 22);
            this.OpcionMenuConsultaYModificacion.Text = "&Consulta y modificación";
            this.OpcionMenuConsultaYModificacion.Click += new System.EventHandler(this.OpcionMenuConsultaYModificacion_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(277, 6);
            // 
            // OpcionMenuEliminarMatricula
            // 
            this.OpcionMenuEliminarMatricula.Name = "OpcionMenuEliminarMatricula";
            this.OpcionMenuEliminarMatricula.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.OpcionMenuEliminarMatricula.Size = new System.Drawing.Size(280, 22);
            this.OpcionMenuEliminarMatricula.Text = "&Eliminar";
            this.OpcionMenuEliminarMatricula.Click += new System.EventHandler(this.OpcionMenuEliminarMatricula_Click);
            // 
            // OpcionMenuGraficas
            // 
            this.OpcionMenuGraficas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpcionMenuGraficaAlumnosMatriculados,
            this.toolStripSeparator9,
            this.OpcionMenuGraficaAlumnosPorAsignatura,
            this.toolStripSeparator10,
            this.OpcionMenuGraficaAlumnosPorGrado});
            this.OpcionMenuGraficas.Name = "OpcionMenuGraficas";
            this.OpcionMenuGraficas.Size = new System.Drawing.Size(61, 20);
            this.OpcionMenuGraficas.Text = "Gráficas";
            // 
            // OpcionMenuGraficaAlumnosMatriculados
            // 
            this.OpcionMenuGraficaAlumnosMatriculados.Name = "OpcionMenuGraficaAlumnosMatriculados";
            this.OpcionMenuGraficaAlumnosMatriculados.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.OpcionMenuGraficaAlumnosMatriculados.Size = new System.Drawing.Size(271, 22);
            this.OpcionMenuGraficaAlumnosMatriculados.Text = "&Alumnos matriculados";
            this.OpcionMenuGraficaAlumnosMatriculados.Click += new System.EventHandler(this.OpcionMenuGraficaAlumnosMatriculados_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(268, 6);
            // 
            // OpcionMenuGraficaAlumnosPorAsignatura
            // 
            this.OpcionMenuGraficaAlumnosPorAsignatura.Name = "OpcionMenuGraficaAlumnosPorAsignatura";
            this.OpcionMenuGraficaAlumnosPorAsignatura.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F11)));
            this.OpcionMenuGraficaAlumnosPorAsignatura.Size = new System.Drawing.Size(271, 22);
            this.OpcionMenuGraficaAlumnosPorAsignatura.Text = "&Alumnos por asignatura";
            this.OpcionMenuGraficaAlumnosPorAsignatura.Click += new System.EventHandler(this.OpcionMenuGraficaAlumnosPorAsignatura_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(268, 6);
            // 
            // OpcionMenuGraficaAlumnosPorGrado
            // 
            this.OpcionMenuGraficaAlumnosPorGrado.Name = "OpcionMenuGraficaAlumnosPorGrado";
            this.OpcionMenuGraficaAlumnosPorGrado.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F12)));
            this.OpcionMenuGraficaAlumnosPorGrado.Size = new System.Drawing.Size(271, 22);
            this.OpcionMenuGraficaAlumnosPorGrado.Text = "&Total de alumnos por grado";
            this.OpcionMenuGraficaAlumnosPorGrado.Click += new System.EventHandler(this.OpcionMenuGraficaAlumnosPorGrado_Click);
            // 
            // OpcionMenuInformes
            // 
            this.OpcionMenuInformes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem17,
            this.toolStripSeparator11,
            this.toolStripMenuItem18});
            this.OpcionMenuInformes.Name = "OpcionMenuInformes";
            this.OpcionMenuInformes.Size = new System.Drawing.Size(66, 20);
            this.OpcionMenuInformes.Text = "&Informes";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.toolStripMenuItem17.Size = new System.Drawing.Size(294, 22);
            this.toolStripMenuItem17.Text = "&Matrícula";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(291, 6);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.toolStripMenuItem18.Size = new System.Drawing.Size(294, 22);
            this.toolStripMenuItem18.Text = "&Listado de alumnos por asignatura";
            // 
            // OpcionMenuAcercaDe
            // 
            this.OpcionMenuAcercaDe.Name = "OpcionMenuAcercaDe";
            this.OpcionMenuAcercaDe.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F13)));
            this.OpcionMenuAcercaDe.Size = new System.Drawing.Size(80, 20);
            this.OpcionMenuAcercaDe.Text = "&Acerca de...";
            this.OpcionMenuAcercaDe.Click += new System.EventHandler(this.OpcionMenuAcercaDe_Click);
            // 
            // OpcionMenuSalir
            // 
            this.OpcionMenuSalir.Name = "OpcionMenuSalir";
            this.OpcionMenuSalir.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.OpcionMenuSalir.Size = new System.Drawing.Size(41, 20);
            this.OpcionMenuSalir.Text = "&Salir";
            this.OpcionMenuSalir.Click += new System.EventHandler(this.OpcionMenuSalir_Click);
            // 
            // toolStripBarraTareas
            // 
            this.toolStripBarraTareas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripInsertarPersona,
            this.toolStripSeparator2,
            this.ToolStripNuevaMatricula,
            this.toolStripSeparator3,
            this.ToolStripImprimirMatricula,
            this.lblUsuarioConectado,
            this.toolStripSeparator4});
            this.toolStripBarraTareas.Location = new System.Drawing.Point(0, 24);
            this.toolStripBarraTareas.Name = "toolStripBarraTareas";
            this.toolStripBarraTareas.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripBarraTareas.Size = new System.Drawing.Size(1264, 25);
            this.toolStripBarraTareas.TabIndex = 3;
            // 
            // ToolStripInsertarPersona
            // 
            this.ToolStripInsertarPersona.Image = global::Presentacion.Properties.Resources.icons8_añadir_usuario_grupo_mujer_hombre_40;
            this.ToolStripInsertarPersona.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.ToolStripInsertarPersona.Name = "ToolStripInsertarPersona";
            this.ToolStripInsertarPersona.Size = new System.Drawing.Size(16, 22);
            this.ToolStripInsertarPersona.Click += new System.EventHandler(this.OpcionMenuPersonasInsertar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripNuevaMatricula
            // 
            this.ToolStripNuevaMatricula.Image = global::Presentacion.Properties.Resources.icons8_formulario_40;
            this.ToolStripNuevaMatricula.Name = "ToolStripNuevaMatricula";
            this.ToolStripNuevaMatricula.Size = new System.Drawing.Size(16, 22);
            this.ToolStripNuevaMatricula.Click += new System.EventHandler(this.OpcionMenuNuevaMatricula_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripImprimirMatricula
            // 
            this.ToolStripImprimirMatricula.Image = global::Presentacion.Properties.Resources.icons8_imprimir_30;
            this.ToolStripImprimirMatricula.Name = "ToolStripImprimirMatricula";
            this.ToolStripImprimirMatricula.Size = new System.Drawing.Size(16, 22);
            // 
            // lblUsuarioConectado
            // 
            this.lblUsuarioConectado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblUsuarioConectado.Name = "lblUsuarioConectado";
            this.lblUsuarioConectado.Size = new System.Drawing.Size(47, 22);
            this.lblUsuarioConectado.Text = "Usuario";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripInferior
            // 
            this.toolStripInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripInferior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblHoraSistema,
            this.toolStripSeparator1,
            this.lblFormulariosAbiertos});
            this.toolStripInferior.Location = new System.Drawing.Point(0, 836);
            this.toolStripInferior.Name = "toolStripInferior";
            this.toolStripInferior.Size = new System.Drawing.Size(1264, 25);
            this.toolStripInferior.TabIndex = 5;
            this.toolStripInferior.Text = "toolStrip1";
            // 
            // lblHoraSistema
            // 
            this.lblHoraSistema.Name = "lblHoraSistema";
            this.lblHoraSistema.Size = new System.Drawing.Size(33, 22);
            this.lblHoraSistema.Text = "Hora";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblFormulariosAbiertos
            // 
            this.lblFormulariosAbiertos.Name = "lblFormulariosAbiertos";
            this.lblFormulariosAbiertos.Size = new System.Drawing.Size(146, 22);
            this.lblFormulariosAbiertos.Text = "Nº de formularios abiertos";
            // 
            // TimerUsuarioConectado
            // 
            this.TimerUsuarioConectado.Enabled = true;
            this.TimerUsuarioConectado.Interval = 1000;
            this.TimerUsuarioConectado.Tick += new System.EventHandler(this.TimerUsuarioConectado_Tick);
            // 
            // ContextMenuStripUsuario
            // 
            this.ContextMenuStripUsuario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MostrarUsurioToolStripMenuItem});
            this.ContextMenuStripUsuario.Name = "ContextMenuStripUsuario";
            this.ContextMenuStripUsuario.Size = new System.Drawing.Size(158, 26);
            // 
            // MostrarUsurioToolStripMenuItem
            // 
            this.MostrarUsurioToolStripMenuItem.Name = "MostrarUsurioToolStripMenuItem";
            this.MostrarUsurioToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.MostrarUsurioToolStripMenuItem.Text = "Mostrar usuario";
            this.MostrarUsurioToolStripMenuItem.MouseHover += new System.EventHandler(this.MostrarUsurioToolStripMenuItem_MouseHover);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 52);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1264, 781);
            this.panelPrincipal.TabIndex = 10;
            // 
            // iconoNotificacion
            // 
            this.iconoNotificacion.ContextMenuStrip = this.ContextMenuStripUsuario;
            this.iconoNotificacion.Icon = ((System.Drawing.Icon)(resources.GetObject("iconoNotificacion.Icon")));
            this.iconoNotificacion.Text = "UniversidadDAM";
            this.iconoNotificacion.Visible = true;
            // 
            // FormMDIMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1264, 861);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.toolStripInferior);
            this.Controls.Add(this.toolStripBarraTareas);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMDIMenuPrincipal";
            this.Text = "Universidad DAM";
            this.Load += new System.EventHandler(this.FormMDIMenuPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripBarraTareas.ResumeLayout(false);
            this.toolStripBarraTareas.PerformLayout();
            this.toolStripInferior.ResumeLayout(false);
            this.toolStripInferior.PerformLayout();
            this.ContextMenuStripUsuario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStripBarraTareas;
        private System.Windows.Forms.ToolStrip toolStripInferior;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuPersonas;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuPersonasInsertar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuModificarPersona;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuEliminarPersona;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuMatricula;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuNuevaMatricula;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuGraficas;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuInformes;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuAcercaDe;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuConsultaYModificacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuEliminarMatricula;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuGraficaAlumnosMatriculados;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuGraficaAlumnosPorAsignatura;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem OpcionMenuGraficaAlumnosPorGrado;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.Timer TimerUsuarioConectado;
        private System.Windows.Forms.ToolStripLabel lblHoraSistema;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblFormulariosAbiertos;
        private System.Windows.Forms.ToolStripLabel ToolStripInsertarPersona;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel ToolStripNuevaMatricula;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel ToolStripImprimirMatricula;
        private System.Windows.Forms.ToolStripLabel lblUsuarioConectado;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripUsuario;
        private System.Windows.Forms.ToolStripMenuItem MostrarUsurioToolStripMenuItem;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.NotifyIcon iconoNotificacion;
    }
}