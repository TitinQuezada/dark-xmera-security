using Core.Configurations;
using Core.Interfaces;
using Core.Managers;
using Helpers.Database;
using Helpers.Database.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dark_xmera_security", Version = "v1" });
            });

            string connectionString = Environment.GetEnvironmentVariable(EnviromentVariables.DarkXmeraSecurityDbConnectionString);
            services.AddDbContext<DarkXmeraSecurityDbContext>(options => options.UseSqlServer(connectionString));

            BuildRepositoriesToScope(services);
            BuildManagersToScope(services);
        }

        private void BuildRepositoriesToScope(IServiceCollection services)
        {
            services.AddScoped<IActionRepository, ActionRepository>();
        }

        private void BuildManagersToScope(IServiceCollection services)
        {
            services.AddScoped<ActionManager, ActionManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dark_xmera_security v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
