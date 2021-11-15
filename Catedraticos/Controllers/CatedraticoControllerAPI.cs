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
    [Route("api/Catedratico")]
    [ApiController]
    public class CatedraticoControllerAPI : Controller
    {
        private readonly iCatedraticoRepository _ctocatedratico;
        private readonly IMapper _mapper;

        //Constructor
        public CatedraticoControllerAPI(iCatedraticoRepository ctoCatedratico, IMapper mapper)
        {
            _ctocatedratico = ctoCatedratico;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListaCatedratico()
        {
            var nListarCatedratico = _ctocatedratico.GetCatedraticoModels();
            //Aplicando Dto
            var nListarCatedraticoDto = new List<CatedraticoDto>();

            foreach (var nListar in nListarCatedratico)
            {
                nListarCatedraticoDto.Add(_mapper.Map<CatedraticoDto>(nListar));
            }
            return Ok(nListarCatedraticoDto);
        }
        [HttpGet("{nCodigoCatedratico:int}", Name = "GetCatedraticoByCodigo")]
        public IActionResult GetCatedraticoByCodigo(int nCodigoCatedratico)
        {
            var ListarCatedratico = _ctocatedratico.GetCatedratico(nCodigoCatedratico);
            if (ListarCatedratico == null)
            {
                NotFound();
            }
            var nRegistroCatedraticoDto = _mapper.Map<CatedraticoDto>(ListarCatedratico);
            return Ok(nRegistroCatedraticoDto);
        }
        [HttpPost]
        public IActionResult CreaPersona([FromBody] GuardarCatedraticoDto catedraticoDto)
        {
            if(catedraticoDto == null)
            {
                return BadRequest(ModelState);
            }
            var catedratico = _mapper.Map<CatedraticoModel>(catedraticoDto);

            if (!_ctocatedratico.CrearCatedratico(catedratico))
            {
                ModelState.AddModelError("", $"Ocurrió un Error al grabar el registro { catedratico.CodigoCatedratico}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetCatedraticoByCodigo", new { nCodigoCatedratico = catedraticoDto.CodigoCatedratico }, catedratico);
        }

    }
}
