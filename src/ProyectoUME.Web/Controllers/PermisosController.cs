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
    public class PermisosController : Controller
    {
        private readonly ProyectoUMEDbContext _context;

        public PermisosController(ProyectoUMEDbContext context)
        {
            _context = context;
        }

        // GET: Permisos
        public async Task<IActionResult> Index()
        {
            var proyectoUMEDbContext = _context.Permisos.Include(p => p.IdObreroNavigation).Include(p => p.IdSupervisorNavigation);
            return View(await proyectoUMEDbContext.ToListAsync());
        }

        // GET: Permisos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisos = await _context.Permisos
                .Include(p => p.IdObreroNavigation)
                .Include(p => p.IdSupervisorNavigation)
                .FirstOrDefaultAsync(m => m.NumeroReferenciaPermiso == id);
            if (permisos == null)
            {
                return NotFound();
            }

            return View(permisos);
        }

        // GET: Permisos/Create
        public IActionResult Create()
        {
            ViewData["IdObrero"] = new SelectList(_context.Obrero, "IdObrero", "Apellido1O");
            ViewData["IdSupervisor"] = new SelectList(_context.Supervisor, "IdSupervisor", "IdSupervisor");
            return View();
        }

        // POST: Permisos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroReferenciaPermiso,IdSupervisor,IdObrero,CodigoProyecto,Nombre1Usuario,Nombre2Usuario,Apellido1Usuario,Apellido2Usuario,Correo,Telefono")] Permisos permisos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permisos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdObrero"] = new SelectList(_context.Obrero, "IdObrero", "Apellido1O", permisos.IdObrero);
            ViewData["IdSupervisor"] = new SelectList(_context.Supervisor, "IdSupervisor", "IdSupervisor", permisos.IdSupervisor);
            return View(permisos);
        }

        // GET: Permisos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisos = await _context.Permisos.FindAsync(id);
            if (permisos == null)
            {
                return NotFound();
            }
            ViewData["IdObrero"] = new SelectList(_context.Obrero, "IdObrero", "Apellido1O", permisos.IdObrero);
            ViewData["IdSupervisor"] = new SelectList(_context.Supervisor, "IdSupervisor", "IdSupervisor", permisos.IdSupervisor);
            return View(permisos);
        }

        // POST: Permisos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroReferenciaPermiso,IdSupervisor,IdObrero,CodigoProyecto,Nombre1Usuario,Nombre2Usuario,Apellido1Usuario,Apellido2Usuario,Correo,Telefono")] Permisos permisos)
        {
            if (id != permisos.NumeroReferenciaPermiso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permisos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisosExists(permisos.NumeroReferenciaPermiso))
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
            ViewData["IdObrero"] = new SelectList(_context.Obrero, "IdObrero", "Apellido1O", permisos.IdObrero);
            ViewData["IdSupervisor"] = new SelectList(_context.Supervisor, "IdSupervisor", "IdSupervisor", permisos.IdSupervisor);
            return View(permisos);
        }

        // GET: Permisos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisos = await _context.Permisos
                .Include(p => p.IdObreroNavigation)
                .Include(p => p.IdSupervisorNavigation)
                .FirstOrDefaultAsync(m => m.NumeroReferenciaPermiso == id);
            if (permisos == null)
            {
                return NotFound();
            }

            return View(permisos);
        }

        // POST: Permisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permisos = await _context.Permisos.FindAsync(id);
            _context.Permisos.Remove(permisos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisosExists(int id)
        {
            return _context.Permisos.Any(e => e.NumeroReferenciaPermiso == id);
        }
    }
}
