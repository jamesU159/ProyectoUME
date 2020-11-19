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
    public class ObreroesController : Controller
    {
        private readonly ProyectoUMEDbContext _context;

        public ObreroesController(ProyectoUMEDbContext context)
        {
            _context = context;
        }

        // GET: Obreroes
        public async Task<IActionResult> Index()
        {
            var proyectoUMEDbContext = _context.Obrero.Include(o => o.NumeroCedulaNavigation);
            return View(await proyectoUMEDbContext.ToListAsync());
        }

        // GET: Obreroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obrero = await _context.Obrero
                .Include(o => o.NumeroCedulaNavigation)
                .FirstOrDefaultAsync(m => m.IdObrero == id);
            if (obrero == null)
            {
                return NotFound();
            }

            return View(obrero);
        }

        // GET: Obreroes/Create
        public IActionResult Create()
        {
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula");
            return View();
        }

        // POST: Obreroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObrero,NumeroCedula,Nombre1O,Apellido1O")] Obrero obrero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obrero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula", obrero.NumeroCedula);
            return View(obrero);
        }

        // GET: Obreroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obrero = await _context.Obrero.FindAsync(id);
            if (obrero == null)
            {
                return NotFound();
            }
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula", obrero.NumeroCedula);
            return View(obrero);
        }

        // POST: Obreroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObrero,NumeroCedula,Nombre1O,Apellido1O")] Obrero obrero)
        {
            if (id != obrero.IdObrero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obrero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObreroExists(obrero.IdObrero))
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
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula", obrero.NumeroCedula);
            return View(obrero);
        }

        // GET: Obreroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obrero = await _context.Obrero
                .Include(o => o.NumeroCedulaNavigation)
                .FirstOrDefaultAsync(m => m.IdObrero == id);
            if (obrero == null)
            {
                return NotFound();
            }

            return View(obrero);
        }

        // POST: Obreroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obrero = await _context.Obrero.FindAsync(id);
            _context.Obrero.Remove(obrero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObreroExists(int id)
        {
            return _context.Obrero.Any(e => e.IdObrero == id);
        }
    }
}
