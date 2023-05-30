using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Interfaces
{
    public interface IRecoveryService
    {
        Task<List<Recovery>> GetAll();
        Task<Recovery> GetById(long id);
        Task<Recovery> AddRecovery(Recovery recovery);
        Task<Recovery> DeleteRecovery(long id);
    }
}
