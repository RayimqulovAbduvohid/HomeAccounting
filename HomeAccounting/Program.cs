
using HomeAccounting.src.HomeAccounting.Application.Services;
using HomeAccounting.src.HomeAccounting.Infrastructure;

namespace HomeAccounting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // 🔹 Infrastructure (DbContext, Repository)
            builder.Services.AddInfrastructure(builder.Configuration);

            // 🔹 Application (Service qatlamlari)
            builder.Services.AddScoped<ExpenseService>();
            builder.Services.AddScoped<CategoryService>();

            var app = builder.Build();

            // 🔹 Swagger faqat developmentda ishlaydi
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
