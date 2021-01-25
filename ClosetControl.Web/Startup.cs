using ClosetControl.Application.Interface;
using ClosetControl.Application.Service;
using ClosetControl.Domain.Entities;
using ClosetControl.Domain.Interfaces;
using ClosetControl.Domain.Validations;
using ClosetControl.Infra.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ClosetControl.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILiteDbContext, LiteDbContext>();
            services.AddScoped<ILiteDbClothesService, LiteDbClothesService>();
            services.AddScoped<IClothesDeleteValidation, ClothesDeleteValidation>();
            services.AddScoped<IClothesUpdateCreationValidation, ClothesUpdateCreationValidation>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Closet Control",
                    Version = "v1",
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Closet Control");
                c.DocExpansion(DocExpansion.None);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
