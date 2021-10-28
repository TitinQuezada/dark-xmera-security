using Core.Configurations;
using Core.Interfaces.Encrypt;
using Core.Interfaces.Repositories;
using Core.Managers;
using Helpers.Database;
using Helpers.Database.Repositories;
using Helpers.Encrypt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace dark_xmera_security
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            AddSwagger(services);
            AddJwt(services);

            string connectionString = Environment.GetEnvironmentVariable(EnviromentVariables.DarkXmeraSecurityDbConnectionString);
            services.AddDbContext<DarkXmeraSecurityDbContext>(options => options.UseSqlServer(connectionString));

            BuildRepositoriesToScope(services);
            BuildManagersToScope(services);
            BuildServicesToScope(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "dark_xmera_security", Version = "v1" });

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

        private void AddJwt(IServiceCollection services)
        {
            string validIssuer = Environment.GetEnvironmentVariable(EnviromentVariables.JwtValidIssuer);
            string validAudience = Environment.GetEnvironmentVariable(EnviromentVariables.JwtValidAudience);
            string secretKey = Environment.GetEnvironmentVariable(EnviromentVariables.JwtSecretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = validIssuer,
                    ValidAudience = validAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }

        private void BuildRepositoriesToScope(IServiceCollection services)
        {
            services.AddScoped<IActionRepository, ActionRepository>();
            services.AddScoped<IScreenRepository, ScreenRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private void BuildManagersToScope(IServiceCollection services)
        {
            services.AddScoped<ActionManager, ActionManager>();
            services.AddScoped<ScreenManager, ScreenManager>();
            services.AddScoped<ModuleManager, ModuleManager>();
            services.AddScoped<RoleManager, RoleManager>();
            services.AddScoped<UserManager, UserManager>();
            services.AddScoped<AuthenticationManager, AuthenticationManager>();
        }

        private void BuildServicesToScope(IServiceCollection services)
        {
            services.AddScoped<IEncryptService, EncryptService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
            }
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dark_xmera_security v1"));

            app.UseCors(op =>
            {
                op.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
