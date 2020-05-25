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
using System.Net;

namespace Web_Browser
{
    public partial class Navegador : Form
    {
        TabPage tabpage;
        List<String> tipoArchivo = new List<string>();
        public Navegador(TabPage tabpage)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.tabpage = tabpage;
            tipoArchivo.Add(".pdf");
            tipoArchivo.Add(".mp4");
            tipoArchivo.Add(".mp3");
            tipoArchivo.Add(".zip");
            tipoArchivo.Add(".rar");
            tipoArchivo.Add(".exe");
            tipoArchivo.Add(".html");
            tipoArchivo.Add(".doc");
            tipoArchivo.Add(".docx");
            tipoArchivo.Add(".ppt");
            tipoArchivo.Add(".pptx");
            tipoArchivo.Add(".jpg");
            tipoArchivo.Add(".png");
            tipoArchivo.Add(".jpge");
            tipoArchivo.Add(".xls");
            tipoArchivo.Add(".gif");
        }


        private void Navegar(string address)
        {
            tabpage.Text = address;
            if (String.IsNullOrEmpty(address))
            {
                return;
            }
            if (address.Equals("about:blank"))
            {
                return;
            }
            if (!address.StartsWith("http://") && !address.StartsWith("https://"))
            {
                address = "https://" + address;
            }

            try
            {
                textBox1.Text = address;
                webBrowser1.ScriptErrorsSuppressed = true;
                webBrowser1.Navigate(new Uri(address));
                guardarHistorial(address);
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            AppContext.Instance.set(webBrowser1.Url.ToString(), webBrowser1.DocumentText);
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navegar((textBox1.Text).ToLower());
        }      

        private void guardarHistorial(string address){
            StreamWriter archivo = File.AppendText("Historial.txt");
            archivo.WriteLine(address);
            archivo.Close();
            AppContext.Instance.setHistorial(address);
        }

        private void webBrowser1_Navigating_1(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (extension(e.Url) && (bool)AppContext.Instance.get("Descargar"))
            {
                e.Cancel = true;
                string filepath = null;

                saveFileDialog1.FileName = e.Url.Segments[e.Url.Segments.Length - 1];
                if (saveFileDialog1.ShowDialog() == DialogResult.OK && (bool)AppContext.Instance.get("Descargar"))
                {
                    AppContext.Instance.set("Descargar", false);
                    filepath = saveFileDialog1.FileName;
                    WebClient client = new WebClient();
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    AppContext.Instance.setDescargas(filepath);
                    client.DownloadFileAsync(e.Url, filepath);
                }
            }
            else
            {
                String url = e.Url.ToString();
                if(AppContext.Instance.get(e.Url.ToString()) != null)
                {
                    webBrowser1.Stop();
                    webBrowser1.DocumentText = (String)AppContext.Instance.get(url);
                    webBrowser1.Update();
                    textBox1.Text = url;
                }
            }
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Archivo descargado");
            AppContext.Instance.set("Descargar", true);
        }

        private Boolean extension(Uri url)
        {
            for(int i = 0; i < tipoArchivo.Count; i++)
            {
                if (url.Segments[url.Segments.Length - 1].EndsWith(tipoArchivo[i]))
                    return true;
            }
            return false;
        }

        public Boolean comparar(TabPage tab)
        {
            return this.tabpage == tab;
        }
    }
}
