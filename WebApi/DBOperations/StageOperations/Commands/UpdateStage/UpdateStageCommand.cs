using WebApi.Models.Entities;
using WebApi.Repositories;
namespace WebApi.DBOperations.StageOperations.Commands.UpdateStage {
  public class UpdateStageCommand {
    private readonly UnitOfWork _uow;

    public UpdateStageModel Model { get ; set; }

    public int StageId { get; set; }
    public UpdateStageCommand(UnitOfWork uow) {
      _uow = uow;
    }

    public void Handle(){
      var stageRepo = _uow.GetRepository<StageModel>();
      var stage = stageRepo.GetById(StageId);
      if (stage == null) {
        throw new InvalidOperationException("Sahne Bulunamadı.");
      }

      stage.Name = Model.Name != default ? Model.Name : stage.Name;
      stage.Adress = Model.Adress != default ? Model.Adress : stage.Adress;
     
      stageRepo.Update(stage);
    }

    public class UpdateStageModel {
      public string? Name { get; set; }
      public string? Adress { get; set; }
    }
  }
}