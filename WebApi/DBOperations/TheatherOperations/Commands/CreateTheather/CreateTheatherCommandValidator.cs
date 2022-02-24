using FluentValidation;

namespace WebApi.DBOperations.TheatherOperations.Commands.CreateTheather {
  public class CreateTheatherCommandValidator : AbstractValidator<CreateTheatherCommand> {
    public CreateTheatherCommandValidator() {
      RuleFor(command => command.Model.AvailableSeats).GreaterThan(0);
      RuleFor(command => command.Model.Date).NotEmpty().GreaterThan(DateTime.Now.Date); 
    }
  }
}