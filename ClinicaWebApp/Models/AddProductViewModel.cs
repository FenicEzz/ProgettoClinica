using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClinicaWebApp.Models
{
    public class AddProductViewModel
    {
        public  long Id { get; set; }

        public  string Name { get; set; }

        public  DataLayer.Entities.MedicineType Type { get; set; }

        public string Description { get; set; } 
    }
}
