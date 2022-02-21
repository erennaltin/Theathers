using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.DBOperations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;

namespace WebApi.DBOperations.TheatherOperations.GetTheatherDetail {
  public class GetTheatherDetailQuery {
    private readonly TheathersDbContext _context;
    private readonly IMapper _mapper;
    public int TheatherId { get; set;}

    public GetTheatherDetailQuery(TheathersDbContext context, IMapper mapper) {
      _context = context;
      _mapper = mapper;
    }

    public TheatherDetailViewModel Handle()
    {
      var theather = _context.Theathers.SingleOrDefault(x => x.Id == TheatherId);
      if (theather == null)
        throw new InvalidOperationException("Oyun Bulunamadı.");
      TheatherDetailViewModel vm = _mapper.Map<TheatherDetailViewModel>(theather);
      return vm;
    }
  }

  public class TheatherDetailViewModel {
    public string? Name {get; set; }
    public string? Description {get; set; }
    public int AvailableSeats {get; set; }
    public string  Date {get; set; }
    public int? TheatherId {get; set; }
    public int Cost {get; set; }
  }
}