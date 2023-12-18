using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZavrsniTest.Models
{
    public class Ribarnica
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Naziv { get; set; }
        [Required]
        [Range(1950,2023)]
        public int GodinaOtvaranja { get; set; }
    }
}
