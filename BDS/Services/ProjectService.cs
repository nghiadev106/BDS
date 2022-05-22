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
        List<ProjectViewModel> Search(string keyword, int categoryId, int provinceId, int districtId, int wardId, string fromPrice, int fromPriceType, string toPrice, int toPriceType, string fromAcreage, string toAcreage);

        Task<List<ProjectViewModel>> GetAll();

        Task<List<ProjectViewModel>> GetByCategoryId(int id);

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
                WardId=p.WardId,
                DirectionName=p.Direction.Name,
                PriceTypeName=p.PriceType.Name,
                AddressDetail=p.AddressDetail,
                Phone=p.Phone
            }).OrderByDescending(x => x.CreateDate).ToListAsync();
        }

        public async Task<List<ProjectViewModel>> GetByCategoryId(int id)
        {
            return await _context.Projects.Where(x=>x.CategoryId==id).Select(p => new ProjectViewModel()
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
                WardId = p.WardId,
                DirectionName = p.Direction.Name,
                PriceTypeName = p.PriceType.Name,
                AddressDetail = p.AddressDetail,
                Phone = p.Phone
            }).OrderByDescending(x => x.CreateDate).ToListAsync();
        }

        public List<ProjectViewModel> Search(string keyword, int categoryId, int provinceId, int districtId, int wardId, string fromPrice, int fromPriceType, string toPrice, int toPriceType, string fromAcreage, string toAcreage)
        {
                string queryString = string.Format("SELECT * FROM Project WHERE dbo.fuConvertToUnsign1(Name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", keyword);
                var model = _context.Projects.FromSqlRaw(queryString).Select(p => new ProjectViewModel()
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
                    WardId = p.WardId,
                    PriceTypeId=p.PriceTypeId,
                    DirectionId=p.DirectionId,
                    ProvinceId=p.ProvinceId,
                    DistrictId=p.DistrictId,
                    CategoryId=p.CategoryId,
                    DirectionName = p.Direction.Name,
                    PriceTypeName = p.PriceType.Name,
                    AddressDetail = p.AddressDetail,
                    Phone = p.Phone
                }).OrderByDescending(x => x.CreateDate).ToList();
                if (categoryId != 0)
                {
                    model = model.Where(x => x.CategoryId == categoryId).ToList();
                }
                if (provinceId != 0)
                {
                    model = model.Where(x => x.ProvinceId == provinceId).ToList();
                }
                if (districtId != 0)
                {
                    model = model.Where(x => x.DistrictId == districtId).ToList();
                }
                if (wardId != 0)
                {
                    model = model.Where(x => x.WardId == wardId).ToList();
                }

                if (!string.IsNullOrEmpty(fromPrice) && fromPriceType != 0)
                {
                    model = model.Where(x => Convert.ToDecimal(x.Price) >= Convert.ToDecimal(fromPrice) && x.PriceTypeId == fromPriceType).ToList();
                }

                if (!string.IsNullOrEmpty(toPrice) && toPriceType != 0)
                {
                    model = model.Where(x => Convert.ToDecimal(x.Price) <= Convert.ToDecimal(toPrice) && x.PriceTypeId == toPriceType).ToList();
                }

                if (!string.IsNullOrEmpty(fromAcreage))
                {
                    model = model.Where(x => Convert.ToDecimal(x.Acreage) >= Convert.ToDecimal(fromAcreage)).ToList();
                }

                if (!string.IsNullOrEmpty(toAcreage))
                {
                    model = model.Where(x => Convert.ToDecimal(x.Acreage) <= Convert.ToDecimal(toAcreage)).ToList();
                }
                return model;
        }

        public async Task<int> Create(ProjectCreateRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Project pro = new Project()
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
                        WardId = request.WardId,
                        PriceTypeId=request.PriceTypeId,
                        ProvinceId=request.ProvinceId,
                        DistrictId=request.DistrictId,
                        DirectionId=request.DirectionId,
                        AddressDetail = request.AddressDetail,
                        Phone = request.Phone
                    };
                    if (request.File != null)
                    {
                        pro.Image = await SaveFile(request.File);
                    }
                    _context.Projects.Add(pro);
                    await _context.SaveChangesAsync();

                    if (request.Files != null)
                    {
                        foreach (var item in request.Files)
                        {
                            ProjectImage image = new ProjectImage()
                            {
                                ProjectId = pro.Id,
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
                    Project pro = await _context.Projects.FindAsync(request.Id);
                    if (pro == null) return -1;
                    pro.Name = request.Name;
                    pro.CategoryId = request.CategoryId;
                    pro.Description = request.Description;
                    pro.Price = request.Price;
                    pro.Detail = request.Detail;
                    pro.IsNew = request.IsNew;
                    pro.Url = request.Url;
                    pro.DisplayOrder = request.DisplayOrder;
                    pro.Status = request.Status;
                    pro.EditDate = DateTime.Now;
                    pro.IsHot = request.IsHot;
                    pro.Acreage = request.Acreage;
                    pro.WardId = request.WardId;
                    pro.DistrictId = request.DistrictId;
                    pro.ProvinceId = request.ProvinceId;
                    pro.PriceTypeId = request.PriceTypeId;
                    pro.DirectionId = request.DirectionId;
                    pro.AddressDetail = request.AddressDetail;
                    pro.Phone = request.Phone;
                    if (request.File != null)
                    {
                        await _storageService.DeleteFileAsync(pro.Image);
                        pro.Image = await SaveFile(request.File);
                    }

                    if (request.Files != null)
                    {
                        List<ProjectImage> images = await _context.ProjectImages.Where(x => x.ProjectId == pro.Id).ToListAsync();
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
                                ProjectId = pro.Id,
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
                    Project pro = await _context.Projects.FindAsync(id);
                    if (pro == null) return -1;
                    if (pro.Image != null)
                    {
                        await _storageService.DeleteFileAsync(pro.Image);
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
                    _context.Projects.Remove(pro);
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
                var query = from pro in _context.Projects
                            join c in _context.Categories on pro.CategoryId equals c.Id
                            join type in _context.PriceTypes on pro.PriceTypeId equals type.Id
                            join dir in _context.Directions on pro.DirectionId equals dir.Id
                            join w in _context.Wards on pro.WardId equals w.Id
                            join d in _context.Districts on w.DistrictId equals d.Id
                            join p in _context.Provinces on d.ProvinceId equals p.Id
                            select new ProjectViewModel()
                            {
                                Id = pro.Id,
                                Name = pro.Name,
                                Image = pro.Image,
                                CategoryId = pro.CategoryId,
                                Description = pro.Description,
                                Price = pro.Price,
                                Detail = pro.Detail,
                                IsNew = pro.IsNew,
                                Url = pro.Url,
                                DisplayOrder = pro.DisplayOrder,
                                Status = pro.Status,
                                IsHot = pro.IsHot,
                                Acreage = pro.Acreage,
                                WardId = pro.WardId,
                                AddressDetail = pro.AddressDetail,
                                DistrictId = d.Id,
                                ProvinceId = p.Id,
                                WardName=w.Name,
                                DirectionName=dir.Name,
                                ProvinceName=p.Name,
                                PriceTypeName=type.Name,
                                DistrictName=d.Name,
                                CategoryName=c.Name,
                                CreateDate=pro.CreateDate,
                                EditDate=pro.EditDate,
                                PriceTypeId = type.Id,
                                DirectionId = dir.Id,
                                Phone = pro.Phone,
                                Images = _context.ProjectImages.Where(x => x.ProjectId == id).ToList()
                            };
                var project = await query.Where(x => x.Id == id).FirstOrDefaultAsync();
                return project;
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
                var query = from pro in _context.Projects
                              join type in _context.PriceTypes on pro.PriceTypeId equals type.Id
                              join dir in _context.Directions on pro.DirectionId equals dir.Id
                              join w in _context.Wards on pro.WardId equals w.Id
                                join d in _context.Districts on w.DistrictId equals d.Id
                                join p in _context.Provinces on d.ProvinceId equals p.Id
                                select new ProjectUpdateRequest()
                                {
                                    Id = pro.Id,
                                    Name = pro.Name,
                                    Image = pro.Image,
                                    CategoryId = pro.CategoryId,
                                    Description = pro.Description,
                                    Price = pro.Price,
                                    Detail = pro.Detail,
                                    IsNew = pro.IsNew,
                                    Url = pro.Url,
                                    DisplayOrder = pro.DisplayOrder,
                                    Status = pro.Status,
                                    IsHot = pro.IsHot,
                                    Acreage = pro.Acreage,
                                    WardId = pro.WardId,
                                    AddressDetail = pro.AddressDetail,
                                    DistrictId=d.Id,
                                    ProvinceId=p.Id,
                                    PriceTypeId=type.Id,
                                    DirectionId=dir.Id,
                                    Phone = pro.Phone,
                                    Images = _context.ProjectImages.Where(x => x.ProjectId == id).ToList()
                                };
                var project = await query.Where(x => x.Id == id).FirstOrDefaultAsync();
                return project;
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
