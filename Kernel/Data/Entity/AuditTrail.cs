using System;

namespace VerFarm.Kernel.Data
{
    internal class ChangeLog
    {
        public int Id { get; set; }
        public int ActionId { get; internal set; }
        public string NewValue { get; internal set; }
        public string OldValue { get; internal set; }                        
        public string EntityName { get; internal set; }
        public string PrimaryKeyValue { get; internal set; }
        public string PropertyName { get; internal set; }
        public string UserName { get; internal set; }
        public DateTime DateTimeChanged { get; internal set; }

        public ChangeLog()
        {
        }

    }
}