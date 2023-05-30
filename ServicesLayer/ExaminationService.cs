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
    public class ExaminationService : IExaminationService
    {
        private readonly ClinicaDbContext _context;

        public ExaminationService(ClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<Examination> AddExam(Examination exam)
        {
            _context.Examinations.Add(exam);
            await _context.SaveChangesAsync();

            return exam;
        }

        public async Task<Examination> DeleteExam(long id)
        {
            var exam = await _context.Examinations.SingleAsync(x => x.Id == id);
            _context.Examinations.Remove(exam);
            await _context.SaveChangesAsync();

            return exam;
        }

        public async Task<List<Examination>> GetAll()
        {
            var list = await _context.Examinations.ToListAsync();

            return list;
        }

        public async Task<Examination> GetExamById(long id)
        {
            var exam = await _context.Examinations.SingleAsync(x => x.Id == id);

            return exam;
        }
    }
}
