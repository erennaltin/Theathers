using WebApi.Models.Entities;
using WebApi.Repositories;
namespace WebApi.DBOperations.TheatherOperations.Commands.UpdateTheather {
  public class UpdateTheatherCommand {
    private readonly UnitOfWork _uow;

    public UpdateTheatherModel Model { get ; set; }

    public int TheatherId { get; set; }
    public UpdateTheatherCommand(TheathersDbContext context) {
      _uow = new UnitOfWork(context);
    }

    public void Handle(){
      var theatherRepo = _uow.GetRepository<TheatherModel>();
      var theather = theatherRepo.GetById(TheatherId);
      if (theather == null) {
        throw new InvalidOperationException("Oyun Bulunamadı.");
      }

      theather.Name = Model.Name != default ? Model.Name : theather.Name;
      theather.Description = Model.Description != default ? Model.Description : theather.Description;
      theather.AvailableSeats = Model.AvailableSeats != default ? Model.AvailableSeats : theather.AvailableSeats;
      theather.Date = Model.Date != default ? Model.Date : theather.Date;
      theather.Cost = Model.Cost != default ? Model.Cost : theather.Cost;
     
      theatherRepo.Update(theather);
    }

    public class UpdateTheatherModel {
      public string? Name {get; set; }
      public string? Description {get; set; }
      public int AvailableSeats {get; set; }
      public DateTime Date {get; set; }
      public int Cost {get; set; }
    }
  }
}