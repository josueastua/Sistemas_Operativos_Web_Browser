using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea1
{
    class Proceso
    {
        public int id;
        public int[] recursos;
        public int[] solicitud;//Cantidad de recursos que va a solicitar
        public int vida;//Tiempo total que requiere para ser ejecutado
        public int inanicion;//Tiempo maximo que esperara entes de ser elimincado de la cola de procesoso
        public int espera;//Tiempo que aguardara antes de solicitar nuevamente recursoso
        public Boolean estado;

        public Proceso(){
            estado = false;
        }

        public Proceso(int id, int[] recursos)
        {
            this.id = id;
            this.recursos = recursos;
            solicitud = new int[recursos.Length];
            iniciarVariables();
        }

        public int getId() => id;
        public int[] getSolicitud() => solicitud;
        public int getVida() => vida;
        public int getInanicion() => inanicion;
        public int getEspera() => espera;
        public Boolean getEstado() => estado;
        public void iniciarVariables()
        {
            var random = new Random();
            vida = random.Next(1, 100);
            inanicion = random.Next(0, 100);
            espera = random.Next(1, 100);
            for(int i = 0; i < recursos.Length; i++)
            {
                solicitud[i] = random.Next(0, recursos[i] + 1);
            }
        }
        public void cambioEstado() => estado = !estado;
    }
}
