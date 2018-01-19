using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SlotMachineApiNetCore2.Config;
using Microsoft.EntityFrameworkCore;
using SlotMachineDomain;

namespace SlotMachineApiNetCore2
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
            // Add framework services.
            services.AddMvc();
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            services.AddOptions();
            services.Configure<Params>(Configuration);
            // add domain services
            services.AddTransient<IBetService, BetService>();
            services.AddTransient<ISpinService, SpinService>();

            // add database

            var connection = @"Server=(localdb)\mssqllocaldb;Database=SlotMachineApi.Database;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<SlotMachineContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // global policy - assign here or on each controller
            app.UseCors("AllowAll");

            app.UseMvc();
        }
    }
}
