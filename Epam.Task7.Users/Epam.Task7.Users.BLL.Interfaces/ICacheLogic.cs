using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.BLL.Interfaces
{
    public interface ICacheLogic
    {
        bool Add<T>(string key, T value);

        T Get<T>(string key) where T : class;

        bool Delete(string key);
    }
}
