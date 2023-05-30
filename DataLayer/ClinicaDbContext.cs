using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> opt) : base(opt) { }

        public ClinicaDbContext() : base() { }

        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Acceptance> Acceptances { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Recovery> Recoveries { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
    }
}
