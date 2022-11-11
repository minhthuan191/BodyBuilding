using BodyBuildingApp.Auth;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using BodyBuildingApp.Utils.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyBuildingApp
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
            services.AddControllersWithViews();
            services.AddScoped<DBContext, DBContext>();
            services.AddScoped<IConfig, Config>();
            //service start
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBodyStatusService, BodyStatusService>();
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IExerciseSessionService, ExerciseSessionService>();
            services.AddScoped<IInstructionDetailService, InstructionDetailService>();
            services.AddScoped<IInstructionService, InstructionService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IDailyPlanService, DailyPlanService>();
            services.AddScoped<IDailyFoodDetailService, DailyFoodDetailService>();
            services.AddScoped<IFoodDetailService, FoodDetailService>();
            //service end

            //repo start
            services.AddScoped<InstructionRepository>();
            services.AddScoped<TrainerRepository>();
            services.AddScoped<ExerciseRepository>();
            services.AddScoped<InstructionDetailRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<BodyStatusRepository>();
            services.AddScoped<DailyPlanRepository>();
            services.AddScoped<FoodDetailRepository>();
            services.AddScoped<DailyFoodDetailRepository>();
            //repo end
            services.AddScoped<AuthGuard>();
            services.AddScoped<AuthGuardTrainner>();
            services.AddScoped<UserFilter>();

            services.AddSession();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BodyBuildingApp", Version = "v1" });
            });

            services.AddCors(options => {
                options.AddDefaultPolicy(
                    builder => {
                        builder.WithOrigins("http://localhost:3000", "https://localhost:5001")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod().AllowCredentials();
                    });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        async public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfig config)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BodyBuildingApp v1"));
            //}
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            await DBContext.InitDatabase(config);
        }
    }
}
