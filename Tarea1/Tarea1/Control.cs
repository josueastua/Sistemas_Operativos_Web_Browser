using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tarea1
{
    class Control
    {
        private int[] recursos;
        private int[] libres;
        private List<Proceso> procesos;
        private List<Thread> hilos;
        private Proceso p, pactual;
        private int count = 0;
        private Boolean bloqueo;

        public Control()
        {
            procesos = new List<Proceso>();
            hilos = new List<Thread>();
            bloqueo = false;
        }

        public void iniciarSimulacion()
        {
            Thread t = new Thread(crearProceso);
            hilos.Add(t);
            t.Start();
        }

        public Control(int[] recursos, List<Proceso> procesos)
        {
            this.recursos = recursos;
            this.procesos = procesos;
        }

        public void crearProceso()
        {
            if (!bloqueo) { 
                Thread.Sleep(10000);
                count++;
                p = new Proceso(count, recursos, libres);
                procesos.Add(p);
                Thread t = new Thread(funcionProceso);
                t.Start(p);
            }

        }

        public void funcionProceso(Object p)
        {
            Proceso paux = (Proceso)p;
            if(procesos.Count == 1)
            {

            }
            else
            {
                Thread.Sleep(paux.getEspera());

            }
        }
    }
}
