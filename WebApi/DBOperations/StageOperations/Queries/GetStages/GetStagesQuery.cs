using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Entities;
using WebApi.DBOperations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using WebApi.Repositories;

namespace WebApi.DBOperations.StageOperations.Queries.GetStages {
  public class GetStagesQuery {
      private readonly IMapper _mapper;
      private readonly UnitOfWork _uow;
    public GetStagesQuery(UnitOfWork uow, IMapper mapper)
    {
      _mapper = mapper;
      _uow = uow;
    }

      public object Handle() {
        var stagesList = _uow.GetRepository<StageModel>().GetAll();
        List<StagesViewModel> vm = _mapper.Map<List<StagesViewModel>>(stagesList);
        return vm;
      }
  }

  public class StagesViewModel {
    public string? Name { get; set; }
    public string? Adress { get; set; }
  }
}