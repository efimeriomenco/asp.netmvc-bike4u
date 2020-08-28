using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeShop.interfaces;
using BikeShop.Models;
using BikeShop.Repository;
using BikeShop.ViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace BikeShop
{
    public class Startup
    {
     
        public Startup(IConfiguration configuration)
        { 
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IBikeRepository,BikeRepository>();
            services.AddTransient<IBikeCategory, CategoryRepository>();
            services.AddTransient<IContacts, ContactsRepository>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder
                        //.WithOrigins("http://localhost:3000")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
            services.AddControllersWithViews().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<ContactsViewModelValidator>();
            });
            services.AddTransient<IValidator<ContactsViewModel>, ContactsViewModelValidator>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("CorsApi");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                context.Database.EnsureCreated();
                DBObjects.Initial(context);
            }
        }
    }
}
 