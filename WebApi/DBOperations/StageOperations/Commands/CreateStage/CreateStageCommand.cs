using WebApi.Models.Entities;
using WebApi.DBOperations;
using AutoMapper;
using WebApi.Repositories;

namespace WebApi.DBOperations.StageOperations.Commands.CreateStage {
  public class CreateStageCommand {

    public CreateStageModel Model {get; set;}
    private readonly IMapper _mapper;
    private readonly UnitOfWork _uow;
    public CreateStageCommand(UnitOfWork uow, IMapper mapper)
    {
      _mapper = mapper;
      _uow = uow;
    }

    public void Handle(){
      var stageRepo = _uow.GetRepository<StageModel>();
      var stage = stageRepo.GetFirst(x => x.Name == Model.Name);
      if (stage != null) {
        throw new InvalidOperationException("Sahne zaten mevcut!");
      }

      stage = _mapper.Map<StageModel>(Model); 
      stageRepo.Insert(stage);
    }

    public class CreateStageModel {
    public string? Name { get; set; }
    public string? Adress { get; set; }
    }
  }
}