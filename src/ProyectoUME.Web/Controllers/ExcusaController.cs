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
    public class ExcusaController : Controller
    {
        private readonly ProyectoUMEDbContext _context;

        public ExcusaController(ProyectoUMEDbContext context)
        {
            _context = context;
        }

        // GET: Excusa
        public async Task<IActionResult> Index()
        {
            var proyectoUMEDbContext = _context.Excusa.Include(e => e.RolIdRolNavigation);
            return View(await proyectoUMEDbContext.ToListAsync());
        }

        // GET: Excusa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusa = await _context.Excusa
                .Include(e => e.RolIdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdExcusa == id);
            if (excusa == null)
            {
                return NotFound();
            }

            return View(excusa);
        }

        // GET: Excusa/Create
        public IActionResult Create()
        {
            ViewData["RolIdRol"] = new SelectList(_context.Rol, "IdRol", "NombreRol");
            return View();
        }

        // POST: Excusa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExcusa,AnexoEvidencia,Nombre1,Nombre2,Apellido1,Apellodo2,Correo,Telefono,RolIdRol")] Excusa excusa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excusa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolIdRol"] = new SelectList(_context.Rol, "IdRol", "NombreRol", excusa.RolIdRol);
            return View(excusa);
        }

        // GET: Excusa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusa = await _context.Excusa.FindAsync(id);
            if (excusa == null)
            {
                return NotFound();
            }
            ViewData["RolIdRol"] = new SelectList(_context.Rol, "IdRol", "NombreRol", excusa.RolIdRol);
            return View(excusa);
        }

        // POST: Excusa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExcusa,AnexoEvidencia,Nombre1,Nombre2,Apellido1,Apellodo2,Correo,Telefono,RolIdRol")] Excusa excusa)
        {
            if (id != excusa.IdExcusa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excusa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcusaExists(excusa.IdExcusa))
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
            ViewData["RolIdRol"] = new SelectList(_context.Rol, "IdRol", "NombreRol", excusa.RolIdRol);
            return View(excusa);
        }

        // GET: Excusa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusa = await _context.Excusa
                .Include(e => e.RolIdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdExcusa == id);
            if (excusa == null)
            {
                return NotFound();
            }

            return View(excusa);
        }

        // POST: Excusa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excusa = await _context.Excusa.FindAsync(id);
            _context.Excusa.Remove(excusa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcusaExists(int id)
        {
            return _context.Excusa.Any(e => e.IdExcusa == id);
        }
    }
}
