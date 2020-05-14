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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_iniciar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_libres = new System.Windows.Forms.Label();
            this.lbl_recursos = new System.Windows.Forms.Label();
            this.lv_espera = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VIDA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EJECUTADO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.INANICION = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ESPERADO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_ejecucion = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_terminados = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_muertos = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_bloqueo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label1.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 61);
            this.label1.TabIndex = 3;
            this.label1.Text = "Procesos en Espera";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label2.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(401, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 61);
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
            this.label3.Location = new System.Drawing.Point(1177, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 61);
            this.label3.TabIndex = 5;
            this.label3.Text = "Procesos Muertos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label4.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(790, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(381, 61);
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
            this.label5.Size = new System.Drawing.Size(1158, 61);
            this.label5.TabIndex = 8;
            this.label5.Text = "Simulador de Procesos";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.BackColor = System.Drawing.Color.White;
            this.btn_iniciar.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_iniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btn_iniciar.Location = new System.Drawing.Point(1177, 9);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(376, 61);
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
            this.label6.Size = new System.Drawing.Size(383, 61);
            this.label6.TabIndex = 11;
            this.label6.Text = "Recursos Totales";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label7.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(790, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(381, 61);
            this.label7.TabIndex = 12;
            this.label7.Text = "Recursos Libres";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_libres
            // 
            this.lbl_libres.BackColor = System.Drawing.Color.LightGray;
            this.lbl_libres.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_libres.Location = new System.Drawing.Point(1181, 91);
            this.lbl_libres.Name = "lbl_libres";
            this.lbl_libres.Size = new System.Drawing.Size(372, 61);
            this.lbl_libres.TabIndex = 13;
            this.lbl_libres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_recursos
            // 
            this.lbl_recursos.BackColor = System.Drawing.Color.LightGray;
            this.lbl_recursos.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_recursos.Location = new System.Drawing.Point(402, 91);
            this.lbl_recursos.Name = "lbl_recursos";
            this.lbl_recursos.Size = new System.Drawing.Size(382, 61);
            this.lbl_recursos.TabIndex = 14;
            this.lbl_recursos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_espera
            // 
            this.lv_espera.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.VIDA,
            this.EJECUTADO,
            this.INANICION,
            this.ESPERADO});
            this.lv_espera.FullRowSelect = true;
            this.lv_espera.GridLines = true;
            this.lv_espera.HideSelection = false;
            this.lv_espera.Location = new System.Drawing.Point(12, 246);
            this.lv_espera.Name = "lv_espera";
            this.lv_espera.Scrollable = false;
            this.lv_espera.Size = new System.Drawing.Size(383, 354);
            this.lv_espera.TabIndex = 18;
            this.lv_espera.UseCompatibleStateImageBehavior = false;
            this.lv_espera.View = System.Windows.Forms.View.Details;
            this.lv_espera.SelectedIndexChanged += new System.EventHandler(this.lv_espera_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 76;
            // 
            // VIDA
            // 
            this.VIDA.Text = "VIDA";
            this.VIDA.Width = 76;
            // 
            // EJECUTADO
            // 
            this.EJECUTADO.Text = "EJECUTADO";
            this.EJECUTADO.Width = 76;
            // 
            // INANICION
            // 
            this.INANICION.Text = "INANICION";
            this.INANICION.Width = 76;
            // 
            // ESPERADO
            // 
            this.ESPERADO.Text = "ESPERADO";
            this.ESPERADO.Width = 76;
            // 
            // lv_ejecucion
            // 
            this.lv_ejecucion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lv_ejecucion.FullRowSelect = true;
            this.lv_ejecucion.GridLines = true;
            this.lv_ejecucion.HideSelection = false;
            this.lv_ejecucion.Location = new System.Drawing.Point(401, 246);
            this.lv_ejecucion.Name = "lv_ejecucion";
            this.lv_ejecucion.Scrollable = false;
            this.lv_ejecucion.Size = new System.Drawing.Size(383, 354);
            this.lv_ejecucion.TabIndex = 19;
            this.lv_ejecucion.UseCompatibleStateImageBehavior = false;
            this.lv_ejecucion.View = System.Windows.Forms.View.Details;
            this.lv_ejecucion.SelectedIndexChanged += new System.EventHandler(this.lv_ejecucion_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 76;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "VIDA";
            this.columnHeader2.Width = 76;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "EJECUTADO";
            this.columnHeader3.Width = 76;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "INANICION";
            this.columnHeader4.Width = 76;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ESPERADO";
            this.columnHeader5.Width = 76;
            // 
            // lv_terminados
            // 
            this.lv_terminados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lv_terminados.FullRowSelect = true;
            this.lv_terminados.GridLines = true;
            this.lv_terminados.HideSelection = false;
            this.lv_terminados.Location = new System.Drawing.Point(790, 246);
            this.lv_terminados.Name = "lv_terminados";
            this.lv_terminados.Scrollable = false;
            this.lv_terminados.Size = new System.Drawing.Size(383, 354);
            this.lv_terminados.TabIndex = 20;
            this.lv_terminados.UseCompatibleStateImageBehavior = false;
            this.lv_terminados.View = System.Windows.Forms.View.Details;
            this.lv_terminados.SelectedIndexChanged += new System.EventHandler(this.lv_terminados_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            this.columnHeader6.Width = 76;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "VIDA";
            this.columnHeader7.Width = 76;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "EJECUTADO";
            this.columnHeader8.Width = 76;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "INANICION";
            this.columnHeader9.Width = 76;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "ESPERADO";
            this.columnHeader10.Width = 76;
            // 
            // lv_muertos
            // 
            this.lv_muertos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.lv_muertos.FullRowSelect = true;
            this.lv_muertos.GridLines = true;
            this.lv_muertos.HideSelection = false;
            this.lv_muertos.Location = new System.Drawing.Point(1175, 246);
            this.lv_muertos.Name = "lv_muertos";
            this.lv_muertos.Scrollable = false;
            this.lv_muertos.Size = new System.Drawing.Size(383, 354);
            this.lv_muertos.TabIndex = 21;
            this.lv_muertos.UseCompatibleStateImageBehavior = false;
            this.lv_muertos.View = System.Windows.Forms.View.Details;
            this.lv_muertos.SelectedIndexChanged += new System.EventHandler(this.lv_muertos_SelectedIndexChanged);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "ID";
            this.columnHeader11.Width = 76;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "VIDA";
            this.columnHeader12.Width = 76;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "EJECUTADO";
            this.columnHeader13.Width = 76;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "INANICION";
            this.columnHeader14.Width = 76;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "ESPERADO";
            this.columnHeader15.Width = 76;
            // 
            // lbl_bloqueo
            // 
            this.lbl_bloqueo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lbl_bloqueo.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bloqueo.ForeColor = System.Drawing.Color.White;
            this.lbl_bloqueo.Location = new System.Drawing.Point(401, 603);
            this.lbl_bloqueo.Name = "lbl_bloqueo";
            this.lbl_bloqueo.Size = new System.Drawing.Size(772, 61);
            this.lbl_bloqueo.TabIndex = 22;
            this.lbl_bloqueo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1565, 669);
            this.Controls.Add(this.lbl_bloqueo);
            this.Controls.Add(this.lv_muertos);
            this.Controls.Add(this.lv_terminados);
            this.Controls.Add(this.lv_ejecucion);
            this.Controls.Add(this.lv_espera);
            this.Controls.Add(this.lbl_recursos);
            this.Controls.Add(this.lbl_libres);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_iniciar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Simulador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador de procesos";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_iniciar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_libres;
        private System.Windows.Forms.Label lbl_recursos;
        private System.Windows.Forms.ListView lv_espera;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader VIDA;
        private System.Windows.Forms.ColumnHeader EJECUTADO;
        private System.Windows.Forms.ColumnHeader INANICION;
        private System.Windows.Forms.ColumnHeader ESPERADO;
        private System.Windows.Forms.ListView lv_ejecucion;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lv_terminados;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ListView lv_muertos;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.Label lbl_bloqueo;
    }
}

