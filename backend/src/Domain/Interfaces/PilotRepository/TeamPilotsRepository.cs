using Domain.Enums;

namespace Domain.Interfaces.PilotRepository
{
    public class TeamPilotsRepository
    {
        public string Team { get; set; }
        public SingleSeaterCategory Category { get; set; }
        public List<PilotDTO> Pilots { get; set; }
    }
}

