using WebApi.Models;
using WebApi.DBOperations;

namespace WebApi.DBOperations.TheatherOperations.DeleteTheather {
  public class DeleteTheatherCommand {
    private readonly TheathersDbContext _context;

    public int TheatherId { get; set; }
    public DeleteTheatherCommand(TheathersDbContext context) {
      _context = context;
    }

    public void Handle(){
      var theather = _context.Theathers.SingleOrDefault(x => x.Id == TheatherId);
      if (theather == null) {
        throw new InvalidOperationException("Oyun Bulunamadı!");
      }

      _context.Theathers.Remove(theather);
      _context.SaveChanges();
    }
  }
}