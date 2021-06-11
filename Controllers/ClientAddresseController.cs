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
    public class ClientAddresseController : Controller
    {
        private readonly AcmeContext _context;

        public ClientAddresseController(AcmeContext context)
        {
            _context = context;
        }

        // GET: ClientAddresse
        public async Task<IActionResult> Index()
        {
            var acmeContext = _context.ClientAddresses.Include(c => c.Client);
            return View(await acmeContext.ToListAsync());
        }

        // GET: ClientAddresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientAddress = await _context.ClientAddresses
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ClientAddressId == id);
            if (clientAddress == null)
            {
                return NotFound();
            }

            return View(clientAddress);
        }

        // GET: ClientAddresse/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientEmail");
            return View();
        }

        // POST: ClientAddresse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientAddressId,ClientId,ClientAddressAddressLine1,ClientAddressAddressLine2,ClientAddressAddressLine3,ClientAddressAddressLine4,ClientAddressPostalCode")] ClientAddress clientAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientEmail", clientAddress.ClientId);
            return View(clientAddress);
        }

        // GET: ClientAddresse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientAddress = await _context.ClientAddresses.FindAsync(id);
            if (clientAddress == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientEmail", clientAddress.ClientId);
            return View(clientAddress);
        }

        // POST: ClientAddresse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientAddressId,ClientId,ClientAddressAddressLine1,ClientAddressAddressLine2,ClientAddressAddressLine3,ClientAddressAddressLine4,ClientAddressPostalCode")] ClientAddress clientAddress)
        {
            if (id != clientAddress.ClientAddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientAddressExists(clientAddress.ClientAddressId))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientEmail", clientAddress.ClientId);
            return View(clientAddress);
        }

        // GET: ClientAddresse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientAddress = await _context.ClientAddresses
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ClientAddressId == id);
            if (clientAddress == null)
            {
                return NotFound();
            }

            return View(clientAddress);
        }

        // POST: ClientAddresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientAddress = await _context.ClientAddresses.FindAsync(id);
            _context.ClientAddresses.Remove(clientAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientAddressExists(int id)
        {
            return _context.ClientAddresses.Any(e => e.ClientAddressId == id);
        }
    }
}
