using Domain.Enums;

namespace Domain.Dto.PilotsDto
{
    public class PilotRequest
    {
        public string Name { get; set; } = string.Empty;
        public TimeSpan Fastestlap { get; set; }
        public decimal Weight { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Circuit { get; set; } = string.Empty;
        public Guid TeamId { get; set; }
        public bool Leader { get; set; }
        public SingleSeaterCategory Category { get; set; }
    }
}
