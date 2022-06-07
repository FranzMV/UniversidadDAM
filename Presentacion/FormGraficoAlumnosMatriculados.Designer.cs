
using System;

namespace Presentacion
{
    partial class FormGraficoAlumnosMatriculados
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
            this.groupBoxAsignaturas = new System.Windows.Forms.GroupBox();
            this.lblAsignatura = new System.Windows.Forms.Label();
            this.comboBoxAsignaturas = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartBarras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxAsignaturas.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAsignaturas
            // 
            this.groupBoxAsignaturas.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxAsignaturas.Controls.Add(this.lblAsignatura);
            this.groupBoxAsignaturas.Controls.Add(this.comboBoxAsignaturas);
            this.groupBoxAsignaturas.Location = new System.Drawing.Point(12, 34);
            this.groupBoxAsignaturas.Name = "groupBoxAsignaturas";
            this.groupBoxAsignaturas.Size = new System.Drawing.Size(200, 602);
            this.groupBoxAsignaturas.TabIndex = 1;
            this.groupBoxAsignaturas.TabStop = false;
            this.groupBoxAsignaturas.Text = "Alumnos matriculados últimos 10 años";
            // 
            // lblAsignatura
            // 
            this.lblAsignatura.AutoSize = true;
            this.lblAsignatura.Location = new System.Drawing.Point(7, 280);
            this.lblAsignatura.Name = "lblAsignatura";
            this.lblAsignatura.Size = new System.Drawing.Size(57, 13);
            this.lblAsignatura.TabIndex = 1;
            this.lblAsignatura.Text = "Asignatura";
            // 
            // comboBoxAsignaturas
            // 
            this.comboBoxAsignaturas.FormattingEnabled = true;
            this.comboBoxAsignaturas.Location = new System.Drawing.Point(6, 299);
            this.comboBoxAsignaturas.Name = "comboBoxAsignaturas";
            this.comboBoxAsignaturas.Size = new System.Drawing.Size(188, 21);
            this.comboBoxAsignaturas.TabIndex = 0;
            this.comboBoxAsignaturas.SelectedIndexChanged += new System.EventHandler(this.comboBoxAsignaturas_SelectedIndexChanged);
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
            this.Controls.Add(this.groupBoxAsignaturas);
            this.Name = "Graficas";
            this.Text = "Alumnos matriculados";
            this.Load += new System.EventHandler(this.FormGraficoAlumnosMatriculados_Load);
            this.groupBoxAsignaturas.ResumeLayout(false);
            this.groupBoxAsignaturas.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).EndInit();
            this.ResumeLayout(false);


        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxAsignaturas;
        private System.Windows.Forms.ComboBox comboBoxAsignaturas;
        private System.Windows.Forms.Label lblAsignatura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBarras;
    }
}