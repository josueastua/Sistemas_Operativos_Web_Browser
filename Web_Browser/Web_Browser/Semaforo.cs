using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

struct elemento
{
    public String url;
    public String html;
}

namespace Web_Browser
{
    class Semaforo
    {
        bool recurso;
        List<elemento> guardar = new List<elemento>();
        Thread hilo;

        public Semaforo(bool recurso)
        {
            this.recurso = recurso;
        }

        public void initSemaforo()
        {
            hilo = new Thread(esperaGuardar);
            hilo.Start();
        }

        public void EscribirCache(elemento e)
        {
            if (recurso)
            {
                recurso = false;
                AppContext.Instance.setCahce(e.url, e.html);
                recurso = true;
            }
            else
            {
                guardar.Add(e);
            }
        }

        public void esperaGuardar()
        {
            while (true)
            {
                if(recurso && guardar.Count > 0)
                {
                    recurso = false;
                    elemento e = guardar[0];
                    AppContext.Instance.set(e.url, e.html);
                    guardar.Remove(e);
                    recurso = true;
                }
            }
        }
    }
}
