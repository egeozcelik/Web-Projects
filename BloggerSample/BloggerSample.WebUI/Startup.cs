using BloggerSample.BLL.Abstract;
using BloggerSample.BLL.BlogService;
using BloggerSample.Core.Data.UnitOfWork;
using BloggerSample.DAL;
using BloggerSample.Mapping.ConfigProfile;
using BloggerSample.WebUI.CustomHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace BloggerSample.WebUI
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

            var optionsBuilder = new DbContextOptionsBuilder<BloggerDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("BlogDbConnection"));
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.EnableSensitiveDataLogging();

            services.AddSingleton<DbContext>(new BloggerDbContext(optionsBuilder.Options));

            using (var context = new BloggerDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }

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

            services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

            services.AddSingleton<IUnitofWork, UnitofWork>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ICommentService, CommentService>();
            services.AddSingleton<IContactService, ContactService>();
            services.AddSingleton<IArticleService, ArticleService>();
           
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
                        name: "ArticleList",
                        pattern: "Admin/Articles",
                        defaults: new { controller = "Admin", action = "ArticleList" });

                endpoints.MapControllerRoute(
                        name: "ArticleAdd",
                        pattern: "Admin/ArticleAdd",
                        defaults: new { controller = "Admin", action = "ArticleAdd" });

                endpoints.MapControllerRoute(
                        name: "CategoryList",
                        pattern: "Admin/Categories",
                        defaults: new { controller = "Admin", action = "CategoryList" });

                endpoints.MapControllerRoute(
                        name: "CategoryAdd",
                        pattern: "Admin/CategoryAdd",
                        defaults: new { controller = "Admin", action = "CategoryAdd" });

                endpoints.MapControllerRoute(
                        name: "CommentList",
                        pattern: "Admin/Comments",
                        defaults: new { controller = "Admin", action = "CommentList" });

                endpoints.MapControllerRoute(
                        name: "ContactList",
                        pattern: "Admin/Contacts",
                        defaults: new { controller = "Admin", action = "ContactList" });

                endpoints.MapControllerRoute(
                        name: "UserList",
                        pattern: "Admin/Users",
                        defaults: new { controller = "Admin", action = "UserList" });

                endpoints.MapControllerRoute(
                       name: "UserAdd",
                       pattern: "Admin/UserAdd",
                       defaults: new { controller = "Admin", action = "UserAdd" });

                endpoints.MapControllerRoute(
                       name: "UserFilter",
                       pattern: "Admin/UserFilter",
                       defaults: new { controller = "Admin", action = "UserFilter" });

                endpoints.MapControllerRoute(
                      name: "Admin",
                      pattern: "Admin",
                      defaults: new { controller = "Admin", action = "Index" });


                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
