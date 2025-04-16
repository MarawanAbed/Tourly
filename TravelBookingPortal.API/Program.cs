using Microsoft.OpenApi.Models;
using TravelBookingPortal.Infrastructure.Hubs;

using TravelBookingPortal.Application.Extensions;
using TravelBookingPortal.Infrastructure.Seeder.Travel;
using TravelBookingPortal.Infrastructure.Extensions;
using Serilog;


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
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();

           

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
                    .WithOrigins("http://localhost:4200", "https://8834-197-63-30-95.ngrok-free.app", "http://localhost:51703", "https://8cff-197-63-30-95.ngrok-free.app") //Rehab editing here
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); //Rehab Editing Here
                    
                });
            });

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<ITravelBookingSeeder>().Seed();

            // Configure the HTTP request pipeline.
            app.UseStaticFiles();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting(); //Rehab editing here
            app.UseCors(myPolicy); //Rehab editing here
            app.UseAuthentication();
            app.UseAuthorization();


            //Mapping HuBs
            app.MapHub<BookingStatusHub>("/bookingStatusHub"); //Rehab Editing Here
            app.MapControllers();

            app.Run();
        }
    }
}
