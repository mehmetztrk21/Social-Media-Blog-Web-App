using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)  //yap�land�rma i�lemleeri.
        {

            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddControllersWithViews();

            //Proje seviyesinde authorize i�lemi i�in. Yani projedeki heer �eye giri� yaparak eri�elim dyoruz.
            services.AddMvc(Configuration =>
            {
                var policy = new AuthorizationPolicyBuilder()
                           .RequireAuthenticatedUser()
                           .Build();

                Configuration.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)  //giri� yapmadan bir yere eri�im yapmaya �al���rsak bizi login sayfas�na y�nlendir.
                .AddCookie(x =>
                {
                x.LoginPath = "/Login/Index";
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

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");  //url de s�k�nt� olursa buras� �al��acak.

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();  //oturum i�lemleri i�in.

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");
            });
        }
    }
}
