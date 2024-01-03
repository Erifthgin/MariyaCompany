using AutoMapper;
using MariyaCompany.Application.Map;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MariyaCompany.Application
{
    public static class ServiceCollection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollection).GetTypeInfo().Assembly;
            services.AddMediatR(assembly);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RequestsProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
