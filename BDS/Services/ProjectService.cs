using BDS.Areas.Admin.Models.Project;
using BDS.Model;
using BDS.Models;
using BDS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BDS.Services
{
    public interface IProjectService
    {
        Task<PaginationViewModel> Pagination(Dictionary<string, object> data);

        Task<List<ProjectViewModel>> GetAll();

        Task<int> Create(ProjectCreateRequest request);

        Task<ProjectViewModel> Detail(int id);

        Task<ProjectUpdateRequest> Edit(int id);

        Task<int> Update(ProjectUpdateRequest request);

        Task<int> Delete(int id);
    }
    public class ProjectService : IProjectService
    {
        private readonly BDSContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "uploads";

        public ProjectService(BDSContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<ProjectViewModel>> GetAll()
        {
            return await _context.Projects.Select(p => new ProjectViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                CategoryName = p.Category.Name,
                Description = p.Description,
                Price = p.Price,
                Detail = p.Detail,
                IsNew = p.IsNew,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate,
                IsHot=p.IsHot,
                Acreage=p.Acreage,
                AddressId=p.AddressId,
                AddressDetail=p.AddressDetail
            }).OrderByDescending(x => x.CreateDate).ToListAsync();
        }

        public async Task<PaginationViewModel> Pagination(Dictionary<string, object> data)
        {
            PaginationViewModel paginationViewModel = new PaginationViewModel();
            try
            {
                int page = int.Parse(data["page"].ToString());
                int pageSize = int.Parse(data["pageSize"].ToString());
                string nameSearch = "";
                if (data.ContainsKey("nameSearch") && !string.IsNullOrEmpty(data["nameSearch"].ToString().Trim()))
                    nameSearch = data["nameSearch"].ToString().Trim().ToLower();
                paginationViewModel.Page = page;
                paginationViewModel.PageSize = pageSize;
                paginationViewModel.TotalItems = await _context.Projects.Where(x => x.Name.ToLower().IndexOf(nameSearch) >= 0).CountAsync();
                var model = from p in _context.Projects
                            select new ProjectViewModel
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Image = p.Image,
                                CategoryName = p.Category.Name,
                                Description = p.Description,
                                Price = p.Price,
                                Detail = p.Detail,
                                IsNew = p.IsNew,
                                Url = p.Url,
                                DisplayOrder = p.DisplayOrder,
                                Status = p.Status,
                                CreateDate = p.CreateDate,
                                IsHot = p.IsHot,
                                Acreage = p.Acreage,
                                AddressId = p.AddressId,
                                AddressDetail = p.AddressDetail
                            };
                string sortByName = "";
                if (data.ContainsKey("sortByName") && !string.IsNullOrEmpty(data["sortByName"].ToString().Trim()))
                    sortByName = data["sortByName"].ToString().Trim().ToLower();
                switch (sortByName)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Name);
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Name);
                        break;
                }
                string sortByCreatedDate = "";
                if (data.ContainsKey("sortByCreatedDate") && !string.IsNullOrEmpty(data["sortByCreatedDate"].ToString().Trim()))
                    sortByCreatedDate = data["sortByCreatedDate"].ToString().Trim().ToLower();
                switch (sortByCreatedDate)
                {
                    case "asc":
                        model = model.OrderBy(x => x.CreateDate);
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.CreateDate);
                        break;
                }
                string sortByPrice = "";
                if (data.ContainsKey("sortByPrice") && !string.IsNullOrEmpty(data["sortByPrice"].ToString().Trim()))
                    sortByPrice = data["sortByPrice"].ToString().Trim().ToLower();
                switch (sortByPrice)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Price);
                        break;
                    case "desc":
                        model = model.OrderByDescending(x => x.Price);
                        break;
                }
                paginationViewModel.Data = model.Where(x => x.Name.ToLower().IndexOf(nameSearch) >= 0).Skip((page - 1) * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paginationViewModel;
        }

        public async Task<int> Create(ProjectCreateRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Project project = new Project()
                    {
                        Name = request.Name,
                        Image = request.Image,
                        CategoryId = request.CategoryId,
                        Description = request.Description,
                        Price = request.Price,
                        Detail = request.Detail,
                        IsNew = request.IsNew,
                        Url = request.Url,
                        DisplayOrder = request.DisplayOrder,
                        Status = request.Status,
                        CreateDate = DateTime.Now,
                        IsHot = request.IsHot,
                        Acreage = request.Acreage,
                        AddressId = request.AddressId,
                        AddressDetail = request.AddressDetail
                    };
                    if (request.File != null)
                    {
                        project.Image = await SaveFile(request.File);
                    }
                    _context.Projects.Add(project);
                    await _context.SaveChangesAsync();

                    if (request.Files != null)
                    {
                        foreach (var item in request.Files)
                        {
                            ProjectImage image = new ProjectImage()
                            {
                                ProjectId = project.Id,
                                Path = await SaveFile(item)
                            };
                            _context.ProjectImages.Add(image);
                        }
                    };

                    int res = await _context.SaveChangesAsync();
                    transaction.Commit();
                    return res;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        public async Task<int> Update(ProjectUpdateRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Project project = await _context.Projects.FindAsync(request.Id);
                    if (project == null) return -1;
                    project.Name = request.Name;
                    project.CategoryId = request.CategoryId;
                    project.Description = request.Description;
                    project.Price = request.Price;
                    project.Detail = request.Detail;
                    project.IsNew = request.IsNew;
                    project.Url = request.Url;
                    project.DisplayOrder = request.DisplayOrder;
                    project.Status = request.Status;
                    project.EditDate = DateTime.Now;
                    project.IsHot = request.IsHot;
                    project.Acreage = request.Acreage;
                    project.AddressId = request.AddressId;
                    project.AddressDetail = request.AddressDetail;
                    if (request.File != null)
                    {
                        await _storageService.DeleteFileAsync(project.Image);
                        project.Image = await SaveFile(request.File);
                    }

                    if (request.Files != null)
                    {
                        List<ProjectImage> images = await _context.ProjectImages.Where(x => x.ProjectId == project.Id).ToListAsync();
                        if (images.Count() > 0)
                        {
                            foreach (var item in images)
                            {
                                _context.ProjectImages.Remove(item);
                                await _storageService.DeleteFileAsync(item.Path);
                            }
                        }

                        foreach (var item in request.Files)
                        {
                            ProjectImage image = new ProjectImage()
                            {
                                ProjectId = project.Id,
                                Path = await SaveFile(item)
                            };
                            _context.ProjectImages.Add(image);
                        }
                    };
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Project project = await _context.Projects.FindAsync(id);
                    if (project == null) return -1;
                    if (project.Image != null)
                    {
                        await _storageService.DeleteFileAsync(project.Image);
                    }
                    List<ProjectImage> images = await _context.ProjectImages.Where(x => x.ProjectId == id).ToListAsync();
                    if (images.Count() > 0)
                    {
                        foreach (var item in images)
                        {
                            _context.ProjectImages.Remove(item);
                            await _storageService.DeleteFileAsync(item.Path);
                        }
                    }
                    _context.Projects.Remove(project);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return 1;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        public async Task<ProjectViewModel> Detail(int id)
        {
            try
            {
                return await _context.Projects.Where(x => x.Id == id).Select(p => new ProjectViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.Image,
                    CategoryName = p.Category.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Detail = p.Detail,
                    Url = p.Url,
                    IsNew = p.IsNew,
                    CategoryId = p.CategoryId,
                    DisplayOrder = p.DisplayOrder,
                    Status = p.Status,
                    CreateDate = p.CreateDate,
                    IsHot = p.IsHot,
                    Acreage = p.Acreage,
                    AddressId = p.AddressId,
                    AddressDetail = p.AddressDetail,
                    Images = _context.ProjectImages.Where(x => x.ProjectId == id).ToList()
                }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ProjectUpdateRequest> Edit(int id)
        {
            try
            {
                Project project = await _context.Projects.FindAsync(id);
                if (project == null) return null;
                ProjectUpdateRequest updateProjectsViewModel = new ProjectUpdateRequest()
                {
                    Id = project.Id,
                    Name = project.Name,
                    Image = project.Image,
                    CategoryId = project.CategoryId,
                    Description = project.Description,
                    Price = project.Price,
                    Detail = project.Detail,
                    IsNew = project.IsNew,
                    Url = project.Url,
                    DisplayOrder = project.DisplayOrder,
                    Status = project.Status,
                    IsHot = project.IsHot,
                    Acreage = project.Acreage,
                    AddressId = project.AddressId,
                    AddressDetail = project.AddressDetail,
                    Images = _context.ProjectImages.Where(x => x.ProjectId == id).ToList()
                };

                return updateProjectsViewModel;
            }
            catch (Exception)
            {
                return null;
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
