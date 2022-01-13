using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using UltimateGiftShop.Services;
using UltimateGiftShop.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using UltimateGiftShop.Repositories;

namespace UltimateGiftShop
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
            services.AddControllersWithViews();
            services.AddSingleton<IRedisRepositoryService,RedisRepositoryService>();
            services
                .AddSingleton<IConnectionMultiplexer>(sp =>
                {
                    var configurationOptions = new ConfigurationOptions
                    {
                        ClientName = "UltimateGiftShop",
                        ConnectTimeout = 5000,
                        SyncTimeout = 5000,
                        AsyncTimeout = 5000
                    };
                    configurationOptions.EndPoints.Add("127.0.0.1",6379);
                    ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(configurationOptions);
                    connection.ConnectionFailed += (sender, e) =>
                    {
                        // logger.LogError($"Connection to Redis failed with type {e.FailureType}", e.Exception);
                        //TODO Do something with readiness etc
                    };

                    return connection;
                });

            services.AddDbContext<UltimateGiftShopDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("UltimateGiftShop"), b => b.MigrationsAssembly("UltimateGiftShop.Repositories")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
