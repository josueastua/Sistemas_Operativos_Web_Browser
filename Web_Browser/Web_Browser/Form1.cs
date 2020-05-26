using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Web_Browser
{
    public partial class Form1 : Form
    {
        int uso = 0;
        public Form1(int uso)
        {
            InitializeComponent();
            this.uso = uso;
            asignarUso();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void asignarUso()
        {
            if (uso == 1)
            {
                lvInformacion.Columns[0].Text = "ID";
                lvInformacion.Columns[1].Text = "Direccion Url";
                agregarElementos(AppContext.Instance.getHistorial());
            }else if(uso == 2)
            {
                lvInformacion.Columns[0].Text = "ID";
                lvInformacion.Columns[1].Text = "Destino Url";
                agregarElementos(AppContext.Instance.getDescargas());
            }else if(uso == 3)
            {
                lvInformacion.Columns[0].Text = "ID";
                lvInformacion.Columns[1].Text = "Direccion Url";
                agregarElementos(AppContext.Instance.getPaginas());
                btnAbrir.Enabled = false;
                btnAbrir.Visible = false;
            }

        }

        private void agregarElementos(List<String> lista)
        {
            for (int a = 0; a < lista.Count; a++)
            {
                String[] cont = { a.ToString(), lista[a] };
                lvInformacion.Items.Add(new ListViewItem(cont));
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void accionBorrartodo(object sender, EventArgs e)
        {
            if(uso == 1)
            {
                AppContext.Instance.getHistorial().Clear();
                StreamWriter archivo = File.CreateText("Historial.txt");
                archivo.Close();
                lvInformacion.Items.Clear();
            }
            if(uso == 2)
            {
                AppContext.Instance.getDescargas().Clear();
                StreamWriter archivo = File.CreateText("Descargas.txt");
                archivo.Close();
                lvInformacion.Items.Clear();
            }
            if(uso == 3)
            {
                AppContext.Instance.getPaginas().Clear();
                AppContext.Instance.clear();
                lvInformacion.Items.Clear();
            }
        }

        private void accionBorraSeleccionado(object sender, EventArgs e)
        {
            if(uso == 1)
            {
                try
                {
                    int index = lvInformacion.Items.IndexOf(lvInformacion.SelectedItems[0]);
                    lvInformacion.Items.Remove(lvInformacion.SelectedItems[0]);
                    AppContext.Instance.getHistorial().RemoveAt(index);
                    StreamWriter archivo = File.CreateText("Historial.txt");
                    archivo.Close();
                    for (int a = 0; a < AppContext.Instance.getHistorial().Count(); a++)
                    {
                        archivo = File.AppendText("Historial.txt");
                        archivo.WriteLine(AppContext.Instance.getHistorial()[a]);
                        archivo.Close();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Hola");
                }
                
            }
            if (uso == 2)
            {
                try
                {
                    int index = lvInformacion.Items.IndexOf(lvInformacion.SelectedItems[0]);
                    lvInformacion.Items.Remove(lvInformacion.SelectedItems[0]);
                    AppContext.Instance.getDescargas().RemoveAt(index);
                    StreamWriter archivo = File.CreateText("Descargas.txt");
                    archivo.Close();
                    for (int a = 0; a < AppContext.Instance.getDescargas().Count(); a++)
                    {
                        archivo = File.AppendText("Descargas.txt");
                        archivo.WriteLine(AppContext.Instance.getDescargas()[a]);
                        archivo.Close();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Hola");
                }

            }
            if (uso == 3)
            {
                try
                {
                    int index = lvInformacion.Items.IndexOf(lvInformacion.SelectedItems[0]);
                    lvInformacion.Items.Remove(lvInformacion.SelectedItems[0]);
                    AppContext.Instance.removeCache(AppContext.Instance.getPaginas()[index]);
                    AppContext.Instance.getPaginas().RemoveAt(index);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Hola");
                }

            }
        }

        private void accionAbrir(object sender, EventArgs e)
        {
            if (lvInformacion.SelectedItems[0] != null)
            {
                int index = lvInformacion.Items.IndexOf(lvInformacion.SelectedItems[0]);
                if(uso == 1)
                {
                    Home home = (Home)AppContext.Instance.get("Home");
                    home.nuevaVentana(AppContext.Instance.getHistorial()[index]);
                }else if(uso == 2)
                {
                    String path = AppContext.Instance.getDescargas()[index];
                    System.Diagnostics.Process.Start(path);
                }
            }
            else
                MessageBox.Show("No hay un elemento seleccionado", "Informacion de seleccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
