

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

           

            builder.Services.AddApplication();


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var myPolicy = "myPolicy";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: myPolicy, policy =>
                {
                    policy
                    .WithOrigins("http://localhost:4200", "https://79b1-197-63-73-173.ngrok-free.app/") //Rehab editing here
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); //Rehab Editing Here
                    
                });
            });

            var app = builder.Build();







            var scope = app.Services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<ITravelBookingSeeder>().Seed();
            // Configure the HTTP request pipeline.

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
