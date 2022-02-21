using FluentValidation;

namespace WebApi.DBOperations.TheatherOperations.DeleteTheather {
  public class DeleteTheatherCommandValidator : AbstractValidator<DeleteTheatherCommand> {
    public DeleteTheatherCommandValidator(){
      RuleFor(command => command.TheatherId).GreaterThan(0);
    }
  }
}
