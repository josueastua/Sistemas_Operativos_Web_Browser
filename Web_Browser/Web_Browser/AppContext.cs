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
        private static List<String> paginas = new List<string>();
        private static List<String> historial = new List<string>();

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
            return cache[key];
        }

        public void set(String key, Object obj)
        {
            if(get(key) == null)
            {
                paginas.Add(key);
                cache.Add(key, obj);
            }
            else
            {
                cache[key] = obj;
            }
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
    }
}
