namespace Tarea_Bloqueos
{
    partial class Simulador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_espera = new System.Windows.Forms.TextBox();
            this.tb_listos = new System.Windows.Forms.TextBox();
            this.tb_muertos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_terminados = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_iniciar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_libres = new System.Windows.Forms.Label();
            this.lbl_recursos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_espera
            // 
            this.tb_espera.AcceptsReturn = true;
            this.tb_espera.AcceptsTab = true;
            this.tb_espera.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_espera.Location = new System.Drawing.Point(13, 252);
            this.tb_espera.Multiline = true;
            this.tb_espera.Name = "tb_espera";
            this.tb_espera.ReadOnly = true;
            this.tb_espera.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_espera.Size = new System.Drawing.Size(300, 387);
            this.tb_espera.TabIndex = 0;
            // 
            // tb_listos
            // 
            this.tb_listos.AcceptsReturn = true;
            this.tb_listos.AcceptsTab = true;
            this.tb_listos.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_listos.Location = new System.Drawing.Point(327, 251);
            this.tb_listos.Multiline = true;
            this.tb_listos.Name = "tb_listos";
            this.tb_listos.ReadOnly = true;
            this.tb_listos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_listos.Size = new System.Drawing.Size(300, 387);
            this.tb_listos.TabIndex = 1;
            // 
            // tb_muertos
            // 
            this.tb_muertos.AcceptsReturn = true;
            this.tb_muertos.AcceptsTab = true;
            this.tb_muertos.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_muertos.Location = new System.Drawing.Point(962, 252);
            this.tb_muertos.Multiline = true;
            this.tb_muertos.Name = "tb_muertos";
            this.tb_muertos.ReadOnly = true;
            this.tb_muertos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_muertos.Size = new System.Drawing.Size(300, 387);
            this.tb_muertos.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label1.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 61);
            this.label1.TabIndex = 3;
            this.label1.Text = "Procesos en Espera";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label2.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(327, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 61);
            this.label2.TabIndex = 4;
            this.label2.Text = "Procesos en Ejecucion";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label3.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(962, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 61);
            this.label3.TabIndex = 5;
            this.label3.Text = "Procesos Muertos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_terminados
            // 
            this.tb_terminados.AcceptsReturn = true;
            this.tb_terminados.AcceptsTab = true;
            this.tb_terminados.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_terminados.Location = new System.Drawing.Point(643, 252);
            this.tb_terminados.Multiline = true;
            this.tb_terminados.Name = "tb_terminados";
            this.tb_terminados.ReadOnly = true;
            this.tb_terminados.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_terminados.Size = new System.Drawing.Size(300, 387);
            this.tb_terminados.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label4.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(640, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 61);
            this.label4.TabIndex = 7;
            this.label4.Text = "Procesos Terminados";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label5.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(930, 61);
            this.label5.TabIndex = 8;
            this.label5.Text = "Simulador de Procesos";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.BackColor = System.Drawing.Color.White;
            this.btn_iniciar.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_iniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btn_iniciar.Location = new System.Drawing.Point(962, 9);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(298, 61);
            this.btn_iniciar.TabIndex = 10;
            this.btn_iniciar.Text = "Iniciar Simulacion";
            this.btn_iniciar.UseVisualStyleBackColor = false;
            this.btn_iniciar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.accionIniciar);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label6.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(300, 61);
            this.label6.TabIndex = 11;
            this.label6.Text = "Recursos Totales";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label7.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(640, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(303, 61);
            this.label7.TabIndex = 12;
            this.label7.Text = "Recursos Libres";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_libres
            // 
            this.lbl_libres.BackColor = System.Drawing.Color.LightGray;
            this.lbl_libres.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_libres.Location = new System.Drawing.Point(963, 89);
            this.lbl_libres.Name = "lbl_libres";
            this.lbl_libres.Size = new System.Drawing.Size(295, 61);
            this.lbl_libres.TabIndex = 13;
            this.lbl_libres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_recursos
            // 
            this.lbl_recursos.BackColor = System.Drawing.Color.LightGray;
            this.lbl_recursos.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_recursos.Location = new System.Drawing.Point(328, 89);
            this.lbl_recursos.Name = "lbl_recursos";
            this.lbl_recursos.Size = new System.Drawing.Size(299, 61);
            this.lbl_recursos.TabIndex = 14;
            this.lbl_recursos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1272, 650);
            this.Controls.Add(this.lbl_recursos);
            this.Controls.Add(this.lbl_libres);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_iniciar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_terminados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_muertos);
            this.Controls.Add(this.tb_listos);
            this.Controls.Add(this.tb_espera);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Simulador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador de procesos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_espera;
        private System.Windows.Forms.TextBox tb_listos;
        private System.Windows.Forms.TextBox tb_muertos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_terminados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_iniciar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_libres;
        private System.Windows.Forms.Label lbl_recursos;
    }
}

