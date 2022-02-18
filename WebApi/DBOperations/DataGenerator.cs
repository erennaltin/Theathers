using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Models;

namespace WebApi.DBOperations {
  public class DataGenerator {
    public static void Initialize(IServiceProvider serviceProvider) {
      using (var context = new TheathersDbContext(serviceProvider.GetRequiredService<DbContextOptions<TheathersDbContext>>( ))){
        if (context.Theathers.Any()) {
          return;
        }

        context.Theathers.AddRange(
           new TheatherModel {
             Name= "Bir Baba Hamlet",
            Description= "DENEME",
            AvailableSeats= 64,
            Date= new DateTime(2022,02,18),
            TheatherId= 1, // Baba Sahne
            Cost= 90, 
          },
          new TheatherModel {
            Name= "Donkişot'um Ben",
            Description= "DENEME",
            AvailableSeats= 64,
            Date= new DateTime(2022,02,19),
            TheatherId= 1, // Baba Sahne
            Cost= 90,
          },
          new TheatherModel {
            Name= "İki kişilik hırgür",
            Description= "DENEME",
            AvailableSeats= 256,
            Date= new DateTime(2022,04,15),
            TheatherId= 2, // Fişekhane
            Cost= 150,
          }
        );

        context.SaveChanges();
      } 
    }
  }
}