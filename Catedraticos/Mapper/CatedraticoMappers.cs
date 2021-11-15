using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catedraticos.Models;
using Catedraticos.Models.DTOs;

namespace Catedraticos.Mapper
{
    public class CatedraticoMappers:Profile
    {
        public CatedraticoMappers()
        {
            CreateMap<CatedraticoModel, CatedraticoDto>().ReverseMap();
            CreateMap<CatedraticoModel, GuardarCatedraticoDto>().ReverseMap();
        }

    }
}
