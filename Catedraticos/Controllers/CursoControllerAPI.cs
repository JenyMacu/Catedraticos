using AutoMapper;
using Catedraticos.Models;
using Catedraticos.Models.DTOs;
using Catedraticos.Repository.iRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedraticos.Controllers
{
    [Route("api/Curso")]
    [ApiController]
    public class CursoControllerAPI : Controller
    {
        private readonly iCatedraticoRepository _ctocatedratico;
        private readonly IMapper _mapper;

        //Constructor
        public CursoControllerAPI(iCatedraticoRepository ctoCurso, IMapper mapper)
        {
            _ctocatedratico = ctoCurso;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListaCurso()
        {
            var nListarCurso = _ctocurso.GetCursoModels();
            //Aplicando Dto
            var nListarCursoDto = new List<CursoDto>();

            foreach (var nListar in nListarCurso)
            {
                nListarCursoDto.Add(_mapper.Map<CursoDto>(nListar));
            }
            return Ok(nListarCursoDto);
        }
        [HttpGet("{nCodigoCurso:int}", Name = "GetCursoByCodigo")]
        public IActionResult GetCursoByCodigo(int nCodigoCurso)
        {
            var ListarCurso = _ctocatedratico.GetCatedratico(nCodigoCurso);
            if (ListarCurso == null)
            {
                NotFound();
            }
            var nRegistroCursoDto = _mapper.Map<CursoDto>(ListarCurso);
            return Ok(nRegistroCursoDto);
        }
        [HttpPost]
        public IActionResult CreaCurso([FromBody] GuardarCursoDto cursoDto)
        {
            if(cursoDto == null)
            {
                return BadRequest(ModelState);
            }
            var curso = _mapper.Map<CursoModel>(cursoDto);

            if (!_ctocurso.CrearCurso(catedratico))
            {
                ModelState.AddModelError("", $"Ocurrió un Error al grabar el registro { curso.CodigoCurso}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetCursoByCodigo", new { nCodigoCurso = cursoDto.CodigoCurso }, curso);
        }

    }
}
