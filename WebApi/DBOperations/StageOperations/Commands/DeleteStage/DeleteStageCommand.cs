using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.DBOperations.StageOperations.Commands.DeleteStage {
  public class DeleteStageCommand {
    private readonly UnitOfWork _uow;

    public int StageId { get; set; }
    public DeleteStageCommand(UnitOfWork uow) {
      _uow = uow;
    }

    public void Handle(){
      var stageRepo = _uow.GetRepository<StageModel>();
      var stage = stageRepo.GetById(StageId);
      if (stage == null) {
        throw new InvalidOperationException("Sahne Bulunamadı!");
      }

      stageRepo.DeletePermanently(stage);
    }
  }
}