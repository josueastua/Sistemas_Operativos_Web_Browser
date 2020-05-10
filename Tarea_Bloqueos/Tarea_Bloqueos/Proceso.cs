using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tarea_Bloqueos
{
    class Proceso
    {
        private int id, vida, inanicion, esperado, nuevo, asignar, estado;
        //esperado = tiempo total esperado
        //nuevo = en ejecucion cambiara recursoso necesarios
        //asignar = intervalo de tiempo en que solicitara nuevos recursos
        //estado = 0 - espera, 1 = Solicitando recursos, 2 = ejecucion, 3 - terminado, 4 - Muerto
        private int[] necesarios, asignados;
        private Thread hilo;

        public Proceso() { }

        public Proceso(int id)
        {
            this.id = id;
            this.vida = 0;
            this.inanicion = 0;
            this.esperado = 0;
            this.nuevo = 0;
            this.asignar = 0;
            this.necesarios = new int[8];
            this.asignados = new int[8];
        }

        public int getId() => id;
        public int getVida() => vida;
        public int getInanicion() => inanicion;
        public int getEsperado() => esperado;
        public int getNuevo() => nuevo;
        public int getAsignar() => asignar;
        public int getEstado() => estado;
        public void setEstado(int estado) => this.estado = estado;
        public Thread getHilo() => hilo;
        public void actualizarVida() => this.vida -= nuevo;
        public void actualizarEsperado(int esperado) => this.esperado += esperado;
        public bool isDead() => this.esperado >= this.inanicion;

        public void initVariables(int[] recursos)
        {
            var random = new Random();
            this.vida = random.Next(1, 15);
            if (vida > 1)
                this.nuevo = random.Next(1, vida);
            this.inanicion = random.Next(0, 30);
            this.asignar = random.Next(1, 6);
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
            for (int i = 0; i < necesarios.Length; i++)
            {
                if (asignados[i] >= necesarios[i])
                {
                    aux = asignados[i] - necesarios[i];
                    libres[i] += aux;
                }
            }
        }

        public void liberarRecursos(int[] libres)
        {
            for (int i = 0; i < asignados.Length; i++)
                libres[i] += asignados[i];
        }

        public string informacionProceso()
        {
            string data = "Informacion de Proceso\n";
            data += "ID: " + this.id + "\nRecursos Necesarios: [ ";
            for (int i = 0; i < necesarios.Length; i++)
            {
                data += necesarios[i];
                if (i < necesarios.Length - 1)
                    data += " , ";
            }
            data += " ]\nRecursos Necesarios: [ ";
            for (int i = 0; i < asignados.Length; i++)
            {
                data += asignados[i];
                if (i < asignados.Length - 1)
                    data += " , ";
            }
            data += "\n";
            return data;
        }
    }
}
