using BDS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BDS.Areas.Admin.Models.FengShui;
using BDS.Models;

namespace BDS.Services
{
    public interface IFengShuiService
    {
        Task<List<FengShuiViewModel>> GetAll();

        Task<int> Create(FengShuiCreateRequest request);

        Task<FengShuiViewModel> Detail(int id);

        Task<FengShuiUpdateRequest> Edit(int id);

        Task<int> Update(FengShuiUpdateRequest request);

        Task<int> Delete(int id);
    }
    public class FengShuiService : IFengShuiService
    {
        private readonly BDSContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "uploads";

        public FengShuiService(BDSContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<FengShuiViewModel>> GetAll()
        {

            return await _context.FengShuis.Select(p => new FengShuiViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                CategoryName = p.Category.Name,
                Description = p.Description,
                Detail = p.Detail,
                IsNew = p.IsNew,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

        public async Task<int> Create(FengShuiCreateRequest request)
        {
            try
            {
                FengShui topic = new FengShui()
                {
                    Name = request.Name,
                    Image = request.Image,
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    Detail = request.Detail,
                    IsNew = request.IsNew,
                    Url = request.Url,
                    DisplayOrder = request.DisplayOrder,
                    Status = request.Status,
                    CreateDate = DateTime.Now
                };
                if (request.FileUpload != null)
                {
                    topic.Image = await SaveFile(request.FileUpload);
                }
                _context.FengShuis.Add(topic);
                int res = await _context.SaveChangesAsync();
                return res;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                FengShui topic = await _context.FengShuis.FindAsync(id);
                if (topic == null) return -1;
                if (topic.Image != null)
                {
                    await _storageService.DeleteFileAsync(topic.Image);
                }
                _context.FengShuis.Remove(topic);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<FengShuiViewModel> Detail(int id)
        {
            try
            {
                return await _context.FengShuis.Where(x => x.Id == id).Select(p => new FengShuiViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.Image,
                    CategoryName = p.Category.Name,
                    Description = p.Description,
                    Detail = p.Detail,
                    IsNew = p.IsNew
                }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<FengShuiUpdateRequest> Edit(int id)
        {
            try
            {
                FengShui topic = await _context.FengShuis.FindAsync(id);
                if (topic == null) return null;
                FengShuiUpdateRequest updateFengShuiViewModel = new FengShuiUpdateRequest()
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    Image = topic.Image,
                    CategoryId = topic.CategoryId,
                    Description = topic.Description,
                    Detail = topic.Detail,
                    IsNew = topic.IsNew,
                    Url = topic.Url,
                    DisplayOrder = topic.DisplayOrder,
                    Status = topic.Status
                };

                return updateFengShuiViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> Update(FengShuiUpdateRequest request)
        {
            try
            {
                FengShui topic = await _context.FengShuis.FindAsync(request.Id);
                if (topic == null) return -1;
                topic.Name = request.Name;
                topic.CategoryId = request.CategoryId;
                topic.Description = request.Description;
                topic.Detail = request.Detail;
                topic.IsNew = request.IsNew;
                topic.Url = request.Url;
                topic.DisplayOrder = request.DisplayOrder;
                topic.Status = request.Status;
                topic.EditDate = DateTime.Now;
                if (request.FileUpload != null)
                {
                    await _storageService.DeleteFileAsync(topic.Image);
                    topic.Image = await SaveFile(request.FileUpload);
                }
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

    }
}
