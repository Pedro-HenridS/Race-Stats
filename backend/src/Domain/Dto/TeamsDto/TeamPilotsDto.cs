using Domain.Dto.PilotsDto;
using Domain.Enums;

namespace Domain.Dto.TeamsDto
{
    public class TeamPilotsDto
    {
        public string Team { get; set; }
        public SingleSeaterCategory Category { get; set; }
        public string Color { get; set; }
        public List<PilotDTO> Pilots { get; set; }
    }
}

