using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VerFarm.Kernel.Model.DTO
{
    [Serializable]
    [DataContract]
    public class BaseDTO : IBaseDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public bool IsError { get; set; }
        [DataMember]
        public string Message { get; set; }

        public void SetError(string message, params object[] args)
        {
            IsError = true;
            Message = string.Format(message, args);
        }
    }
}
