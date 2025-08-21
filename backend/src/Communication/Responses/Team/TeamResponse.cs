using Communication.Responses.Pilot;

namespace Communication.Responses.Team
{
    public class TeamResponse
    {
        public Guid Id { get; set; }
        public string Team { get; set; }
        public string Color { get; set; }
        public List<PilotResponse> Pilots { get; set; }
    }
}
