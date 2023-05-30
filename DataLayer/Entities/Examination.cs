using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Examination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public DateTime ExaminationDate { get; set; }

        [Required]
        public string Disease { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Treatment { get; set; }
        public Pet Pet { get; set; }
    }
}
