using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catedraticos.Models;
using Catedraticos.Models.DTOs;

namespace Catedraticos.Mapper
{
    public class CursoMappers:Profile
    {
        public CursoMappers()
        {
            CreateMap<CatedraticoModel, CursoDto>().ReverseMap();
            CreateMap<CursoModel, GuardarCursoDto>().ReverseMap();
        }

    }
}
