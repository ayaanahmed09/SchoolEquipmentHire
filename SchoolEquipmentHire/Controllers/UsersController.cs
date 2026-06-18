using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolEquipmentHire.Areas.Identity.Pages.Account;

namespace SchoolEquipmentHire.Controllers
{
    public class UsersController : Controller
    {
        private readonly SchoolEquipmentContext _context;

        public UsersController(SchoolEquipmentContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var roles = new List<SelectListItem> { new SelectListItem { Value = "", Text = "--Select Role--" } };
            roles.AddRange(Enum.GetValues(typeof(RoleType)).Cast<RoleType>()
                .Select(r => new SelectListItem { Value = r.ToString(), Text = r.ToString() }));
            ViewBag.Role = roles;
            var yearLevels = new List<SelectListItem> { new SelectListItem { Value = "", Text = "--Select Year Level--" } };
            yearLevels.AddRange(Enumerable.Range(9, 5).Select(y => new SelectListItem { Value = y.ToString(), Text = y.ToString() }));
            ViewBag.YearLevels = yearLevels;
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,YearLevel,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var roles = new List<SelectListItem> { new SelectListItem { Value = "", Text = "--Select Role--" } };
            roles.AddRange(Enum.GetValues(typeof(RoleType)).Cast<RoleType>()
                .Select(r => new SelectListItem { Value = r.ToString(), Text = r.ToString() }));
            ViewBag.Role = roles;
            var yearLevels = new List<SelectListItem> { new SelectListItem { Value = "", Text = "--Select Year Level--" } };
            yearLevels.AddRange(Enumerable.Range(9, 5).Select(y => new SelectListItem { Value = y.ToString(), Text = y.ToString() }));
            ViewBag.YearLevels = yearLevels;
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var roles = new List<SelectListItem> { new SelectListItem { Value = "", Text = "--Select Role--" } };
            roles.AddRange(Enum.GetValues(typeof(RoleType)).Cast<RoleType>()
                .Select(r => new SelectListItem { Value = r.ToString(), Text = r.ToString() }));
            ViewBag.Role = roles;
            var yearLevels = new List<SelectListItem> { new SelectListItem { Value = "", Text = "--Select Year Level--" } };
            yearLevels.AddRange(Enumerable.Range(9, 5).Select(y => new SelectListItem { Value = y.ToString(), Text = y.ToString() }));
            ViewBag.YearLevels = yearLevels;
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,YearLevel,Role")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
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
            var roles = new List<SelectListItem> { new SelectListItem { Value = "", Text = "--Select Role--" } };
            roles.AddRange(Enum.GetValues(typeof(RoleType)).Cast<RoleType>()
                .Select(r => new SelectListItem { Value = r.ToString(), Text = r.ToString() }));
            ViewBag.Role = roles;
            var yearLevels = new List<SelectListItem> { new SelectListItem { Value = "", Text = "--Select Year Level--" } };
            yearLevels.AddRange(Enumerable.Range(9, 5).Select(y => new SelectListItem { Value = y.ToString(), Text = y.ToString() }));
            ViewBag.YearLevels = yearLevels;
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.ID == id);
        }
    }
}
