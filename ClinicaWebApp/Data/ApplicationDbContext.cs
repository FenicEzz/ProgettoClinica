using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;
using ClinicaWebApp.Models;

namespace ClinicaWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DataLayer.Entities.Acceptance> Acceptance { get; set; } = default!;
        public DbSet<DataLayer.Entities.Pet> Pet { get; set; } = default!;
        public DbSet<DataLayer.Entities.Examination> Examination { get; set; } = default!;
        public DbSet<DataLayer.Entities.Recovery> Recovery { get; set; } = default!;
        public DbSet<DataLayer.Entities.Provider> Provider { get; set; } = default!;
        public DbSet<ClinicaWebApp.Models.AddProductViewModel> AddProductViewModel { get; set; } = default!;
        public DbSet<DataLayer.Entities.Product> Product { get; set; } = default!;
    }
}