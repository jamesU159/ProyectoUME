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
    public class SupervisorsController : Controller
    {
        private readonly ProyectoUMEDbContext _context;

        public SupervisorsController(ProyectoUMEDbContext context)
        {
            _context = context;
        }

        // GET: Supervisors
        public async Task<IActionResult> Index()
        {
            var proyectoUMEDbContext = _context.Supervisor.Include(s => s.NumeroCedulaNavigation);
            return View(await proyectoUMEDbContext.ToListAsync());
        }

        // GET: Supervisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor
                .Include(s => s.NumeroCedulaNavigation)
                .FirstOrDefaultAsync(m => m.IdSupervisor == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // GET: Supervisors/Create
        public IActionResult Create()
        {
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula");
            return View();
        }

        // POST: Supervisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSupervisor,NumeroCedula,Nombre1S,Apellido1S")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula", supervisor.NumeroCedula);
            return View(supervisor);
        }

        // GET: Supervisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor.FindAsync(id);
            if (supervisor == null)
            {
                return NotFound();
            }
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula", supervisor.NumeroCedula);
            return View(supervisor);
        }

        // POST: Supervisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSupervisor,NumeroCedula,Nombre1S,Apellido1S")] Supervisor supervisor)
        {
            if (id != supervisor.IdSupervisor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supervisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisorExists(supervisor.IdSupervisor))
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
            ViewData["NumeroCedula"] = new SelectList(_context.Usuario, "NumeroCedula", "NumeroCedula", supervisor.NumeroCedula);
            return View(supervisor);
        }

        // GET: Supervisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor
                .Include(s => s.NumeroCedulaNavigation)
                .FirstOrDefaultAsync(m => m.IdSupervisor == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // POST: Supervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supervisor = await _context.Supervisor.FindAsync(id);
            _context.Supervisor.Remove(supervisor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisorExists(int id)
        {
            return _context.Supervisor.Any(e => e.IdSupervisor == id);
        }
    }
}
