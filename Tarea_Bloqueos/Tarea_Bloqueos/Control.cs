using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tarea_Bloqueos
{
    class Control
    {
        private int[] recursos, libres;
        private List<Proceso> procesos, espera, solicitarliberar, ejecutando, terminados, muertos;
        private Thread creador, auxiliar;
        private int index;
        private bool bloqueo;
        private Proceso paux;

        public Control()
        {
            this.procesos = new List<Proceso>();
            this.espera = new List<Proceso>();
            this.solicitarliberar = new List<Proceso>();
            this.ejecutando = new List<Proceso>();
            this.muertos = new List<Proceso>();
            this.terminados = new List<Proceso>();
            this.recursos = new int[] {50, 10, 25, 35, 60, 80, 15, 11};
            this.libres = recursos;
            this.bloqueo = false;
            this.index = 0;
        }

        public bool getBloqueo() => bloqueo;
        public List<Proceso> getEspera() => espera;
        public List<Proceso> getEjecutando() => ejecutando;
        public List<Proceso> getTerminados() => terminados;
        public List<Proceso> getMuertos() => muertos;

        public void initSimulador()
        {
            creador = new Thread(crearProceso);
            creador.Start();
        }

        public void crearProceso()
        {
            while(!bloqueo)
            {
                Thread.Sleep(5000);
                index++;
                paux = new Proceso(index);
                paux.initVariables(recursos);
                auxiliar = paux.getHilo();
                auxiliar = new Thread(funcionProceso);
                auxiliar.Start(paux);
                procesos.Add(paux);
                espera.Add(paux);
                bloqueo = determinarBloqueo();
            }
            terminarTodo();
        }

        public void funcionProceso(object process) 
        {
            paux = (Proceso)process;
            bool ciclo = true;
            while (ciclo)
            {
                switch (paux.getEstado())
                {
                    case 0:
                        Thread.Sleep(paux.getAsignar());
                        paux.actualizarEsperado(paux.getAsignar());
                        if (paux.getEstado() != 5)
                            paux.setEstado(1);
                        else
                        {
                            muertos.Add(paux);
                            espera.Remove(paux);
                        }
                            
                        solicitarliberar.Add(paux);
                        break;
                    case 1:
                        if (solicitarliberar.IndexOf(paux) == 0)
                        {
                            paux.cargarAsignados(libres);
                            if (paux.puedeEjecutarse())
                            { 
                                paux.setEstado(2);
                                ejecutando.Add(paux);
                                espera.Remove(paux);
                            }
                            else
                            {
                                paux.setEstado(1);
                            }
                            solicitarliberar.Remove(paux);
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            paux.actualizarEsperado(1);
                            if (paux.getEstado() == 5)
                            {
                                muertos.Add(paux);
                                espera.Remove(paux);
                            }
                                
                        }
                        break;
                    case 2:
                        Thread.Sleep(paux.getNuevo());
                        paux.actualizarVida();
                        if (paux.getEstado() != 4)
                            paux.setEstado(3);
                        else
                        {
                            terminados.Add(paux);
                            espera.Remove(paux);
                            ejecutando.Remove(paux);
                        }
                        solicitarliberar.Add(paux);
                        break;
                    case 3:
                        if(solicitarliberar.IndexOf(paux) == 0)
                        {
                            paux.cargarNecesarios(recursos);
                            if (paux.puedeEjecutarse())
                            {
                                paux.setEstado(2);
                            }
                            else
                            {
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
                            if (paux.getEstado() == 5)
                            {
                                muertos.Add(paux);
                                espera.Remove(paux);
                            }
                                
                        }
                        break;
                    case 4:
                        if(solicitarliberar.IndexOf(paux) == 0)
                        {
                            paux.liberarRecursos(libres);
                        }
                        Thread.Sleep(1000);
                        break;
                    case 5:
                        if (solicitarliberar.IndexOf(paux) == 0)
                        {
                            paux.liberarRecursos(libres);
                        }
                        Thread.Sleep(1000);
                        break;
                    default:
                        break;
                }
            }

        }

        public bool determinarBloqueo() { 
            for(int i = 0; i < procesos.Count; i++)
            {
                procesos[i].cargarFaltantes();
                if (procesos[i].alcanzanRecursos(libres))
                    return false;
            }
            return true;
        }

        public void terminarTodo()
        {
            for(int i = 0; i < procesos.Count; i++)
            {
                procesos[i].finishHim();
            }
            creador.Abort();
        }
    }
}
