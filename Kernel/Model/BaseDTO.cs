﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VerFarm.Kernel.Model
{
    [Serializable]
    [DataContract]
    public class BaseDTO
    {
        [DataMember]
        public int Id { get; set; }
    }
}
