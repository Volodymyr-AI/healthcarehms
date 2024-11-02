using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Service.Infrastructure;
using SQLitePCL;
using UserManagement.Service.Domain;
using UserManagement.Service.Services.AuthServices;
using UserManagement.Service.Services.UserServices;

namespace UserManagement.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            
            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidateAudience = true,
                        ValidAudience = jwtSettings["Audience"],
                        ValidateLifetime = true
                    };
                });

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("UserManagementConnection");
            builder.Services.AddDbContext<UserManagementDbContext>(options =>
                options.UseSqlite(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            //CORS  
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            
            builder.Services.AddScoped<GlobalAdminService>();
            builder.Services.AddScoped<StaffAdminService>();
            builder.Services.AddScoped<StaffMemberService>();
            builder.Services.AddScoped<JwtAndLoginService>();
            builder.Services.AddScoped<JwtService>();
            builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");
            
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
