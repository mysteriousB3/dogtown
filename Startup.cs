using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dog7.Data;
using dog7.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using dog7.Controllers;
using Hangfire;
using Hangfire.MySql;
using dog7.Services;

namespace dog7
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
            services.AddTransient<SellerPackage2Controller>();
            services.AddTransient<IMyService, MyService>(); 

            services.AddIdentity<AppUser,AppRole>()
             .AddEntityFrameworkStores<dog7DbContext>()
             .AddDefaultTokenProviders()
             .AddDefaultUI();            
            
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; 
                 
            });
           
            services.ConfigureApplicationCookie(options =>
            {
                //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.AccessDeniedPath = "/home";
                options.Cookie.Name = "YourAppCookieName";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //options.LoginPath = "/Identity/Account/Login";
                options.LoginPath = "/Security/Login";

                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });
            
            //setup db
			services.AddDbContextPool<dog7DbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(
                        Configuration.GetConnectionString("DefaultConnection"),
                        new MySqlServerVersion(new Version(8, 0, 21)), 
                        mySqlOptions => mySqlOptions
                        .CharSetBehavior(CharSetBehavior.NeverAppend)
                    )  
			    );
            //1. add user-defined services
            services.AddTransient<IMyService, MyService>();  

            //2. support for http request
            services.AddHttpClient();

            string hangfireConnectionString = Configuration.GetConnectionString("HangfireDb");
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseStorage(
                    new MySqlStorage(
                        hangfireConnectionString,
                        new MySqlStorageOptions
                        {
                            QueuePollInterval = TimeSpan.FromSeconds(10),
                            JobExpirationCheckInterval = TimeSpan.FromHours(1),
                            CountersAggregateInterval = TimeSpan.FromMinutes(5),
                            PrepareSchemaIfNecessary = true,
                            DashboardJobListLimit = 25000,
                            TransactionTimeout = TimeSpan.FromMinutes(1),
                            TablesPrefix = "Hangfire",
                        }
                    )
                ));
            // Add the processing server as IHostedService
            services.AddHangfireServer(options => options.WorkerCount = 1);
            //end add hangfire service
            

            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions (apiDescriptions => apiDescriptions.First ());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "project api version1", Version = "v1" });
            });	
            //setup mvc and cshtml runtime compliation
            services.AddControllersWithViews()
            .AddRazorRuntimeCompilation()
            .AddNewtonsoftJson(options =>
            	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );    
            //add support for razor page
            services.AddRazorPages(); 
        }//ef

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,dog7DbContext context)
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
            

            context.Database.Migrate();
				
            app.UseHttpsRedirection();

            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "project api version1"));
	

  
  			app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"dogPic")),
                RequestPath = new PathString("/dogPic")
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"evidencePic")),
                RequestPath = new PathString("/evidencePic")
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"feedPostPic")),
                RequestPath = new PathString("/feedPostPic")
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"homePic")),
                RequestPath = new PathString("/homePic")
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"sellerProfilePic")),
                RequestPath = new PathString("/sellerProfilePic")
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"sellerRegisterPic")),
                RequestPath = new PathString("/sellerRegisterPic")
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"sellingPostpic")),
                RequestPath = new PathString("/sellingPostpic")
            });

  
            app.UseRouting();
			app.UseAuthentication();

  			app.UseAuthorization();
            
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
               {
                    IgnoreAntiforgeryToken = true   ,
                   DashboardTitle = "Thunder Jobs",
                   Authorization = new[]
                    {
                        new  HangfireAuthorizationFilter("admin")
                    }
               });

			 
			app.UseEndpoints(endpoints =>
            {  
                endpoints.MapRazorPages();//razor page mapping
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");   
            });

        }//ef

		 
         


    }//ec
}//en
