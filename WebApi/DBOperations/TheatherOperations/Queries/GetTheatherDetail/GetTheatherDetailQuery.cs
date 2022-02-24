using WebApi.Models.Entities;
using AutoMapper;
using WebApi.Repositories;

namespace WebApi.DBOperations.TheatherOperations.Queries.GetTheatherDetail {
  public class GetTheatherDetailQuery {
    private readonly IMapper _mapper;
    private readonly UnitOfWork _uow;
    public int TheatherId { get; set;}

    public GetTheatherDetailQuery(TheathersDbContext context, IMapper mapper) {
      _mapper = mapper;
      _uow = new UnitOfWork(context);
    }

    public TheatherDetailViewModel Handle()
    {
      var theather = _uow.GetRepository<TheatherModel>().GetById(TheatherId);
      if (theather == null)
        throw new InvalidOperationException("Oyun Bulunamadı.");
      TheatherDetailViewModel vm = _mapper.Map<TheatherDetailViewModel>(theather);
      var stage = _uow.GetRepository<StageModel>().GetById(vm.StageId);
      vm.Stage = stage;
      return vm;
    }
  }

  public class TheatherDetailViewModel {
    public string? Name {get; set; }
    public string? Description {get; set; }
    public int AvailableSeats {get; set; }
    public string? Date {get; set; }
    public int StageId {get; set; }
    public StageModel? Stage {get; set; }
    public int Cost {get; set; }
  }
}