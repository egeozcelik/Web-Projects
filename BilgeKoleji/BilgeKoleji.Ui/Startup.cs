 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BilgeKoleji.BLL;
using BilgeKoleji.BLL.Abstract;
using BilgeKoleji.BLL.Service;
using BilgeKoleji.Core.Data.UnitOfWork;
using BilgeKoleji.DAL;
using BilgeKoleji.Mapping.ConfigProfile;
using BilgeKoleji.Model;
using BilgeKoleji.Ui.CustomHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BilgeKoleji.Ui
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MapperConfig.RegisterMappers();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
    
        
        
             
        
        
        
        
        
        
        
        
        
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //services.AddControllersWithViews();


            ////////////////////////////////////////////////////////////////
            var optionsBuilder = new DbContextOptionsBuilder<BilgeKolejiDbContext>();
          
           optionsBuilder.UseSqlServer(Configuration.GetConnectionString("BlogDbConnection"));
            
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            
            optionsBuilder.EnableSensitiveDataLogging();
            ////////////////////////////////////////////////////////////////////////


         services.AddSingleton<DbContext>(new BilgeKolejiDbContext(optionsBuilder.Options));
        
        
         using (var context = new BilgeKolejiDbContext(optionsBuilder.Options))
         {   
             context.Database.EnsureCreated();
             context.Database.Migrate();
         }



            services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDersService, DersService>();
            services.AddSingleton<IGenelTablo, GenelTabloService>();
            services.AddSingleton<IOgretmenService, OgretmenService>();
            services.AddSingleton<IOgrenciService, OgrenciService>();
            services.AddSingleton<ISinifService, SinifService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IRoleService, RoleService>();





            services.AddAuthentication("CookieAuthentication")
         .AddCookie("CookieAuthentication", config =>
         {
             config.Cookie.Name = "UserLoginCookie";
             config.LoginPath = "/Login";
             config.AccessDeniedPath = "/AccessDenied";
         });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("UserPolicy", policyBuilder =>
                {
                    policyBuilder.UserRequireCustomClaim(ClaimTypes.Email);
                });

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
               name: "Register",
               pattern: "Register",
               defaults: new { controller = "Login", action = "Register" });

                endpoints.MapControllerRoute(
                    name: "Login",
                    pattern: "Login",
                    defaults: new { controller = "Login", action = "UserLogin" });

                endpoints.MapControllerRoute(
                     name: "AccessDenied",
                     pattern: "AccessDenied",
                     defaults: new { controller = "Login", action = "AccessDenied" });

                endpoints.MapControllerRoute(
                     name: "Logout",
                     pattern: "Logout",
                     defaults: new { controller = "Login", action = "Logout" });

                endpoints.MapControllerRoute(
                        name: "AddRole",
                        pattern: "AddRole",
                        defaults: new { controller = "Admin", action = "AddRole" });

                endpoints.MapControllerRoute(
                        name: "AddUser",
                        pattern: "AddUser",
                        defaults: new { controller = "Admin", action = "AddUser" });

                endpoints.MapControllerRoute(
                        name: "DersEkle",
                        pattern: "DersEkle",
                        defaults: new { controller = "Admin", action = "DersEkle" });

                endpoints.MapControllerRoute(
                        name: "DersListele",
                        pattern: "DersListele",
                        defaults: new { controller = "Admin", action = "DersListele" });
                endpoints.MapControllerRoute(
                        name: "SinifDuzenle",
                        pattern: "SinifDuzenle",
                        defaults: new { controller = "Admin", action = "SinifDuzenle" });

                endpoints.MapControllerRoute(
                        name: "OgrenciListele",
                        pattern: "OgrenciListele",
                        defaults: new { controller = "Admin", action = "OgrenciListele" });

                endpoints.MapControllerRoute(
                        name: "OgretmenEkle",
                        pattern: "OgretmenEkle",
                        defaults: new { controller = "Admin", action = "OgretmenEkle" });
                endpoints.MapControllerRoute(
                        name: "OgrenciEkle",
                        pattern: "OgrenciEkle",
                        defaults: new { controller = "Admin", action = "OgrenciEkle" }); 
                endpoints.MapControllerRoute(
                       name: "OgretmenListele",
                       pattern: "OgretmenListele",
                       defaults: new { controller = "Admin", action = "OgretmenListele" });

                endpoints.MapControllerRoute(
                      name: "SinifEkle",
                      pattern: "SinifEkle",
                      defaults: new { controller = "Admin", action = "SinifEkle" });
                endpoints.MapControllerRoute(
                      name: "SinifListele",
                      pattern: "SinifListele",
                      defaults: new { controller = "Admin", action = "SinifListele" });
                endpoints.MapControllerRoute(
                      name: "UserList",
                      pattern: "UserList",
                      defaults: new { controller = "Admin", action = "UserList" });
                endpoints.MapControllerRoute(
                    name: "Index",
                    pattern: "Default",
                    defaults: new { controller = "Admin", action = "Index" });



                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Admin}/{action=Index}/{id?}");
            });
        }
    }
}
