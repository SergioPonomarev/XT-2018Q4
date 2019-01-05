using Epam.Task7.Users.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.BLL
{
    public class CacheLogic : ICacheLogic
    {
        private static Dictionary<string, object> data = new Dictionary<string, object>();

        public bool Add<T>(string key, T value)
        {
            if (data.ContainsKey(key))
            {
                return false;
            }

            data.Add(key, value);

            return true;
        }

        public bool Delete(string key)
        {
            return data.Remove(key);
        }

        public T Get<T>(string key) where T : class
        {
            if (!data.ContainsKey(key))
            {
                return null;
            }

            return data[key] as T;
        }
    }
}
