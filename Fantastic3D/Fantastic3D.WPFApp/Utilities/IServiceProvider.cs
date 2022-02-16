using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.GUI.Utilities
{
    public interface IServiceProvider
    {
        void RegisterService<T>(T service) where T : class;
        T GetService<T>() where T : class;
    }
}
