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
    public class AdministratorController : Controller
    {
        private readonly AcmeContext _context;

        public AdministratorController(AcmeContext context)
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
        public async Task<IActionResult> Login(string inUsername, string inPassword)
        {
            if (ModelState.IsValid)
            {
                string hashPassword = new Security().ComputeSha256Hash(inPassword);

                Administrator getUser = await _context.Administrators
                    .FirstOrDefaultAsync(m => m.AdministratorUsername.Equals(inUsername) & m.AdministratorPassword.Equals(hashPassword));

                if (getUser == null)
                {
                    ViewBag.userNotFound = "You have entered an invalid username or password";
                    return Login();
                }

                //success, sending user to dashboard
                HttpContext.Session.SetInt32("currentAdminId", getUser.AdministratorId);//storing PK of user
                return RedirectToAction("index", "products");

            }
            return View();
        }

        // GET: Administrator/Create
        public IActionResult Signup()
        {
            return View();
        }

        // POST: Administrator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup([Bind("AdministratorId,AdministratorEmployeeNumber,AdministratorUsername,AdministratorPassword")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                administrator.AdministratorPassword = new Security().ComputeSha256Hash(administrator.AdministratorPassword);
                _context.Add(administrator);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32("currentUserId", administrator.AdministratorId);

                return RedirectToAction(nameof(Index));
            }
            return View(administrator);
        }

        // GET: Administrator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }
            return View(administrator);
        }

        // GET: Administrator
        public async Task<IActionResult> Index()
        {
            return View(await _context.Administrators.ToListAsync());
        }

        // GET: Administrator/Details/5
        public async Task<IActionResult> Details()
        {
            int? id = HttpContext.Session.GetInt32("currentAdminId");

            if (id == null)
            {
                return RedirectToAction("login", "client");
            }

            var administrator = await _context.Administrators
                .FirstOrDefaultAsync(m => m.AdministratorId == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        

        // POST: Administrator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdministratorId,AdministratorEmployeeNumber,AdministratorUsername,AdministratorPassword")] Administrator administrator)
        {
            if (id != administrator.AdministratorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    administrator.AdministratorPassword = new Security().ComputeSha256Hash(administrator.AdministratorPassword);
                    _context.Update(administrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministratorExists(administrator.AdministratorId))
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
            return View(administrator);
        }

        // GET: Administrator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators
                .FirstOrDefaultAsync(m => m.AdministratorId == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // POST: Administrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrator = await _context.Administrators.FindAsync(id);
            _context.Administrators.Remove(administrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministratorExists(int id)
        {
            return _context.Administrators.Any(e => e.AdministratorId == id);
        }
    }
}
