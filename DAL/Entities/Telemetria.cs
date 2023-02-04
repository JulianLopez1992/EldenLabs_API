namespace DAL.Entities
{
    public class Telemetria
    {
        public int Id { get; set; }
        public string ConnectionDeviceId { get; set; }
        public DateTime EventProcessedUtcTime { get; set; }
        public string HefestoId { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public string VarName { get; set; }
        public int Value { get; set; }
        public string Puglin { get; set; }
        public string Request { get; set; }
        public string VarName1 { get; set; }
        public int Device { get; set; }

    }
}
