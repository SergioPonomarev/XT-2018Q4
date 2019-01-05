using System;

namespace Epam.Task7.Users.BLL.Interfaces
{
    public interface ICacheLogic
    {
        bool Add<T>(string key, T value);

        T Get<T>(string key) where T : class;

        bool Delete(string key);
    }
}
