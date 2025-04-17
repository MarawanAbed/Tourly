
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using TravelBookingPortal.Infrastructure.Seeder;

using TravelBookingPortal.Infrastructure.Hubs;

using TravelBookingPortal.Application.Extensions;
using TravelBookingPortal.Infrastructure.Seeder.Travel;
using TravelBookingPortal.Infrastructure.Extensions;


namespace TravelBookingPortal.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();

            builder.Services.AddHttpContextAccessor(); //Menna Editing Here


            builder.Services.AddApplication();


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                var scope = app.Services.CreateScope();
                await scope.ServiceProvider.GetRequiredService<ITravelBookingSeeder>().Seed();
            }


            var myPolicy = "myPolicy";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: myPolicy, policy =>
                {
                    policy
                    .WithOrigins("http://localhost:4200", "https://8834-197-63-30-95.ngrok-free.app", "http://localhost:62237", "https://8cff-197-63-30-95.ngrok-free.app") //Rehab editing here
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); //Rehab Editing Here
                    
                });
            });


            var app = builder.Build();
            //Mapping HuBs
            app.MapHub<BookingHub>("/bookingHub");
            var scope = app.Services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<ITravelBookingSeeder>().Seed();
            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseHttpsRedirection();
            app.UseAuthorization();



            app.UseCors(myPolicy);


            app.MapControllers();

            app.Run();
        }
    }
}
