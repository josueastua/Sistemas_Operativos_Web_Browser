using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tarea_Bloqueos
{
    class Proceso
    {
        private int id;
        private int[] necesarios;
        private int[] asignados;
        private int tvida;
        private int tinanicion;
        private int tespera;
        private int tte;
        private Thread hilo;

        public Proceso() { }

        public Proceso(int id)
        {
            this.id = id;
            this.necesarios = new int[8];
            this.asignados = new int[8];
            this.tvida = 0;
            this.tinanicion = 0;
            this.tespera = 0;
            this.tte = 0;
        }

        public int getId() => id;
        public int getTvida() => tvida;
        public int getTinanicion() => tinanicion;
        public int getTespera() => tespera;
        public int getTte() => tte;
        public Thread getHilo() => hilo;

        public void iniciarVariables(int[] recursos)
        {
            var random = new Random();
            tvida = random.Next(1, 10);
            while(tespera < tvida)
                tespera = random.Next(1, 10);
            while (tinanicion <= tvida && tinanicion != 0)
                tinanicion = random.Next(0, 10);
            for (int i = 0; i < recursos.Length; i++)
                necesarios[i] = random.Next(0, recursos[i] + 1);
        }

        public Boolean puedeEjecutarse()
        {
            for (int i = 0; i < necesarios.Length; i++)
            {
                if (necesarios[i] < asignados[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void restarRecursos(int[] libres)
        {
            for (int i = 0; i < libres.Length; i++)
            {
                libres[i] -= asignados[i];
            }
        }
    }
}
