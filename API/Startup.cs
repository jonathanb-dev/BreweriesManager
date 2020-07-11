using Application.Services;
using AutoMapper;
using Domain.Repos;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Persistence.Repos;

namespace API
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
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddAutoMapper(typeof(Startup));

            // Repositories
            services.AddScoped<IBreweryRepository, BreweryRepository>();
            services.AddScoped<IWholesalerRepository, WholesalerRepository>();
            services.AddScoped<IBeerRepository, BeerRepository>();
            services.AddScoped<ISaleHeaderRepository, SaleHeaderRepository>();
            services.AddScoped<IWholesalerBeerRepository, WholesalerBeerRepository>();

            // Services
            services.AddScoped<IBreweryService, BreweryService>();
            services.AddScoped<IWholesalerService, WholesalerService>();
            services.AddScoped<IBeerService, BeerService>();
            services.AddScoped<IWholesalerBeerService, WholesalerBeerService>();
            services.AddScoped<ISaleHeaderService, SaleHeaderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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