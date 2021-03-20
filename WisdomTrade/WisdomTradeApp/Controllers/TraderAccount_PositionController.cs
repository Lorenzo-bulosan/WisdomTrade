using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WisdomTradeApp.Data;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Controllers
{
    public class TraderAccount_PositionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TraderAccount_PositionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TraderAccount_Position
        public async Task<IActionResult> Index()
        {
            return View(await _context.TraderAccount_Position.ToListAsync());
        }

        // GET: TraderAccount_Position/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traderAccount_Position = await _context.TraderAccount_Position
                .FirstOrDefaultAsync(m => m.Id == id);
            if (traderAccount_Position == null)
            {
                return NotFound();
            }

            return View(traderAccount_Position);
        }

        // GET: TraderAccount_Position/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TraderAccount_Position/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PositionId,TraderEmail")] TraderAccount_Position traderAccount_Position)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traderAccount_Position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(traderAccount_Position);
        }

        // GET: TraderAccount_Position/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traderAccount_Position = await _context.TraderAccount_Position.FindAsync(id);
            if (traderAccount_Position == null)
            {
                return NotFound();
            }
            return View(traderAccount_Position);
        }

        // POST: TraderAccount_Position/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PositionId,TraderEmail")] TraderAccount_Position traderAccount_Position)
        {
            if (id != traderAccount_Position.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traderAccount_Position);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraderAccount_PositionExists(traderAccount_Position.Id))
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
            return View(traderAccount_Position);
        }

        // GET: TraderAccount_Position/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traderAccount_Position = await _context.TraderAccount_Position
                .FirstOrDefaultAsync(m => m.Id == id);
            if (traderAccount_Position == null)
            {
                return NotFound();
            }

            return View(traderAccount_Position);
        }

        // POST: TraderAccount_Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traderAccount_Position = await _context.TraderAccount_Position.FindAsync(id);
            _context.TraderAccount_Position.Remove(traderAccount_Position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraderAccount_PositionExists(int id)
        {
            return _context.TraderAccount_Position.Any(e => e.Id == id);
        }
    }
}
