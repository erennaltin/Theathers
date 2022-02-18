using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.DBOperations;
using WebApi.DBOperations.TheatherOperations.GetTheathers;

namespace WebApi.Controllers {
  [ApiController]
  [Route("[controller]s")]
  public class TheatherController : ControllerBase {
    
    private readonly TheathersDbContext _context;

    public TheatherController (TheathersDbContext context) {
      _context = context;
    }


    [HttpGet]
    public IActionResult GetTheathers(){
      GetTheathersQuery query = new GetTheathersQuery(_context);
      var result = query.Handle();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public TheatherModel GetById(int id){
      var theather = _context.Theathers.SingleOrDefault(x => x.Id == id);
      return theather;
    }


    [HttpPost]
    public IActionResult AddTheather([FromBody] TheatherModel newTheater) {
      var theather = _context.Theathers.SingleOrDefault(x => x.Name == newTheater.Name);
      if (theather != null) {
        return BadRequest();
      }

      _context.Theathers.Add(newTheater);
      _context.SaveChanges();

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTheather(int id, [FromBody] TheatherModel newTheather) {
      var theather = _context.Theathers.SingleOrDefault(x => x.Id == id);
      if (theather == null) {
        return BadRequest();
      }

      theather.Name = newTheather.Name != default ? newTheather.Name : theather.Name;
      theather.Description = newTheather.Description != default ? newTheather.Description : theather.Description;
      theather.AvailableSeats = newTheather.AvailableSeats != default ? newTheather.AvailableSeats : theather.AvailableSeats;
      theather.Date = newTheather.Date != default ? newTheather.Date : theather.Date;
      theather.TheatherId = newTheather.TheatherId != default ? newTheather.TheatherId : theather.TheatherId;
      theather.Cost = newTheather.Cost != default ? newTheather.Cost : theather.Cost;
    
      _context.SaveChanges();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTheather(int id) {
      var theather = _context.Theathers.SingleOrDefault(x => x.Id == id);
      if (theather == null) {
        return BadRequest();
      }

      _context.Theathers.Remove(theather);
      _context.SaveChanges();
      return Ok();
    }
  }
}