using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Models.Entities;

namespace WebApi.DBOperations {
  public class DataGenerator {
    public static void Initialize(IServiceProvider serviceProvider) {
      using (var context = new TheathersDbContext(serviceProvider.GetRequiredService<DbContextOptions<TheathersDbContext>>( ))){
        if (context.Theathers.Any()) {
          return;
        }

        context.Stages.AddRange(
          
          new StageModel {
            Name= "Baba Sahne",
            Adress = "Deneme"
          },
          new StageModel {
            Name="Fişekhane",
            Adress = "Deneme2"
          }
        );


        context.Theathers.AddRange(
           new TheatherModel {
            Name= "Bir Baba Hamlet",
            Description= "DENEME",
            AvailableSeats= 64,
            Date= new DateTime(2022,02,18),
            StageId= 1, // Baba Sahne
            Cost= 90, 
          },
          new TheatherModel {
            Name= "Donkişot'um Ben",
            Description= "DENEME",
            AvailableSeats= 64,
            Date= new DateTime(2022,02,19),
            StageId= 1, // Baba Sahne
            Cost= 90,
          },
          new TheatherModel {
            Name= "İki kişilik hırgür",
            Description= "DENEME",
            AvailableSeats= 256,
            Date= new DateTime(2022,04,15),
            StageId= 2, // Fişekhane
            Cost= 150,
          }
        );

        context.SaveChanges();
      } 
    }
  }
}