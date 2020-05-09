﻿using System;
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
        private List<Proceso> procesos, listos, muertos, terminados;
        private Thread creador;
        private int indice;
        private Boolean signal/*si se estan asignado recursos*/, bloqueo;
        private Proceso p, pactual;

        public Control()
        {
            this.procesos = new List<Proceso>();
            this.listos = new List<Proceso>();
            this.muertos = new List<Proceso>();
            this.terminados = new List<Proceso>();
            this.recursos = new int[8];
            this.libres = new int[8];
            this.bloqueo = false;
            indice = 0;
            signal = false;
        }

        public void crearProceso()
        {
            if (!bloqueo)
            {
                Thread.Sleep(5000);
                indice++;
                p = new Proceso(indice);
                p.iniciarVariables(recursos);
                while (signal)
                    Console.WriteLine("Esperando...crearProceso");
                signal = true;
                asignarRecursos();
                signal = false;
                
                //Aqui se crea el hilo con el funcionamiento
                //Pero antes hay que implementar peterson
            }
        }

        public void iniciarSimulacion()
        {
            creador = new Thread(crearProceso);
            creador.Start();
        }

        public void asignarRecursos()
        {
            for(int i = 0; i < procesos.Count; i++)
            {
                procesos[i].cargarAsignados(libres);
            }
        }

        public void funcionProceso(object process)
        {
            Proceso p = (Proceso)process;
            while(true)
            {
                Thread.Sleep(1000);
                switch (p.getEstado())
                {
                    case 0://Espera
                        if (p.puedeEjecutarse())
                            p.setEstado(1);
                        else
                        {
                            p.actualizarTte();
                            if (p.isDead())
                                p.setEstado(4);
                        }
                        break;
                    case 1://Listo
                        if (listos.IndexOf(p) == 0)
                            p.setEstado(2);
                        break;
                    case 2://En ejecucion
                        while(p.getEstado() == 2)
                        {
                            Thread.Sleep(p.getTespera());
                            p.actualizarTvida();
                            if (p.getTvida() > 0)
                            {
                                while (signal) { }
                                signal = true;
                                p.cargarNecesarios(libres);
                                signal = false;
                                if (!p.puedeEjecutarse())
                                    p.setEstado(1);
                            }
                            else
                                p.setEstado(3);
                        }
                        break;
                    case 3:
                        procesos.Remove(p);
                        terminados.Add(p);
                        break;
                    case 4:
                        procesos.Remove(p);
                        muertos.Add(p);
                        break;
                    default:
                        break;
                }
                if(p.getEstado() == 3 || p.getEstado() == 4)
                {
                    p.getHilo().Abort();
                    break;
                }
            }
        }
    }
}
