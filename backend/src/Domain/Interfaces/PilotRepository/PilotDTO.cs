

using Domain.Enums;

namespace Domain.Interfaces.PilotRepository
{
    public class PilotDTO
    {
        public string Name { get; set; } = string.Empty;
        public TimeSpan Fastestlap { get; set; }
        public decimal Weight { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Circuit { get; set; } = string.Empty;
        public Guid TeamId { get; set; }
        public SingleSeaterCategory Category { get; set; }
    }
}
