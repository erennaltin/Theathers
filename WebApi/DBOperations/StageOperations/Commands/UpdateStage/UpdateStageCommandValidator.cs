using FluentValidation;

namespace WebApi.DBOperations.StageOperations.Commands.UpdateStage {
  public class UpdateStageCommandValidator : AbstractValidator<UpdateStageCommand>{
    public UpdateStageCommandValidator(){
      RuleFor(command => command.StageId).GreaterThan(0);
      RuleFor(command => command.Model.Name).NotEmpty();
    }
  }
}