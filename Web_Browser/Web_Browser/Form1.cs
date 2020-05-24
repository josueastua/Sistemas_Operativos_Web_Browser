using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            agregarElementos(AppContext.Instance.getHistorial());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void agregarElementos(List<String> lista)
        {
            //ListViewGroup historial = new ListViewGroup("Historial");
            for (int a = 0; a < lista.Count; a++)
            {
                lvInformacion.Items.Add(new ListViewItem(lista.ElementAt<string>(a)));
                //lv_ejecucion.Items.Add(new ListViewItem(url));
                Console.WriteLine(lista.ElementAt<string>(a));
            }
            //lvInformacion.Groups.Add(historial);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
