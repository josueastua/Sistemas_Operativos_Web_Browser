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
        private List<Proceso> espera, ejecutando, terminados, muertos;
        private Thread creador, auxiliar;
        private int index;
        private bool signal, bloqueo;
        private Proceso paux;

        public Control()
        {
            this.espera = new List<Proceso>();
            this.ejecutando = new List<Proceso>();
            this.muertos = new List<Proceso>();
            this.terminados = new List<Proceso>();
            this.recursos = new int[8];
            this.libres = new int[8];
            this.bloqueo = false;
            this.index = 0;
            this.signal = false;
        }

        public void initSimulador()
        {
            creador = new Thread(crearProceso);
            creador.Start();
        }

        public void crearProceso()
        {
            if (!bloqueo)
            {
                Thread.Sleep(5000);
                index++;
                paux = new Proceso(index);
                paux.initVariables(recursos);
            }
        }

        public void funcionProceso(object process) { }

        public void determinarBloqueo() { }
    }
}
