using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZavrsniTest.Models.DTO
{
    public class RibaDTO
    {
        public int Id { get; set; }
        public string Sorta { get; set; }
        public string Mesto { get; set; }
        public decimal Cena { get; set; }
        public int Kolicina { get; set; }
        public int RibarnicaId { get; set; }
        public string RibarnicaNaziv { get; set; }
        public int RibarnicaGodinaOtvaranja { get; set; }
    }
}
