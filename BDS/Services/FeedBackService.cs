using BDS.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Services
{
    public interface IFeedbackService
    {
        Task<List<Feedback>> GetAll();
        Task<int> Create(Feedback request);
        Task<Feedback> Detail(int id);
        Task<int> Update(int id);
        Task<int> Delete(int id);
    }
    public class FeedbackService : IFeedbackService
    {
        private readonly BDSContext _context;

        public FeedbackService(BDSContext flowerContext)
        {
            _context = flowerContext;
        }

        public async Task<int> Create(Feedback request)
        {
            try
            {
                Feedback fb = new Feedback()
                {
                    Name = request.Name,
                    Email = request.Email,
                    Phone = request.Phone,
                    Address = request.Address,
                    Message = request.Message,
                    Status = 0,
                    CreateDate = DateTime.Now
                };
                _context.Feedbacks.Add(fb);
                int res = await _context.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                Feedback fb = await _context.Feedbacks.FindAsync(id);
                if (fb == null) return -1;
                _context.Feedbacks.Remove(fb);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<Feedback> Detail(int id)
        {
            try
            {
                Feedback fb = await _context.Feedbacks.FindAsync(id);
                Feedback detailFeedback = new Feedback()
                {
                    Id = fb.Id,
                    Name = fb.Name,
                    Email = fb.Email,
                    Phone = fb.Phone,
                    Address = fb.Address,
                    Message = fb.Message,
                    Status = fb.Status
                };
                return detailFeedback;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Feedback>> GetAll()
        {

            return await _context.Feedbacks.Select(p => new Feedback()
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Phone = p.Phone,
                Address = p.Address,
                Message = p.Message,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

        public async Task<int> Update(int id)
        {
            try
            {
                Feedback fb = await _context.Feedbacks.FindAsync(id);
                if (fb == null) return -1;
                fb.Status = 1;
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
