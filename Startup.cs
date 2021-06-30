using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace restapidemo
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
            
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("restapidemo"));
            // services.AddDbContext<TodoContext>(op => op.UseSqlServer(Configuration.GetConnectionString("Database"))); 
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "restapidemo", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        //      //Specify the MyCustomPage1.html as the default page
        // DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
        // defaultFilesOptions.DefaultFileNames.Clear();
        // defaultFilesOptions.DefaultFileNames.Add("qweindex.html");

        // Use UseFileServer instead of UseDefaultFiles & UseStaticFiles
        FileServerOptions fileServerOptions = new FileServerOptions();
        fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
        fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("fruits.html");

        app.UseFileServer(fileServerOptions);

            app.UseDefaultFiles();
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "restapidemo v1"));
            }

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
