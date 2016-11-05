namespace AntColonyOptimization.Vista
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
            this.lb_tamanio_tablero = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_cambiar = new System.Windows.Forms.Button();
            this.lb_semilla = new System.Windows.Forms.Label();
            this.txt_semilla = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbox_unitario = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbox_conjunto = new System.Windows.Forms.CheckBox();
            this.lb_resultado = new System.Windows.Forms.Label();
            this.ls_resultados = new System.Windows.Forms.ListBox();
            this.lb_paso = new System.Windows.Forms.Label();
            this.lb_inicio = new System.Windows.Forms.Label();
            this.txt_paso = new System.Windows.Forms.TextBox();
            this.txt_inicio = new System.Windows.Forms.TextBox();
            this.txt_cant_semillas = new System.Windows.Forms.TextBox();
            this.lb_cant_semillas = new System.Windows.Forms.Label();
            this.btn_simular = new System.Windows.Forms.Button();
            this.btn_graficas = new System.Windows.Forms.Button();
            this.panel_tablero = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_tamanio_tablero
            // 
            this.lb_tamanio_tablero.AutoSize = true;
            this.lb_tamanio_tablero.Location = new System.Drawing.Point(37, 34);
            this.lb_tamanio_tablero.Name = "lb_tamanio_tablero";
            this.lb_tamanio_tablero.Size = new System.Drawing.Size(131, 17);
            this.lb_tamanio_tablero.TabIndex = 0;
            this.lb_tamanio_tablero.Text = "Tamaño del tablero";
            this.lb_tamanio_tablero.Click += new System.EventHandler(this.lb_tamanio_tablero_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(174, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "3";
            // 
            // btn_cambiar
            // 
            this.btn_cambiar.Location = new System.Drawing.Point(223, 33);
            this.btn_cambiar.Name = "btn_cambiar";
            this.btn_cambiar.Size = new System.Drawing.Size(75, 23);
            this.btn_cambiar.TabIndex = 2;
            this.btn_cambiar.Text = "Cambiar";
            this.btn_cambiar.UseVisualStyleBackColor = true;
            // 
            // lb_semilla
            // 
            this.lb_semilla.AutoSize = true;
            this.lb_semilla.Location = new System.Drawing.Point(6, 35);
            this.lb_semilla.Name = "lb_semilla";
            this.lb_semilla.Size = new System.Drawing.Size(53, 17);
            this.lb_semilla.TabIndex = 3;
            this.lb_semilla.Text = "Semilla";
            // 
            // txt_semilla
            // 
            this.txt_semilla.Location = new System.Drawing.Point(65, 35);
            this.txt_semilla.Name = "txt_semilla";
            this.txt_semilla.Size = new System.Drawing.Size(35, 22);
            this.txt_semilla.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbox_unitario);
            this.groupBox1.Controls.Add(this.txt_semilla);
            this.groupBox1.Controls.Add(this.lb_semilla);
            this.groupBox1.Location = new System.Drawing.Point(32, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 74);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Semilla unitaria";
            // 
            // ckbox_unitario
            // 
            this.ckbox_unitario.AutoSize = true;
            this.ckbox_unitario.Checked = true;
            this.ckbox_unitario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbox_unitario.Location = new System.Drawing.Point(161, 37);
            this.ckbox_unitario.Name = "ckbox_unitario";
            this.ckbox_unitario.Size = new System.Drawing.Size(79, 21);
            this.ckbox_unitario.TabIndex = 7;
            this.ckbox_unitario.Text = "Unitario";
            this.ckbox_unitario.UseVisualStyleBackColor = true;
            this.ckbox_unitario.CheckedChanged += new System.EventHandler(this.ckbox_unitario_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbox_conjunto);
            this.groupBox2.Controls.Add(this.lb_resultado);
            this.groupBox2.Controls.Add(this.ls_resultados);
            this.groupBox2.Controls.Add(this.lb_paso);
            this.groupBox2.Controls.Add(this.lb_inicio);
            this.groupBox2.Controls.Add(this.txt_paso);
            this.groupBox2.Controls.Add(this.txt_inicio);
            this.groupBox2.Controls.Add(this.txt_cant_semillas);
            this.groupBox2.Controls.Add(this.lb_cant_semillas);
            this.groupBox2.Location = new System.Drawing.Point(32, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 395);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conjunto semillas";
            // 
            // ckbox_conjunto
            // 
            this.ckbox_conjunto.AutoSize = true;
            this.ckbox_conjunto.Location = new System.Drawing.Point(161, 21);
            this.ckbox_conjunto.Name = "ckbox_conjunto";
            this.ckbox_conjunto.Size = new System.Drawing.Size(86, 21);
            this.ckbox_conjunto.TabIndex = 8;
            this.ckbox_conjunto.Text = "Conjunto";
            this.ckbox_conjunto.UseVisualStyleBackColor = true;
            this.ckbox_conjunto.CheckedChanged += new System.EventHandler(this.ckbox_conjunto_CheckedChanged);
            // 
            // lb_resultado
            // 
            this.lb_resultado.AutoSize = true;
            this.lb_resultado.Location = new System.Drawing.Point(6, 130);
            this.lb_resultado.Name = "lb_resultado";
            this.lb_resultado.Size = new System.Drawing.Size(79, 17);
            this.lb_resultado.TabIndex = 7;
            this.lb_resultado.Text = "Resultados";
            // 
            // ls_resultados
            // 
            this.ls_resultados.FormattingEnabled = true;
            this.ls_resultados.ItemHeight = 16;
            this.ls_resultados.Location = new System.Drawing.Point(24, 150);
            this.ls_resultados.Name = "ls_resultados";
            this.ls_resultados.Size = new System.Drawing.Size(221, 228);
            this.ls_resultados.TabIndex = 6;
            // 
            // lb_paso
            // 
            this.lb_paso.AutoSize = true;
            this.lb_paso.Location = new System.Drawing.Point(102, 91);
            this.lb_paso.Name = "lb_paso";
            this.lb_paso.Size = new System.Drawing.Size(40, 17);
            this.lb_paso.TabIndex = 5;
            this.lb_paso.Text = "Paso";
            // 
            // lb_inicio
            // 
            this.lb_inicio.AutoSize = true;
            this.lb_inicio.Location = new System.Drawing.Point(5, 89);
            this.lb_inicio.Name = "lb_inicio";
            this.lb_inicio.Size = new System.Drawing.Size(49, 17);
            this.lb_inicio.TabIndex = 4;
            this.lb_inicio.Text = "Desde";
            // 
            // txt_paso
            // 
            this.txt_paso.Location = new System.Drawing.Point(148, 86);
            this.txt_paso.Name = "txt_paso";
            this.txt_paso.Size = new System.Drawing.Size(38, 22);
            this.txt_paso.TabIndex = 3;
            // 
            // txt_inicio
            // 
            this.txt_inicio.Location = new System.Drawing.Point(60, 86);
            this.txt_inicio.Name = "txt_inicio";
            this.txt_inicio.Size = new System.Drawing.Size(36, 22);
            this.txt_inicio.TabIndex = 2;
            // 
            // txt_cant_semillas
            // 
            this.txt_cant_semillas.Location = new System.Drawing.Point(130, 49);
            this.txt_cant_semillas.Name = "txt_cant_semillas";
            this.txt_cant_semillas.Size = new System.Drawing.Size(39, 22);
            this.txt_cant_semillas.TabIndex = 1;
            // 
            // lb_cant_semillas
            // 
            this.lb_cant_semillas.AutoSize = true;
            this.lb_cant_semillas.Location = new System.Drawing.Point(6, 49);
            this.lb_cant_semillas.Name = "lb_cant_semillas";
            this.lb_cant_semillas.Size = new System.Drawing.Size(118, 17);
            this.lb_cant_semillas.TabIndex = 0;
            this.lb_cant_semillas.Text = "Cantidad semillas";
            // 
            // btn_simular
            // 
            this.btn_simular.Location = new System.Drawing.Point(762, 556);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(73, 40);
            this.btn_simular.TabIndex = 7;
            this.btn_simular.Text = "Simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            // 
            // btn_graficas
            // 
            this.btn_graficas.Location = new System.Drawing.Point(672, 556);
            this.btn_graficas.Name = "btn_graficas";
            this.btn_graficas.Size = new System.Drawing.Size(73, 40);
            this.btn_graficas.TabIndex = 8;
            this.btn_graficas.Text = "Gráficas";
            this.btn_graficas.UseVisualStyleBackColor = true;
            // 
            // panel_tablero
            // 
            this.panel_tablero.Location = new System.Drawing.Point(335, 37);
            this.panel_tablero.Name = "panel_tablero";
            this.panel_tablero.Size = new System.Drawing.Size(500, 500);
            this.panel_tablero.TabIndex = 9;
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 623);
            this.Controls.Add(this.panel_tablero);
            this.Controls.Add(this.btn_graficas);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_cambiar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lb_tamanio_tablero);
            this.Name = "Sudoku";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.Sudoku_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_tamanio_tablero;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_cambiar;
        private System.Windows.Forms.Label lb_semilla;
        private System.Windows.Forms.TextBox txt_semilla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_resultado;
        private System.Windows.Forms.ListBox ls_resultados;
        private System.Windows.Forms.Label lb_paso;
        private System.Windows.Forms.Label lb_inicio;
        private System.Windows.Forms.TextBox txt_paso;
        private System.Windows.Forms.TextBox txt_inicio;
        private System.Windows.Forms.TextBox txt_cant_semillas;
        private System.Windows.Forms.Label lb_cant_semillas;
        private System.Windows.Forms.CheckBox ckbox_unitario;
        private System.Windows.Forms.CheckBox ckbox_conjunto;
        private System.Windows.Forms.Button btn_simular;
        private System.Windows.Forms.Button btn_graficas;
        private System.Windows.Forms.Panel panel_tablero;
    }
}