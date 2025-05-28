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
    public class PFE_EtudiantsController : Controller
    {
        private readonly SoutenanceContext _context;

        public PFE_EtudiantsController(SoutenanceContext context)
        {
            _context = context;
        }

        // GET: PFE_Etudiants
        public async Task<IActionResult> Index()
        {
            var soutenanceContext = _context.PFE_Etudiant.Include(p => p.Etudiant).Include(p => p.PFE);
            return View(await soutenanceContext.ToListAsync());
        }

        // GET: PFE_Etudiants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PFE_Etudiant == null)
            {
                return NotFound();
            }

            var pFE_Etudiant = await _context.PFE_Etudiant
                .Include(p => p.Etudiant)
                .Include(p => p.PFE)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pFE_Etudiant == null)
            {
                return NotFound();
            }

            return View(pFE_Etudiant);
        }

        // GET: PFE_Etudiants/Create
        public IActionResult Create()
        {
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "Id", "FullName");
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "titre");
            return View();
        }

        // POST: PFE_Etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EtudiantId,PFEID")] PFE_Etudiant pFE_Etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pFE_Etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "Id", "FullName", pFE_Etudiant.EtudiantId);
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "titre", pFE_Etudiant.PFEID);
            return View(pFE_Etudiant);
        }

        // GET: PFE_Etudiants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PFE_Etudiant == null)
            {
                return NotFound();
            }

            var pFE_Etudiant = await _context.PFE_Etudiant.FindAsync(id);
            if (pFE_Etudiant == null)
            {
                return NotFound();
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "Id", "FullName", pFE_Etudiant.EtudiantId);
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "titre", pFE_Etudiant.PFEID);
            return View(pFE_Etudiant);
        }

        // POST: PFE_Etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EtudiantId,PFEID")] PFE_Etudiant pFE_Etudiant)
        {
            if (id != pFE_Etudiant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pFE_Etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PFE_EtudiantExists(pFE_Etudiant.ID))
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
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "Id", "FullName", pFE_Etudiant.EtudiantId);
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "titre", pFE_Etudiant.PFEID);
            return View(pFE_Etudiant);
        }

        // GET: PFE_Etudiants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PFE_Etudiant == null)
            {
                return NotFound();
            }

            var pFE_Etudiant = await _context.PFE_Etudiant
                .Include(p => p.Etudiant)
                .Include(p => p.PFE)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pFE_Etudiant == null)
            {
                return NotFound();
            }

            return View(pFE_Etudiant);
        }

        // POST: PFE_Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PFE_Etudiant == null)
            {
                return Problem("Entity set 'SoutenanceContext.PFE_Etudiant'  is null.");
            }
            var pFE_Etudiant = await _context.PFE_Etudiant.FindAsync(id);
            if (pFE_Etudiant != null)
            {
                _context.PFE_Etudiant.Remove(pFE_Etudiant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PFE_EtudiantExists(int id)
        {
          return (_context.PFE_Etudiant?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
