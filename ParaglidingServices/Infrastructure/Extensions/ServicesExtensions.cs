using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ParaglidingServices.Api.Configuration;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure;
using ParaglidingServices.Persistence.Data;
using System.Linq;
using System.Reflection;

namespace ParaglidingServices.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddJwtAuthentication(this IServiceCollection services, AuthOptions authOptions)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authOptions.Audience,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                };
            });
        }

        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            static void Options(IdentityOptions options)
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            }

            services.AddIdentity<User, Role>(Options)
                .AddRoles<Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddSignInManager<SignInManager<User>>();

            services.Configure<IdentityOptions>(Options);

            return services;
        }

        public static AuthOptions ConfigureAuthOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptionsConfigurationSection = configuration.GetSection("AuthOptions");
            services.Configure<AuthOptions>(authOptionsConfigurationSection);
            var authOptions = authOptionsConfigurationSection.Get<AuthOptions>();
            return authOptions;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(Command<>));
            var commandTypes = assembly.ExportedTypes.Where(type =>
                type.BaseType != null && (type.BaseType == typeof(Command) || (type.BaseType.IsConstructedGenericType &&
                    (type.BaseType.GetGenericTypeDefinition() == typeof(Command<>) || type.BaseType.GetGenericTypeDefinition() == typeof(Command<,>)))));

            foreach (var commandType in commandTypes)
            {
                services.AddTransient(commandType);
            }

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(Query<>));
            var queryTypes = assembly.ExportedTypes.Where(type =>
                type.BaseType != null && type.BaseType.IsConstructedGenericType &&
                (type.BaseType.GetGenericTypeDefinition() == typeof(Query<>) || type.BaseType.GetGenericTypeDefinition() == typeof(Query<,>)));

            foreach (var queryType in queryTypes)
            {
                services.AddTransient(queryType);
            }

            return services;
        }
    }
}
