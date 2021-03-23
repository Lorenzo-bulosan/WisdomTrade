using System.Collections.Generic;
using System.Threading.Tasks;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Data.Services
{
    public interface IPositionService
    {
        public Task<List<Position>> GetAllPositionsAsync();
        public Task<Position> GetPosition(int id);
    }
}