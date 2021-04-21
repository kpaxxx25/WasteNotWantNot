using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WNWN.Data;

namespace WNWN
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
            services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddAuthentication()
            .AddJwtBearer();
            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
/*        public static Microsoft.EntityFrameworkCore.DbContextOptionsBuilder UseCosmos(this Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder, string connectionString, string databaseName, Action<Microsoft.EntityFrameworkCore.Infrastructure.CosmosDbContextOptionsBuilder> cosmosOptionsAction = default);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseCosmos(
        "DefaultConnection",
        databaseName: "wnwnpantry",
        options =>
        {
            options.ConnectionMode(ConnectionMode.Gateway);
            options.WebProxy(new WebProxy());
            options.LimitToEndpoint();
            options.Region(Regions.EastUS2);
            options.GatewayModeMaxConnectionLimit(32);
            options.MaxRequestsPerTcpConnection(8);
            options.MaxTcpConnectionsPerEndpoint(16);
            options.IdleTcpConnectionTimeout(TimeSpan.FromMinutes(1));
            options.OpenTcpConnectionTimeout(TimeSpan.FromMinutes(1));
            options.RequestTimeout(TimeSpan.FromMinutes(1));
        });*/
    }
}
