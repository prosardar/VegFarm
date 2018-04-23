using System;
using System.Runtime.Serialization;

namespace VerFarm.Kernel.Model.DTO
{
    [Serializable]
    [DataContract]
    public class ChangeLogDTO : BaseDTO
    {
        public int ActionId { get; set; }

        public string NewValue { get; set; }

        public string OldValue { get; set; }

        public string EntityName { get; set; }

        public string PrimaryKeyValue { get; set; }

        public string PropertyName { get; set; }

        public string UserName { get; set; }

        public DateTime? DateChanged { get; set; }
    }
}