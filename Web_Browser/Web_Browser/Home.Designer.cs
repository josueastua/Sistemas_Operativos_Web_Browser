﻿namespace Web_Browser
{
    partial class Home
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnDescargas = new System.Windows.Forms.Button();
            this.btnCache = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tc_pestanas = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.tc_pestanas.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.button1.Location = new System.Drawing.Point(9, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Nueva Ventana ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.AutoSize = true;
            this.btnHistorial.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnHistorial.Location = new System.Drawing.Point(399, 12);
            this.btnHistorial.Margin = new System.Windows.Forms.Padding(2);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(180, 40);
            this.btnHistorial.TabIndex = 2;
            this.btnHistorial.Text = "Historial ";
            this.btnHistorial.UseMnemonic = false;
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnQuitar.Location = new System.Drawing.Point(208, 12);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(186, 40);
            this.btnQuitar.TabIndex = 3;
            this.btnQuitar.Text = "Quitar Ventana ";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.accionQuitar);
            // 
            // btnDescargas
            // 
            this.btnDescargas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDescargas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnDescargas.Location = new System.Drawing.Point(584, 12);
            this.btnDescargas.Name = "btnDescargas";
            this.btnDescargas.Size = new System.Drawing.Size(165, 40);
            this.btnDescargas.TabIndex = 4;
            this.btnDescargas.Text = "Descargas ";
            this.btnDescargas.UseVisualStyleBackColor = false;
            this.btnDescargas.Click += new System.EventHandler(this.accionDescargas);
            // 
            // btnCache
            // 
            this.btnCache.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCache.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnCache.Location = new System.Drawing.Point(755, 12);
            this.btnCache.Name = "btnCache";
            this.btnCache.Size = new System.Drawing.Size(165, 40);
            this.btnCache.TabIndex = 5;
            this.btnCache.Text = "Cache";
            this.btnCache.UseVisualStyleBackColor = false;
            this.btnCache.Click += new System.EventHandler(this.accionCache);
            // 
            // tabPage1
            // 
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1228, 621);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inicio";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tc_pestanas
            // 
            this.tc_pestanas.Controls.Add(this.tabPage1);
            this.tc_pestanas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tc_pestanas.Location = new System.Drawing.Point(9, 68);
            this.tc_pestanas.Margin = new System.Windows.Forms.Padding(0);
            this.tc_pestanas.Name = "tc_pestanas";
            this.tc_pestanas.SelectedIndex = 0;
            this.tc_pestanas.Size = new System.Drawing.Size(1236, 647);
            this.tc_pestanas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(927, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 40);
            this.label1.TabIndex = 6;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1254, 724);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCache);
            this.Controls.Add(this.btnDescargas);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tc_pestanas);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Name = "Home";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.tc_pestanas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnDescargas;
        private System.Windows.Forms.Button btnCache;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tc_pestanas;
        private System.Windows.Forms.Label label1;
    }
}

