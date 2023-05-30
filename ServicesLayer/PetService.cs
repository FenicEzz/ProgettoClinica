using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.Interfaces;

namespace ServicesLayer
{
    public class PetService : IPetService
    {
        private readonly ClinicaDbContext _context;

        public PetService(ClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        public async Task<Pet> DeletePet(long id)
        {
            var pet = await _context.Pets.SingleAsync(x => x.Id == id);
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        public async Task<List<Pet>> GetAll()
        {
            var pets = await _context.Pets.ToListAsync();

            return pets;
        }

        public async Task<Pet> GetPetById(long id)
        {
            var pet = await _context.Pets.SingleAsync(a => a.Id == id);

            return pet;
        }
    }
}