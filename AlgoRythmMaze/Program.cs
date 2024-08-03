using AlgoRythmMaze.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AlgoRythmMaze
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("Database") ?? throw new ArgumentNullException("Connection string is not defined");
            builder.Services.AddDbContextPool<AlgoRythmDbContext>(
                options => options.UseSqlServer(connString,
                    builder =>
                    {
                        builder.MigrationsAssembly("AlgoRythmMaze.Infrastructure");
                    }));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AlgoRythmDbContext>();
                await db.Database.MigrateAsync();
            }

            // Configure the HTTP request pipeline.
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
