using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Context;
using EmployeeManagement.Infrastructure.Repository;
using EmployeeManagement.Services.Business;
using EmployeeManagement.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Net.Mime;
using System.Reflection;
using EmployeeManagement.Application.Employees.Commands.CreateEmployee;

namespace EmployeeManagement.Presentation
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
            services.AddDbContext<CrudDDDContext>(options =>
               options.UseInMemoryDatabase(databaseName: "EmployeeDB"));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IRepository<Employee>, BaseRepository<Employee>>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddMediatR();
            services.AddMvc().AddFluentValidation(fv => {
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Employees}/{action=Index}/{id?}");
            });
        }
    }

}
