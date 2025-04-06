

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
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
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

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();



            app.UseCors(myPolicy);


            app.MapControllers();

            app.Run();
        }
    }
}
