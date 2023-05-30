using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Interfaces
{
    public interface IAcceptanceService
    {
        Task<List<Acceptance>> GetAll();
        Task<Acceptance> GetAccById(long id);
        Task<Acceptance> AddAcceptance(Acceptance acc);
        Task<Acceptance> DeleteAcceptance(long id);
    }
}
