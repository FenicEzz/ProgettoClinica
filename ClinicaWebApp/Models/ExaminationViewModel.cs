using DataLayer.Entities;

namespace ClinicaWebApp.Models
{
    public class ExaminationViewModel
    {
        public long PetId { get; set; }
        public string Treatment { get; set; }
        public string Disease { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
