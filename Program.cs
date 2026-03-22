using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=GameTournamentDb.db"));

            builder.Services.AddScoped<ITournamentService, TournamentService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Exposes: /openapi/v1.json
                app.MapOpenApi();

                // Exposes Swagger UI: /swagger
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
                    options.RoutePrefix = "swagger";
                });
            }
            Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors("AllowAll");

            app.MapControllers();


            app.Run();
        }
    }
}
