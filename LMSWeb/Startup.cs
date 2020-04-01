using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Web.Http.Cors;
using Microsoft.OpenApi.Models;

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
            //  services.AddSwaggerGen(C =>
            //  {
            //      C.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            //  }
            //);
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
            services.AddControllers();
            //services.AddCors();
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
