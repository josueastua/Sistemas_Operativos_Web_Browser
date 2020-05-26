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
using System.IO;
using System.Diagnostics;

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
            Semaforo s = new Semaforo(true);
            s.initSemaforo();
            AppContext.Instance.set("Semaforo", s);
            cargarHistorial();
            cargarDescargas();
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

        private void nuevaVentana(Navegador nav)
        {
            nav.Show();
        }

        private void cargarHistorial()
        {
            if (File.Exists("Historial.txt")){
                StreamReader archivo = new StreamReader("Historial.txt");
                while (!archivo.EndOfStream)
                {
                    string linea = archivo.ReadLine();
                    AppContext.Instance.setHistorial(linea);
                    Console.WriteLine(linea);
                }
                archivo.Close();
            }
        }

        private void cargarDescargas()
        {
            if (File.Exists("Descargas.txt"))
            {
                StreamReader archivo = new StreamReader("Descargas.txt");
                while (!archivo.EndOfStream)
                {
                    string linea = archivo.ReadLine();
                    AppContext.Instance.setDescargas(linea);
                    Console.WriteLine(linea);
                }
                archivo.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TabPage myTabPage = new TabPage("Hstorial");
            tc_pestanas.TabPages.Add(myTabPage);
            Form1 ventInformacion = new Form1(1);
            ventInformacion.TopLevel = false;
            myTabPage.Controls.Add(ventInformacion);
            myTabPage.Tag = ventInformacion;
            ventInformacion.Show();
        }

        private void accionQuitar(object sender, EventArgs e)
        {
            if (tc_pestanas.TabPages.Count > 1)
            {
                TabPage aux = tc_pestanas.SelectedTab;
                int index = tc_pestanas.SelectedIndex - 1;
                tc_pestanas.TabPages.Remove(tc_pestanas.SelectedTab);
                if (tc_pestanas.SelectedIndex != 0 && aux.Text != "Descargas" && aux.Text != "Cache" && aux.Text != "Historial")
                {
                    ventanas.Remove(ventanas[index]);
                    hilos.Remove(hilos[index]);
                }
            }
        }

        private void accionDescargas(object sender, EventArgs e)
        {
            TabPage myTabPage = new TabPage("Descargas");
            tc_pestanas.TabPages.Add(myTabPage);
            Form1 ventInformacion = new Form1(2);
            ventInformacion.TopLevel = false;
            myTabPage.Controls.Add(ventInformacion);
            myTabPage.Tag = ventInformacion;
            ventInformacion.Show();
        }

        private void accionCache(object sender, EventArgs e)
        {
            TabPage myTabPage = new TabPage("Cache");
            tc_pestanas.TabPages.Add(myTabPage);
            Form1 ventInformacion = new Form1(3);
            ventInformacion.TopLevel = false;
            myTabPage.Controls.Add(ventInformacion);
            myTabPage.Tag = ventInformacion;
            ventInformacion.Show();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            System.Environment.Exit(1);
        }
    }
}
