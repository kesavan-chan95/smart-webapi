using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartOffice.BusinessLayer.Services;
using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;

namespace SmartOffice.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterRepositories(services);
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

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

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private void RegisterRepositories(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("MasterConnection");

            services.AddDbContext<MasterDBContext>(options => options.UseMySQL(connectionString));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddTransient<ImasuserRepository, masuserRepository>();
            services.AddTransient<IconfigdatamanagerRepository, configdatamanagerRepository>();
            services.AddTransient<IconfiglovRepository, configlovRepository>();
            services.AddTransient<IconfigsubscriptionRepository, configsubscriptionRepository>();
            services.AddTransient<ImasacgroupRepository, masacgroupRepository>();
            services.AddTransient<ImasacmasterRepository, masacmasterRepository>();
            services.AddTransient<ImasaddressRepository, masaddressRepository>();
            services.AddTransient<ImasbranchRepository, masbranchRepository>();
            services.AddTransient<ImasbusinessRepository, masbusinessRepository>();
            services.AddTransient<ImasemployeeRepository, masemployeeRepository>();
            services.AddTransient<ImasfacilityRepository, masfacilityRepository>();
            services.AddTransient<ImassalarygroupRepository, massalarygroupRepository>();
            services.AddTransient<ImasshiftRepository, masshiftRepository>();
            services.AddTransient<ImasslotRepository, masslotRepository>();
            services.AddTransient<ItrnattendanceRepository, trnattendanceRepository>();
            services.AddTransient<ItrnledgerRepository, trnledgerRepository>();
            services.AddTransient<ItrnsalarydetailsRepository, trnsalarydetailsRepository>();
            services.AddTransient<ItrnsalaryheaderRepository, trnsalaryheaderRepository>();
            services.AddTransient<ItrnslotbookingRepository, trnslotbookingRepository>();
        }
        private void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IBusinessService, BusinessService>();
            services.AddTransient<IBranchService, BranchService>();

        }

    }
}
