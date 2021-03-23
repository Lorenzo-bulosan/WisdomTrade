using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<Position> GetPosition(int id)
        {
            return await _context.Positions
               .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
