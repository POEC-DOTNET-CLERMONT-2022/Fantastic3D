using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Fantastic3D.Legacy.Dtos;

namespace Fantastic3D.Legacy.Services
{ 
     // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class F3DAssetService : IAssetService
    {
        IDtoImporter<AssetDto> _dataImporter = new DummyDtoImporter();
        List<AssetDto> _importedDtos = new List<AssetDto>();

        public F3DAssetService()
        {
            _dataImporter.ImportData(_importedDtos);
        }

        public List<string> GetList(int offset = 0)
        {
            return _importedDtos.Select(asset => asset.Name).ToList();
            // TODO : [Service / GetList()] : coder l'offset et la limite de 10
        }

        AssetDto IAssetService.SearchAssetDto(string modelName)
        {
            try
            {
                var assetDto = _importedDtos.Single(asset => asset.Name.Contains(modelName));
                return assetDto;
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException("Several models found containing those characters : " + modelName, ioe);
            }
        }

        public AssetDto GetAssetDto(int modelId)
        {
            return _importedDtos.Single(asset => asset.Id == modelId);
        }
    }
}
