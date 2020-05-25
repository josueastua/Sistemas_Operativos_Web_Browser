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
            }

        }

        private void agregarElementos(List<String> lista)
        {
            for (int a = 0; a < lista.Count; a++)
            {
                String[] cont = { a.ToString(), lista[a] };
                lvInformacion.Items.Add(new ListViewItem(cont));
                Console.WriteLine(lista.ElementAt<string>(a));
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
                lvInformacion.Items.Clear();
            }
        }

        private void accionBorraSeleccionado(object sender, EventArgs e)
        {
            if(uso == 1)
            {
                Console.WriteLine(lvInformacion.SelectedItems[0].GetType());
            }
        }
    }
}
