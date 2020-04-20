using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LMSWeb
{
    public class Startup
    {
        EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
            //            .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyMethod();
                    });
                //options.AddPolicy("AzureAd", builder => builder
                //    .WithOrigins("http://localhost:4200", "Access-Control-Allow-Origin", "Access-Control-Allow-Credentials")
                //    .AllowAnyMethod()
                //    .AllowAnyHeader()
                //    .AllowCredentials()
                //     );
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddTransient<LeaveManagementSystemService.ILoginService, LeaveManagementSystemService.LoginService>();
            services.AddTransient<LeaveManagementSystemRepository.ILoginRepository, LeaveManagementSystemRepository.LoginRepository>();
            services.AddTransient<LeaveManagementSystemService.IEmployeeService , LeaveManagementSystemService.EmployeeService>();
            services.AddTransient<LeaveManagementSystemRepository.IEmployeeRepository, LeaveManagementSystemRepository.EmployeeRepository>();
            services.AddTransient<LeaveManagementSystemService.ILeaveService, LeaveManagementSystemService.LeaveService>();
            services.AddTransient<LeaveManagementSystemRepository.ILeaveRepository, LeaveManagementSystemRepository.LeaveRepository>();
            services.AddTransient<LeaveManagementSystemService.IProjectService, LeaveManagementSystemService.ProjectService>();
            services.AddTransient<LeaveManagementSystemRepository.IProjectRepository, LeaveManagementSystemRepository.ProjectRepository>();
            services.AddTransient<LeaveManagementSystemService.ILocationService, LeaveManagementSystemService.LocationService>();
            services.AddTransient<LeaveManagementSystemRepository.ILocationRepository, LeaveManagementSystemRepository.LocationRepository>();
            services.AddControllers();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors("AzurePolicy");
            app.UseAuthentication();

            app.UseSession();
            
            app.UseCors(MyAllowSpecificOrigins);

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
