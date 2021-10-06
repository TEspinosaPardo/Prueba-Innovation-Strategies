using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SampleApp.Application.Contracts.DTO;
using SampleApp.Application.Contracts.Services;
using SampleApp.Application.Services;
using SampleApp.Application.Validators;
using SampleApp.Infrastructure;
using System.Reflection;

namespace SampleApp.Application
{
    public static class Startup
    {
        /// <summary>
        /// Dependency injection for the Application layer
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<ISampleAppService, SampleAppService>();

            services.AddTransient<IValidator<SampleForCreate>, SampleForCreateValidator>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddInfrastructureLayer();

            return services;
        }
    }
}
