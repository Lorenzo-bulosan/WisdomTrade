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
    public class WisdomTradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WisdomTradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WisdomTrades
        public async Task<IActionResult> Index()
        {
            return View(await _context.WisdomTrade.ToListAsync());
        }

        // GET: WisdomTrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wisdomTrade = await _context.WisdomTrade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wisdomTrade == null)
            {
                return NotFound();
            }

            return View(wisdomTrade);
        }

        // GET: WisdomTrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WisdomTrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ticker,Population,TotalCredit,AverageUpperLimit,AverageLowerLimit,FinalDirection")] WisdomTrade wisdomTrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wisdomTrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wisdomTrade);
        }

        // GET: WisdomTrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wisdomTrade = await _context.WisdomTrade.FindAsync(id);
            if (wisdomTrade == null)
            {
                return NotFound();
            }
            return View(wisdomTrade);
        }

        // POST: WisdomTrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ticker,Population,TotalCredit,AverageUpperLimit,AverageLowerLimit,FinalDirection")] WisdomTrade wisdomTrade)
        {
            if (id != wisdomTrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wisdomTrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WisdomTradeExists(wisdomTrade.Id))
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
            return View(wisdomTrade);
        }

        // GET: WisdomTrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wisdomTrade = await _context.WisdomTrade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wisdomTrade == null)
            {
                return NotFound();
            }

            return View(wisdomTrade);
        }

        // POST: WisdomTrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wisdomTrade = await _context.WisdomTrade.FindAsync(id);
            _context.WisdomTrade.Remove(wisdomTrade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WisdomTradeExists(int id)
        {
            return _context.WisdomTrade.Any(e => e.Id == id);
        }
    }
}
