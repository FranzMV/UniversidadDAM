
namespace Presentacion
{
    partial class FormAnyadirPersonas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnyadirPersonas));
            this.CheckBoxAlumno = new System.Windows.Forms.CheckBox();
            this.CheckBoxProfesor = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.MaskedTextBoxTelef = new System.Windows.Forms.MaskedTextBox();
            this.CmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.DtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.rdbMujer = new System.Windows.Forms.RadioButton();
            this.rdbHombre = new System.Windows.Forms.RadioButton();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.TxtbDireccion = new System.Windows.Forms.TextBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.TxtbCiudad = new System.Windows.Forms.TextBox();
            this.lblNIF = new System.Windows.Forms.Label();
            this.TxtbNIF = new System.Windows.Forms.TextBox();
            this.lblSegundoApell = new System.Windows.Forms.Label();
            this.TxtbSegundoApell = new System.Windows.Forms.TextBox();
            this.lblPrimerApell = new System.Windows.Forms.Label();
            this.TxtbPrimerApell = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.TxtbNombre = new System.Windows.Forms.TextBox();
            this.PictureBoxImagenPersona = new System.Windows.Forms.PictureBox();
            this.BtnAnyadirPersona = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.BtnCancelarPersona = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxImagenPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxAlumno
            // 
            this.CheckBoxAlumno.AutoSize = true;
            this.CheckBoxAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBoxAlumno.Location = new System.Drawing.Point(209, 26);
            this.CheckBoxAlumno.Name = "CheckBoxAlumno";
            this.CheckBoxAlumno.Size = new System.Drawing.Size(71, 20);
            this.CheckBoxAlumno.TabIndex = 1;
            this.CheckBoxAlumno.Text = "Alumno";
            this.CheckBoxAlumno.UseVisualStyleBackColor = true;
            this.CheckBoxAlumno.CheckedChanged += new System.EventHandler(this.CheckBoxAlumno_CheckedChanged);
            // 
            // CheckBoxProfesor
            // 
            this.CheckBoxProfesor.AutoSize = true;
            this.CheckBoxProfesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBoxProfesor.Location = new System.Drawing.Point(364, 26);
            this.CheckBoxProfesor.Name = "CheckBoxProfesor";
            this.CheckBoxProfesor.Size = new System.Drawing.Size(77, 20);
            this.CheckBoxProfesor.TabIndex = 2;
            this.CheckBoxProfesor.Text = "Profesor";
            this.CheckBoxProfesor.UseVisualStyleBackColor = true;
            this.CheckBoxProfesor.CheckedChanged += new System.EventHandler(this.CheckBoxProfesor_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblInfo.Location = new System.Drawing.Point(30, 412);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(349, 16);
            this.lblInfo.TabIndex = 23;
            this.lblInfo.Text = "*Los campos marcados con un asterisco son obligatorios";
            // 
            // MaskedTextBoxTelef
            // 
            this.MaskedTextBoxTelef.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaskedTextBoxTelef.Location = new System.Drawing.Point(549, 218);
            this.MaskedTextBoxTelef.Mask = "000-000-000";
            this.MaskedTextBoxTelef.Name = "MaskedTextBoxTelef";
            this.MaskedTextBoxTelef.Size = new System.Drawing.Size(83, 25);
            this.MaskedTextBoxTelef.TabIndex = 10;
            this.MaskedTextBoxTelef.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.MaskedTextBoxTelef_MaskInputRejected);
            // 
            // CmbDepartamento
            // 
            this.CmbDepartamento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbDepartamento.FormattingEnabled = true;
            this.CmbDepartamento.Location = new System.Drawing.Point(926, 218);
            this.CmbDepartamento.Name = "CmbDepartamento";
            this.CmbDepartamento.Size = new System.Drawing.Size(231, 25);
            this.CmbDepartamento.TabIndex = 13;
            this.CmbDepartamento.Leave += new System.EventHandler(this.CmbDepartamento_Leave);
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDepartamento.Location = new System.Drawing.Point(926, 197);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(98, 16);
            this.lblDepartamento.TabIndex = 20;
            this.lblDepartamento.Text = "*Departamento";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFechaNac.Location = new System.Drawing.Point(209, 329);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(137, 16);
            this.lblFechaNac.TabIndex = 17;
            this.lblFechaNac.Text = "*Fecha de nacimiento";
            // 
            // DtpFechaNacimiento
            // 
            this.DtpFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DtpFechaNacimiento.Location = new System.Drawing.Point(209, 350);
            this.DtpFechaNacimiento.Name = "DtpFechaNacimiento";
            this.DtpFechaNacimiento.Size = new System.Drawing.Size(232, 25);
            this.DtpFechaNacimiento.TabIndex = 7;
            this.DtpFechaNacimiento.Leave += new System.EventHandler(this.DtpFechaNacimiento_Leave);
            // 
            // rdbMujer
            // 
            this.rdbMujer.AutoSize = true;
            this.rdbMujer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbMujer.Location = new System.Drawing.Point(1097, 95);
            this.rdbMujer.Name = "rdbMujer";
            this.rdbMujer.Size = new System.Drawing.Size(60, 21);
            this.rdbMujer.TabIndex = 12;
            this.rdbMujer.Text = "Mujer";
            this.rdbMujer.UseVisualStyleBackColor = true;
            // 
            // rdbHombre
            // 
            this.rdbHombre.AutoSize = true;
            this.rdbHombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbHombre.Location = new System.Drawing.Point(926, 95);
            this.rdbHombre.Name = "rdbHombre";
            this.rdbHombre.Size = new System.Drawing.Size(74, 21);
            this.rdbHombre.TabIndex = 11;
            this.rdbHombre.Text = "Hombre";
            this.rdbHombre.UseVisualStyleBackColor = true;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTelefono.Location = new System.Drawing.Point(549, 197);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(61, 16);
            this.lblTelefono.TabIndex = 14;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDireccion.Location = new System.Drawing.Point(549, 134);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(69, 16);
            this.lblDireccion.TabIndex = 12;
            this.lblDireccion.Text = "*Dirección";
            // 
            // TxtbDireccion
            // 
            this.TxtbDireccion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtbDireccion.Location = new System.Drawing.Point(549, 155);
            this.TxtbDireccion.Name = "TxtbDireccion";
            this.TxtbDireccion.Size = new System.Drawing.Size(266, 25);
            this.TxtbDireccion.TabIndex = 9;
            this.TxtbDireccion.Leave += new System.EventHandler(this.TxtbDireccion_Leave);
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCiudad.Location = new System.Drawing.Point(549, 70);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(55, 16);
            this.lblCiudad.TabIndex = 10;
            this.lblCiudad.Text = "*Ciudad";
            // 
            // TxtbCiudad
            // 
            this.TxtbCiudad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtbCiudad.Location = new System.Drawing.Point(549, 91);
            this.TxtbCiudad.Name = "TxtbCiudad";
            this.TxtbCiudad.Size = new System.Drawing.Size(266, 25);
            this.TxtbCiudad.TabIndex = 8;
            this.TxtbCiudad.Leave += new System.EventHandler(this.TxtbCiudad_Leave);
            // 
            // lblNIF
            // 
            this.lblNIF.AutoSize = true;
            this.lblNIF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNIF.Location = new System.Drawing.Point(209, 70);
            this.lblNIF.Name = "lblNIF";
            this.lblNIF.Size = new System.Drawing.Size(33, 16);
            this.lblNIF.TabIndex = 8;
            this.lblNIF.Text = "*NIF";
            // 
            // TxtbNIF
            // 
            this.TxtbNIF.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtbNIF.Location = new System.Drawing.Point(209, 90);
            this.TxtbNIF.Name = "TxtbNIF";
            this.TxtbNIF.Size = new System.Drawing.Size(232, 25);
            this.TxtbNIF.TabIndex = 3;
            this.TxtbNIF.Leave += new System.EventHandler(this.TxtbNIF_Leave);
            // 
            // lblSegundoApell
            // 
            this.lblSegundoApell.AutoSize = true;
            this.lblSegundoApell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSegundoApell.Location = new System.Drawing.Point(209, 261);
            this.lblSegundoApell.Name = "lblSegundoApell";
            this.lblSegundoApell.Size = new System.Drawing.Size(72, 16);
            this.lblSegundoApell.TabIndex = 6;
            this.lblSegundoApell.Text = "2º Apellido";
            // 
            // TxtbSegundoApell
            // 
            this.TxtbSegundoApell.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtbSegundoApell.Location = new System.Drawing.Point(209, 282);
            this.TxtbSegundoApell.Name = "TxtbSegundoApell";
            this.TxtbSegundoApell.Size = new System.Drawing.Size(232, 25);
            this.TxtbSegundoApell.TabIndex = 6;
            this.TxtbSegundoApell.Leave += new System.EventHandler(this.TxtbSegundoApell_Leave);
            // 
            // lblPrimerApell
            // 
            this.lblPrimerApell.AutoSize = true;
            this.lblPrimerApell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrimerApell.Location = new System.Drawing.Point(209, 197);
            this.lblPrimerApell.Name = "lblPrimerApell";
            this.lblPrimerApell.Size = new System.Drawing.Size(84, 16);
            this.lblPrimerApell.TabIndex = 4;
            this.lblPrimerApell.Text = "*1er Apellido";
            // 
            // TxtbPrimerApell
            // 
            this.TxtbPrimerApell.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtbPrimerApell.Location = new System.Drawing.Point(209, 218);
            this.TxtbPrimerApell.Name = "TxtbPrimerApell";
            this.TxtbPrimerApell.Size = new System.Drawing.Size(232, 25);
            this.TxtbPrimerApell.TabIndex = 5;
            this.TxtbPrimerApell.Leave += new System.EventHandler(this.TxtbPrimerApell_Leave);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(209, 134);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(61, 16);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "*Nombre";
            // 
            // TxtbNombre
            // 
            this.TxtbNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtbNombre.Location = new System.Drawing.Point(209, 153);
            this.TxtbNombre.Name = "TxtbNombre";
            this.TxtbNombre.Size = new System.Drawing.Size(232, 25);
            this.TxtbNombre.TabIndex = 4;
            this.TxtbNombre.Leave += new System.EventHandler(this.TxtbNombre_Leave);
            // 
            // PictureBoxImagenPersona
            // 
            this.PictureBoxImagenPersona.BackColor = System.Drawing.Color.White;
            this.PictureBoxImagenPersona.ErrorImage = global::Presentacion.Properties.Resources.camera;
            this.PictureBoxImagenPersona.Image = global::Presentacion.Properties.Resources.camera;
            this.PictureBoxImagenPersona.ImageLocation = "";
            this.PictureBoxImagenPersona.InitialImage = global::Presentacion.Properties.Resources.camera;
            this.PictureBoxImagenPersona.Location = new System.Drawing.Point(30, 86);
            this.PictureBoxImagenPersona.Name = "PictureBoxImagenPersona";
            this.PictureBoxImagenPersona.Size = new System.Drawing.Size(156, 157);
            this.PictureBoxImagenPersona.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxImagenPersona.TabIndex = 0;
            this.PictureBoxImagenPersona.TabStop = false;
            this.PictureBoxImagenPersona.DoubleClick += new System.EventHandler(this.PictureBoxImagenPersona_DoubleClick);
            // 
            // BtnAnyadirPersona
            // 
            this.BtnAnyadirPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAnyadirPersona.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnyadirPersona.Image")));
            this.BtnAnyadirPersona.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnAnyadirPersona.Location = new System.Drawing.Point(926, 403);
            this.BtnAnyadirPersona.Name = "BtnAnyadirPersona";
            this.BtnAnyadirPersona.Size = new System.Drawing.Size(108, 33);
            this.BtnAnyadirPersona.TabIndex = 14;
            this.BtnAnyadirPersona.Text = "Añadir";
            this.BtnAnyadirPersona.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAnyadirPersona.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAnyadirPersona.UseVisualStyleBackColor = true;
            this.BtnAnyadirPersona.Click += new System.EventHandler(this.BtnAnyadirPersona_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTipo.Location = new System.Drawing.Point(30, 26);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(112, 16);
            this.lblTipo.TabIndex = 24;
            this.lblTipo.Text = "*Tipo de persona";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSexo.Location = new System.Drawing.Point(926, 70);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(43, 16);
            this.lblSexo.TabIndex = 27;
            this.lblSexo.Text = "*Sexo";
            // 
            // BtnCancelarPersona
            // 
            this.BtnCancelarPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelarPersona.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelarPersona.Image")));
            this.BtnCancelarPersona.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnCancelarPersona.Location = new System.Drawing.Point(1055, 403);
            this.BtnCancelarPersona.Name = "BtnCancelarPersona";
            this.BtnCancelarPersona.Size = new System.Drawing.Size(102, 33);
            this.BtnCancelarPersona.TabIndex = 15;
            this.BtnCancelarPersona.Text = "Cancelar";
            this.BtnCancelarPersona.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelarPersona.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCancelarPersona.UseVisualStyleBackColor = true;
            this.BtnCancelarPersona.Click += new System.EventHandler(this.BtnCancelarPersona_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.lblTipo);
            this.panel1.Controls.Add(this.BtnCancelarPersona);
            this.panel1.Controls.Add(this.BtnAnyadirPersona);
            this.panel1.Controls.Add(this.CheckBoxAlumno);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.rdbMujer);
            this.panel1.Controls.Add(this.CheckBoxProfesor);
            this.panel1.Controls.Add(this.lblSexo);
            this.panel1.Controls.Add(this.TxtbNIF);
            this.panel1.Controls.Add(this.rdbHombre);
            this.panel1.Controls.Add(this.lblDireccion);
            this.panel1.Controls.Add(this.lblFechaNac);
            this.panel1.Controls.Add(this.lblTelefono);
            this.panel1.Controls.Add(this.DtpFechaNacimiento);
            this.panel1.Controls.Add(this.TxtbDireccion);
            this.panel1.Controls.Add(this.lblNIF);
            this.panel1.Controls.Add(this.TxtbCiudad);
            this.panel1.Controls.Add(this.lblCiudad);
            this.panel1.Controls.Add(this.MaskedTextBoxTelef);
            this.panel1.Controls.Add(this.PictureBoxImagenPersona);
            this.panel1.Controls.Add(this.lblSegundoApell);
            this.panel1.Controls.Add(this.TxtbNombre);
            this.panel1.Controls.Add(this.CmbDepartamento);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.TxtbSegundoApell);
            this.panel1.Controls.Add(this.TxtbPrimerApell);
            this.panel1.Controls.Add(this.lblPrimerApell);
            this.panel1.Controls.Add(this.lblDepartamento);
            this.panel1.Location = new System.Drawing.Point(43, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 445);
            this.panel1.TabIndex = 29;
            // 
            // FormAnyadirPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1262, 496);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAnyadirPersonas";
            this.Text = "Añadir Persona";
            this.Load += new System.EventHandler(this.FormAnyadirPersonas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxImagenPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PictureBoxImagenPersona;
        private System.Windows.Forms.Label lblNIF;
        private System.Windows.Forms.TextBox TxtbNIF;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox TxtbNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.TextBox TxtbCiudad;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.DateTimePicker DtpFechaNacimiento;
        private System.Windows.Forms.RadioButton rdbMujer;
        private System.Windows.Forms.RadioButton rdbHombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox TxtbDireccion;
        private System.Windows.Forms.Label lblSegundoApell;
        private System.Windows.Forms.TextBox TxtbSegundoApell;
        private System.Windows.Forms.Label lblPrimerApell;
        private System.Windows.Forms.TextBox TxtbPrimerApell;
        private System.Windows.Forms.ComboBox CmbDepartamento;
        private System.Windows.Forms.Button BtnAnyadirPersona;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.MaskedTextBox MaskedTextBoxTelef;
        private System.Windows.Forms.CheckBox CheckBoxProfesor;
        private System.Windows.Forms.CheckBox CheckBoxAlumno;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Button BtnCancelarPersona;
        private System.Windows.Forms.Panel panel1;
    }
}