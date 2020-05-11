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

namespace Tarea_Bloqueos
{
    public partial class Simulador : Form
    {
        Control control;
        List<Proceso> aux;
        public Simulador()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void accionIniciar(object sender, MouseEventArgs e)
        {
            btn_iniciar.Enabled = false;
            Thread hilo = new Thread(accionSimulador);
            hilo.Start();
        }

        private void accionSimulador()
        {
            control = new Control();
            control.initSimulador();
            while (!control.getBloqueo())
            {
                Console.WriteLine("En While");
                tb_espera.Text = "Informacion de Procesos en Espera\r\n";
                tb_listos.Text = "Informacion de Procesos en Ejecucion\r\n";
                tb_terminados.Text = "Informacion de Procesos Terminados\r\n";
                tb_muertos.Text = "Informacion de Procesos Muertos\r\n";
                aux = control.getEspera();
                for (int i = 0; i < aux.Count; i++)
                    tb_espera.Text += aux[i].informacionProceso();
                aux = control.getEjecutando();
                for (int i = 0; i < aux.Count; i++)
                    tb_listos.Text += aux[i].informacionProceso();
                aux = control.getTerminados();
                for (int i = 0; i < aux.Count; i++)
                    tb_terminados.Text += aux[i].informacionProceso();
                aux = control.getMuertos();
                for (int i = 0; i < aux.Count; i++)
                    tb_muertos.Text += aux[i].informacionProceso(); 
                 Thread.Sleep(2000);
                tb_espera.Text = "";
                tb_listos.Text = "";
                tb_terminados.Text = "";
                tb_muertos.Text = "";
            }
        }
    }
}
