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
    public class TraderAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TraderAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TraderAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.TraderAccount.ToListAsync());
        }

        // GET: TraderAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traderAccount = await _context.TraderAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (traderAccount == null)
            {
                return NotFound();
            }

            return View(traderAccount);
        }

        // GET: TraderAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TraderAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Credits")] TraderAccount traderAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traderAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(traderAccount);
        }

        // GET: TraderAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traderAccount = await _context.TraderAccount.FindAsync(id);
            if (traderAccount == null)
            {
                return NotFound();
            }
            return View(traderAccount);
        }

        // POST: TraderAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Credits")] TraderAccount traderAccount)
        {
            if (id != traderAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traderAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraderAccountExists(traderAccount.Id))
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
            return View(traderAccount);
        }

        // GET: TraderAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traderAccount = await _context.TraderAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (traderAccount == null)
            {
                return NotFound();
            }

            return View(traderAccount);
        }

        // POST: TraderAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traderAccount = await _context.TraderAccount.FindAsync(id);
            _context.TraderAccount.Remove(traderAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraderAccountExists(int id)
        {
            return _context.TraderAccount.Any(e => e.Id == id);
        }
    }
}
