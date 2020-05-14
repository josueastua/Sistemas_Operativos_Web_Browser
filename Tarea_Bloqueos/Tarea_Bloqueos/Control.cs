using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace Tarea_Bloqueos
{
    class Control
    {
        private int[] recursos, libres;
        private List<Proceso> procesos, espera, solicitarliberar, ejecutando, terminados, muertos;
        private Thread creador;
        private int index;
        private bool bloqueo;

        public Control()
        {
            this.procesos = new List<Proceso>();
            this.espera = new List<Proceso>();
            this.solicitarliberar = new List<Proceso>();
            this.ejecutando = new List<Proceso>();
            this.muertos = new List<Proceso>();
            this.terminados = new List<Proceso>();
            this.recursos = new int[] { 50, 10, 25, 35, 60, 80, 15, 11 };
            this.libres = new int[] { 50, 10, 25, 35, 60, 80, 15, 11 };
            this.bloqueo = false;
            this.index = 0;
        }

        public bool getBloqueo() => bloqueo;
        public List<Proceso> getEspera() => espera;
        public List<Proceso> getEjecutando() => ejecutando;
        public List<Proceso> getTerminados() => terminados;
        public List<Proceso> getMuertos() => muertos;
        public int[] getRecursos() => recursos;
        public int[] getLibres() => libres;

        public void initSimulador()
        {
            creador = new Thread(crearProceso);
            creador.Start();
        }

        public void crearProceso()
        {
            while (true)
            {
                index++;
                Proceso paux = new Proceso(index);
                paux.initVariables(recursos);
                Thread auxiliar = new Thread(funcionProceso);
                procesos.Add(paux);
                espera.Add(paux);
                paux.setHilo(auxiliar);
                auxiliar.Start(paux);
                bloqueo = determinarBloqueo();
                Thread.Sleep(10000);
            }
        }

        public void funcionProceso(object process)
        {
            Proceso paux = (Proceso)process;
            bool ciclo = true;
            while (ciclo)
            {
                switch (paux.getEstado())
                {
                    case 0:
                        Thread.Sleep(paux.getAsignar() * 1000);
                        paux.actualizarEsperado(paux.getAsignar());
                        if (!paux.isDead())
                            paux.setEstado(1);
                        else
                        {
                            paux.setEstado(5);
                            muertos.Add(paux);
                            espera.Remove(paux);
                        }
                        solicitarliberar.Add(paux);
                        break;
                    case 1:
                        if (solicitarliberar.IndexOf(paux) == 0)
                        {
                            cargarAsignados(paux.getAsignados(), paux.getNecesarios());
                            if (paux.puedeEjecutarse())
                            {
                                paux.setEstado(2);
                                ejecutando.Add(paux);
                                espera.Remove(paux);
                            }
                            else
                                paux.setEstado(0);
                            solicitarliberar.Remove(paux);
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            paux.actualizarEsperado(1);
                            if (paux.isDead())
                            {
                                paux.setEstado(5);
                                muertos.Add(paux);
                                espera.Remove(paux);
                            }
                        }
                        break;
                    case 2:
                        Thread.Sleep(paux.getNuevo() * 1000);
                        paux.actualizarEjecutado();
                        if (!paux.isEnd())
                            paux.setEstado(3);
                        else
                        {
                            paux.setEstado(4);
                            terminados.Add(paux);
                            ejecutando.Remove(paux);
                        }
                        solicitarliberar.Add(paux);
                        break;
                    case 3:
                        if (solicitarliberar.IndexOf(paux) == 0)
                        {
                            cargarNecesarios(paux.getNecesarios(), paux.getAsignados());
                            if (paux.puedeEjecutarse())
                                paux.setEstado(2);
                            else
                            {
                                paux.actualizarEsperado(0);
                                paux.setEstado(1);
                                ejecutando.Remove(paux);
                                espera.Add(paux);
                            }
                            solicitarliberar.Remove(paux);
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            paux.actualizarEsperado(1);
                            if (paux.isDead())
                            {
                                paux.setEstado(5);
                                muertos.Add(paux);
                            }
                        }
                        break;
                    case 4:
                        if (solicitarliberar.IndexOf(paux) == 0)
                        {
                            liberarRecursos(paux.getAsignados(), paux.getNecesarios());
                            solicitarliberar.Remove(paux);
                            ciclo = false;
                        }
                        Thread.Sleep(1000);
                        break;
                    case 5:
                        if (solicitarliberar.IndexOf(paux) == 0)
                        {
                            liberarRecursos(paux.getAsignados(), paux.getNecesarios());
                            solicitarliberar.Remove(paux);
                            ciclo = false;
                        }
                        Thread.Sleep(1000);
                        break;
                    default:
                        break;
                }
            }
            paux.finishHim();
        }

        private void cargarNecesarios(int[] necesarios, int[] asignados)
        {
            int aux = 0;
            var random = new Random();
            for (int i = 0; i < 8; i++)
            {
                aux = random.Next(0, recursos[i] + 1);
                necesarios[i] = aux;
            }
            for (int i = 0; i < 8; i++)
            {
                if (asignados[i] > necesarios[i])
                {
                    aux = asignados[i] - necesarios[i];
                    asignados[i] = necesarios[i];
                    libres[i] += aux;
                }
            }
        }

        private void liberarRecursos(int[] asignados, int[] necesarios)
        {
            for (int i = 0; i < 8; i++)
            {
                libres[i] += asignados[i];
                asignados[i] = 0;
                necesarios[i] = 0;
            }
        }

        private void cargarAsignados(int[] asignados, int[] necesarios)
        {
            int aux = 0;
            var random = new Random();
            for (int i = 0; i < 8; i++)
            {
                aux = random.Next(0, libres[i] + 1);
                if (aux > asignados[i] && aux <= necesarios[i])
                {
                    asignados[i] = aux;
                    libres[i] -= aux;
                }
            }
        }

        public bool determinarBloqueo()
        {
            for (int i = 0; i < espera.Count; i++)
            {
                espera[i].cargarFaltantes();
                if (espera[i].alcanzanRecursos(libres))
                    return false;
            }
            return true;
        }

        public void terminarTodo()
        {
            for (int i = 0; i < procesos.Count; i++)
            {
                procesos[i].finishHim();
            }
            creador.Abort();
        }

    }
}
