using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeFinderWebApi.Data;
using CafeFinderWebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CafeFinderWebApi
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
            services.AddControllers();

             services.AddMvc();
             
             services.AddScoped<ICafeService, CafeService>();
             services.AddSwaggerDocument(configure=>{
                 configure.PostProcess=(doc =>
                 {
                     doc.Info.Title="All Cafes Api";
                     doc.Info.Version="1.0.10";
                     doc.Info.Contact= new NSwag.OpenApiContact(){
                         Name="Said Ahmet Bayrak",
                         Url="https://github.com/saidahmetbayrak",
                         Email="saidahmetbayrak@gmail.com"
                     };
                 });
             });


             services.AddDbContext<CafeDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseOpenApi();

            app.UseSwaggerUi3(); 

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
