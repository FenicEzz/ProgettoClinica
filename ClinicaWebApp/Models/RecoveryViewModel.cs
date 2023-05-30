using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClinicaWebApp.Models
{
    public class RecoveryViewModel
    {
        public long PetId { get; set; }

        [Required]
        public DateTime RecoveryDate { get; set; }

        [Required]
        public string UrlPicture { get; set; }
    }
}
