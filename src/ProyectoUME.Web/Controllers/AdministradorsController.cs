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
    public class AdministradorsController : Controller
    {
        private readonly ProyectoUMEDbContext _context;

        public AdministradorsController(ProyectoUMEDbContext context)
        {
            _context = context;
        }

        // GET: Administradors
        public async Task<IActionResult> Index()
        {
            var proyectoUMEDbContext = _context.Administrador.Include(a => a.NumeroCedulaNavigation);
            return View(await proyectoUMEDbContext.ToListAsync());
        }

        // GET: Administradors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador
                .Include(a => a.NumeroCedulaNavigation)
                .FirstOrDefaultAsync(m => m.IdAdministrador == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // GET: Administradors/Create
        public IActionResult Create()
        {
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula");
            return View();
        }

        // POST: Administradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdministrador,NumeroCedula,Nombre1A,Apellido1A")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula", administrador.NumeroCedula);
            return View(administrador);
        }

        // GET: Administradors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula", administrador.NumeroCedula);
            return View(administrador);
        }

        // POST: Administradors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdministrador,NumeroCedula,Nombre1A,Apellido1A")] Administrador administrador)
        {
            if (id != administrador.IdAdministrador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.IdAdministrador))
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
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula", administrador.NumeroCedula);
            return View(administrador);
        }

        // GET: Administradors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador
                .Include(a => a.NumeroCedulaNavigation)
                .FirstOrDefaultAsync(m => m.IdAdministrador == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // POST: Administradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrador = await _context.Administrador.FindAsync(id);
            _context.Administrador.Remove(administrador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administrador.Any(e => e.IdAdministrador == id);
        }
    }
}
