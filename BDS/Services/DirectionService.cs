using BDS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDS.Services
{
    public interface IDirectionService
    {

        Task<List<Direction>> GetAll();
    }
    public class DirectionService : IDirectionService
    {
        private readonly BDSContext _context;

        public DirectionService(BDSContext context)
        {
            _context = context;
        }

        public async Task<List<Direction>> GetAll()
        {

            return await _context.Directions.ToListAsync();
        }
    }
}
