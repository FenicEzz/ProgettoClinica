using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public string FurColor { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        public bool HasMicrochip { get; set; }

        public int? MicrochipNumber { get; set; }

        public string? CustomerFirstname { get; set; }

        public string? CustomerLastname { get; set; }

        public List<Examination>? Examinations { get; set; }
    }
}
