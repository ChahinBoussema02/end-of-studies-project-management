using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Soutenances.Data;
using Gestion_Soutenances.Models;

namespace Gestion_Soutenances.Controllers
{
    public class PFEsController : Controller
    {
        private readonly SoutenanceContext _context;

        public PFEsController(SoutenanceContext context)
        {
            _context = context;
        }

        // GET: PFEs
        public async Task<IActionResult> Index()
        {
            var soutenanceContext = _context.PFE.Include(p => p.Enseignant).Include(p => p.Societe);
            return View(await soutenanceContext.ToListAsync());
        }

        // GET: PFEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PFE == null)
            {
                return NotFound();
            }

            var pFE = await _context.PFE
                .Include(p => p.Enseignant)
                .Include(p => p.Societe)
                .FirstOrDefaultAsync(m => m.PFEID == id);
            if (pFE == null)
            {
                return NotFound();
            }

            return View(pFE);
        }

        // GET: PFEs/Create
        public IActionResult Create()
        {
            ViewData["SocieteId"] = new SelectList(_context.Societe, "Id", "Lib");
            ViewData["EncadrantId"] = new SelectList(_context.Enseignant, "Id", "FullName");
            return View();
        }

        // POST: PFEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PFEID,titre,desc,DateD,DateF,EncadrantId,SocieteId")] PFE pFE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pFE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SocieteId"] = new SelectList(_context.Societe, "Id", "Adresse", pFE.SocieteId);
            ViewData["EncadrantId"] = new SelectList(_context.Enseignant, "Id", "FullName", pFE.EncadrantId);
            return View(pFE);
        }

        // GET: PFEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PFE == null)
            {
                return NotFound();
            }

            var pFE = await _context.PFE.FindAsync(id);
            if (pFE == null)
            {
                return NotFound();
            }
            ViewData["SocieteId"] = new SelectList(_context.Societe, "Id", "Adresse", pFE.SocieteId);
            return View(pFE);
        }

        // POST: PFEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PFEID,titre,desc,DateD,DateF,EncadrantId,SocieteId")] PFE pFE)
        {
            if (id != pFE.PFEID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pFE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PFEExists(pFE.PFEID))
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
            ViewData["SocieteId"] = new SelectList(_context.Societe, "Id", "Adresse", pFE.SocieteId);
            return View(pFE);
        }

        // GET: PFEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PFE == null)
            {
                return NotFound();
            }

            var pFE = await _context.PFE
                .Include(p => p.Societe)
                .FirstOrDefaultAsync(m => m.PFEID == id);
            if (pFE == null)
            {
                return NotFound();
            }

            return View(pFE);
        }

        // POST: PFEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PFE == null)
            {
                return Problem("Entity set 'SoutenanceContext.PFE'  is null.");
            }
            var pFE = await _context.PFE.FindAsync(id);
            if (pFE != null)
            {
                _context.PFE.Remove(pFE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PFEExists(int id)
        {
          return (_context.PFE?.Any(e => e.PFEID == id)).GetValueOrDefault();
        }
    }
}
