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
    public class CatedraticoController : Controller
    {
        private readonly ILogger<CatedraticoController> _logger;
        private readonly Conn _context;

        public CatedraticoController(Conn context)
        {
            _context = context;  
        }

        public IActionResult Catedratico()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_Catedratico.ToListAsync());  
        }
        [HttpPost]
        public async Task<IActionResult> Catedratico([Bind("CodigoCatedratico, NombreCatedratico, ApellidoCatedratico, EdadCatedratico, EstadoCatedratico")] CatedraticoModel catedraticomodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catedraticomodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catedraticomodel);
        }
        [HttpGet]
        public async Task<IActionResult> ConsultaCatedratico(string id) {

            if (id == null) {
                return NotFound();
            }
            var Datos = await _context.tbl_Catedratico
                .FirstOrDefaultAsync(a => a.CodigoCatedratico == int.Parse(id));
            return View(Datos);        
        }

        public async Task<IActionResult> EditaCatedratico(string id) {
            int nCodigoCatedratico;
            if (id == null) {
                return NotFound();
            }

            nCodigoCatedratico = int.Parse(id);
            var Datos = await _context.tbl_Catedratico.FindAsync(nCodigoCatedratico);

            if (Datos == null) {
                return NotFound();
            }
            return View(Datos);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditaCatedratico(string id,[Bind("CodigoCatedratico, NombreCatedratico, ApellidoCatedratico, EdadCatedratico, EstadoCatedratico")] CatedraticoModel catedraticomodel)
        {

            if (id == null) {
                return NotFound();
            }

            if (ModelState.IsValid)
            try
            {
                    _context.Update(catedraticomodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuscaCatedratico(catedraticomodel.CodigoCatedratico.ToString()))
                    {
                        return NotFound();
                    }
                }
            return RedirectToAction(nameof(Index));
        }

        private bool BuscaCatedratico(string id)
        {
            return _context.tbl_Catedratico.Any(e => e.CodigoCatedratico.ToString() == id);
        }
    }

 }
