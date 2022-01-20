using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.Dto
{
    /// <summary>
    /// Defines classes that contains an Id.
    /// </summary>
    internal interface IWithId
    {
        public int Id { get; set; }
    }
}
