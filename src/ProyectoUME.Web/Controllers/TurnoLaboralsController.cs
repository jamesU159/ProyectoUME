using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoUME.Core;
using ProyectoUME.Core.Domain;

namespace ProyectoUME.Web.Controllers
{
    public class TurnoLaboralsController : Controller
    {
        private readonly ProyectoUMEDbContext _context;

        public TurnoLaboralsController(ProyectoUMEDbContext context)
        {
            _context = context;
        }

        // GET: TurnoLaborals
        public async Task<IActionResult> Index()
        {
            return View(await _context.TurnoLaboral.ToListAsync());
        }

        // GET: TurnoLaborals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoLaboral = await _context.TurnoLaboral
                .FirstOrDefaultAsync(m => m.NumeroConsulta == id);
            if (turnoLaboral == null)
            {
                return NotFound();
            }

            return View(turnoLaboral);
        }

        // GET: TurnoLaborals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TurnoLaborals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroConsulta,IdObrero,CodigoProyecto,Jornada")] TurnoLaboral turnoLaboral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turnoLaboral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turnoLaboral);
        }

        // GET: TurnoLaborals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoLaboral = await _context.TurnoLaboral.FindAsync(id);
            if (turnoLaboral == null)
            {
                return NotFound();
            }
            return View(turnoLaboral);
        }

        // POST: TurnoLaborals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroConsulta,IdObrero,CodigoProyecto,Jornada")] TurnoLaboral turnoLaboral)
        {
            if (id != turnoLaboral.NumeroConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turnoLaboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoLaboralExists(turnoLaboral.NumeroConsulta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(turnoLaboral);
        }

        // GET: TurnoLaborals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoLaboral = await _context.TurnoLaboral
                .FirstOrDefaultAsync(m => m.NumeroConsulta == id);
            if (turnoLaboral == null)
            {
                return NotFound();
            }

            return View(turnoLaboral);
        }

        // POST: TurnoLaborals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turnoLaboral = await _context.TurnoLaboral.FindAsync(id);
            _context.TurnoLaboral.Remove(turnoLaboral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoLaboralExists(int id)
        {
            return _context.TurnoLaboral.Any(e => e.NumeroConsulta == id);
        }
    }
}
