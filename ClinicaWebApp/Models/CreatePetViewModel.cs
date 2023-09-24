using System.ComponentModel.DataAnnotations;

namespace ClinicaWebApp.Models
{
    public class CreatePetViewModel
    {
        public required string Name { get; set; }

        public required string Race { get; set; }

        public required string FurColor { get; set; }

        public DateTime Birthdate { get; set; }

        public bool HasMicrochip { get; set; }

        public int? MicrochipNumber { get; set; }

        public string? CustomerFirstname { get; set; }

        public string? CustomerLastname { get; set; }
    }
}
