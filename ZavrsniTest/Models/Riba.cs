using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZavrsniTest.Models
{
    public class Riba
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Sorta { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(120)]
        public string Mesto { get; set; }
        [Required]
        [Range(100,10000)]
        public decimal Cena { get; set; }
        [Required]
        [Range(1,1000)]
        public int Kolicina { get; set; }
        public Ribarnica Ribarnica { get; set; }
        public int RibarnicaId { get; set; }
    }
}
