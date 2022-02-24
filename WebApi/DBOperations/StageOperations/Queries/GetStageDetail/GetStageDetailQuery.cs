using WebApi.Models.Entities;
using AutoMapper;
using WebApi.Repositories;

namespace WebApi.DBOperations.StageOperations.Queries.GetStageDetail {
  public class GetStageDetailQuery {
    private readonly IMapper _mapper;
    private readonly UnitOfWork _uow;
    public int StageId { get; set;}

    public GetStageDetailQuery(UnitOfWork uow, IMapper mapper) {
      _mapper = mapper;
      _uow = uow;
    }

    public StageDetailViewModel Handle()
    {
      var stage = _uow.GetRepository<StageModel>().GetById(StageId);
      if (stage == null)
        throw new InvalidOperationException("Sahne Bulunamadı.");
      StageDetailViewModel vm = _mapper.Map<StageDetailViewModel>(stage);
      return vm;
    }
  }

  public class StageDetailViewModel {
    public string? Name { get; set; }
    public string? Adress { get; set; }
  }
}