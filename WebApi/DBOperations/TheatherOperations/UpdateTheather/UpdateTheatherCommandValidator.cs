using FluentValidation;

namespace WebApi.DBOperations.TheatherOperations.UpdateTheather {
  public class UpdateTheatherCommandValidator : AbstractValidator<UpdateTheatherCommand>{
    public UpdateTheatherCommandValidator(){
      RuleFor(command => command.TheatherId).GreaterThan(0);
      RuleFor(command => command.Model.AvailableSeats).GreaterThan(0);
      RuleFor(command => command.Model.Name).NotEmpty();
    }
  }
}