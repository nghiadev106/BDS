using BDS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Services
{
    public interface IDistrictService
    {

        Task<List<District>> GetAll();
        Task<List<District>> GetByProvince(int id);
    }
    public class DistrictService : IDistrictService
    {
        private readonly BDSContext _context;

        public DistrictService(BDSContext context)
        {
            _context = context;
        }

        public async Task<List<District>> GetAll()
        {

            return await _context.Districts.ToListAsync();
        }

        public async Task<List<District>> GetByProvince(int id)
        {

            return await _context.Districts.Where(x => x.ProvinceId == id).ToListAsync();
        }

    }
}
