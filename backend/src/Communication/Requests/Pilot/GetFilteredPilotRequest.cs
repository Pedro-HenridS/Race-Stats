using Communication.Enums;

namespace Communication.Requests.Pilot
{
    public class GetFilteredPilotRequest
    {
        public Guid? Team { get; set; }
        public GenderDto? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? Circuit { get; set; }
        public Weight? weight { get; set; }
        public string? Search { get; set; }
    }
}
