using Domain.Dto.Filter;
using Domain.Dto.PilotsDto;
using Domain.Entities;
using Domain.Enums;
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

        public async Task<Pilot> GetPilotById(Guid id)
        {
            return await _context.Pilots.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task UpdatePilot(Pilot pilot)
        {
            _context.Pilots.Update(pilot);
            await _context.SaveChangesAsync();
        }
        public async Task<List<CategoryPilotsDto>> GetFilteredAsync(PilotFilterRequest filters)
        {
            var query = _context.Pilots.Include(t => t.Team).AsQueryable();

            if (!string.IsNullOrEmpty(filters.Gender.ToString()))
            {
                query = query.Where(p => p.Gender == filters.Gender);
            }
            if (!string.IsNullOrEmpty(filters.Nationality))
            {
                query = query.Where(p => p.Nationality == filters.Nationality);
            }
            if (!string.IsNullOrEmpty(filters.Circuit))
            {
                query = query.Where(p => p.Circuit == filters.Circuit);
            }
            if (!string.IsNullOrEmpty(filters.weight.ToString()))
            {
                if (filters.weight == (Weight)0)
                {
                    query = query.Where(p => p.Weight <= 70);
                }
                else if (filters.weight == (Weight)1)
                {
                    query = query.Where(p => p.Weight <= 75 && p.Weight > 70);
                }
                else if (filters.weight == (Weight)2)
                {
                    query = query.Where(p => p.Weight > 75);
                }

            }

            if (!string.IsNullOrEmpty(filters.Search))
            {
                var term = filters.Search.ToLower();

                query = query.Where(p => p.Name.ToLower() == filters.Search || p.Team.Name.ToLower() == filters.Search);
            }

            var pilotos = await query
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
                        TeamName = p.Team.Name,
                        Category = p.Category
                    }).ToList()
                })
                .ToListAsync();

            return pilotos;
        }
    }
}
