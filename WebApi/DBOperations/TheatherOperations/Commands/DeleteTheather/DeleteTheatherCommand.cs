using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.DBOperations.TheatherOperations.Commands.DeleteTheather {
  public class DeleteTheatherCommand {
    private readonly TheathersDbContext _context;
    private readonly UnitOfWork _uow;

    public int TheatherId { get; set; }
    public DeleteTheatherCommand(TheathersDbContext context) {
      _context = context;
      _uow = new UnitOfWork(context);
    }

    public void Handle(){
      var theather = _uow.GetRepository<TheatherModel>().GetById(TheatherId);
      if (theather == null) {
        throw new InvalidOperationException("Oyun Bulunamadı!");
      }

      _context.Theathers.Remove(theather);
      _context.SaveChanges();
    }
  }
}