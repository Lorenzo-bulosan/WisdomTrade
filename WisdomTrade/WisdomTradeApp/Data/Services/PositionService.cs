using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Data.Services
{
    public class PositionService:IPositionService
    {
        private ApplicationDbContext _context;

        public PositionService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<List<Position>> GetAllPositionsAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetPositionAsync(int id)
        {
            return await _context.Positions
               .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddPositionAsync(Position position)
        {
            _context.Add(position);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePositionAsync(Position position)
        {
            _context.Update(position);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync (Position position)
        {
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
        }
        public bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }

        /// <summary>
        /// Method that returns a report by grouping ticker and date
        /// and aggregates population by counting number of positions and 
        /// averaging the prices of the groups
        /// </summary>
        /// <returns></returns>
        public IQueryable<WisdomTrade> GetWisdomTrades()
        {
            var wisdomTrades =
                from c in _context.Positions
                group c by new
                {
                    c.Ticker,
                    c.Date,
                } into gcs
                select new WisdomTrade()
                {
                    Ticker = gcs.Key.Ticker,
                    Date = gcs.Key.Date,
                    Population = gcs.Count(),
                    FinalPricePrediction = gcs.Average(g => g.PricePrediction)
                };
            return wisdomTrades;
        }
    }
}
