using FluentValidation;

namespace WebApi.DBOperations.TheatherOperations.GetTheatherDetail {
  public class GetTheatherDetailQueryValidator : AbstractValidator<GetTheatherDetailQuery> {
    public GetTheatherDetailQueryValidator(){
      RuleFor(query => query.TheatherId).GreaterThan(0);
    }
  }
}