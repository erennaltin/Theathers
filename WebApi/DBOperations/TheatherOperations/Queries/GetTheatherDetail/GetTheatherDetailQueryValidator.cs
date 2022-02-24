using FluentValidation;

namespace WebApi.DBOperations.TheatherOperations.Queries.GetTheatherDetail {
  public class GetTheatherDetailQueryValidator : AbstractValidator<GetTheatherDetailQuery> {
    public GetTheatherDetailQueryValidator(){
      RuleFor(query => query.TheatherId).GreaterThan(0);
    }
  }
}