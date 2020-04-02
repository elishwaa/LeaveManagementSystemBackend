using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LMSWeb
{
    public class Startup
    {
        EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
        //config.EnableCors(cors);
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            
        }
       

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
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
            });
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseSwagger(C =>
            //{
            //    C.RouteTemplate = "swagger/{documentName}/swagger.json";
            //}
            //);

            //app.UseSwaggerUI(C => {
            //    C.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            //    C.RoutePrefix = "swagger";
            //});
            app.UseSession();
            
            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseCors(
            //    options => options.WithOrigins("*").AllowAnyMethod()
            //    );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
