using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClinicaWebApp.Models
{
    public class AddProductViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DataLayer.Entities.Type Type { get; set; }

        [Required]
        public string Description { get; set; } 
    }
}
