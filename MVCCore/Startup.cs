using CoreMVCApp.Models;
using CoreMVCApp.Models.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreMVCApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //register framework services 
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().
                AddEntityFrameworkStores<AppDbContext>();

            //adding repositories to the service 
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();

            services.AddMvc();

            //register customized services

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseAuthentication();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}"
                        );
                });

        }
    }
}
