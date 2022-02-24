using FluentValidation;

namespace WebApi.DBOperations.StageOperations.Commands.CreateStage {
  public class CreateStageCommandValidator : AbstractValidator<CreateStageCommand> {
    public CreateStageCommandValidator() {
      RuleFor(command => command.Model.Name).NotEmpty();
      
    }
  }
}