using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.DBOperations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.DBOperations.TheatherOperations.GetTheathers {
  public class GetTheathersQuery {
      private readonly TheathersDbContext _context;
      public GetTheathersQuery(TheathersDbContext dBContext) {
        _context = dBContext; 
      }

      public List<TheathersViewModel> Handle(){
        var theatherList = _context.Theathers.OrderBy(x => x.Id).ToList<TheatherModel>();
        List<TheathersViewModel> vm = new List<TheathersViewModel>();
        foreach (var theather in theatherList) {
          vm.Add(new TheathersViewModel(){
            Name = theather.Name,
            Description = theather.Description,
            AvailableSeats = theather.AvailableSeats,
            Date = theather.Date.Date.ToString("dd/MM/yyy"),
            TheatherId = theather.TheatherId,
            Cost = theather.Cost,
          }); 
        }
        return vm;
      }
  }

  public class TheathersViewModel {
    [DatabaseGenerated(DatabaseGeneratedOption .Identity)]
    public int Id {get; set; }
    public string? Name {get; set; }
    public string? Description {get; set; }
    public int AvailableSeats {get; set; }
    public string  Date {get; set; }
    public int? TheatherId {get; set; }
    public int Cost {get; set; }
  }
}