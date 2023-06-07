using Business.Abstract.IServices;
using Business.Concrete.Services;
using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.Abstract.Repository.ClassRepository;
using DataAccess.Concrete.Dal.ClassDal;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.Repository.ClassRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //Scoped
            services.AddScoped<IUrunDal, UrunDal>();
            services.AddScoped<IMusteriDal, MusteriDal>();
            services.AddScoped<ISatýsDal, SatýsDal>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IUrunlerServices, UrunlerServices>();
            services.AddScoped<IMusteriServices, MusteriServices>();
            services.AddScoped<ISatýsServices, SatýsServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddDbContext<EfNorthwindContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));



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
