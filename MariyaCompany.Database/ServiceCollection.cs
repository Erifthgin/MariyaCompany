using MariyaCompany.Application.Abstractions.Database;
using MariyaCompany.Application.Abstractions.Entity;
using MariyaCompany.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MariyaCompany.Database
{
    public static class ServiceCollection
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MariyaCompanyContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")), ServiceLifetime.Transient);

            services.AddTransient<IRepository<CompanyPosition>, Repository<CompanyPosition>>();
            services.AddTransient<IRepository<Department>, Repository<Department>>();
            services.AddTransient<IRepository<Employee>, Repository<Employee>>();
        }
    }
}
