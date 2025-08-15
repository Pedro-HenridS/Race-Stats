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
            var pilotos = await _context.Pilots.Include(t => t.Team).ToListAsync();

            return pilotos;
        }

        public async Task<Pilot> GetPilotById(Guid id)
        {
            var piloto = await _context.Pilots.Where(p => p.Id == id).FirstOrDefaultAsync();

            return piloto;
        }
    }
}
