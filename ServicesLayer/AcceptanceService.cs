using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public class AcceptanceService : IAcceptanceService
    {
        private readonly ClinicaDbContext _context;

        public AcceptanceService(ClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<Acceptance> AddAcceptance(Acceptance acc)
        {
            _context.Acceptances.Add(acc);
            await _context.SaveChangesAsync();

            return acc;
        }

        public async Task<Acceptance> DeleteAcceptance(long id)
        {
            var acc = await _context.Acceptances.SingleAsync(x => x.Id == id);
            _context.Acceptances.Remove(acc);
            await _context.SaveChangesAsync();

            return acc;
        }

        public async Task<Acceptance> GetAccById(long id)
        {
            var acc = await _context.Acceptances.SingleAsync(x => x.Id == id);

            return acc;
        }

        public async Task<List<Acceptance>> GetAll()
        {
            var all = await _context.Acceptances.ToListAsync();

            return all;
        }
    }
}
