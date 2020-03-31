using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using Microsoft.Extensions.Hosting;
using BeezyBackend.Service.Interfaces;
using BeezyBackend.Service;
using Microsoft.EntityFrameworkCore;
using BeezyBackend.Repository.Data;
using BeezyBackend.Repository.Configuration;

namespace BeezyBackendAPI
{
    public class Startup
    {
        private string _movieDBConnectionKey = "movieDBConnectionKey";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;
        //setting up our services and DB string
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DataContext>
                (opt => opt.UseSqlServer(new APIConfiguration().GetEndpointDataFromConfig(_movieDBConnectionKey))); ;

            services.AddScoped<IMoviesService,MoviesService >();
            services.AddScoped<ITVShowService, TVShowService>();
            services.AddScoped<IDocumentaryService,DocumentaryService >();
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //register swagger
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Movie DB Core API", Description = "Swagger Movie DB API" });
                }
            );

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseSwagger();
                app.UseSwaggerUI(c =>
                   {
                       c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie DB Core API");
                   }
                    );
            
        }
    }
}
