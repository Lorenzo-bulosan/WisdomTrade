using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Data.Services
{
    public interface IPositionService
    {
        public Task<List<Position>> GetAllPositionsAsync();
        public Task<Position> GetPositionAsync(int id);
        public Task AddPositionAsync(Position position);
        public Task UpdatePositionAsync(Position position);
        public Task DeleteAsync(Position position);
        public bool PositionExists(int id);
        public IQueryable<WisdomTrade> GetWisdomTrades();
    }
}