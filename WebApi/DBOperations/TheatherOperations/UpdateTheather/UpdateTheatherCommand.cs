using WebApi.Models;
using WebApi.DBOperations;

namespace WebApi.DBOperations.TheatherOperations.UpdateTheather {
  public class UpdateTheatherCommand {
    private readonly TheathersDbContext _context;

    public UpdateTheatherModel Model { get; set; }

    public int TheatherId { get; set; }
    public UpdateTheatherCommand(TheathersDbContext context) {
      _context = context;
    }

    public void Handle(){
      var theather = _context.Theathers.SingleOrDefault(x => x.Id == TheatherId);
      if (theather == null) {
        throw new InvalidOperationException("Oyun Bulunamadı.");
      }

      theather.Name = Model.Name != default ? Model.Name : theather.Name;
      theather.Description = Model.Description != default ? Model.Description : theather.Description;
      theather.AvailableSeats = Model.AvailableSeats != default ? Model.AvailableSeats : theather.AvailableSeats;
      theather.Date = Model.Date != default ? Model.Date : theather.Date;
      theather.Cost = Model.Cost != default ? Model.Cost : theather.Cost;
     
      _context.SaveChanges();
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