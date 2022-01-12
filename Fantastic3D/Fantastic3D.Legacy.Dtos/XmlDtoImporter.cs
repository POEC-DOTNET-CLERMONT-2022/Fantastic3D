using System;
using System.Collections.Generic;
using System.Text;

namespace Fantastic3D.Legacy.Dtos
{
    internal class XmlDtoImporter : IDtoImporter<AssetDto>
    {
        // Todo : Globaliser le xmlDataPath entre XmlDataHandler et XmlDtoImporter
        private readonly string _xmlDataPath = Environment.CurrentDirectory + $"/Asset.xml";
        public void ImportData(List<AssetDto> loadedList)
        {
            throw new NotImplementedException();
        }
    }
}
