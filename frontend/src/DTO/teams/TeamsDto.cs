using src.DTO.pilot;

namespace src.DTO.teams
{
    public class TeamsDto
    {
        public Guid Id { get; set; }
        public string Team { get; set; } = string.Empty;
        public string Color { get; set; }
        public List<PilotItems> Pilots { get; set; }
    }
}
