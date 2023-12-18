using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavrsniTest.Models.DTO;

namespace ZavrsniTest.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Riba, RibaDTO>();
        }
    }
}
