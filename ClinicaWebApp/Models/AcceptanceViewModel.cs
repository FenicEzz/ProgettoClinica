using DataLayer.Entities;

namespace ClinicaWebApp.Models
{
    public class AcceptanceViewModel
    {
        public Pet Pet { get; set; }
        public List<Examination>? Examinations { get; set; } = new List<Examination>();
    }
}
