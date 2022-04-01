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
        public void ConfigureServices(IServiceCollection services)  //yapýlandýrma iþlemleeri.
        {

            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddControllersWithViews();

            //Proje seviyesinde authorize iþlemi için. Yani projedeki heer þeye giriþ yaparak eriþelim dyoruz.
            services.AddMvc(Configuration =>
            {
                var policy = new AuthorizationPolicyBuilder()
                           .RequireAuthenticatedUser()
                           .Build();

                Configuration.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)  //giriþ yapmadan bir yere eriþim yapmaya çalýþýrsak bizi login sayfasýna yönlendir.
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

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");  //url de sýkýntý olursa burasý çalýþacak.

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();  //oturum iþlemleri için.

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
