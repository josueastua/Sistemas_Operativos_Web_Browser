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
        int[] aux2;
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
            aux2 = control.getRecursos();
            lbl_recursos.Text = "[ " + aux2[0];
            for (int i = 1; i < 8; i++)
            {
                lbl_recursos.Text += ", " + aux2[i];
            }
            lbl_recursos.Text += " ]";
            while (!control.getBloqueo())
            {
                aux2 = control.getLibres();
                lbl_libres.Text = "[ " + aux2[0];
                for (int i = 1; i < 8; i++)
                {
                    lbl_libres.Text += ", " + aux2[i];
                }
                lbl_libres.Text += " ]";
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
                 Thread.Sleep(1000);
                tb_espera.Text = "";
                tb_listos.Text = "";
                tb_terminados.Text = "";
                tb_muertos.Text = "";
            }
        }
    }
}
