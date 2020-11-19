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
    public class ExcusasController : Controller
    {
        private readonly ProyectoUMEDbContext _context;

        public ExcusasController(ProyectoUMEDbContext context)
        {
            _context = context;
        }

        // GET: Excusas
        public async Task<IActionResult> Index()
        {
            var proyectoUMEDbContext = _context.Excusas.Include(e => e.IdAdministradorNavigation).Include(e => e.IdObreroNavigation);
            return View(await proyectoUMEDbContext.ToListAsync());
        }

        // GET: Excusas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusas = await _context.Excusas
                .Include(e => e.IdAdministradorNavigation)
                .Include(e => e.IdObreroNavigation)
                .FirstOrDefaultAsync(m => m.NumeroReferencia == id);
            if (excusas == null)
            {
                return NotFound();
            }

            return View(excusas);
        }

        // GET: Excusas/Create
        public IActionResult Create()
        {
            ViewData["IdAdministrador"] = new SelectList(_context.Administrador, "IdAdministrador", "IdAdministrador");
            ViewData["IdObrero"] = new SelectList(_context.Obrero, "IdObrero", "Apellido1O");
            return View();
        }

        // POST: Excusas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroReferencia,AnexoEvidencia,IdAdministrador,IdObrero,Nombre1Usuario,Nombre2Usuario,Apellido1Usuario,Apellido2Usuario,Correo,Telefono,CodigoProyecto")] Excusas excusas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excusas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdministrador"] = new SelectList(_context.Administrador, "IdAdministrador", "IdAdministrador", excusas.IdAdministrador);
            ViewData["IdObrero"] = new SelectList(_context.Obrero, "IdObrero", "Apellido1O", excusas.IdObrero);
            return View(excusas);
        }

        // GET: Excusas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusas = await _context.Excusas.FindAsync(id);
            if (excusas == null)
            {
                return NotFound();
            }
            ViewData["IdAdministrador"] = new SelectList(_context.Administrador, "IdAdministrador", "IdAdministrador", excusas.IdAdministrador);
            ViewData["IdObrero"] = new SelectList(_context.Obrero, "IdObrero", "Apellido1O", excusas.IdObrero);
            return View(excusas);
        }

        // POST: Excusas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroReferencia,AnexoEvidencia,IdAdministrador,IdObrero,Nombre1Usuario,Nombre2Usuario,Apellido1Usuario,Apellido2Usuario,Correo,Telefono,CodigoProyecto")] Excusas excusas)
        {
            if (id != excusas.NumeroReferencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excusas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcusasExists(excusas.NumeroReferencia))
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
            ViewData["IdAdministrador"] = new SelectList(_context.Administrador, "IdAdministrador", "IdAdministrador", excusas.IdAdministrador);
            ViewData["IdObrero"] = new SelectList(_context.Obrero, "IdObrero", "Apellido1O", excusas.IdObrero);
            return View(excusas);
        }

        // GET: Excusas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusas = await _context.Excusas
                .Include(e => e.IdAdministradorNavigation)
                .Include(e => e.IdObreroNavigation)
                .FirstOrDefaultAsync(m => m.NumeroReferencia == id);
            if (excusas == null)
            {
                return NotFound();
            }

            return View(excusas);
        }

        // POST: Excusas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excusas = await _context.Excusas.FindAsync(id);
            _context.Excusas.Remove(excusas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcusasExists(int id)
        {
            return _context.Excusas.Any(e => e.NumeroReferencia == id);
        }
    }
}
