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
    public partial class Navegador : Form
    {
        TabPage tabpage;
        bool primera = true;
        public Navegador(TabPage tabpage)
        {
            InitializeComponent();
            this.tabpage = tabpage;
        }

        private void Navegar(string address)
        {
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
                tabpage.Text = address;
                textBox1.Text = address;
                webBrowser1.ScriptErrorsSuppressed = true;
                webBrowser1.Navigate(new Uri(address));
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
            AppContext.Instance.set(webBrowser1.Url.ToString(), (HtmlDocument)webBrowser1.Document);
            if (primera)
                primera = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navegar((textBox1.Text).ToLower());
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!primera)
            {
                String url = webBrowser1.Url.ToString();
                if (AppContext.Instance.get(url) != null)
                {
                    webBrowser1.Stop();
                    HtmlDocument aux = (HtmlDocument)AppContext.Instance.get(url);
                    webBrowser1.DocumentText = aux.ToString();
                    webBrowser1.Update();
                    primera = true;
                }
                Console.WriteLine("Llego");
            }

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
        }
    }
}
