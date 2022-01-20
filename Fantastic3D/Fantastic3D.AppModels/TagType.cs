using System.Runtime.Serialization;
using Fantastic3D.DataManager;
namespace Fantastic3D.AppModels
{

    /// <summary>
    /// A type of tag, with tag constraints
    /// </summary>
 
    public class TagType : ObservableModel, IManageable
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        /// <summary>
        /// Defines if at tag is mandatory (needs to be added at least 1 time to an asset)
        /// </summary>
     
        public bool IsMandatory { get; private set; }
        /// <summary>
        /// Defines if a tag must only be used once or can be used multiple times.
        /// </summary>
        public bool IsOnlyOne { get; private set; }

        public TagType(string name, bool isMandatory, bool isOnlyOne)
        {
            Name = name;
            IsMandatory = isMandatory;
            IsOnlyOne = isOnlyOne;
        }

        public override string ToString()
        {
            return $"{Name} (" + (IsMandatory ? "obligatoire " : "") + (IsOnlyOne ? "unique" : "plusieurs") + ").";
        }
    }
}