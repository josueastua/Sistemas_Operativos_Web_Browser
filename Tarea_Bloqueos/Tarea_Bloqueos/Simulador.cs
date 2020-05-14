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
        bool simular;
        public Simulador()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            simular = false;
        }

        private void accionIniciar(object sender, MouseEventArgs e)
        {
            if (!simular)
            {
                btn_iniciar.Text = "Terminar Simulacion";
                Thread hilo = new Thread(accionSimulador);
                hilo.Start();
                simular = true;
            }
            else
            {
                simular = false;
                control.terminarTodo();
                Close();
            }
            
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
            while (simular)
            {
                aux2 = control.getLibres();
                lbl_libres.Text = "[ " + aux2[0];
                for (int i = 1; i < 8; i++)
                {
                    lbl_libres.Text += ", " + aux2[i];
                }
                lbl_libres.Text += " ]";
                aux = control.getEspera();
                for(int i = 0; i < aux.Count; i++)
                {
                    aux[i].actualizarVista();
                    lv_espera.Items.Add(new ListViewItem(aux[i].getVista()));
                }
                aux = control.getEjecutando();
                for (int i = 0; i < aux.Count; i++)
                {
                    aux[i].actualizarVista();
                    lv_ejecucion.Items.Add(new ListViewItem(aux[i].getVista()));
                }
                aux = control.getTerminados();
                for (int i = 0; i < aux.Count; i++)
                {
                    aux[i].actualizarVista();
                    lv_terminados.Items.Add(new ListViewItem(aux[i].getVista()));
                }
                aux = control.getMuertos();
                for (int i = 0; i < aux.Count; i++)
                {
                    aux[i].actualizarVista();
                    lv_muertos.Items.Add(new ListViewItem(aux[i].getVista()));
                }
                if (control.getBloqueo())
                {
                    lbl_bloqueo.Text = "Hay un bloqueo";
                }
                else
                {
                    lbl_bloqueo.Text = "No hay un bloqueo";
                }
                Thread.Sleep(500);
                if (simular)
                {
                    lv_espera.Items.Clear();
                    lv_ejecucion.Items.Clear();
                    lv_muertos.Items.Clear();
                    lv_terminados.Items.Clear();
                }
                
            }
        }

        private void lv_espera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem select = lv_espera.SelectedItems[0];
                int index = lv_espera.Items.IndexOf(select);
                MessageBox.Show(control.getEspera()[index].informacionProceso(), "Informacion de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex) { }
            
        }

        private void lv_ejecucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem select = lv_ejecucion.SelectedItems[0];
                int index = lv_ejecucion.Items.IndexOf(select);
                MessageBox.Show(control.getEjecutando()[index].informacionProceso(), "Informacion de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { }
        }

        private void lv_terminados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem select = lv_terminados.SelectedItems[0];
                int index = lv_terminados.Items.IndexOf(select);
                MessageBox.Show(control.getTerminados()[index].informacionProceso(), "Informacion de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { }
        }

        private void lv_muertos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem select = lv_muertos.SelectedItems[0];
                int index = lv_muertos.Items.IndexOf(select);
                MessageBox.Show(control.getMuertos()[index].informacionProceso(), "Informacion de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { }
        }
    }
}
