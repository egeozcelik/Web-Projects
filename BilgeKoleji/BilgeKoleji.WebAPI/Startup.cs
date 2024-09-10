using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilgeKoleji.BLL;
using BilgeKoleji.BLL.Abstract;
using BilgeKoleji.BLL.Service;
using BilgeKoleji.Core.Data.UnitOfWork;
using BilgeKoleji.DAL;
using BilgeKoleji.Mapping.ConfigProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BilgeKoleji.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            MapperConfig.RegisterMappers();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(z => z.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BilgeKolejiAPI", Version = "V1" }));
          
            




            services.AddControllers();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<DbContext, BilgeKolejiDbContext>();
            services.AddSingleton<IDersService, DersService>();
            services.AddSingleton<IOgrenciService, OgrenciService>();
            services.AddSingleton<IOgretmenService, OgretmenService>();
            services.AddSingleton<ISinifService, SinifService>();
            services.AddSingleton<IGenelTablo, GenelTabloService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IRoleService, RoleService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(z =>
                    z.SwaggerEndpoint("/swagger/v1/swagger.json", "BilgeKolejiAPI"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
