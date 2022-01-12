using System;
using System.Runtime.Serialization;
/// <summary>
/// This namespace contains DTO and Readers compliant with older versions of .NET
/// </summary>
namespace Fantastic3D.Legacy.Dtos
{
    [DataContract]
    public class AssetDto
    {
        [DataMember]
        public string Name { get; }
        [DataMember]
        public int Id { get; }
        [DataMember]
        private string _description;
        [DataMember]
        private float _price;
        [DataMember]
        private string _creator;


        public AssetDto(int id, string name, string description, float price, string creator)
        {
            Id = id;
            Name = name;
            _description = description;
            _price = price;
            _creator = creator;
        }
    }
}
