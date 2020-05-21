﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            Navegador nav = new Navegador(tabPage1);
            nav.TopLevel = false;
            tabPage1.Controls.Add(nav);
            tabPage1.Tag = nav;
            nav.Show();
            AppContext.Instance.set("Desargar", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage myTabPage = new TabPage("Nueva Pestaña");
            Navegador nav = new Navegador(myTabPage);
            nav.TopLevel = false;
            myTabPage.Controls.Add(nav);
            myTabPage.Tag = nav;
            nav.Show();
            tc_pestanas.TabPages.Add(myTabPage);

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
