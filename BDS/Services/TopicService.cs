using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDS.Areas.Admin.Models.Topic;
using BDS.Models;
using BDS.Model;

namespace BDS.Services
{
    public interface ITopicService
    {

        Task<List<TopicViewModel>> GetAll();
        Task<List<TopicViewModel>> GetEdit(int id);

        Task<int> Create(TopicRequest request);

        Task<TopicViewModel> Detail(int id);

        Task<TopicRequest> Edit(int id);

        Task<int> Update(TopicRequest request);

        Task<int> Delete(int id);
    }
    public class TopicService : ITopicService
    {
        private readonly BDSContext _context;

        public TopicService(BDSContext context)
        {
            _context = context;
        }

        public async Task<int> Create(TopicRequest request)
        {
            try
            {
                Topic topic = new Topic()
                {
                    Name = request.Name,                  
                    Description = request.Description,   
                    ParentId=request.ParentId,
                    ShowHome = request.ShowHome,
                    Url = request.Url,
                    DisplayOrder = request.DisplayOrder,
                    Status = request.Status,
                    CreateDate = DateTime.Now
                };
                _context.Topics.Add(topic);
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
                Topic topic = await _context.Topics.FindAsync(id);
                if (topic == null) return -1;
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<TopicViewModel> Detail(int id)
        {
            try
            {
                Topic topic = await _context.Topics.FindAsync(id);
                TopicViewModel detailTopicViewModel = new TopicViewModel()
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    ParentId=topic.ParentId,
                    ShowHome = topic.ShowHome,
                    Description = topic.Description,
                    Url = topic.Url,
                    DisplayOrder = topic.DisplayOrder,
                    Status = topic.Status
                };
                return detailTopicViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TopicRequest> Edit(int id)
        {
            try
            {
                Topic topic = await _context.Topics.FindAsync(id);
                if (topic == null) return null;
                TopicRequest updateTopicsViewModel = new TopicRequest()
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    ParentId=topic.ParentId,
                    ShowHome = topic.ShowHome,
                    Description = topic.Description, 
                    Url = topic.Url,
                    DisplayOrder = topic.DisplayOrder,
                    Status = topic.Status
                };

                return updateTopicsViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<TopicViewModel>> GetAll()
        {

            return await _context.Topics.Select(p => new TopicViewModel()
            {

                Id = p.Id,
                Name = p.Name,               
                ParentId=p.ParentId,
                Description = p.Description,
                ShowHome = p.ShowHome,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

        public async Task<List<TopicViewModel>> GetEdit(int id)
        {

            return await _context.Topics.Where(x=>x.Id!=id).Select(p => new TopicViewModel()
            {

                Id = p.Id,
                Name = p.Name,
                ParentId = p.ParentId,
                Description = p.Description,
                ShowHome = p.ShowHome,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }



        public async Task<int> Update(TopicRequest request)
        {
            try
            {
                Topic topic = await _context.Topics.FindAsync(request.Id);
                if (topic == null) return -1;
                topic.Name = request.Name;
                topic.ParentId = request.ParentId;
                topic.Description = request.Description;           
                topic.Url = request.Url;
                topic.DisplayOrder = request.DisplayOrder;
                topic.Status = request.Status;
                topic.ShowHome = request.ShowHome;
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
