using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolEquipmentHire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolEquipmentHire.Controllers
{
    public class BookingsController : Controller
    {
        private readonly SchoolEquipmentContext _context;

        public BookingsController(SchoolEquipmentContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Booking
        .Include(b => b.Equipment)
        .Include(b => b.User)
        .ToListAsync();

            foreach (var b in bookings)
            {
                if (b.Status != "Returned") // Don't override returned bookings
                {
                    if (b.ReturnDate < DateTime.Now)
                        b.Status = "Overdue";
                    else if (b.Status == "Pending")
                        b.Status = "Approved"; // Example logic
                }
            }

            await _context.SaveChangesAsync();
            return View(bookings);
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,UserID,EquipmentID,BookingDate,ReturnDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                // Auto status when booking is created
                booking.Status = "Pending";   // Default status

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,UserID,EquipmentID,BookingDate,ReturnDate")] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingID))
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
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            if (booking != null)
            {
                _context.Booking.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingID == id);
        }

        public async Task<IActionResult> MarkReturned(int id)
        {
            var booking = await _context.Booking.FindAsync(id);

            if (booking == null)
                return NotFound();

            booking.Status = "Returned";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Book(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);

            if (equipment == null)
                return NotFound();

            if (equipment.Quantity <= 0)
            {
                TempData["ErrorMessage"] = "Equipment is fully booked.";
                return RedirectToAction("Details", new { id });
            }

            equipment.Quantity -= 1;

            var booking = new Booking
            {
                BookingDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(3),
                Status = "Pending",
                EquipmentID = equipment.ID,
                UserID = User.FindFirstValue(ClaimTypes.NameIdentifier) // REQUIRED
            };

            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Bookings");
        }


    }
}
