
using System;

namespace Presentacion
{
    partial class FormGraficoTotalAlumnosPorGrado
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
            this.groupBoxCursos = new System.Windows.Forms.GroupBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.comboBoxCursos = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartBarras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxCursos.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCursos
            // 
            this.groupBoxCursos.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxCursos.Controls.Add(this.lblCurso);
            this.groupBoxCursos.Controls.Add(this.comboBoxCursos);
            this.groupBoxCursos.Location = new System.Drawing.Point(12, 34);
            this.groupBoxCursos.Name = "groupBoxCursos";
            this.groupBoxCursos.Size = new System.Drawing.Size(200, 602);
            this.groupBoxCursos.TabIndex = 1;
            this.groupBoxCursos.TabStop = false;
            this.groupBoxCursos.Text = "Alumnos por grado";
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Location = new System.Drawing.Point(7, 280);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(57, 13);
            this.lblCurso.TabIndex = 1;
            this.lblCurso.Text = "Curso";
            // 
            // comboBoxCursos
            // 
            this.comboBoxCursos.FormattingEnabled = true;
            this.comboBoxCursos.Location = new System.Drawing.Point(6, 299);
            this.comboBoxCursos.Name = "comboBoxCursos";
            this.comboBoxCursos.Size = new System.Drawing.Size(188, 21);
            this.comboBoxCursos.TabIndex = 0;
            this.comboBoxCursos.SelectedIndexChanged += new System.EventHandler(this.comboBoxCursos_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chartBarras);
            this.panel1.Location = new System.Drawing.Point(218, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 602);
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
            this.chartBarras.Size = new System.Drawing.Size(794, 596);
            this.chartBarras.TabIndex = 0;
            this.chartBarras.Text = "chart1";
            // 
            // AlumnosPorGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 675);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxCursos);
            this.Name = "AlumnosPorGrado";
            this.Text = "Total de alumnos por grado";
            this.Load += new System.EventHandler(this.FormGraficoTotalAlumnosPorGrado_Load);
            this.groupBoxCursos.ResumeLayout(false);
            this.groupBoxCursos.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).EndInit();
            this.ResumeLayout(false);


        }


        #endregion
        private System.Windows.Forms.GroupBox groupBoxCursos;
        private System.Windows.Forms.ComboBox comboBoxCursos;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBarras;
    }
}