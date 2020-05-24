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

namespace Web_Browser
{
    public partial class Navegador : Form
    {
        TabPage tabpage;
        bool primera = false;
        bool cargando = false;
        HtmlDocument htmlDoc;

        public Navegador(TabPage tabpage)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.tabpage = tabpage;
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
            /*if (cargando)
            {
                Semaforo s = (Semaforo)AppContext.Instance.get("Semaforo");
                elemento element = new elemento();
                element.url = webBrowser1.Url.ToString();
                element.html = webBrowser1.DocumentText;
                s.EscribirCache(element);
                cargando = false;
            }*/
            if (webBrowser1.Document != null)
            {
                htmlDoc = webBrowser1.Document;
                htmlDoc.Click += new HtmlElementEventHandler(htmlDoc_Click);
            }
        }
        private void htmlDoc_Click(object sender, HtmlElementEventArgs e)
        {
            HtmlElementCollection a = webBrowser1.Document.Links;
            HtmlElement elem = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == elem)
                    Console.WriteLine(a[i].TagName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navegar((textBox1.Text).ToLower());
        }       

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            try
            {
                Console.WriteLine(webBrowser1.Url);
            } catch (Exception ex) { }
           
            /*
            if (!cargando)
            {
                String url = "";
                cargando = true;
                if (!(bool)AppContext.Instance.get("Carga"))
                {
                    AppContext.Instance.set("Carga", true);
                    url = textBox1.Text;
                    if (AppContext.Instance.get(url) != null)
                    {
                        webBrowser1.Stop();
                        webBrowser1.DocumentText = (String)AppContext.Instance.get(url);
                        webBrowser1.Update();
                    }
                }
                else
                {
                    if (!primera)
                    {
                        url = textBox1.Text;
                        primera = true;
                        if (AppContext.Instance.get(url) != null)
                        {
                            webBrowser1.Stop();
                            webBrowser1.DocumentText = (String)AppContext.Instance.get(url);
                            webBrowser1.Update();
                        }
                    }
                    else
                    {
                        url = webBrowser1.Url.ToString();
                        Console.WriteLine(url);
                        if (AppContext.Instance.get(url) != null)
                        {
                            webBrowser1.Stop();
                            webBrowser1.DocumentText = (String)AppContext.Instance.get(url);
                            webBrowser1.Update();
                        }
                    }
                }
            }
            */
        }

        private void webBrowser1_FileDownload(object sender, EventArgs e)
        {
            (webBrowser1.ActiveXInstance as SHDocVw.ShellBrowserWindow).FileDownload += accionDescargar;
        }

        private void accionDescargar(bool ActivateDocument, ref bool Cancel)
        {
            if (!(bool)AppContext.Instance.get("Descargar"))
            {
                Cancel = true;
            }
            else
            {
                AppContext.Instance.set("Descargar", false);
            }
        }


        private void guardarHistorial(string address){
            StreamWriter archivo = File.AppendText("Historial.txt");
            archivo.WriteLine(address);
            archivo.Close();
            AppContext.Instance.setHistorial(address);
        }

        private void webBrowser1_Navigating_1(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!cargando)
            {
                cargando = true;
            }
        }
    }
}
