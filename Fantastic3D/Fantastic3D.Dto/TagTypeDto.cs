﻿using System.Runtime.Serialization;

namespace Fantastic3D.Dto
{

    /// <summary>
    /// Data Transfert Object for a type of tag
    /// </summary>
    [DataContract]
    public class TagTypeDto
    {
        [DataMember]
        public string Name { get; private set; }
        /// <summary>
        /// Defines if at tag is mandatory (needs to be added at least 1 time to an asset)
        /// </summary>
        [DataMember]
        public bool IsMandatory { get; private set; }
        /// <summary>
        /// Defines if a tag must only be used once or can be used multiple times.
        /// </summary>
        public bool IsOnlyOne { get; private set; }
    }
}