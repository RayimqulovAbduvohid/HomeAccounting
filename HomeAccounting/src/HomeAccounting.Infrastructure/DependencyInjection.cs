using HomeAccounting.Api.src.HomeAccounting.Application.Interfaces;
using HomeAccounting.Api.src.HomeAccounting.Infrastructure.Repositories;
using HomeAccounting.src.HomeAccounting.Application.Interfaces;
using HomeAccounting.src.HomeAccounting.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.src.HomeAccounting.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DbConnection")));

            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
