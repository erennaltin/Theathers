using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Models;
using WebApi.DBOperations;
using WebApi.DBOperations.TheatherOperations.GetTheathers;
using WebApi.DBOperations.TheatherOperations.GetTheatherDetail;
using WebApi.DBOperations.TheatherOperations.CreateTheather;
using static WebApi.DBOperations.TheatherOperations.CreateTheather.CreateTheatherCommand;
using WebApi.DBOperations.TheatherOperations.UpdateTheather;
using static WebApi.DBOperations.TheatherOperations.UpdateTheather.UpdateTheatherCommand;
using WebApi.DBOperations.TheatherOperations.DeleteTheather;

namespace WebApi.Controllers {
  [ApiController]
  [Route("[controller]s")]
  public class TheatherController : ControllerBase {
    
    private readonly TheathersDbContext _context;
    private readonly IMapper _mapper;

    public TheatherController(TheathersDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }


    [HttpGet]
    public IActionResult GetTheathers(){
      GetTheathersQuery query = new GetTheathersQuery(_context, _mapper);
      var result = query.Handle();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id){
      GetTheatherDetailQuery query = new GetTheatherDetailQuery(_context, _mapper);
      query.TheatherId = id;
      try {
        TheatherDetailViewModel result = query.Handle();
        return Ok(result);
      }
      catch(Exception ex) {
        return BadRequest(ex.Message );
      }
    }


    [HttpPost]
    public IActionResult AddTheather([FromBody] CreateTheatherModel newTheater) {
      CreateTheatherCommand command = new CreateTheatherCommand(_context, _mapper);
      try {  
        command.Model = newTheater;
        command.Handle();   
      }
      catch(Exception e) {
        return BadRequest(e.Message);
      }
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTheather(int id, [FromBody] UpdateTheatherModel newTheather) {
      UpdateTheatherCommand command = new UpdateTheatherCommand(_context);
      command.Model = newTheather;
      command.TheatherId = id;
      try {
        command.Handle();
        return Ok();
      }
      catch(Exception ex) {
        return BadRequest(ex.Message); 
      }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTheather(int id) {
      DeleteTheatherCommand command = new DeleteTheatherCommand(_context);
      command.TheatherId = id;
      try {
        command.Handle();
        return Ok();
      }
      catch(Exception ex) {
        return BadRequest(ex.Message);
      }
    }
  }
}