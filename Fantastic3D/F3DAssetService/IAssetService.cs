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
    [ServiceContract]
    public interface IAssetService
    {

        /// <summary>
        /// Returns the names of the 10 first models found,.
        /// </summary>
        /// <param name="offset">Starts the resulting list with an offset.</param>
        /// <returns></returns>
        [OperationContract]
        List<string> GetList(int offset = 0);

        /// <summary>
        /// Get information about a model from its name.
        /// </summary>
        [OperationContract]
        AssetDto SearchAssetDto(string modelName);
        /// <summary>
        /// Get information about a model from its ID.
        /// </summary>
        [OperationContract]
        AssetDto GetAssetDto(int modelId);
    }
}
