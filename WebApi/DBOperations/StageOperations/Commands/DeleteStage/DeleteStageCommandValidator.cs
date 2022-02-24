using FluentValidation;

namespace WebApi.DBOperations.StageOperations.Commands.DeleteStage {
  public class DeleteStageCommandValidator : AbstractValidator<DeleteStageCommand> {
    public DeleteStageCommandValidator(){
      RuleFor(command => command.StageId).GreaterThan(0);
    }
  }
}
