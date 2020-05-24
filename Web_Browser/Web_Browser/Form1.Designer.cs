namespace Web_Browser
{
    partial class Form1
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
            this.lvInformacion = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvInformacion
            // 
            this.lvInformacion.AccessibleName = "";
            this.lvInformacion.FullRowSelect = true;
            this.lvInformacion.GridLines = true;
            this.lvInformacion.HideSelection = false;
            this.lvInformacion.Location = new System.Drawing.Point(27, 30);
            this.lvInformacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvInformacion.Name = "lvInformacion";
            this.lvInformacion.Size = new System.Drawing.Size(406, 459);
            this.lvInformacion.TabIndex = 0;
            this.lvInformacion.UseCompatibleStateImageBehavior = false;
            this.lvInformacion.View = System.Windows.Forms.View.List;
            this.lvInformacion.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 539);
            this.Controls.Add(this.lvInformacion);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvInformacion;
    }
}