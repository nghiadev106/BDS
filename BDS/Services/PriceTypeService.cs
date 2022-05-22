using BDS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDS.Services
{
    public interface IPriceTypeService
    {

        Task<List<PriceType>> GetAll();
    }
    public class PriceTypeService : IPriceTypeService
    {
        private readonly BDSContext _context;

        public PriceTypeService(BDSContext context)
        {
            _context = context;
        }

        public async Task<List<PriceType>> GetAll()
        {

            return await _context.PriceTypes.ToListAsync();
        }
    }
}
