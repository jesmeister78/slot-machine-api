using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlotMachineApiNetCore2.Config;
using SlotMachineApiNetCore2.Model;

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
            services.AddTransient<ISlotMachineRepo, SlotMachineRepo>();

            // add database
            // local db
            var connection = Configuration.GetConnectionString("SlotMachineApiDotNetCore2_db");
              // @"Server=(localdb)\mssqllocaldb;Database=SlotMachineApi.Database;Trusted_Connection=True;ConnectRetryCount=0";
            // azure sql db
            // var azureConnection = @"Data Source=slotmachineapidotnetcore2dbserver.database.windows.net;Initial Catalog=SlotMachineApiDotNetCore2_db;Integrated Security=False;User ID=jesmeister;Password=Gaib1313!;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<SlotMachineContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            // global policy - assign here or on each controller
            app.UseCors("AllowAll");

            app.UseMvc();
        }
    }
}