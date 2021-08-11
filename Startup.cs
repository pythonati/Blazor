using FirstBlazor.Data;
using FirstBlazor.Data.Repository;
using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using FirstBlazor.Models.DB.View;
using FirstBlazor.OtherClasses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FirstBlazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<DB>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppDB"));
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IRepositoryU1<TranDBModel>, SQLServerTran>();
            services.AddScoped<IRepositoryU1<AccountDBModel>, SQLServerAccount>();
            services.AddScoped<IRepositoryU1<CategoryDBModel>, SQLServerCategory>();
            services.AddScoped<IRepositoryU1<LableDBModel>, SQLServerLable>();

            services.AddScoped<IRepositoryU2<Chart1DBModel>, SQLServerChart1>();
            services.AddScoped<IRepositoryU2<Chart2DBModel>, SQLServerChart2>();

            services.AddSingleton<CurrentUser>();   //Представляет текущего пользователя
            services.AddScoped<IRepositoryU3<LoginDBModel>, SQLServerLogin>();
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
