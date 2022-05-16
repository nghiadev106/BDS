using BDS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BDS.Areas.Admin.Models.News;
using BDS.Models;

namespace BDS.Services
{
     public interface INewsService
    {
        Task<List<NewsViewModel>> GetAll();

        Task<int> Create(NewsCreateRequest request);

        Task<NewsViewModel> Detail(int id);

        Task<NewsUpdateRequest> Edit(int id);

        Task<int> Update(NewsUpdateRequest request);

        Task<int> Delete(int id);
    }
    public class NewsService:INewsService
    {
        private readonly BDSContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "uploads";

        public NewsService(BDSContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<NewsViewModel>> GetAll()
        {

            return await _context.News.Select(p => new NewsViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                CategotyName = p.Category.Name,
                Description = p.Description,
                Detail = p.Detail,
                IsNew = p.IsNew,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

         public async Task<int> Create(NewsCreateRequest request)
        {
            try
            {
                News news = new News()
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
                if(request.FileUpload != null)
                {
                    news.Image = await SaveFile(request.FileUpload);
                }
                _context.News.Add(news);
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
                News news = await _context.News.FindAsync(id);
                if (news == null) return -1;
                if (news.Image != null)
                {
                    await _storageService.DeleteFileAsync(news.Image);
                }
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<NewsViewModel> Detail(int id)
        {
            try
            {
                return await _context.News.Where(x=>x.Id==id).Select(p => new NewsViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.Image,
                    CategotyName = p.Category.Name,
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

        public async Task<NewsUpdateRequest> Edit(int id)
        {
            try
            {
                News news = await _context.News.FindAsync(id);
                if (news == null) return null;
                NewsUpdateRequest updateNewsViewModel = new NewsUpdateRequest()
                {
                    Id = news.Id,
                    Name = news.Name,
                    Image = news.Image,
                    CategoryId = news.CategoryId,
                    Description = news.Description,
                    Detail = news.Detail,
                    IsNew = news.IsNew,
                    Url = news.Url,
                    DisplayOrder = news.DisplayOrder,
                    Status = news.Status
                };

                return updateNewsViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }  
     
        public async Task<int> Update(NewsUpdateRequest request)
        {
            try
            {
                News news = await _context.News.FindAsync(request.Id);
                if (news == null) return -1;
                news.Name = request.Name;
                news.CategoryId = request.CategoryId;
                news.Description = request.Description;
                news.Detail = request.Detail;
                news.IsNew = request.IsNew;
                news.Url = request.Url;
                news.DisplayOrder = request.DisplayOrder;
                news.Status = request.Status;
                news.EditDate = DateTime.Now;
                if (request.FileUpload != null)
                {
                    await _storageService.DeleteFileAsync(news.Image);
                    news.Image = await SaveFile(request.FileUpload);
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
