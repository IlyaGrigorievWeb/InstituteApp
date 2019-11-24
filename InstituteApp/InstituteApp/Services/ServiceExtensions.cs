using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstituteApp.Services.Directions;
using InstituteApp.Services.Directions.Abstractions;
using InstituteApp.Services.Institutes;
using InstituteApp.Services.Institutes.Abstractions;
using InstituteApp.Services.Specialties;
using InstituteApp.Services.Specialties.Abstractions;

namespace InstituteApp.Services
{
    /// <summary>
    /// Класс-расширение коллекции сервисов
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Добавление Domain
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns></returns>
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            //Сервисы

            //Направления
            services.AddScoped<IDirectionsService, DirectionsService>();
            //Учебные заведения
            services.AddScoped<IInstitutesService, InstitutesService>();
            //Специальности
            services.AddScoped<ISpecialtiesService, SpecialtiesService>();

            return services;
        }
    }
}
