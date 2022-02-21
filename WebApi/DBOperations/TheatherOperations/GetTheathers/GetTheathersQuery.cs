using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.DBOperations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;


namespace WebApi.DBOperations.TheatherOperations.GetTheathers {
  public class GetTheathersQuery {
      private readonly TheathersDbContext _context;
      private readonly IMapper _mapper;
    public GetTheathersQuery(TheathersDbContext dBContext, IMapper mapper)
    {
      _context = dBContext;
      _mapper = mapper;
    }

    public List<TheathersViewModel> Handle(){
        var theatherList = _context.Theathers.OrderBy(x => x.Id).ToList<TheatherModel>();
        List<TheathersViewModel> vm = _mapper.Map<List<TheathersViewModel>>(theatherList);
        return vm;
      }
  }

  public class TheathersViewModel {
    public int Id {get; set; }
    public string? Name {get; set; }
    public string? Description {get; set; }
    public int AvailableSeats {get; set; }
    public string Date {get; set; }
    public int? TheatherId {get; set; }
    public int Cost {get; set; }
  }
}