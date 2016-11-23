﻿namespace AntColonyOptimization.Vista
{
    partial class Fr_Sudoku
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
            this.lb_semilla = new System.Windows.Forms.Label();
            this.txt_semilla = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_simular = new System.Windows.Forms.Button();
            this.btn_graficas = new System.Windows.Forms.Button();
            this.panel_tablero = new System.Windows.Forms.Panel();
            this.lb_limpiar = new System.Windows.Forms.LinkLabel();
            this.btn_archivo = new System.Windows.Forms.Button();
            this.gbox_resultados = new System.Windows.Forms.GroupBox();
            this.txt_simulacion = new System.Windows.Forms.TextBox();
            this.lb_simulacion = new System.Windows.Forms.Label();
            this.txt_solucion = new System.Windows.Forms.TextBox();
            this.lb_solucion = new System.Windows.Forms.Label();
            this.txt_iteracion = new System.Windows.Forms.TextBox();
            this.lb_iteración = new System.Windows.Forms.Label();
            this.lb_casillas = new System.Windows.Forms.Label();
            this.ls_casillas = new System.Windows.Forms.ListBox();
            this.txt_tiempo = new System.Windows.Forms.TextBox();
            this.lb_tiempo = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbox_resultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_semilla
            // 
            this.lb_semilla.AutoSize = true;
            this.lb_semilla.Location = new System.Drawing.Point(5, 38);
            this.lb_semilla.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_semilla.Name = "lb_semilla";
            this.lb_semilla.Size = new System.Drawing.Size(56, 17);
            this.lb_semilla.TabIndex = 3;
            this.lb_semilla.Text = "Semilla";
            // 
            // txt_semilla
            // 
            this.txt_semilla.Location = new System.Drawing.Point(67, 38);
            this.txt_semilla.Margin = new System.Windows.Forms.Padding(4);
            this.txt_semilla.Name = "txt_semilla";
            this.txt_semilla.Size = new System.Drawing.Size(33, 25);
            this.txt_semilla.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_semilla);
            this.groupBox1.Controls.Add(this.lb_semilla);
            this.groupBox1.Location = new System.Drawing.Point(32, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(201, 79);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Semilla unitaria";
            // 
            // btn_simular
            // 
            this.btn_simular.Location = new System.Drawing.Point(647, 552);
            this.btn_simular.Margin = new System.Windows.Forms.Padding(4);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(99, 43);
            this.btn_simular.TabIndex = 7;
            this.btn_simular.Text = "Simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.btn_simular_Click);
            // 
            // btn_graficas
            // 
            this.btn_graficas.Location = new System.Drawing.Point(524, 552);
            this.btn_graficas.Margin = new System.Windows.Forms.Padding(4);
            this.btn_graficas.Name = "btn_graficas";
            this.btn_graficas.Size = new System.Drawing.Size(91, 43);
            this.btn_graficas.TabIndex = 8;
            this.btn_graficas.Text = "Gráficas";
            this.btn_graficas.UseVisualStyleBackColor = true;
            this.btn_graficas.Click += new System.EventHandler(this.btn_graficas_Click);
            // 
            // panel_tablero
            // 
            this.panel_tablero.Font = new System.Drawing.Font("HelvLight", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_tablero.Location = new System.Drawing.Point(246, 21);
            this.panel_tablero.Margin = new System.Windows.Forms.Padding(4);
            this.panel_tablero.Name = "panel_tablero";
            this.panel_tablero.Size = new System.Drawing.Size(500, 499);
            this.panel_tablero.TabIndex = 9;
            // 
            // lb_limpiar
            // 
            this.lb_limpiar.AutoSize = true;
            this.lb_limpiar.Location = new System.Drawing.Point(683, 525);
            this.lb_limpiar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_limpiar.Name = "lb_limpiar";
            this.lb_limpiar.Size = new System.Drawing.Size(56, 17);
            this.lb_limpiar.TabIndex = 10;
            this.lb_limpiar.TabStop = true;
            this.lb_limpiar.Text = "Limpiar";
            this.lb_limpiar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_limpiar_LinkClicked);
            // 
            // btn_archivo
            // 
            this.btn_archivo.Location = new System.Drawing.Point(359, 552);
            this.btn_archivo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_archivo.Name = "btn_archivo";
            this.btn_archivo.Size = new System.Drawing.Size(141, 43);
            this.btn_archivo.TabIndex = 11;
            this.btn_archivo.Text = "Cargar archivo";
            this.btn_archivo.UseVisualStyleBackColor = true;
            this.btn_archivo.Click += new System.EventHandler(this.btn_archivo_Click);
            // 
            // gbox_resultados
            // 
            this.gbox_resultados.Controls.Add(this.txt_simulacion);
            this.gbox_resultados.Controls.Add(this.lb_simulacion);
            this.gbox_resultados.Controls.Add(this.txt_solucion);
            this.gbox_resultados.Controls.Add(this.lb_solucion);
            this.gbox_resultados.Controls.Add(this.txt_iteracion);
            this.gbox_resultados.Controls.Add(this.lb_iteración);
            this.gbox_resultados.Controls.Add(this.lb_casillas);
            this.gbox_resultados.Controls.Add(this.ls_casillas);
            this.gbox_resultados.Controls.Add(this.txt_tiempo);
            this.gbox_resultados.Controls.Add(this.lb_tiempo);
            this.gbox_resultados.Location = new System.Drawing.Point(32, 110);
            this.gbox_resultados.Margin = new System.Windows.Forms.Padding(4);
            this.gbox_resultados.Name = "gbox_resultados";
            this.gbox_resultados.Padding = new System.Windows.Forms.Padding(4);
            this.gbox_resultados.Size = new System.Drawing.Size(201, 476);
            this.gbox_resultados.TabIndex = 6;
            this.gbox_resultados.TabStop = false;
            this.gbox_resultados.Text = "Resultados";
            // 
            // txt_simulacion
            // 
            this.txt_simulacion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_simulacion.Location = new System.Drawing.Point(101, 71);
            this.txt_simulacion.Name = "txt_simulacion";
            this.txt_simulacion.ReadOnly = true;
            this.txt_simulacion.Size = new System.Drawing.Size(81, 25);
            this.txt_simulacion.TabIndex = 9;
            // 
            // lb_simulacion
            // 
            this.lb_simulacion.AutoSize = true;
            this.lb_simulacion.Location = new System.Drawing.Point(15, 74);
            this.lb_simulacion.Name = "lb_simulacion";
            this.lb_simulacion.Size = new System.Drawing.Size(80, 17);
            this.lb_simulacion.TabIndex = 8;
            this.lb_simulacion.Text = "Simulación";
            // 
            // txt_solucion
            // 
            this.txt_solucion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_solucion.Location = new System.Drawing.Point(101, 109);
            this.txt_solucion.Name = "txt_solucion";
            this.txt_solucion.ReadOnly = true;
            this.txt_solucion.Size = new System.Drawing.Size(81, 25);
            this.txt_solucion.TabIndex = 7;
            // 
            // lb_solucion
            // 
            this.lb_solucion.AutoSize = true;
            this.lb_solucion.Location = new System.Drawing.Point(15, 112);
            this.lb_solucion.Name = "lb_solucion";
            this.lb_solucion.Size = new System.Drawing.Size(64, 17);
            this.lb_solucion.TabIndex = 6;
            this.lb_solucion.Text = "Solución";
            // 
            // txt_iteracion
            // 
            this.txt_iteracion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_iteracion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_iteracion.Location = new System.Drawing.Point(101, 36);
            this.txt_iteracion.Name = "txt_iteracion";
            this.txt_iteracion.ReadOnly = true;
            this.txt_iteracion.Size = new System.Drawing.Size(81, 25);
            this.txt_iteracion.TabIndex = 5;
            // 
            // lb_iteración
            // 
            this.lb_iteración.AutoSize = true;
            this.lb_iteración.Location = new System.Drawing.Point(15, 39);
            this.lb_iteración.Name = "lb_iteración";
            this.lb_iteración.Size = new System.Drawing.Size(63, 17);
            this.lb_iteración.TabIndex = 4;
            this.lb_iteración.Text = "Iteración";
            // 
            // lb_casillas
            // 
            this.lb_casillas.AutoSize = true;
            this.lb_casillas.Location = new System.Drawing.Point(15, 184);
            this.lb_casillas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_casillas.Name = "lb_casillas";
            this.lb_casillas.Size = new System.Drawing.Size(159, 17);
            this.lb_casillas.TabIndex = 3;
            this.lb_casillas.Text = "Casillas (Fila,Col,Valor)";
            this.lb_casillas.Click += new System.EventHandler(this.lb_casillas_Click);
            // 
            // ls_casillas
            // 
            this.ls_casillas.FormattingEnabled = true;
            this.ls_casillas.ItemHeight = 17;
            this.ls_casillas.Location = new System.Drawing.Point(16, 205);
            this.ls_casillas.Margin = new System.Windows.Forms.Padding(4);
            this.ls_casillas.Name = "ls_casillas";
            this.ls_casillas.Size = new System.Drawing.Size(166, 259);
            this.ls_casillas.TabIndex = 2;
            // 
            // txt_tiempo
            // 
            this.txt_tiempo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_tiempo.Location = new System.Drawing.Point(101, 144);
            this.txt_tiempo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tiempo.Name = "txt_tiempo";
            this.txt_tiempo.ReadOnly = true;
            this.txt_tiempo.Size = new System.Drawing.Size(81, 25);
            this.txt_tiempo.TabIndex = 1;
            // 
            // lb_tiempo
            // 
            this.lb_tiempo.AutoSize = true;
            this.lb_tiempo.Location = new System.Drawing.Point(13, 147);
            this.lb_tiempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tiempo.Name = "lb_tiempo";
            this.lb_tiempo.Size = new System.Drawing.Size(56, 17);
            this.lb_tiempo.TabIndex = 0;
            this.lb_tiempo.Text = "Tiempo";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(241, 552);
            this.btn_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(92, 43);
            this.btn_guardar.TabIndex = 12;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.guardar_archivo);
            // 
            // Fr_Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 608);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_archivo);
            this.Controls.Add(this.lb_limpiar);
            this.Controls.Add(this.panel_tablero);
            this.Controls.Add(this.btn_graficas);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.gbox_resultados);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Fr_Sudoku";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.Sudoku_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbox_resultados.ResumeLayout(false);
            this.gbox_resultados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_semilla;
        private System.Windows.Forms.TextBox txt_semilla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_simular;
        private System.Windows.Forms.Button btn_graficas;
        private System.Windows.Forms.Panel panel_tablero;
        private System.Windows.Forms.LinkLabel lb_limpiar;
        private System.Windows.Forms.Button btn_archivo;
        private System.Windows.Forms.GroupBox gbox_resultados;
        private System.Windows.Forms.Label lb_casillas;
        private System.Windows.Forms.ListBox ls_casillas;
        private System.Windows.Forms.TextBox txt_tiempo;
        private System.Windows.Forms.Label lb_tiempo;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.TextBox txt_simulacion;
        private System.Windows.Forms.Label lb_simulacion;
        private System.Windows.Forms.TextBox txt_solucion;
        private System.Windows.Forms.Label lb_solucion;
        private System.Windows.Forms.TextBox txt_iteracion;
        private System.Windows.Forms.Label lb_iteración;
    }
}