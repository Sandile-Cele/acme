using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACME.Models.DatabaseModels;

namespace ACME.Controllers
{
    public class AdministerController : Controller
    {
        private readonly AcmeContext _context;

        public AdministerController(AcmeContext context)
        {
            _context = context;
        }

        // GET: Administer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Administrators.ToListAsync());
        }

        // GET: Administer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administer = await _context.Administrators
                .FirstOrDefaultAsync(m => m.AdministratorId == id);
            if (administer == null)
            {
                return NotFound();
            }

            return View(administer);
        }

        // GET: Administer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdministerId,AdministerEmployeeNumber,AdministerUsername,AdministerPassword")] Administer administer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administer);
        }

        // GET: Administer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administer = await _context.Administrators.FindAsync(id);
            if (administer == null)
            {
                return NotFound();
            }
            return View(administer);
        }

        // POST: Administer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdministerId,AdministerEmployeeNumber,AdministerUsername,AdministerPassword")] Administer administer)
        {
            if (id != administer.AdministerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministerExists(administer.AdministerId))
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
            return View(administer);
        }

        // GET: Administer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administer = await _context.Administrators
                .FirstOrDefaultAsync(m => m.AdministratorId == id);
            if (administer == null)
            {
                return NotFound();
            }

            return View(administer);
        }

        // POST: Administer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administer = await _context.Administrators.FindAsync(id);
            _context.Administrators.Remove(administer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministerExists(int id)
        {
            return _context.Administrators.Any(e => e.AdministratorId == id);
        }
    }
}
