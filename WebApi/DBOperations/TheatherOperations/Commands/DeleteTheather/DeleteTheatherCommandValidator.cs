using FluentValidation;

namespace WebApi.DBOperations.TheatherOperations.Commands.DeleteTheather {
  public class DeleteTheatherCommandValidator : AbstractValidator<DeleteTheatherCommand> {
    public DeleteTheatherCommandValidator(){
      RuleFor(command => command.TheatherId).GreaterThan(0);
    }
  }
}
