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
        bool nueva = false;
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


        public void Navegar(string address)
        {
            tabpage.Text = nombreTab(address);
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
            if (webBrowser1.CanGoBack)
                webBrowser1.GoBack();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
                webBrowser1.GoForward();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Semaforo s = (Semaforo)AppContext.Instance.get("Semaforo");
            elemento elem;
            elem.url = webBrowser1.Url.ToString();
            elem.html = webBrowser1.DocumentStream;
            s.EscribirCache(elem);
            textBox1.Text = webBrowser1.Url.ToString();
            guardarHistorial(e.Url.ToString());
            tabpage.Text = nombreTab(e.Url.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navegar((textBox1.Text).ToLower());
        }      

        private void guardarHistorial(string address){
            StreamWriter archivo = File.AppendText("Historial.txt");
            archivo.Close();
            AppContext.Instance.setHistorial(address);
        }

        private void guardarDescarga(string downloaded){
            StreamWriter archivo = File.AppendText("Descargas.txt");
            archivo.WriteLine(downloaded);
            archivo.Close();
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
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_progresoDescarga);
                    AppContext.Instance.setDescargas(filepath);
                    client.DownloadFileAsync(e.Url, filepath);
                    guardarDescarga(filepath);
                }
            }
            else
            {
                if (!(bool)AppContext.Instance.get("Descargar"))
                    MessageBox.Show("Ya hay un archivo en descarga", "Informacion de descarga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                String url = e.Url.ToString();
                if (nueva)
                {
                    Home home = (Home)tabpage.FindForm();
                    home.nuevaVentana(url);
                    nueva = false;
                }
                else
                {
                    if (AppContext.Instance.getCache(e.Url.ToString()) != null)
                    {
                        webBrowser1.DocumentStream = (Stream)AppContext.Instance.getCache(url);
                        textBox1.Text = "";
                        textBox1.Text = url;
                    }
                }
            }
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("La descarga a finalizado", "Informacion de descarga", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AppContext.Instance.set("Descargar", true);
        }

        private void client_progresoDescarga(object sender, DownloadProgressChangedEventArgs e)
        {
            Home home = (Home)AppContext.Instance.get("Home");
            home.escribirLabel("Porcentaje de descarga: " + e.ProgressPercentage.ToString());
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

        private void webBrowser1_FileDownload(object sender, EventArgs e)
        {
            (webBrowser1.ActiveXInstance as SHDocVw.ShellBrowserWindow).FileDownload += browser_FileDownload;
        }

        private void browser_FileDownload(bool ActivateDocument, ref bool Cancel)
        {
            Cancel = true;
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            nueva = true;
        }

        public String nombreTab(String url)
        {
            String tabname = "";
            int contBarra = 0;
            for(int i = 0; i < url.Length; i++)
            {
                if (url[i] == '/')
                    contBarra++;
                if (contBarra <= 2)
                    tabname += url[i];
                else
                    break;
            }
            return tabname;
        }
    }
}
