﻿namespace Tarea_Bloqueos
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
            this.tb_ejecucion = new System.Windows.Forms.TextBox();
            this.btn_iniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_espera
            // 
            this.tb_espera.Location = new System.Drawing.Point(13, 252);
            this.tb_espera.Multiline = true;
            this.tb_espera.Name = "tb_espera";
            this.tb_espera.ReadOnly = true;
            this.tb_espera.Size = new System.Drawing.Size(300, 387);
            this.tb_espera.TabIndex = 0;
            // 
            // tb_listos
            // 
            this.tb_listos.Location = new System.Drawing.Point(327, 251);
            this.tb_listos.Multiline = true;
            this.tb_listos.Name = "tb_listos";
            this.tb_listos.ReadOnly = true;
            this.tb_listos.Size = new System.Drawing.Size(300, 387);
            this.tb_listos.TabIndex = 1;
            // 
            // tb_muertos
            // 
            this.tb_muertos.Location = new System.Drawing.Point(962, 252);
            this.tb_muertos.Multiline = true;
            this.tb_muertos.Name = "tb_muertos";
            this.tb_muertos.ReadOnly = true;
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
            this.label2.Text = "Procesos Listos para Ejecucion";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label3.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(959, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 61);
            this.label3.TabIndex = 5;
            this.label3.Text = "Procesos Muertos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_terminados
            // 
            this.tb_terminados.Location = new System.Drawing.Point(643, 252);
            this.tb_terminados.Multiline = true;
            this.tb_terminados.Name = "tb_terminados";
            this.tb_terminados.ReadOnly = true;
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
            this.label5.Location = new System.Drawing.Point(13, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 61);
            this.label5.TabIndex = 8;
            this.label5.Text = "Proceso en Ejecucion";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_ejecucion
            // 
            this.tb_ejecucion.Location = new System.Drawing.Point(327, 33);
            this.tb_ejecucion.Multiline = true;
            this.tb_ejecucion.Name = "tb_ejecucion";
            this.tb_ejecucion.ReadOnly = true;
            this.tb_ejecucion.Size = new System.Drawing.Size(616, 61);
            this.tb_ejecucion.TabIndex = 9;
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.BackColor = System.Drawing.Color.White;
            this.btn_iniciar.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_iniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btn_iniciar.Location = new System.Drawing.Point(972, 33);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(288, 61);
            this.btn_iniciar.TabIndex = 10;
            this.btn_iniciar.Text = "Iniciar Simulacion";
            this.btn_iniciar.UseVisualStyleBackColor = false;
            this.btn_iniciar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.accionIniciar);
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1272, 650);
            this.Controls.Add(this.btn_iniciar);
            this.Controls.Add(this.tb_ejecucion);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Simulador";
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
        private System.Windows.Forms.TextBox tb_ejecucion;
        private System.Windows.Forms.Button btn_iniciar;
    }
}
