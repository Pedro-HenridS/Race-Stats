using Domain.Enums;

namespace Domain.Dto.PilotsDto
{
    public class CategoryPilotsDto
    {
        public SingleSeaterCategory Category { get; set; }
        public List<PilotDTO> pilotDTOs { get; set; }
    }
}
