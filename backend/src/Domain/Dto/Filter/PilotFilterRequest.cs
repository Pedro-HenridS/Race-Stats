using Domain.Enums;

namespace Domain.Dto.Filter
{
    public class PilotFilterRequest
    {
        public string? Team { get; set; }
        public Gender? Gender { get; set; }
        public string? Nationality { get; set; }
    }
}
