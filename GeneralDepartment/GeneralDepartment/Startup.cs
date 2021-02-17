using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace GeneralDepartment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {

            //Enable CORS
            services.AddCors(c =>{
                c.AddPolicy("Allow Origin", options => options.AllowAnyOrigin().AllowAnyMethod()
                .AllowAnyHeader());
            });
            //JSON Serializer
            services.AddControllersWithViews().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling
            =Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                =new DefaultContractResolver());

            services.AddControllers();
        }

        // This method gets called by the runtime. 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options=>options.AllowAnyOrigin().AllowAnyMethod()
            .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
                RequestPath = "/Photos"
            });
        }
    }
}
