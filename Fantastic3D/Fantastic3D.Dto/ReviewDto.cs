﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.Dto
{
    [DataContract]
    public class ReviewDto : IWithId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Note { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        private bool IsPublished { get; set; }
        [DataMember]
        public int Asset { get; set; }
        [DataMember]
        public int Author { get; set; }
    }
}
