using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public enum MedicineType
    {
        Medicine,
        Food
    }

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public MedicineType Type { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public Provider Provider { get; set; }
    }
}
