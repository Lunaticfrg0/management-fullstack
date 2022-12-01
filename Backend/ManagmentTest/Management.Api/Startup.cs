using Microsoft.OpenApi.Models;
using Persistance.Context;
using Business.Mappers;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api
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
            //Context
            services.AddScoped<Context>();
            services.AddPersistence(Configuration);
            //Dependencies
            //services.AddProjectHelpers(Configuration);
            services.AddViewModelMaping();
            services.AddRepositoryServices();
            services.AddSwaggerGen();
            services.AddControllers();

            //Version
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);

            });
            
            services.AddControllers();
            AddSwagger(services);
        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {


                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"Management.Manager v1",
                    Version = "v1",
                    Description = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Management.Manager v1",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
                options.ResolveConflictingActions(a => a.First());
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Local" || env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Management.Manager API V1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Management.Manager API V2");
                });
            }
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseDeveloperExceptionPage();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
