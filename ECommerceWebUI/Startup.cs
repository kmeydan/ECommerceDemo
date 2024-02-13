using Business.Abstract.IServices;
using Business.Concrete.Services;
using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.Abstract.Repository.ClassRepository;
using DataAccess.Concrete.Dal.ClassDal;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.Repository.ClassRepository;
using DataAccess.Entities.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ECommerceWebUI.Helpers;
using Microsoft.Extensions.Options;

namespace ECommerce
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
            services.AddControllersWithViews();
            services.AddRazorPages();
            //AutoMapper
            services.AddAutoMapper(x=>x.AddProfile<AutoMapperProfiles>());

            //Scoped
            services.AddScoped<IOdemeTipiDal, OdemeTipiDal>();
            services.AddScoped<IOdemeTipiServices, OdemeTipiServices>();
            services.AddScoped<ISiparisDurumlariServices, SiparisDurumlariServices>();
            services.AddScoped<ISiparisDurumlarýDal,SiparisDurumlariDal>();
            services.AddScoped<IArananKelimeDal, ArananKelimeDal>();
            services.AddScoped<IArananKelimeServices, ArananKelimeServices>();
            services.AddScoped<ITedarikciDal, TedarikciDal>();
            services.AddScoped<ITedarikciServices, TedarikciServices>();
            services.AddScoped<IUrunDal, UrunDal>();
            services.AddScoped<IMusteriDal, MusteriDal>();
            services.AddScoped<ISatýsDal, SatýsDal>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IUrunlerServices, UrunlerServices>();
            services.AddScoped<IMusteriServices, MusteriServices>();
            services.AddScoped<ISatýsServices, SatýsServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<ISliderDal, SliderDal>();
            services.AddScoped<ISliderServices, SliderServices>();
            services.AddScoped<ISliderPossitionServices, SliderPossitionServices>();
            services.AddScoped<ISliderPossitionDal, SliderPossitionDal>();
            services.AddDbContext<EfNorthwindContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("identityConnection")));
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                //Password
                opt.Password.RequiredLength = 8;
                opt.Password.RequireUppercase = true;

                //Lockout
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.AllowedForNewUsers = true;

            }).AddEntityFrameworkStores<AppDbContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Home/Login";

			});

            //cors
            services.AddCors(opt =>
            {
                opt.AddPolicy("AngularApp",
                    builder => builder.WithOrigins("http://localhost:4200"));
            });
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

			app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("AngularApp");
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
