using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Blazor_CRUD_test.Contracts;
using Blazor_CRUD_test.Concrete;
using Syncfusion.Blazor;

namespace Blazor_CRUD_test
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
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddDbContext<DataAccess.AppContext>(options =>
                          options.UseSqlServer(
                              Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DataAccess.AppContext1>(options =>
                          options.UseSqlServer(
                              Configuration.GetConnectionString("CustomConnection")));

            //Article service  
            services.AddScoped<IArticleManager, ArticleManager>();
            services.AddScoped<IProductItemManager, ProductItemManager>();

            //Register dapper in scope  
            services.AddScoped<IDapperManager, DapperManager>();
            services.AddScoped<IDapperManager1, DapperManager1>();

            services.AddSyncfusionBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzAwMjM3QDMxMzgyZTMyMmUzMFlDTlhucStnUUZlejR1aTVGYWY4UlRWSlFlMFQ5QnNQWk8ycVZMVXZ4S0E9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
