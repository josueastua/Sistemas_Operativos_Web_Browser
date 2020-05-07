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
        private List<Proceso> procesos, listos;
        private Thread creador;
        private int indice;
        private Boolean signal, bloqueo;
        private Proceso p, pactual;

        public Control()
        {
            this.procesos = new List<Proceso>();
            this.listos = new List<Proceso>();
            this.recursos = new int[8];
            this.libres = new int[8];
            this.bloqueo = false;
            indice = 0;
        }

        public void crearProceso()
        {
            if (!bloqueo)
            {
                Thread.Sleep(5000);
                indice++;
                p = new Proceso(indice);
                p.iniciarVariables(recursos);
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
    }
}
