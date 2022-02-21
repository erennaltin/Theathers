using WebApi.Models;
using WebApi.DBOperations;
using AutoMapper;

namespace WebApi.DBOperations.TheatherOperations.CreateTheather {
  public class CreateTheatherCommand {

    public CreateTheatherModel Model {get; set;}
    private readonly TheathersDbContext _context;
    private readonly IMapper _mapper;
    public CreateTheatherCommand(TheathersDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public void Handle(){
      var theather = _context.Theathers.SingleOrDefault(x => x.Name == Model.Name);
      if (theather != null) {
        throw new InvalidOperationException("Oyun zaten mevcut!");
      }

      theather = _mapper.Map<TheatherModel>(Model); 
      _context.Theathers.Add(theather);
      _context.SaveChanges();
    }

    public class CreateTheatherModel {
    public string? Name {get; set; }
    public string? Description {get; set; }
    public int AvailableSeats {get; set; }
    public DateTime Date {get; set; }
    public int? TheatherId {get; set; }
    public int Cost {get; set; }
    }
  }
}