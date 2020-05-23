using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    public partial class Home : Form
    {
        List<Navegador> ventanas = new List<Navegador>();
        List<Task> hilos = new List<Task>();

        public delegate void showForm(Navegador nav);
        public Home()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; ;
            Navegador nav = new Navegador(tabPage1);
            nav.TopLevel = false;
            tabPage1.Controls.Add(nav);
            tabPage1.Tag = nav;
            nav.Show();
            AppContext.Instance.set("Descargar", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage myTabPage = new TabPage("Nueva Pestaña");
            tc_pestanas.TabPages.Add(myTabPage);
            Navegador nav = new Navegador((TabPage)myTabPage);
            nav.TopLevel = false;
            myTabPage.Controls.Add(nav);
            myTabPage.Tag = nav;
            var @delegate = new showForm(nuevaVentana);
            Task hilo = new Task(() => myTabPage.BeginInvoke(@delegate, nav));
            hilo.Start();
            hilos.Add(hilo);
            ventanas.Add(nav);
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void nuevaVentana(Navegador nav)
        {
            
            nav.Show();

        }
    }
}
