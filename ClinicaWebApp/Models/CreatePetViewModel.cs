using System.ComponentModel.DataAnnotations;

namespace ClinicaWebApp.Models
{
    public class CreatePetViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public string FurColor { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        public bool HasMicrochip { get; set; }

        public int? MicrochipNumber { get; set; }

        public string? CustomerFirstname { get; set; }

        public string? CustomerLastname { get; set; }
    }
}
