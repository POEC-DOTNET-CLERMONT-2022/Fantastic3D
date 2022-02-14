using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.GUI.Utilities
{
    public class ServiceProvider : IServiceProvider
    {
        private Dictionary<Type, object> _services = new();
        public T GetService<T>() where T : class
        {
            return _services.GetValueOrDefault(typeof(T)) as T;
        }

        public void RegisterService<T>(T service) where T : class
        {
            _services.Add(typeof(T), service);
        }
    }
}
