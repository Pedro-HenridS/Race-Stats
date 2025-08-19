using Domain.Dto.PilotsDto;
using Domain.Dto.TeamsDto;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.PilotRepository;
using Exception;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.PilotRepository
{
    public class PilotRepository : IPilotRepository
    {
        private AppDbContext _context;

        public PilotRepository(
            AppDbContext context
        )
        {
            _context = context;
        }
        public async Task<List<CategoryPilotsDto>> GetPilots()
        {
            var pilotos = await _context.Pilots.Include(t => t.Team)
                .GroupBy(p => p.Category)
                .Select(g => new CategoryPilotsDto
                {
                    Category = g.Key,
                    pilotDTOs = g.OrderBy(p => p.Fastestlap).Select(p => new PilotDTO
                    {
                        Name = p.Name,
                        Fastestlap = p.Fastestlap,
                        Weight = p.Weight,
                        Gender = p.Gender,
                        Nationality = p.Nationality,
                        Circuit = p.Circuit,
                        TeamId = p.TeamId,
                        Category = p.Category
                    }).ToList()
                })
                .ToListAsync();

            return pilotos;
        }

        public async Task<List<TeamPilotsDto>> GetPilotsGroupByEquip(string category)
        {

            SingleSeaterCategory category_enum;



            if (Enum.TryParse(category, out SingleSeaterCategory result))
            {
                category_enum = result;
            }
            else
            {
                throw new RaceException(ResourceErrorMessages.BAD_REQUEST, 404);
            }



            var pilotos = await _context.Pilots.Include(t => t.Team).Where(t => t.Category == category_enum).GroupBy(
                p => new { p.Team.Name, p.Team.Color, p.Category })
                .OrderBy(t => t.Key.Category)
                .Select(g => new TeamPilotsDto
                {
                    Team = g.Key.Name,
                    Category = g.Key.Category,
                    Color = g.Key.Color,
                    Pilots = g.Select(p => new PilotDTO
                    {
                        Name = p.Name,
                        Fastestlap = p.Fastestlap,
                        Weight = p.Weight,
                        Gender = p.Gender,
                        Nationality = p.Nationality,
                        Circuit = p.Circuit,
                        TeamId = p.TeamId,
                        Category = p.Category

                    }).OrderBy(p => p.Fastestlap).ToList()
                }).ToListAsync();

            return pilotos;
        }

        public async Task<Pilot> GetPilotById(Guid id)
        {
            var piloto = await _context.Pilots.Where(p => p.Id == id).FirstOrDefaultAsync();

            return piloto;
        }

        public async Task UpdatePilot(Pilot pilot)
        {
            _context.Pilots.Update(pilot);
            await _context.SaveChangesAsync();
        }


    }
}
