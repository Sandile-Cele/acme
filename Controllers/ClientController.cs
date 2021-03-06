using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACME.Models.DatabaseModels;
using ACME.ProjectWorker;
using Microsoft.AspNetCore.Http;

namespace ACME.Controllers
{
    public class ClientController : Controller
    {
        private readonly AcmeContext _context;

        public ClientController(AcmeContext context)
        {
            _context = context;
        }

        //Login 
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string inEmail, string inPassword)
        {
            if (ModelState.IsValid)
            {
                string hashPassword = new Security().ComputeSha256Hash(inPassword);

                Client getUser = await _context.Clients
                    .FirstOrDefaultAsync(m => m.ClientEmail.Equals(inEmail) & m.ClientPassword.Equals(hashPassword));

                if (getUser == null)
                {
                    ViewBag.userNotFound = "You have entered an invalid username or password";
                    return Login();
                }

                HttpContext.Session.SetInt32("currentClientId", getUser.ClientId);//storing PK of user
                return RedirectToAction("index", "products");

            }
            return View();
        }

        // GET: Client/Create
        public IActionResult Signup()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup([Bind("ClientId,ClientName,ClientSurname,ClientEmail,ClientPassword")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.ClientPassword = new Security().ComputeSha256Hash(client.ClientPassword);

                _context.Add(client);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32("currentClientId", client.ClientId);//storing PK of user
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details()
        {
            int? id = HttpContext.Session.GetInt32("currentUserId");

            if (id == null)
            {
                return RedirectToAction("login", "client");
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit()
        {
            int? id = HttpContext.Session.GetInt32("currentClientId");

            if (id == null)
            {
                return RedirectToAction("login", "client");
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,ClientName,ClientSurname,ClientEmail,ClientPassword")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    client.ClientPassword = new Security().ComputeSha256Hash(client.ClientPassword);
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
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
            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}
