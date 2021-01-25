using ClosetControl.Application.Interface;
using ClosetControl.Application.Service;
using ClosetControl.Domain.Interfaces;
using ClosetControl.Domain.Validations;
using ClosetControl.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ClosetControl.Application
{
    public static class DependecyInjection
    {
        public static void DependecyInjections(this IServiceCollection services)
        {
            services.AddSingleton<ILiteDbContext, LiteDbContext>();
            services.AddScoped<IClothesRepository, ClothesRepository>();
            services.AddScoped<IClothesService, ClothesService>();
            services.AddScoped<IClothesDeleteValidation, ClothesDeleteValidation>();
            services.AddScoped<IClothesUpdateCreationValidation, ClothesUpdateCreationValidation>();
        }
    }
}
