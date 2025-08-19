using Communication.Enums;
using Communication.Responses.Pilot;
using Domain.Entities;

namespace Application.Mapping
{
    public class PilotMapping
    {
        public PilotResponse MapToResponse(Pilot pilot)
        {
            return new PilotResponse
            {
                Name = pilot.Name,
                Fastestlap = pilot.Fastestlap,
                Weight = pilot.Weight,
                Gender = (Gender)pilot.Gender,
                Nationality = pilot.Nationality,
                Circuit = pilot.Circuit,
                TeamId = pilot.TeamId,
                Category = pilot.Category.ToString()
            };
        }
    }
}
