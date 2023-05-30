using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Interfaces
{
    public interface IPetService
    {
        Task<List<Pet>> GetAll();
        Task<Pet> GetPetById(long id);
        Task<Pet> AddPet(Pet pet);
        Task<Pet> DeletePet(long id);
    }
}
