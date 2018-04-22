namespace VerFarm.Kernel.Data
{
    internal class AuditTrail
    {
        public string NewData { get; internal set; }
        public string Actions { get; internal set; }
        public string OldData { get; internal set; }
        public string UserName { get; internal set; }
        public string TableIdValue { get; internal set; }
        public string TableName { get; internal set; }
        public string ChangedColums { get; internal set; }

        public AuditTrail()
        {
        }

    }
}