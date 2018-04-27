using System;
using System.Runtime.Serialization;

namespace VerFarm.Kernel.Model.DTO
{
    [Serializable]
    [DataContract]
    public class ChangeLogDTO : BaseDTO
    {
        [DataMember]
        public int ActionId { get; set; }

        [DataMember]
        public string NewValue { get; set; }

        [DataMember]
        public string OldValue { get; set; }

        [DataMember]
        public string EntityName { get; set; }

        [DataMember]
        public string PrimaryKeyValue { get; set; }

        [DataMember]
        public string PropertyName { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public DateTime? DateChanged { get; set; }
    }
}