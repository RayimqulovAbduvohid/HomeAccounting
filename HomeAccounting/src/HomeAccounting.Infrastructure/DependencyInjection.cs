using Microsoft.EntityFrameworkCore;
using HomeAccounting.src.HomeAccounting.Application.Interfaces;
using HomeAccounting.src.HomeAccounting.Infrastructure.Repositories;

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

            return services;
        }
    }
}
