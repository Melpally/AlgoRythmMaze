using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlgoRythmMaze
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("Database") ?? throw new ArgumentNullException("Connection string is not defined");
            builder.Services.AddDbContextPool<Infrastructure.Data.DbContext>(
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
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = builder.Configuration.GetSection("Roles").Get<List<string>>();

                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }
                }
                else
                {
                    throw new ArgumentNullException("Roles", "The roles were not provided.");
                }

                var db = scope.ServiceProvider.GetRequiredService<Infrastructure.Data.DbContext>();
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
