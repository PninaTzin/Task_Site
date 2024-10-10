// using Web_Api_Project.Services;
// using Microsoft.OpenApi.Models;
// using Web_Api_Project.Models;

// namespace Web_Api_Project
// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {

//             var builder = WebApplication.CreateBuilder(args);

//             builder.Services.AddScoped<ITaskServices, TaskService>();


//             builder.Services.AddSwaggerGen(c =>
//             {
//                 c.SwaggerDoc(
//             builder.Services.AddScoped<ITa"v1", new OpenApiInfo { Title = "TASKS", Version = "v1" });

//                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//                 {
//                     In = ParameterLocation.Header,
//                     Description = 
          
// "Please enter JWT with Bearer prefix in the field",
//                     Name = "Authorization",
//                     Type = SecuritySchemeType.ApiKey
//                 });

//                 c.AddSecurityRequirement(new OpenApiSecurityRequirement {
//                 {
//                     new OpenApiSecurityScheme
//                     {
//                         Reference = 
//                     {
//                         Refer
// new OpenApiReference {Type = ReferenceType.SecurityScheme,Id = "Bearer"}
//                     },
//                     new string[] {}
//                 }
//                 });
//             });

            
//                 }
//                 });

//             // Authentication with JWT
//             // builder.Services.AddAuthentication(options => 
//             // { 
//             //     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; 
//             // })
//             // .AddJwtBearer(cfg =>
//             // {
//             //     cfg.RequireHttpsMetadata = false;
//             //     cfg.TokenValidationParameters = TasksTokenService.GetTokenValidationParameters();
//             // });

//             // // // Authorization policies for Admin and User
//             builder.Services.AddAuthorization(authorizationOptions =>
//             {
//                 authorizationOptions.AddPolicy("Admin", policy => policy.RequireClaim("type", "Admin"));
//                 authorizationOptions.AddPolicy("User", policy => policy.RequireClaim("type", "User", "Admin"));
//             });

//             builder.Services.AddSwaggerGen(c =>
//             {
//                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "TASKS", Version = "v1" });

//                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//                 {
//                     In = ParameterLocation.Header,
//                     Description = "Please enter JWT with Bearer prefix in the field",
//                     Name = "Authorization",
//                     Type = SecuritySchemeType.ApiKey
//                 });

//                 c.AddSecurityRequirement(new OpenApiSecurityRequirement {
//         {
//             new OpenApiSecurityScheme
//             {
//                 Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme,Id = "Bearer"}
//             },
//             new string[] {}
//         }
//                 });
//             });

//             var app = builder.Build();

//             // // Middleware for logging (if needed)
//             // app.UseMiddleware<LogMiddleware>();

//             // // Enable Swagger only in development
//             if (app.Environment.IsDevelopment())
//             {
//                 app.UseSwagger();
//                 app.UseSwaggerUI(c =>
//                 {
//                     c.SwaggerEndpoint("/swagger/v1/swagger.json", "TASKS API V1");
//                     c.RoutePrefix = string.Empty;
//                 });
//             }
//             app.UseDefaultFiles(new DefaultFilesOptions
//             {
//                 DefaultFileNames = new List<string> { "index.html" }
//             });
//             app.UseStaticFiles();

//             app.UseHttpsRedirection();
//             app.UseAuthentication();
//             app.UseAuthorization();

//             app.MapControllers();

//             app.Run();
//         }
//     }
// }

// // using Microsoft.AspNetCore.Builder;
// // using Microsoft.Extensions.DependencyInjection;
// // using Microsoft.Extensions.Hosting;
// // using Web_Api_Project.services;
// // using Web_Api_Project.Models;
// // using Microsoft.OpenApi.Models;

// // var builder = WebApplication.CreateBuilder(args);

// // // Add services to the container.
// // builder.Services.AddControllers(); // תומך ב-API מבוסס controllers
// // builder.Services.AddSwaggerGen(); // הוספת Swagger לתיעוד ה-API


// // var app = builder.Build();

// // // Configure the HTTP request pipeline.
// // if (app.Environment.IsDevelopment())
// // {
// //     app.UseDeveloperExceptionPage();

// //     // הפעלת Swagger בסביבת פיתוח
// //     app.UseSwagger();
// //     app.UseSwaggerUI(c =>
// //     {
// //         c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
// //         c.RoutePrefix = string.Empty; // גורם ל-Swagger להיות ברירת מחדל
// //     });
// // }

// // app.UseHttpsRedirection();

// // app.UseRouting();

// // app.UseAuthorization();

// // app.MapControllers(); // הגדרת הראוטינג עבור controllers

// // app.Run();

// // var builder = WebApplication.CreateBuilder(args);

// // // Add services to the container.
// // builder.Services.AddControllers();
// // builder.Services.AddSwaggerGen(); // הוספת Swagger

// // var app = builder.Build();

// // // Configure the HTTP request pipeline.
// // if (app.Environment.IsDevelopment())
// // {
// //     app.UseDeveloperExceptionPage();

// //     // הפעלת Swagger בסביבת פיתוח
// //     app.UseSwagger();
// //     app.UseSwaggerUI(c =>
// //     {
// //         c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
// //         c.RoutePrefix = string.Empty; // גורם ל-Swagger להיות ברירת מחדל
// //     });
// // }

// // app.UseHttpsRedirection();
// // app.UseRouting();
// // app.UseAuthorization();

// // app.MapControllers();

// // app.Run();
// // 
// // using System;
// // using System.Collections.Generic;
// // using System.Linq;
// // using System.Threading.Tasks;
// // using Microsoft.AspNetCore.Hosting;
// // using Microsoft.Extensions.Hosting;


// // namespace Web_Api_Project
// // {
// //     public class Program
// //     {
// //         public static void Main(string[] args)
// //         {
// //             CreateHostBuilder(args).Build().Run();

// //         }
// //         public static IHostBuilder CreateHostBuilder(string[] args) =>
// //             Host.CreateDefaultBuilder(args)
// //                 .ConfigureWebHostDefaults(webBuilder =>
// //                 {
// //                     webBuilder.UseStartup<Startup>();
// //                 });

// //     }
// // }
// // // var builder = WebApplication.CreateBuilder(args);

// // // // Add services to the container.
// // // // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// // // builder.Services.AddEndpointsApiExplorer();
// // // builder.Services.AddSwaggerGen();

// // // var app = builder.Build();

// // // // Configure the HTTP request pipeline.
// // // if (app.Environment.IsDevelopment())
// // // {
// // //     app.UseSwagger();
// // //     app.UseSwaggerUI();
// // // }

// // // app.UseHttpsRedirection();

// // // var summaries = new[]
// // // {
// // //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// // // };

// // // app.MapGet("/weatherforecast", () =>
// // // {
// // //     var forecast =  Enumerable.Range(1, 5).Select(index =>
// // //         new WeatherForecast
// // //         (
// // //             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
// // //             Random.Shared.Next(-20, 55),
// // //             summaries[Random.Shared.Next(summaries.Length)]
// // //         ))
// // //         .ToArray();
// // //     return forecast;
// // // })
// // // .WithName("GetWeatherForecast")
// // // .WithOpenApi();

// // // app.Run();

// // // record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// // // {
// // //     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// // // }



// using Web_Api_Project.Interface;
// using Web_Api_Project.Services;

// public static class ServiceCollectionExtensions
// {
//     public static IServiceCollection AddMyServices(this IServiceCollection services)
//     {
//         services.AddScoped<IUserService, UserService>();
//         services.AddScoped<ITaskServices, TaskService>();
//         return services;
//     }
// }



// using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;


// namespace Web_Api_Project.Helpers
// {
//     public class JwtAuthenticationManager
//     {
//         private readonly string key;

//         public JwtAuthenticationManager(string key)
//         {
//             this.key = key;
//         }

//         public string Authenticate(string username, string role)
//         {
//             // יצירת ה-Claims
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var tokenKey = Encoding.ASCII.GetBytes(key);
//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Subject = new ClaimsIdentity(new Claim[]
//                 {
//                     new Claim(ClaimTypes.Name, username),
//                     new Claim(ClaimTypes.Role, role) // שמירת התפקיד של המשתמש
//                 }),
//                 Expires = DateTime.UtcNow.AddHours(1),
//                 SigningCredentials = new SigningCredentials(
//                     new SymmetricSecurityKey(tokenKey), 
//                     SecurityAlgorithms.HmacSha256Signature)
//             };

//             var token = tokenHandler.CreateToken(tokenDescriptor);
//             return tokenHandler.WriteToken(token);
//         }
//     }
// }

