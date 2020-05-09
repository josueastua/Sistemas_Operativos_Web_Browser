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
        private int estado; // 0 - espera, 1 = listo, 2 = ejecucion, 3 - terminado, 4 - Muerto
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
        public int getEstado() => estado;
        public void setEstado(int estado) => this.estado = estado;
        public void actualizarTvida() => this.tvida -= this.tespera;
        public void actualizarTte() => this.tte += 1;

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
            for (int i = 0; i < asignados.Length; i++)
                asignados[i] = 0;
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

        public void cargarAsignados(int[] libres)
        {
            int aux = 0;
            var random = new Random();
            for (int i = 0; i < libres.Length; i++)
            {
                aux = random.Next(0, libres[i] + 1);
                if (aux > asignados[i] && aux <= necesarios[i])
                {
                    asignados[i] = aux;
                    libres[i] -= aux;
                }
            }   
        }

        public void cargarNecesarios(int[] libres)
        {
            int aux = 0;
            var random = new Random();
            for (int i = 0; i < libres.Length; i++)
            {
                aux = random.Next(0, libres[i] + 1);
                necesarios[i] = aux;
                libres[i] -= aux;
            }
            for(int i = 0; i < necesarios.Length; i++)
            {
                if(asignados[i] >= necesarios[i])
                {
                    aux = asignados[i] - necesarios[i];
                    libres[i] += aux;
                }
            }
        }

        public Boolean isDead()
        {
            return tte >= tinanicion;
        }
    }
}
