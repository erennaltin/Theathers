using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Entities;
using WebApi.DBOperations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using WebApi.Repositories;

namespace WebApi.DBOperations.TheatherOperations.Queries.GetTheathers {
  public class GetTheathersQuery {
      private readonly IMapper _mapper;
      private readonly UnitOfWork _uow;
    public GetTheathersQuery(TheathersDbContext context, IMapper mapper)
    {
      _mapper = mapper;
      _uow = new UnitOfWork(context);
    }

      public object Handle() {
        var theatherList = _uow.GetRepository<TheatherModel>().GetAll();
        List<TheathersViewModel> vm = _mapper.Map<List<TheathersViewModel>>(theatherList);
        return vm;
      }
  }

  public class TheathersViewModel {
    public int Id {get; set; }
    public string? Name {get; set; }
    public string? Description {get; set; }
    public int AvailableSeats {get; set; }
    public string? Date {get; set; }
    public int? TheatherId {get; set; }
    public int Cost {get; set; }
  }
}