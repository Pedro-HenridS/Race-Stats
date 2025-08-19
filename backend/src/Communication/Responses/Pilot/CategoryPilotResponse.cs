using Communication.Responses.Pilot;

namespace Domain.Dto.PilotsDto
{
    public class CategoryPilotResponse
    {
        public string Category { get; set; }
        public List<PilotResponse> pilotDTOs { get; set; }
    }
}
