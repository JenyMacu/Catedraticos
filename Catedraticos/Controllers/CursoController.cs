using Catedraticos.Connection;
using Catedraticos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedraticos.Controllers
{
    public class CursoController : Controller
    {
        private readonly ILogger<CursoController> _logger;
        private readonly Conn _context;

        public CursoController(Conn context)
        {
            _context = context;  
        }

        public IActionResult Curso()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_Catedratico.ToListAsync());  
        }
        [HttpPost]
        public async Task<IActionResult> Catedratico([Bind("CodigoCurso, NombreCurso, EstadoCurso")] CursoModel cursomodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursomodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursomodel);
        }
        [HttpGet]
        public async Task<IActionResult> ConsultaCurso(string id) {

            if (id == null) {
                return NotFound();
            }
            var Datos = await _context.tbl_Cursos
                .FirstOrDefaultAsync(a => a.CodigoCurso == int.Parse(id));
            return View(Datos);        
        }

        public async Task<IActionResult> EditaCurso(string id) {
            int nCodigoCurso;
            if (id == null) {
                return NotFound();
            }

            nCodigoCurso = int.Parse(id);
            var Datos = await _context.tbl_Cursos.FindAsync(nCodigoCurso);

            if (Datos == null) {
                return NotFound();
            }
            return View(Datos);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditaCurso(string id,[Bind("CodigoCurso, NombreCurso, EstadoCurso")] CursoModel cursomodel)
        {

            if (id == null) {
                return NotFound();
            }

            if (ModelState.IsValid)
            try
            {
                    _context.Update(cursomodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuscaCurso(cursomodel.CodigoCurso.ToString()))
                    {
                        return NotFound();
                    }
                }
            return RedirectToAction(nameof(Index));
        }

        private bool BuscaCurso(string id)
        {
            return _context.tbl_Cursos.Any(e => e.CodigoCurso.ToString() == id);
        }
    }

 }
