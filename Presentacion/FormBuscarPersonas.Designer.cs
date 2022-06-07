
namespace Presentacion
{
    partial class FormBuscarPersonas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuscarPersonas));
            this.DGVPersonas = new System.Windows.Forms.DataGridView();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.BtnCancelarBusqueda = new System.Windows.Forms.Button();
            this.panelBarraBusqueda = new System.Windows.Forms.Panel();
            this.TxtBoxBuscar = new System.Windows.Forms.TextBox();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.CheckBoxNIF = new System.Windows.Forms.CheckBox();
            this.CheckBoxNomApell = new System.Windows.Forms.CheckBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPersonas)).BeginInit();
            this.panelPrincipal.SuspendLayout();
            this.panelBarraBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVPersonas
            // 
            this.DGVPersonas.AllowUserToAddRows = false;
            this.DGVPersonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVPersonas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DGVPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPersonas.Location = new System.Drawing.Point(47, 110);
            this.DGVPersonas.Name = "DGVPersonas";
            this.DGVPersonas.RowTemplate.Height = 25;
            this.DGVPersonas.Size = new System.Drawing.Size(1082, 315);
            this.DGVPersonas.TabIndex = 0;
            this.DGVPersonas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPersonas_CellContentDoubleClick);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.lblInfo);
            this.panelPrincipal.Controls.Add(this.BtnCancelarBusqueda);
            this.panelPrincipal.Controls.Add(this.panelBarraBusqueda);
            this.panelPrincipal.Controls.Add(this.CheckBoxNIF);
            this.panelPrincipal.Controls.Add(this.CheckBoxNomApell);
            this.panelPrincipal.Controls.Add(this.lblFiltrar);
            this.panelPrincipal.Controls.Add(this.DGVPersonas);
            this.panelPrincipal.Location = new System.Drawing.Point(40, 30);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1182, 497);
            this.panelPrincipal.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblInfo.Location = new System.Drawing.Point(47, 458);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(349, 16);
            this.lblInfo.TabIndex = 24;
            this.lblInfo.Text = "*Los campos marcados con un asterisco son obligatorios";
            // 
            // BtnCancelarBusqueda
            // 
            this.BtnCancelarBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelarBusqueda.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelarBusqueda.Image")));
            this.BtnCancelarBusqueda.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnCancelarBusqueda.Location = new System.Drawing.Point(1027, 449);
            this.BtnCancelarBusqueda.Name = "BtnCancelarBusqueda";
            this.BtnCancelarBusqueda.Size = new System.Drawing.Size(102, 33);
            this.BtnCancelarBusqueda.TabIndex = 16;
            this.BtnCancelarBusqueda.Text = "Cancelar";
            this.BtnCancelarBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelarBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCancelarBusqueda.UseVisualStyleBackColor = true;
            this.BtnCancelarBusqueda.Click += new System.EventHandler(this.BtnCancelarBusqueda_Click);
            // 
            // panelBarraBusqueda
            // 
            this.panelBarraBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBarraBusqueda.Controls.Add(this.TxtBoxBuscar);
            this.panelBarraBusqueda.Controls.Add(this.pictureBoxSearch);
            this.panelBarraBusqueda.Location = new System.Drawing.Point(47, 72);
            this.panelBarraBusqueda.Name = "panelBarraBusqueda";
            this.panelBarraBusqueda.Size = new System.Drawing.Size(333, 28);
            this.panelBarraBusqueda.TabIndex = 6;
            // 
            // TxtBoxBuscar
            // 
            this.TxtBoxBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBoxBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtBoxBuscar.Location = new System.Drawing.Point(32, 5);
            this.TxtBoxBuscar.Name = "TxtBoxBuscar";
            this.TxtBoxBuscar.Size = new System.Drawing.Size(296, 18);
            this.TxtBoxBuscar.TabIndex = 3;
            this.TxtBoxBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBoxBuscar_KeyDown);
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.ErrorImage = global::Presentacion.Properties.Resources.search;
            this.pictureBoxSearch.Image = global::Presentacion.Properties.Resources.search;
            this.pictureBoxSearch.Location = new System.Drawing.Point(-1, -1);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(30, 32);
            this.pictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSearch.TabIndex = 3;
            this.pictureBoxSearch.TabStop = false;
            // 
            // CheckBoxNIF
            // 
            this.CheckBoxNIF.AutoSize = true;
            this.CheckBoxNIF.Location = new System.Drawing.Point(336, 35);
            this.CheckBoxNIF.Name = "CheckBoxNIF";
            this.CheckBoxNIF.Size = new System.Drawing.Size(44, 19);
            this.CheckBoxNIF.TabIndex = 2;
            this.CheckBoxNIF.Text = "NIF";
            this.CheckBoxNIF.UseVisualStyleBackColor = true;
            this.CheckBoxNIF.CheckedChanged += new System.EventHandler(this.CheckBoxNIF_CheckedChanged);
            // 
            // CheckBoxNomApell
            // 
            this.CheckBoxNomApell.AutoSize = true;
            this.CheckBoxNomApell.Location = new System.Drawing.Point(150, 35);
            this.CheckBoxNomApell.Name = "CheckBoxNomApell";
            this.CheckBoxNomApell.Size = new System.Drawing.Size(129, 19);
            this.CheckBoxNomApell.TabIndex = 1;
            this.CheckBoxNomApell.Text = "Nombre y apellidos";
            this.CheckBoxNomApell.UseVisualStyleBackColor = true;
            this.CheckBoxNomApell.CheckedChanged += new System.EventHandler(this.CheckBoxNomApell_CheckedChanged);
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFiltrar.Location = new System.Drawing.Point(47, 35);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(68, 16);
            this.lblFiltrar.TabIndex = 2;
            this.lblFiltrar.Text = "*Filtrar por";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormBuscarPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 561);
            this.Controls.Add(this.panelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormBuscarPersonas";
            this.Text = "Buscardor de personas";
            this.Load += new System.EventHandler(this.FormBuscarPersonas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPersonas)).EndInit();
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.panelBarraBusqueda.ResumeLayout(false);
            this.panelBarraBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVPersonas;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.TextBox TxtBoxBuscar;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.CheckBox CheckBoxNomApell;
        private System.Windows.Forms.CheckBox CheckBoxNIF;
        private System.Windows.Forms.Panel panelBarraBusqueda;
        private System.Windows.Forms.Button BtnCancelarBusqueda;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}