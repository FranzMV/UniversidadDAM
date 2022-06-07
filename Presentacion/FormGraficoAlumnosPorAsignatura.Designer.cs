
namespace Presentacion
{
    partial class FormGraficoAlumnosPorAsignatura
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBoxCursosEscolares = new System.Windows.Forms.GroupBox();
            this.lblCursoEscolar = new System.Windows.Forms.Label();
            this.comboBoxCursoEscolar = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartBarras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxCursosEscolares.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCursosEscolares
            // 
            this.groupBoxCursosEscolares.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxCursosEscolares.Controls.Add(this.lblCursoEscolar);
            this.groupBoxCursosEscolares.Controls.Add(this.comboBoxCursoEscolar);
            this.groupBoxCursosEscolares.Location = new System.Drawing.Point(12, 34);
            this.groupBoxCursosEscolares.Name = "groupBoxCursosEscolares";
            this.groupBoxCursosEscolares.Size = new System.Drawing.Size(200, 602);
            this.groupBoxCursosEscolares.TabIndex = 1;
            this.groupBoxCursosEscolares.TabStop = false;
            this.groupBoxCursosEscolares.Text = "Alumnos por asignatura";
            // 
            // lblCursoEscolar
            // 
            this.lblCursoEscolar.AutoSize = true;
            this.lblCursoEscolar.Location = new System.Drawing.Point(7, 280);
            this.lblCursoEscolar.Name = "lblCursoEscolar";
            this.lblCursoEscolar.Size = new System.Drawing.Size(71, 13);
            this.lblCursoEscolar.TabIndex = 1;
            this.lblCursoEscolar.Text = "Curso escolar";
            // 
            // comboBoxCursoEscolar
            // 
            this.comboBoxCursoEscolar.FormattingEnabled = true;
            this.comboBoxCursoEscolar.Location = new System.Drawing.Point(6, 299);
            this.comboBoxCursoEscolar.Name = "comboBoxCursoEscolar";
            this.comboBoxCursoEscolar.Size = new System.Drawing.Size(188, 21);
            this.comboBoxCursoEscolar.TabIndex = 0;
            this.comboBoxCursoEscolar.SelectedIndexChanged += new System.EventHandler(this.comboBoxCursoEscolar_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chartBarras);
            this.panel1.Location = new System.Drawing.Point(218, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 602);
            this.panel1.TabIndex = 2;
            // 
            // chartBarras
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBarras.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBarras.Legends.Add(legend1);
            this.chartBarras.Location = new System.Drawing.Point(3, 3);
            this.chartBarras.Name = "chartBarras";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBarras.Series.Add(series1);
            this.chartBarras.Size = new System.Drawing.Size(814, 596);
            this.chartBarras.TabIndex = 0;
            this.chartBarras.Text = "chart1";
            // 
            // Graficas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 675);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxCursosEscolares);
            this.Name = "Graficas";
            this.Text = "Alumnos por asignatura";
            this.Load += new System.EventHandler(this.FormGraficoAlumnosPorAsignatura_Load);
            this.groupBoxCursosEscolares.ResumeLayout(false);
            this.groupBoxCursosEscolares.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxCursosEscolares;
        private System.Windows.Forms.ComboBox comboBoxCursoEscolar;
        private System.Windows.Forms.Label lblCursoEscolar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBarras;
    }
}