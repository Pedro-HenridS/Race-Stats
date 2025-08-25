using Communication.Enums;

namespace Communication.Responses.Pilot
{
    public class PilotResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeSpan Fastestlap { get; set; }
        public decimal Weight { get; set; }
        public GenderDto Gender { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Circuit { get; set; } = string.Empty;
        public Guid TeamId { get; set; }
        public string? TeamName { get; set; }
        public SingleSeaterCategoryDto Category { get; set; }
    }
}
