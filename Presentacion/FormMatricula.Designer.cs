
namespace Presentacion
{
    partial class FormMatricula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMatricula));
            this.panelPricipal = new System.Windows.Forms.Panel();
            this.lblGradoSeleccionado = new System.Windows.Forms.Label();
            this.groupBoxInfoAlumno = new System.Windows.Forms.GroupBox();
            this.lblNIF = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.TxtbNombre = new System.Windows.Forms.TextBox();
            this.BtnSelecionarAlumno = new System.Windows.Forms.Button();
            this.TxtbPrimerApell = new System.Windows.Forms.TextBox();
            this.lblPrimerApell = new System.Windows.Forms.Label();
            this.TxtbNIF = new System.Windows.Forms.TextBox();
            this.lblResultadoAsignaturas = new System.Windows.Forms.Label();
            this.groupBoxGrados = new System.Windows.Forms.GroupBox();
            this.DGVGrados = new System.Windows.Forms.DataGridView();
            this.BtnCancelarMatricula = new System.Windows.Forms.Button();
            this.BtnCrearMatricula = new System.Windows.Forms.Button();
            this.groupBoxAsigSeleccionadas = new System.Windows.Forms.GroupBox();
            this.DGVResultadoMatricula = new System.Windows.Forms.DataGridView();
            this.groupBoxAsignaturas = new System.Windows.Forms.GroupBox();
            this.DGVAsignaturas = new System.Windows.Forms.DataGridView();
            this.panelPricipal.SuspendLayout();
            this.groupBoxInfoAlumno.SuspendLayout();
            this.groupBoxGrados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGrados)).BeginInit();
            this.groupBoxAsigSeleccionadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVResultadoMatricula)).BeginInit();
            this.groupBoxAsignaturas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAsignaturas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPricipal
            // 
            this.panelPricipal.BackColor = System.Drawing.Color.White;
            this.panelPricipal.Controls.Add(this.lblGradoSeleccionado);
            this.panelPricipal.Controls.Add(this.groupBoxInfoAlumno);
            this.panelPricipal.Controls.Add(this.lblResultadoAsignaturas);
            this.panelPricipal.Controls.Add(this.groupBoxGrados);
            this.panelPricipal.Controls.Add(this.BtnCancelarMatricula);
            this.panelPricipal.Controls.Add(this.BtnCrearMatricula);
            this.panelPricipal.Controls.Add(this.groupBoxAsigSeleccionadas);
            this.panelPricipal.Controls.Add(this.groupBoxAsignaturas);
            this.panelPricipal.Location = new System.Drawing.Point(157, 24);
            this.panelPricipal.Name = "panelPricipal";
            this.panelPricipal.Size = new System.Drawing.Size(950, 741);
            this.panelPricipal.TabIndex = 0;
            // 
            // lblGradoSeleccionado
            // 
            this.lblGradoSeleccionado.AutoSize = true;
            this.lblGradoSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGradoSeleccionado.Location = new System.Drawing.Point(39, 435);
            this.lblGradoSeleccionado.Name = "lblGradoSeleccionado";
            this.lblGradoSeleccionado.Size = new System.Drawing.Size(133, 16);
            this.lblGradoSeleccionado.TabIndex = 26;
            this.lblGradoSeleccionado.Text = "Grado seleccionado:";
            // 
            // groupBoxInfoAlumno
            // 
            this.groupBoxInfoAlumno.Controls.Add(this.lblNIF);
            this.groupBoxInfoAlumno.Controls.Add(this.lblNombre);
            this.groupBoxInfoAlumno.Controls.Add(this.TxtbNombre);
            this.groupBoxInfoAlumno.Controls.Add(this.BtnSelecionarAlumno);
            this.groupBoxInfoAlumno.Controls.Add(this.TxtbPrimerApell);
            this.groupBoxInfoAlumno.Controls.Add(this.lblPrimerApell);
            this.groupBoxInfoAlumno.Controls.Add(this.TxtbNIF);
            this.groupBoxInfoAlumno.Location = new System.Drawing.Point(20, 15);
            this.groupBoxInfoAlumno.Name = "groupBoxInfoAlumno";
            this.groupBoxInfoAlumno.Size = new System.Drawing.Size(910, 145);
            this.groupBoxInfoAlumno.TabIndex = 17;
            this.groupBoxInfoAlumno.TabStop = false;
            this.groupBoxInfoAlumno.Text = "Datos alumno";
            // 
            // lblNIF
            // 
            this.lblNIF.AutoSize = true;
            this.lblNIF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNIF.Location = new System.Drawing.Point(15, 25);
            this.lblNIF.Name = "lblNIF";
            this.lblNIF.Size = new System.Drawing.Size(28, 16);
            this.lblNIF.TabIndex = 16;
            this.lblNIF.Text = "NIF";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(348, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombre";
            // 
            // TxtbNombre
            // 
            this.TxtbNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtbNombre.Location = new System.Drawing.Point(348, 44);
            this.TxtbNombre.Name = "TxtbNombre";
            this.TxtbNombre.ReadOnly = true;
            this.TxtbNombre.Size = new System.Drawing.Size(232, 25);
            this.TxtbNombre.TabIndex = 11;
            // 
            // BtnSelecionarAlumno
            // 
            this.BtnSelecionarAlumno.Location = new System.Drawing.Point(776, 116);
            this.BtnSelecionarAlumno.Name = "BtnSelecionarAlumno";
            this.BtnSelecionarAlumno.Size = new System.Drawing.Size(118, 23);
            this.BtnSelecionarAlumno.TabIndex = 17;
            this.BtnSelecionarAlumno.Text = "Buscar Alumno";
            this.BtnSelecionarAlumno.UseVisualStyleBackColor = true;
            this.BtnSelecionarAlumno.Click += new System.EventHandler(this.BtnSelecionarAlumno_Click);
            // 
            // TxtbPrimerApell
            // 
            this.TxtbPrimerApell.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtbPrimerApell.Location = new System.Drawing.Point(673, 44);
            this.TxtbPrimerApell.Name = "TxtbPrimerApell";
            this.TxtbPrimerApell.ReadOnly = true;
            this.TxtbPrimerApell.Size = new System.Drawing.Size(221, 25);
            this.TxtbPrimerApell.TabIndex = 13;
            // 
            // lblPrimerApell
            // 
            this.lblPrimerApell.AutoSize = true;
            this.lblPrimerApell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrimerApell.Location = new System.Drawing.Point(673, 25);
            this.lblPrimerApell.Name = "lblPrimerApell";
            this.lblPrimerApell.Size = new System.Drawing.Size(79, 16);
            this.lblPrimerApell.TabIndex = 12;
            this.lblPrimerApell.Text = "1er Apellido";
            // 
            // TxtbNIF
            // 
            this.TxtbNIF.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtbNIF.Location = new System.Drawing.Point(15, 45);
            this.TxtbNIF.Name = "TxtbNIF";
            this.TxtbNIF.ReadOnly = true;
            this.TxtbNIF.Size = new System.Drawing.Size(232, 25);
            this.TxtbNIF.TabIndex = 10;
            // 
            // lblResultadoAsignaturas
            // 
            this.lblResultadoAsignaturas.AutoSize = true;
            this.lblResultadoAsignaturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResultadoAsignaturas.ForeColor = System.Drawing.Color.Red;
            this.lblResultadoAsignaturas.Location = new System.Drawing.Point(495, 435);
            this.lblResultadoAsignaturas.Name = "lblResultadoAsignaturas";
            this.lblResultadoAsignaturas.Size = new System.Drawing.Size(288, 16);
            this.lblResultadoAsignaturas.TabIndex = 25;
            this.lblResultadoAsignaturas.Text = "El grado seleccionado no contiene asignaturas";
            // 
            // groupBoxGrados
            // 
            this.groupBoxGrados.Controls.Add(this.DGVGrados);
            this.groupBoxGrados.Location = new System.Drawing.Point(20, 177);
            this.groupBoxGrados.Name = "groupBoxGrados";
            this.groupBoxGrados.Size = new System.Drawing.Size(439, 246);
            this.groupBoxGrados.TabIndex = 20;
            this.groupBoxGrados.TabStop = false;
            this.groupBoxGrados.Text = "Seleccionar grado";
            // 
            // DGVGrados
            // 
            this.DGVGrados.AllowUserToAddRows = false;
            this.DGVGrados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVGrados.Location = new System.Drawing.Point(19, 22);
            this.DGVGrados.Name = "DGVGrados";
            this.DGVGrados.RowTemplate.Height = 25;
            this.DGVGrados.Size = new System.Drawing.Size(402, 201);
            this.DGVGrados.TabIndex = 18;
            this.DGVGrados.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVGrados_CellContentDoubleClick);
            // 
            // BtnCancelarMatricula
            // 
            this.BtnCancelarMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelarMatricula.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelarMatricula.Image")));
            this.BtnCancelarMatricula.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnCancelarMatricula.Location = new System.Drawing.Point(829, 696);
            this.BtnCancelarMatricula.Name = "BtnCancelarMatricula";
            this.BtnCancelarMatricula.Size = new System.Drawing.Size(102, 33);
            this.BtnCancelarMatricula.TabIndex = 24;
            this.BtnCancelarMatricula.Text = "Cancelar";
            this.BtnCancelarMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelarMatricula.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCancelarMatricula.UseVisualStyleBackColor = true;
            this.BtnCancelarMatricula.Click += new System.EventHandler(this.BtnCancelarMatricula_Click);
            // 
            // BtnCrearMatricula
            // 
            this.BtnCrearMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCrearMatricula.Image = ((System.Drawing.Image)(resources.GetObject("BtnCrearMatricula.Image")));
            this.BtnCrearMatricula.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnCrearMatricula.Location = new System.Drawing.Point(704, 696);
            this.BtnCrearMatricula.Name = "BtnCrearMatricula";
            this.BtnCrearMatricula.Size = new System.Drawing.Size(108, 33);
            this.BtnCrearMatricula.TabIndex = 23;
            this.BtnCrearMatricula.Text = "Crear";
            this.BtnCrearMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCrearMatricula.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCrearMatricula.UseVisualStyleBackColor = true;
            this.BtnCrearMatricula.Click += new System.EventHandler(this.BtnCrearMatricula_Click);
            // 
            // groupBoxAsigSeleccionadas
            // 
            this.groupBoxAsigSeleccionadas.Controls.Add(this.DGVResultadoMatricula);
            this.groupBoxAsigSeleccionadas.Location = new System.Drawing.Point(22, 469);
            this.groupBoxAsigSeleccionadas.Name = "groupBoxAsigSeleccionadas";
            this.groupBoxAsigSeleccionadas.Size = new System.Drawing.Size(910, 206);
            this.groupBoxAsigSeleccionadas.TabIndex = 22;
            this.groupBoxAsigSeleccionadas.TabStop = false;
            this.groupBoxAsigSeleccionadas.Text = "Asignaturas a matricular";
            // 
            // DGVResultadoMatricula
            // 
            this.DGVResultadoMatricula.AllowUserToAddRows = false;
            this.DGVResultadoMatricula.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVResultadoMatricula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVResultadoMatricula.Location = new System.Drawing.Point(19, 22);
            this.DGVResultadoMatricula.Name = "DGVResultadoMatricula";
            this.DGVResultadoMatricula.RowTemplate.Height = 25;
            this.DGVResultadoMatricula.Size = new System.Drawing.Size(873, 168);
            this.DGVResultadoMatricula.TabIndex = 0;
            this.DGVResultadoMatricula.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVResultadoMatricula_CellContentDoubleClick);
            // 
            // groupBoxAsignaturas
            // 
            this.groupBoxAsignaturas.Controls.Add(this.DGVAsignaturas);
            this.groupBoxAsignaturas.Location = new System.Drawing.Point(475, 177);
            this.groupBoxAsignaturas.Name = "groupBoxAsignaturas";
            this.groupBoxAsignaturas.Size = new System.Drawing.Size(457, 246);
            this.groupBoxAsignaturas.TabIndex = 21;
            this.groupBoxAsignaturas.TabStop = false;
            this.groupBoxAsignaturas.Text = "Seleccionar asignaturas";
            // 
            // DGVAsignaturas
            // 
            this.DGVAsignaturas.AllowUserToAddRows = false;
            this.DGVAsignaturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.DGVAsignaturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAsignaturas.Location = new System.Drawing.Point(20, 22);
            this.DGVAsignaturas.Name = "DGVAsignaturas";
            this.DGVAsignaturas.RowTemplate.Height = 25;
            this.DGVAsignaturas.Size = new System.Drawing.Size(419, 207);
            this.DGVAsignaturas.TabIndex = 19;
            this.DGVAsignaturas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAsignaturas_CellContentDoubleClick);
            // 
            // FormMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 801);
            this.ControlBox = false;
            this.Controls.Add(this.panelPricipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMatricula";
            this.Text = "Crear Matrícula";
            this.Load += new System.EventHandler(this.FormMatricula_Load);
            this.panelPricipal.ResumeLayout(false);
            this.panelPricipal.PerformLayout();
            this.groupBoxInfoAlumno.ResumeLayout(false);
            this.groupBoxInfoAlumno.PerformLayout();
            this.groupBoxGrados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVGrados)).EndInit();
            this.groupBoxAsigSeleccionadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVResultadoMatricula)).EndInit();
            this.groupBoxAsignaturas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAsignaturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPricipal;
        private System.Windows.Forms.DataGridView DGVGrados;
        private System.Windows.Forms.GroupBox groupBoxInfoAlumno;
        private System.Windows.Forms.DataGridView DGVAsignaturas;
        private System.Windows.Forms.GroupBox groupBoxGrados;
        private System.Windows.Forms.GroupBox groupBoxAsigSeleccionadas;
        private System.Windows.Forms.DataGridView DGVResultadoMatricula;
        private System.Windows.Forms.GroupBox groupBoxAsignaturas;
        private System.Windows.Forms.Button BtnCancelarMatricula;
        private System.Windows.Forms.Button BtnCrearMatricula;
        private System.Windows.Forms.TextBox TxtbNIF;
        private System.Windows.Forms.Label lblPrimerApell;
        private System.Windows.Forms.Label lblNIF;
        private System.Windows.Forms.TextBox TxtbPrimerApell;
        private System.Windows.Forms.TextBox TxtbNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button BtnSelecionarAlumno;
        private System.Windows.Forms.Label lblResultadoAsignaturas;
        private System.Windows.Forms.Label lblGradoSeleccionado;
    }
}