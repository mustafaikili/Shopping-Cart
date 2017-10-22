using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.DataAccess.Abstract;
using ShoppingCart.DataAccess.Concrete.EntityFramework.Entities;
using ShoppingCart.Business.Abstract;
using ShoppingCart.Business.Concrete;
using Microsoft.AspNetCore.Http;
using ShoppingCart.WebMVC.UI.Services.Abstract;
using ShoppingCart.WebMVC.UI.Services.Concrete;
using ShoppingCart.WebMVC.UI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ShoppingCart.WebMVC.UI
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
            services.AddScoped<IProductDAL, EFProductDAL>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDAL, EFCategoryDAL>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICartService, CartService>();
            services.AddSingleton<ICartSummaryService, CartSummaryService>();

            services.AddDbContext<CustomIdentityDbContext>
                (options => options.UseSqlServer("Server=.;Database=NORTHWND;Integrated Security=true"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            //session kullanabilmek için
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //session kullanımı ayarı
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
