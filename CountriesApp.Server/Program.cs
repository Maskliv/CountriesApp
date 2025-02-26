
using CountriesApp.Server.AppStartup;
using Microsoft.OpenApi.Models;

namespace CountriesApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration config = builder.Configuration.AddJsonFile("appsettings.json").Build();

            // Add services to the container.
            builder.Services.AddCorsDocumentation(config);
            builder.Services.AddControllers();
            builder.Services.AddDependencyInjectionConfig(config);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt => { opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Countries API", Version = "v1" }); });

            var app = builder.Build();
            app.UseCorsDocumentation();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseExceptionMiddleware();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
