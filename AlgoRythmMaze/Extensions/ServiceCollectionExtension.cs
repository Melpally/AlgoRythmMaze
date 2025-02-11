using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;
using AlgoRythmMaze.Infrastructure.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TopiTopi.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException("Connection string is not defined");

            services.AddDbContext<DataContext>(options => options.UseSqlServer(connString));

            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICaregiverProfileRepository, CaregiverProfileRepository>();
            services.AddScoped<IClientProfileRepository, ClientProfileRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
        }

        public static void AddIdentityRegistry(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>(
            options =>
            {
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
                // uncheck the flag for non confirmed emails later once the email to confirm the email has been sent
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
        }


        public static void AddUserSignInManagers(this IServiceCollection services)
        {
            services.AddScoped<UserManager<User>>();
            services.AddScoped<SignInManager<User>>();
            services.AddScoped<RoleManager<IdentityRole<int>>>();
        }

        public static void AddSwaggerGenRegistry(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("cookieAuth", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Cookie",
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Cookie-based authentication"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "cookieAuth"
                            }
                        },
                        new string[] {}
                    }
                }); 
            });
        }
    }
}
