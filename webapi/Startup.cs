using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using newwebapi.Services;
using newwebapi.MiddleWares;
using newwebapi.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData;
using Microsoft.AspNet.OData.Builder;
using newwebapi.Models;
using Microsoft.OData.Edm;

namespace newwebapi
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

            services.AddControllers( config =>
            {
            config.EnableEndpointRouting = false;
            })
            .AddNewtonsoftJson(options=> 
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);;
            services.AddScoped<IUserDataService, UserDataService>();
            services.AddCors(p => 
            {
                p.AddPolicy("MyPolicy",
                    builder => {
                        builder.AllowAnyHeader()
                        .WithOrigins("http://127.0.0.1:5500")
                        .WithMethods("GET", "POST", "PUT", "DELETE")
                        .Build();
                    });               
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "newwebapi", Version = "v1" });
            });
            
            // services.AddDbContext<ApiAppContext>(options =>
            //        options.UseInMemoryDatabase("AppDB"));
            services.AddDbContext<ApiAppContext>(options =>
                   options.UseSqlServer(@"Data Source=localhost;Initial Catalog=ApiDotNetCore;Integrated Security=SSPI;"));

            services.AddResponseCaching();
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "newwebapi v1"));
            }

            // app.UseHttpsRedirection();
            app.UseRouting();
            app.UseResponseCaching();
            app.UseCors();            
            //app.UseAuthorization();
            app.UseMvc( routeBuilder =>
            {
                routeBuilder.Expand().Select().OrderBy().Filter();
                routeBuilder.EnableDependencyInjection();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
            app.UseWelcomePage();
            app.UserStatusMiddleWare();

            // app.Run( async context =>
            // {
            //     await context.Response.WriteAsync("URL no encontrado");
            // });
        }

        IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<User>("USers");

            return odataBuilder.GetEdmModel();
        }
    }
}
