using System;
using AutoMapper;
using BankIdService.Application.Configurations;
using BankIdService.Application.Handlers;
using BankIdService.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankIdService.Api
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
            var settings = Configuration.GetSection("BankIdSettings").Get<BankIdSettings>();

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IAuthHandler, AuthHandler>();
            services.AddScoped<IBankIdService, Infrastructure.Services.BankIdService>();
            services.AddHttpClient<IBankIdService, Infrastructure.Services.BankIdService>(s =>
            {
                s.BaseAddress = new Uri(settings.BaseUrl);
            });
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
