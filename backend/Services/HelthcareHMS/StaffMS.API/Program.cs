
using StaffMS.Application;
using StaffMS.Application.Utils.Interfaces.Infrastructure;
using StaffMS.Application.Utils.Mapping;
using StaffMS.Persistence;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using StaffMS.API.Middleware;

namespace StaffMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();

            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(config => // adding automapper to program
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IStaffMSDbContext).Assembly));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            
            //builder.Services.AddAuthentication(config =>
            //    {
            //        config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    })
            //    .AddJwtBearer("Bearer", options =>
            //    {
            //        options.Authority = "https://localhost:5000/";
            //        options.Audience = "StaffMSAPI";
            //        options.RequireHttpsMetadata = false;
            //    });

             
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<StaffMSDbContext>();
                    DbInitializer.Initialize(context); 
                }
                catch (Exception ex)
                {
                    
                }
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCustomExceptionHandler();
            app.UseCors("AllowAll");
            app.UseAuthorization();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
