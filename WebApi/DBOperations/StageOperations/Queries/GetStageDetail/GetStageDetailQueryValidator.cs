using FluentValidation;

namespace WebApi.DBOperations.StageOperations.Queries.GetStageDetail {
  public class GetStageDetailQueryValidator : AbstractValidator<GetStageDetailQuery> {
    public GetStageDetailQueryValidator(){
      RuleFor(query => query.StageId).GreaterThan(0);
    }
  }
}