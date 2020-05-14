using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_Bloqueos
{
    class Proceso
    {
        private int id, vida, inanicion, esperado, nuevo, asignar, estado, ejecutado;
        //esperado = tiempo total esperado
        //nuevo = en ejecucion cambiara recursoso necesarios
        //asignar = intervalo de tiempo en que solicitara nuevos recursos
        //estado = 0 - espera, 1 = Solicitando recursos, 2 = ejecucion,, 3 - ejecutando solicitando, 4 - terminado, 5 - Muerto
        private int[] necesarios, asignados, faltantes;
        private Thread hilo;
        private ListViewItem vista;
        String[] cont;

        public Proceso() { }

        public Proceso(int id)
        {
            this.id = id;
            this.vida = 0;
            this.inanicion = 0;
            this.esperado = 0;
            this.nuevo = 0;
            this.asignar = 0;
            this.ejecutado = 0;
            this.necesarios = new int[8];
            this.asignados = new int[8];
            this.faltantes = new int[8];
            this.vista = new ListViewItem();
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
        public void setHilo(Thread hilo) => this.hilo = hilo;
        public int[] getNecesarios() => necesarios;
        public int[] getAsignados() => asignados;
        public String[] getVista() => cont;
        public void actualizarEjecutado()
        {
            this.ejecutado += nuevo;
        }
        public void actualizarEsperado(int esperado)
        {
            if(esperado == 0)
            {
                this.esperado = esperado;
            }
            else
            {
                this.esperado += esperado;
            }
        }

        public bool isDead()
        {
            return esperado >= inanicion && inanicion != 0;
        }

        public bool isEnd()
        {
            if (inanicion == 0)
                return false;
            return ejecutado >= vida;
        }

        public void initVariables(int[] recursos)
        {
            int aux;
            var random = new Random();
            this.vida = random.Next(1, 9);
            if (vida > 1)
                this.nuevo = random.Next(1, vida);
            this.inanicion = random.Next(0, 15);
            if (inanicion != 0 && inanicion <= vida)
                inanicion = vida + 1;
            this.asignar = random.Next(0, 2);
            for (int i = 0; i < 8; i++)
            {
                necesarios[i] = random.Next(0, recursos[i] + 1);
                aux = random.Next(5, 11);
                if (necesarios[i] > aux)
                    necesarios[i] -= aux;
            }
            for (int i = 0; i < asignados.Length; i++)
                asignados[i] = 0;
            this.cont = new string[]{ id.ToString(), vida.ToString(), ejecutado.ToString(), inanicion.ToString(), esperado.ToString() };
        }

        public Boolean puedeEjecutarse()
        {
            for (int i = 0; i < 8; i++)
            {
                if (necesarios[i] != asignados[i])
                {
                    return false;
                }
            }
            return true;
        }

        public string informacionProceso()
        {
            string data = "\r\nInformacion de Proceso\r\n";
            data += "ID: " + this.id+"\r\nTiempo de vida: "+vida+"\r\nTiempo Ejecutado: "+ejecutado+"\r\nTiempo de Inanicion: "+inanicion+"\r\nTiempo esperado: "+esperado+"\r\n";
            data += "Recursos Necesarios: [ ";
            for (int i = 0; i < necesarios.Length; i++)
            {
                data += necesarios[i];
                if (i < necesarios.Length - 1)
                    data += ", ";
            }
            data += " ]\r\nRecursos Asignados: [ ";
            for (int i = 0; i < asignados.Length; i++)
            {
                data += asignados[i];
                if (i < asignados.Length - 1)
                    data += ", ";
            }
            data += " ]";
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
                if (libres[i] < faltantes[i])
                {
                    return false;
                } 
            }
            return true;
        }

        public void finishHim()
        {
            this.hilo.Abort();
            this.hilo = null;
        }

        public void actualizarVista()
        {
            this.cont = new string[]{ id.ToString(), vida.ToString(), ejecutado.ToString(), inanicion.ToString(), esperado.ToString() };
        }
    }
}
