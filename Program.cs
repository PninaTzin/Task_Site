using Microsoft.OpenApi.Models;
using Web_Api_Project.Interface;
using Web_Api_Project.Services;

namespace Web_Api_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);


            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web API Project", Version = "v1" });
            });
            builder.Services.AddScoped<IUserTaskServices, UserTaskServices>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITaskServices, TaskService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });
            var app = builder.Build();

            app.UseMiddleware<logMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAllOrigins"); // הוסף את זה לפני app.UseRouting()

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API Project V1");
                c.RoutePrefix = "swagger";
            });
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
// builder.Services.AddMyServices();
