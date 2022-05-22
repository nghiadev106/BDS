using BDS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Services
{
    public interface IWardService
    {

        Task<List<Ward>> GetAll();
        Task<List<Ward>> GetByDistirct(int id);
    }
    public class WardService : IWardService
    {
        private readonly BDSContext _context;

        public WardService(BDSContext context)
        {
            _context = context;
        }

        public async Task<List<Ward>> GetAll()
        {

            return await _context.Wards.ToListAsync();
        }

        public async Task<List<Ward>> GetByDistirct(int id)
        {

            return await _context.Wards.Where(x=>x.DistrictId==id).ToListAsync();
        }

    }
}
