using Domain.Entities;
using Domain.Interfaces.PilotRepository;
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
        public async Task<List<Pilot>> GetPilots()
        {
            var pilotos = await _context.Pilots.Include(t => t.Team).OrderBy(p => p.Fastestlap).ToListAsync();

            return pilotos;
        }

        public async Task<List<TeamPilotsRepository>> GetPilotsGroupByEquip()
        {
            var pilotos = await _context.Pilots.Include(t => t.Team).GroupBy(
                p => new { p.Team.Name, p.Team.Color, p.Category })
                .OrderBy(t => t.Key.Category)
                .Select(g => new TeamPilotsRepository
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
