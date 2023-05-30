using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Interfaces
{
    public interface IExaminationService
    {
        Task<Examination> GetExamById(long id);
        Task<Examination> AddExam(Examination exam);
        Task<List<Examination>> GetAll();
        Task<Examination> DeleteExam(long id);
    }
}
