using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TripTracker.BackService.Data;

namespace TripTracker.BackService
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
            //services.AddTransient<Models.Repository>();
            services.AddMvc();
            services.AddDbContext<TripContext>(options => options.UseSqlite("DataSource = MyTrips.db"));
            services.AddSwaggerGen
                (
                    options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "Trip Tracker", Version = "v1" })
                );
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI
            (
                o => o.SwaggerEndpoint("/swagger/v1/swagger.json","Trip Tracker v1")
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvc();

           TripContext.SeedData(app.ApplicationServices);

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
