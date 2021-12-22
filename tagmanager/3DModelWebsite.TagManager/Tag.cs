using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The3DModelWebsite.Tags
{
    /// <summary>
    /// Defines a Tag. A tags holds a name and belongs to a tagType
    /// </summary>
    internal class Tag
    {
        private string _name;
        private TagType _tagType;

        public Tag(string name, TagType tagType)
        {
            _name = name;
            _tagType = tagType;
        }

        public override string ToString()
        {
            return $"{_name} (of type {_tagType.Name})";
        }
        public void Rename(string newName)
        {
            _name = newName;
        }
    }
}
