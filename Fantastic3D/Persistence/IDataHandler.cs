using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.Persistence
{
    /// <summary>
    /// Les éléments de cette interface peuvent
    /// </summary>
    public interface IDataHandler
    {
        public void SaveData(string dataIdentifier, object obj);
        public object LoadData(string dataIdentifier);
    }
}