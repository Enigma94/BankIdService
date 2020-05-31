using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using BankIdService.Api.HttpClientExtensions;
using BankIdService.Application.Configurations;
using BankIdService.Application.Handlers;
using BankIdService.Application.Interfaces;
using BankIdService.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
            var settings = Configuration.GetSection("BankIdSettings");
            var bankIdSettings = settings.Get<BankIdSettings>();

            services.Configure<BankIdSettings>(settings);

            services.AddAutoMapper(
                typeof(Profiles.AuthProfile),
                typeof(Profiles.CollectProfile),
                typeof(Infrastructure.Profiles.AuthProfile),
                typeof(Infrastructure.Profiles.CollectProfile)
                );

            services.AddControllers();
            services.AddScoped<IAuthHandler, AuthHandler>();
            services.AddScoped<ICollectHandler, CollectHandler>();
            services.AddTransient<HttpCertificateHandler>();
            services.AddTransient<HttpBankIdRequestHandler>();

            services.AddHttpClient<IBankIdServiceHandler, BankIdServiceHandler>(s =>
            {
                s.BaseAddress = new Uri(bankIdSettings.BaseUrl);
            })
            .ConfigurePrimaryHttpMessageHandler<HttpCertificateHandler>()
            .AddHttpMessageHandler<HttpBankIdRequestHandler>()
            .SetHandlerLifetime(TimeSpan.FromMinutes(3));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo() { Title = "BankId", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankId Service");
            });

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
