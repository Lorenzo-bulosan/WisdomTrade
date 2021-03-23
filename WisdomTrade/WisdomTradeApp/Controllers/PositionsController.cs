using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WisdomTradeApp.Data;
using WisdomTradeApp.Data.Services;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Controllers
{
    [Authorize]
    public class PositionsController : Controller
    {
        private IPositionService _positionService;
        private readonly ApplicationDbContext _context;

        public PositionsController(ApplicationDbContext context, IPositionService positionService)
        {
            _context = context;
            _positionService = positionService;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            return View(await _positionService.GetAllPositionsAsync());
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var position = await _positionService.GetPositionAsync((int)id);

            if (position == null) return NotFound();

            return View(position);
        }

        // GET: Positions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ticker,Date,PricePrediction")] Position position)
        {
            if (ModelState.IsValid)
            {
                await _positionService.AddPositionAsync(position);
                return RedirectToAction(nameof(Index));
            }

            return View(position);            
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            //var position = await _context.Positions.FindAsync(id);
            var position = await _positionService.GetPositionAsync((int)id);

            if (position == null) return NotFound();

            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ticker,Date,PricePrediction")] Position position)
        {
            if (id != position.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _positionService.UpdatePositionAsync(position);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(position.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(position);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }
        private int CountPositions(string ticker, DateTime date)
        {
            return _context.Positions
                .Where(p => p.Ticker == ticker && p.Date==date).Count();
        }
        private IEnumerable<Position> GetAllPositions(string ticker, DateTime date)
        {
            return _context.Positions
                .Where(p => p.Ticker == ticker && p.Date == date);
        }
    }
}
