using BDS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BDS.Areas.Admin.Models.Furniture;
using BDS.Models;

namespace BDS.Services
{
    public interface IFurnitureService
    {
        Task<List<FurnitureViewModel>> GetAll();

        Task<int> Create(FurnitureCreateRequest request);

        Task<FurnitureViewModel> Detail(int id);

        Task<FurnitureUpdateRequest> Edit(int id);

        Task<int> Update(FurnitureUpdateRequest request);

        Task<int> Delete(int id);
    }
    public class FurnitureService : IFurnitureService
    {
        private readonly BDSContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "uploads";

        public FurnitureService(BDSContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<FurnitureViewModel>> GetAll()
        {

            return await _context.Furnitures.Select(p => new FurnitureViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Description = p.Description,
                Detail = p.Detail,
                IsNew = p.IsNew,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

        public async Task<int> Create(FurnitureCreateRequest request)
        {
            try
            {
                Furniture topic = new Furniture()
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
                _context.Furnitures.Add(topic);
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
                Furniture topic = await _context.Furnitures.FindAsync(id);
                if (topic == null) return -1;
                if (topic.Image != null)
                {
                    await _storageService.DeleteFileAsync(topic.Image);
                }
                _context.Furnitures.Remove(topic);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<FurnitureViewModel> Detail(int id)
        {
            try
            {
                return await _context.Furnitures.Where(x => x.Id == id).Select(p => new FurnitureViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.Image,
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

        public async Task<FurnitureUpdateRequest> Edit(int id)
        {
            try
            {
                Furniture topic = await _context.Furnitures.FindAsync(id);
                if (topic == null) return null;
                FurnitureUpdateRequest updateFurnitureViewModel = new FurnitureUpdateRequest()
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

                return updateFurnitureViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> Update(FurnitureUpdateRequest request)
        {
            try
            {
                Furniture topic = await _context.Furnitures.FindAsync(request.Id);
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
