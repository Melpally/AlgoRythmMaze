using AlgoRythmMaze.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TopiTopi.API.Extensions;
using TopiTopi.Application.Interfaces;
using TopiTopi.Application.Services;
using TopiTopi.Domain.Interfaces;
using TopiTopi.Infrastructure.ExternalServices;

namespace AlgoRythmMaze
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseKestrel(options =>
            {
                options.Limits.MaxRequestBodySize = 2 * 1024 * 1024;
            });

            builder.Services.AddDataAccess(builder.Configuration);

            builder.Services.AddIdentityRegistry();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.SlidingExpiration = true;
                options.Cookie.Name = "IdentityCookie";
                options.LoginPath = new PathString("/login");
                options.Cookie.Expiration = TimeSpan.FromMinutes(30);
                options.AccessDeniedPath = new PathString("/not-found");
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

            });

            builder.Services.AddUserSignInManagers();

            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGenRegistry();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<ICalendarService, GoogleCalendarService>();


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
                var roles = builder.Configuration.GetSection("Roles").Get<List<string>>();
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();

                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(new IdentityRole<int>(role));
                        }
                    }
                }
                else
                {
                    throw new ArgumentNullException("Roles", "The roles were not provided.");
                }

                await db.SaveChangesAsync();
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
