using BDS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDS.Services
{
    public interface IProvinceService
    {

        Task<List<Province>> GetAll();
    }
    public class ProvinceService : IProvinceService
    {
        private readonly BDSContext _context;

        public ProvinceService(BDSContext context)
        {
            _context = context;
        }

        public async Task<List<Province>> GetAll()
        {

            return await _context.Provinces.ToListAsync();
        }
    }
}
