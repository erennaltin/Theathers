using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers {
  [ApiController]
  [Route("[controller]s")]
  public class TheatherController : ControllerBase {
    private static List<TheatherModel> _theathers = new List<TheatherModel>(){
      new TheatherModel {
        Id= 1,
        Name= "Bir Baba Hamlet",
        Description= "DENEME",
        AvailableSeats= 64,
        Date= new DateTime(2022,02,18),
        TheatherId= 1, // Baba Sahne
        Cost= 90, 
      },
      new TheatherModel {
        Id= 2,
        Name= "Donkişot'um Ben",
        Description= "DENEME",
        AvailableSeats= 64,
        Date= new DateTime(2022,02,19),
        TheatherId= 1, // Baba Sahne
        Cost= 90,
      },
      new TheatherModel {
        Id= 3,
        Name= "İki kişilik hırgür",
        Description= "DENEME",
        AvailableSeats= 256,
        Date= new DateTime(2022,04,15),
        TheatherId= 2, // Fişekhane
        Cost= 150,
      }
    };


    [HttpGet]
    public List<TheatherModel> GetTheathers(){
      var theatherList = _theathers.OrderBy(x => x.Id).ToList<TheatherModel>();
      return theatherList;
    }

    [HttpGet("{id}")]
    public TheatherModel GetById(int id){
      var theather = _theathers.SingleOrDefault(x => x.Id == id);
      return theather;
    }


    [HttpPost]
    public IActionResult AddTheather([FromBody] TheatherModel newTheater) {
      var theather = _theathers.SingleOrDefault(x => x.Name == newTheater.Name);
      if (theather != null) {
        return BadRequest();
      }

      _theathers.Add(newTheater);
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTheather(int id, [FromBody] TheatherModel newTheather) {
      var theather = _theathers.SingleOrDefault(x => x.Id == id);
      if (theather == null) {
        return BadRequest();
      }

      theather.Name = newTheather.Name != default ? newTheather.Name : theather.Name;
      theather.Description = newTheather.Description != default ? newTheather.Description : theather.Description;
      theather.AvailableSeats = newTheather.AvailableSeats != default ? newTheather.AvailableSeats : theather.AvailableSeats;
      theather.Date = newTheather.Date != default ? newTheather.Date : theather.Date;
      theather.TheatherId = newTheather.TheatherId != default ? newTheather.TheatherId : theather.TheatherId;
      theather.Cost = newTheather.Cost != default ? newTheather.Cost : theather.Cost;
    
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTheather(int id) {
      var theather = _theathers.SingleOrDefault(x => x.Id == id);
      if (theather == null) {
        return BadRequest();
      }

      _theathers.Remove(theather);
      return Ok();
    }
  }
}