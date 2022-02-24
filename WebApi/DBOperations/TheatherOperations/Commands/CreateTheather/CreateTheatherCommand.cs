using WebApi.Models.Entities;
using WebApi.DBOperations;
using AutoMapper;
using WebApi.Repositories;

namespace WebApi.DBOperations.TheatherOperations.Commands.CreateTheather {
  public class CreateTheatherCommand {

    public CreateTheatherModel Model {get; set;}
    private readonly TheathersDbContext _context;
    private readonly IMapper _mapper;
    private readonly UnitOfWork _uow;
    public CreateTheatherCommand(TheathersDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
      _uow = new UnitOfWork(context);
    }

    public void Handle(){
      var theatherRepo = _uow.GetRepository<TheatherModel>();
      var theather = theatherRepo.GetFirst(x => x.Name == Model.Name);
      if (theather != null) {
        throw new InvalidOperationException("Oyun zaten mevcut!");
      }

      theather = _mapper.Map<TheatherModel>(Model); 
      theatherRepo.Insert(theather);
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