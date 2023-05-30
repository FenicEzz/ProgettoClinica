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
    public class RecoveryService : IRecoveryService
    {
        private readonly ClinicaDbContext _context;

        public RecoveryService(ClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<Recovery> AddRecovery(Recovery recovery)
        {
            _context.Recoveries.Add(recovery);
            await _context.SaveChangesAsync();

            return recovery;
        }

        public async Task<Recovery> DeleteRecovery(long id)
        {
            var rec = await _context.Recoveries.SingleAsync(x => x.Id == id);
            _context.Recoveries.Remove(rec);
            await _context.SaveChangesAsync();

            return rec;
        }

        public async Task<List<Recovery>> GetAll()
        {
            var recoveries = await _context.Recoveries.ToListAsync();

            return recoveries;
        }

        public Task<Recovery> GetById(long id)
        {
            var rec = _context.Recoveries.SingleAsync(x => x.Id == id);

            return rec;
        }
    }
}
