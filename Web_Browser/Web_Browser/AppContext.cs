using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Browser
{
    class AppContext
    {
        private static AppContext instance = null;
        private static Hashtable cache = new Hashtable();
        private static Hashtable context = new Hashtable();
        private static List<String> paginas = new List<string>();
        private static List<String> historial = new List<string>();
        private static List<String> descargas = new List<string>();

        public AppContext() { }

        public static AppContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new AppContext();
                return instance;
            }
        }

        public Object get(String key)
        {
            return context[key];
        }

        public void set(String key, Object obj)
        {
            if(get(key) == null)
            {
                context.Add(key, obj);
            }
            else
            {
                context[key] = obj;
            }
        }

        public Object getCache(String key)
        {
            return cache[key];
        }

        public void setCahce(String key, Object obj)
        {
            if(getCache(key) == null)
            {
                paginas.Add(key);
                cache.Add(key, obj);
            }
        }

        public void setDescargas(string dir)
        {
            descargas.Add(dir);
        }

        public List<String> getDescargas()
        {
            return descargas;
        }

        public List<String> getPaginas()
        {
            return paginas;
        }

        public void clear()
        {
            cache.Clear();
        }

        public void setHistorial(String key)
        {
            historial.Add(key);
        }

        public List<String> getHistorial()
        {
            return historial;
        }

        public Hashtable getCache()
        {
            return cache;
        }

        public void removeCache(String key)
        {
            cache.Remove(key);
        }
    }
}
