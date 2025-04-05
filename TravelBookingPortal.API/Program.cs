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

            //add infrastructure
            builder.Services.AddInfrastructure(builder.Configuration);

           

            builder.Services.AddApplication();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
