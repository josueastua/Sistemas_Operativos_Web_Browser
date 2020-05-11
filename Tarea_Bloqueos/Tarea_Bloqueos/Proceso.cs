﻿using System;
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
        //estado = 0 - espera, 1 = Solicitando recursos, 2 = ejecucion,, 3 - ejecutando solicitando, 4 - terminado, 5 - Muerto
        private int[] necesarios, asignados, faltantes;
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
            this.faltantes = new int[8];
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
        public void actualizarVida()
        {
            this.vida -= nuevo;
            if (vida <= 0)
                this.estado = 4;
        }
        public void actualizarEsperado(int esperado)
        {
            this.esperado += esperado;
            if (esperado >= inanicion)
                this.estado = 5;
        }

        public void initVariables(int[] recursos)
        {
            var random = new Random();
            this.vida = random.Next(1, 15);
            if (vida > 1)
                this.nuevo = random.Next(1, vida);
            this.inanicion = random.Next(0, 30);
            if (inanicion != 0)
                inanicion += vida;
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

        public void cargarNecesarios(int[] recursos)
        {
            int aux = 0;
            var random = new Random();
            for (int i = 0; i < recursos.Length; i++)
            {
                aux = random.Next(0, recursos[i] + 1);
                necesarios[i] = aux;
            }
            for (int i = 0; i < necesarios.Length; i++)
            {
                if (asignados[i] >= necesarios[i])
                {
                    aux = asignados[i] - necesarios[i];
                }
            }
        }

        public void liberarRecursos(int[] libres)
        {
            for (int i = 0; i < asignados.Length; i++)
            {
                libres[i] += asignados[i];
                asignados[i] = 0;
                necesarios[i] = 0;
            }
        }

        public string informacionProceso()
        {
            string data = "\r\nInformacion de Proceso\r\n";
            data += "ID: " + this.id;
            if(estado  != 4 && estado != 5)
            {
                data += "\r\nRecursos Necesarios: [ ";
                for (int i = 0; i < necesarios.Length; i++)
                {
                    data += necesarios[i];
                    if (i < necesarios.Length - 1)
                        data += " , ";
                }
                data += " ]\r\nAsignados: [ ";
                for (int i = 0; i < asignados.Length; i++)
                {
                    data += asignados[i];
                    if (i < asignados.Length - 1)
                        data += " , ";
                }
                data += " ]";
            }
            data += "\r\n";
            return data;
        }

        public void cargarFaltantes()
        {
            for (int i = 0; i < 8; i++)
                faltantes[i] = necesarios[i] - asignados[i];
        }

        public bool alcanzanRecursos(int[] libres)
        {
            cargarFaltantes();
            for(int i = 0; i < 8; i++)
            {
                if(faltantes[i] > necesarios[i])
                {
                    return false;
                } 
            }
            return true;
        }

        public void finishHim()
        {
            this.hilo.Abort();
        }
    }
}
