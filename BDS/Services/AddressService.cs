using BDS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDS.Services
{
    public interface IAddressService
    {

        Task<List<Address>> GetAll();
    }
    public class AddressService : IAddressService
    {
        private readonly BDSContext _context;

        public AddressService(BDSContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetAll()
        {

            return await _context.Addresses.ToListAsync();
        }

    }
}
