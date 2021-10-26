using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using ParaglidingServices.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Core;
using ParaglidingServices.Infrastructure;
using ParaglidingServices.Infrastructure.Profiles;
using ParaglidingServices.Api.Extensions;
using FluentValidation.AspNetCore;
using ParaglidingServices.Infrastructure.Validators.Organizers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ParaglidingServices.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using ParaglidingServices.Api.Infrastructure.Security;

namespace ParaglidingServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("ConnectionStr"));
            });

            /*            services.AddIdentity<User, Role>(options =>
                        {
                            options.Password.RequiredLength = 8;
                            options.Password.RequireDigit = false;
                            options.Password.RequireUppercase = false;
                            options.Password.RequireLowercase = false;
                            options.Password.RequireNonAlphanumeric = false;
                            options.User.RequireUniqueEmail = true;
                        })
                            .AddRoles<Role>()
                            .AddEntityFrameworkStores<AppDbContext>()
                            .AddUserManager<UserManager<User>>()
                            .AddSignInManager<SignInManager<User>>();*/
            services.AddCors();

            services.ConfigureIdentity();

            var authOptions = services.ConfigureAuthOptions(Configuration);
            services.AddJwtAuthentication(authOptions);
            services.AddControllers()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<OrganizerCreateUpdateModelValidator>());

            /*            services.AddAuthentication(opt =>
                    {
                        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                        .AddJwtBearer(opt =>
                        {
                            opt.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,

                                ValidIssuer = "https://localhost:44335",
                                ValidAudience = "https://localhost:44335",
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                            };
                        });
                        */

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddCommands();
            services.AddQueries();

            //services.AddScoped<JwtService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ParaglidingServices API1", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
