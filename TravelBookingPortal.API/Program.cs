
using Microsoft.OpenApi.Models;
using Serilog;
using TravelBookingPortal.API.Middlewares;
using TravelBookingPortal.Application.Extensions;
using TravelBookingPortal.Application.Interfaces.Seeder.Travel;
using TravelBookingPortal.Infrastructure.Extensions;
using TravelBookingPortal.Infrastructure.Hubs;
using TravelBookingPortal.Persistence.Extensions;


namespace TravelBookingPortal.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, services, configuration) =>
            {
                configuration
                .ReadFrom.Configuration(context.Configuration);
                
            });
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelBookingPortal.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            var myPolicy = "myPolicy";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: myPolicy, policy =>
                {
                    policy

                    .WithOrigins( "http://localhost:4200","https://f8c7-197-63-49-3.ngrok-free.app", "http://localhost:51819", "https://8cff-197-63-30-95.ngrok-free.app") //Rehab editing here
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                    ;

                });
            });

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<ITravelBookingSeeder>().Seed();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseStaticFiles();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting(); 
            app.UseCors(myPolicy);
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapHub<BookingStatusHub>("/bookingStatusHub");
            app.MapControllers();

            app.Run();
        }
    }
}
