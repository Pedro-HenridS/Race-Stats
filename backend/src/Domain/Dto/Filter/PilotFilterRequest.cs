using Domain.Enums;

namespace Domain.Dto.Filter
{
    public class PilotFilterRequest
    {
        public Guid? Team { get; set; }
        public Gender? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? Circuit { get; set; }
        public Weight? weight { get; set; }
    }
}
