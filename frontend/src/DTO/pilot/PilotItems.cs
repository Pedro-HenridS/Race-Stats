using src.Common.Enums.Pilot;

namespace src.DTO.pilot
{
    public class PilotItems
    {
        public string Name { get; set; }
        public TimeSpan Fastestlap { get; set; }
        public decimal Weight { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Circuit { get; set; }
        public Guid TeamId { get; set; }
        public string Category { get; set; }
    }
}
