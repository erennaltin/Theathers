using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.DBOperations.StageOperations.Commands.CreateStage;
using WebApi.DBOperations.StageOperations.Commands.DeleteStage;
using WebApi.DBOperations.StageOperations.Commands.UpdateStage;
using WebApi.DBOperations.StageOperations.Queries.GetStageDetail;
using WebApi.DBOperations.StageOperations.Queries.GetStages;
using WebApi.Repositories;
using static WebApi.DBOperations.StageOperations.Commands.CreateStage.CreateStageCommand;
using static WebApi.DBOperations.StageOperations.Commands.UpdateStage.UpdateStageCommand;

namespace WebApi.Controllers {
  
  [ApiController]
  [Route("[controller]s/[action]")]
  public class StageController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly UnitOfWork _uow;

    public StageController(TheathersDbContext context, IMapper mapper){
      _mapper = mapper;
      _uow = new UnitOfWork(context);
    }


    [HttpGet]
    public IActionResult GetStages(){
      GetStagesQuery query = new GetStagesQuery(_uow, _mapper);
      var result = query.Handle();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id){
      GetStageDetailQuery query = new GetStageDetailQuery(_uow, _mapper);
      query.StageId = id;
      GetStageDetailQueryValidator validator = new GetStageDetailQueryValidator();
      validator.ValidateAndThrow(query);
      StageDetailViewModel result = query.Handle();
      return Ok(result);
    }


    [HttpPost]
    public IActionResult AddStage([FromBody] CreateStageModel newStage) {
      CreateStageCommand command = new CreateStageCommand(_uow, _mapper);
      command.Model = newStage;
      CreateStageCommandValidator validator = new CreateStageCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();   

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStage(int id, [FromBody] UpdateStageModel newStage) {
      UpdateStageCommand command = new UpdateStageCommand(_uow);

      command.Model = newStage;
      command.StageId = id;
      UpdateStageCommandValidator validator = new UpdateStageCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStage(int id) {
      DeleteStageCommand command = new DeleteStageCommand(_uow);
      command.StageId = id;
      DeleteStageCommandValidator validator = new DeleteStageCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();
      return Ok();
      
    }
  }
}

