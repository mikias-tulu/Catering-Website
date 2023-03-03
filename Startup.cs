using adminautentication.Data;
using adminautentication.Interface;
using adminautentication.Models;
using adminautentication.Settings;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using MongoDB.Driver.Core.Configuration;

namespace adminautentication
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
            var mongoDbSettings = Configuration.GetSection(nameof(Mongodbconfig)).Get<Mongodbconfig>();
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(
                mongoDbSettings.ConnectionString,
                mongoDbSettings.Name);

            services.AddTransient<ISweetcatering, SweetcateringDBContext>();

            services.Configure<Setting>(
                options =>
                {
                    options.ConnectionString = Configuration.GetSection("MongoDB:ConnectionString").Value;
                    options.Database = Configuration.GetSection("MongoDB:Database").Value;
                }


                );

            services.AddRazorPages();
            services.AddRazorPages();
            services.AddControllersWithViews();
           
            

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();






        }
    }
}
