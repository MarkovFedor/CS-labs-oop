using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reports.API.Mapping;
using Reports.API.Persistence.Contexts;
using Reports.API.Domain.Repositories;
using Reports.API.Domain.Services;
using Reports.API.Services;
using Reports.API.Persistence.Repositories;

namespace Reports.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ReportAppContext>(options => options.UseSqlServer(connection));
            services.AddCors();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaskMappingProfile());
                mc.AddProfile(new ReportMappingProfile());
                mc.AddProfile(new EmployeeMappingProfile());
                mc.AddProfile(new TaskChangeMappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ITaskChangeRepository, TaskChangeRepository>();
            services.AddTransient<ITaskChangeService, TaskChangeService>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
