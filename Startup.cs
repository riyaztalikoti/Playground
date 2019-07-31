using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.Database;
using GraphQL.Types;
using GraphQL.Types1;
using GraphQL_DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApp.GraphQL.Queries;
using WebApp.GraphQL.Schema;

namespace WebApp.GraphQL
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
            string connectionString = Configuration["connectionstring"];

            // Register Device Manager DB Context Service
            services.AddDbContext<DeviceDBContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebApp.GraphQL")));
            services.AddDbContext<DeviceDBContext>(option => option.UseSqlServer(connectionString));
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<DeviceQuery>();
            services.AddSingleton<DeviceType1>();

            services.AddSingleton<DeviceTypeQuery>();
            services.AddSingleton<DeviceTypeType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new DeviceSchema(new FuncDependencyResolver(type => sp.GetService(type))));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseGraphiQl();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
