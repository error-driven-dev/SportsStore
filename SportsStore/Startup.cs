using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;

namespace SportsStore
{
    public class Startup
    {   //NEED BETTER UNDERSTANDING -reads connection string from Json file...p.213 or ch14
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:SportsStoreProducts:ConnectionString"]));
            //registers IProdRepo and specifies that when a component needs one, that it should get an instance of FakeProdRepo. 
            //AddTransient meth specifies that new FakeRepo obj should be created each time IProdRepo is needed
//            **services.AddTransient<IProductRepository, FakeProductRepository>();
            
            //changing transient to point to  EF Product Repo
            services.AddTransient<IProductRepository, EFProductRepository>();
            //register SessionCart service; same object should be used for related requests; related to SessionCart service
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline -- which consists of classes used as middleware.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: null, 
                    template: "{category}/Page{productPage:int}",
                    defaults: new {Controller = "Product", action = "List", productPage = 1});

                    routes.MapRoute(
                        name: null, 
                        template: "Page{productPage:int}", 
                        defaults: new{Controller = "Product", action = "List", productPage=1});

                routes.MapRoute(
                        name: null, 
                        template: "{category}", 
                        defaults: new{Controller = "Product", action = "List", productPage=1});

                routes.MapRoute(
                        name: null, 
                        template: "", 
                        defaults: new{Controller = "Product", action = "List", productPage=1});
                
                    
                    //setting up default route pattern, controller/action/id -- where if nothing is entered Product will be defaultcontroller and List will be default action, id can be null.
                    routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
                });
            SeedData.EnsurePopulated(app);



        }
    }
}
