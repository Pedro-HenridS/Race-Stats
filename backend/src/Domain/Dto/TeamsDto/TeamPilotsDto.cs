using Domain.Dto.PilotsDto;

namespace Domain.Dto.TeamsDto
{
    public class TeamPilotsDto
    {
        public string Team { get; set; }
        public string Color { get; set; }
        public List<PilotDTO> Pilots { get; set; }
    }
}

