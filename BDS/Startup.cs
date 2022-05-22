using BDS.Model;
using BDS.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BDS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<BDSContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

             //Specifiying we are going to use Identity Framework
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = true;
                options.User.RequireUniqueEmail = true;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IStorageService, FileStorageService>();
            services.AddTransient<ICategoryService,CategoryService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ICategoryNewsService, CategoryNewsService>();
            services.AddTransient<IFengShuiService, FengShuiService>();
            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<IFurnitureService, FurnitureService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IWardService, WardService>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<IProvinceService, ProvinceService>();
            services.AddTransient<IPriceTypeService, PriceTypeService>();
            services.AddTransient<IDirectionService, DirectionService>();
            services.AddTransient<IFeedbackService, FeedbackService>();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
            IMvcBuilder builder = services.AddRazorPages();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

#if DEBUG
            if (environment == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();     
            
            app.UseAuthorization();

            app.UseSession();
          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "admin",
                pattern: "admin", new
                {
                    area = "Admin",
                    controller = "User",
                    action = "Login"
                });

                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
               name: "logout",
               pattern: "dang-xuat", new
               {
                   controller = "User",
                   action = "LogOut"
               });

                endpoints.MapControllerRoute(
             name: "post project",
             pattern: "dang-du-an", new
             {
                 controller = "PostProject",
                 action = "Create"
             });

                endpoints.MapControllerRoute(
                 name: "Login",
                 pattern: "dang-nhap", new
                 {
                     controller = "User",
                     action = "Login"
                 });

                endpoints.MapControllerRoute(
                name: "register",
                pattern: "dang-ky", new
                {
                    controller = "User",
                    action = "Register"
                });

                endpoints.MapControllerRoute(
              name: "district",
              pattern: "get-district", new
              {
                  controller = "Home",
                  action = "GetDistrict"
              });

                endpoints.MapControllerRoute(
               name: "ward",
               pattern: "get-ward", new
               {
                   controller = "Home",
                   action = "GetWard"
               });

                endpoints.MapControllerRoute(
               name: "admin",
               pattern: "admin", new
               {
                   area = "Admin",
                   controller = "User",
                   action = "Login"
               });


                endpoints.MapControllerRoute(
               name: "Search",
               pattern: "tim-kiem", new
               {
                   controller = "Project",
                   action = "Search"
               });

                endpoints.MapControllerRoute(
                 name: "ProjectCategories",
                 pattern: "{url}/{id}",
                 defaults: new { controller = "Project", action = "ProjectCategories" }
                 );


                endpoints.MapControllerRoute(
                 name: "Project Detail",
                 pattern: "du-an/chi-tiet/{url}/{id}", new
                 {
                     controller = "Project",
                     action = "Detail"
                 });

                endpoints.MapControllerRoute(
                name: "Blog",
                pattern: "tin-tuc", new
                {
                    controller = "News",
                    action = "ListNews"
                });

                endpoints.MapControllerRoute(
                name: "Blog Detail",
                pattern: "tin-tuc/chi-tiet/{url}/{id}", new
                {
                    controller = "News",
                    action = "Detail"
                });

                endpoints.MapControllerRoute(
               name: "Blog by category",
               pattern: "tin-tuc/{url}/{id}", new
               {
                   controller = "News",
                   action = "ListNewCategories"
               });

                endpoints.MapControllerRoute(
                 name: "Phong thuy",
                 pattern: "phong-thuy", new
                 {
                     controller = "FengShui",
                     action = "Index"
                 });

                endpoints.MapControllerRoute(
                 name: "Phong thuy",
                 pattern: "phong-thuy/{url}/{id}", new
                 {
                     controller = "FengShui",
                     action = "Detail"
                 });

                endpoints.MapControllerRoute(
                name: "Noi ngoai that",
                pattern: "noi-ngoai-that", new
                {
                    controller = "Furniture",
                    action = "Index"
                });

                endpoints.MapControllerRoute(
                 name: "Noi ngoai that chi tiet",
                 pattern: "noi-ngoai-that/{url}/{id}", new
                 {
                     controller = "Furniture",
                     action = "Detail"
                 });

                endpoints.MapControllerRoute(
                 name: "Contact",
                 pattern: "lien-he", new
                 {
                     controller = "Home",
                     action = "Contact"
                 });

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapRazorPages();
            });
        }
    }
}
