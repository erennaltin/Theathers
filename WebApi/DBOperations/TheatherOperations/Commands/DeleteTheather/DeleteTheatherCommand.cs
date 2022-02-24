using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.DBOperations.TheatherOperations.Commands.DeleteTheather {
  public class DeleteTheatherCommand {
    private readonly UnitOfWork _uow;

    public int TheatherId { get; set; }
    public DeleteTheatherCommand(TheathersDbContext context) {
      _uow = new UnitOfWork(context);
    }

    public void Handle(){
      var theatherRepo = _uow.GetRepository<TheatherModel>();
      var theather = theatherRepo.GetById(TheatherId);
      if (theather == null) {
        throw new InvalidOperationException("Oyun Bulunamadı!");
      }

      theatherRepo.DeletePermanently(theather);
    }
  }
}