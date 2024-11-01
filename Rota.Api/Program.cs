using Microsoft.Extensions.DependencyInjection;

namespace Rota.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer()
                            .AddSwaggerGen()
                            .SetupRota();

            var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    
            builder.Services.AddCors(o => o.AddPolicy(MyAllowSpecificOrigins, options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();                    
            }));
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.UseCors(MyAllowSpecificOrigins);

            app.Run();
        }
    }
}
