using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Models;
using WebApi.DBOperations;
using WebApi.DBOperations.TheatherOperations.Queries.GetTheathers;
using WebApi.DBOperations.TheatherOperations.Queries.GetTheatherDetail;
using WebApi.DBOperations.TheatherOperations.Commands.CreateTheather;
using static WebApi.DBOperations.TheatherOperations.Commands.CreateTheather.CreateTheatherCommand;
using WebApi.DBOperations.TheatherOperations.Commands.UpdateTheather;
using static WebApi.DBOperations.TheatherOperations.Commands.UpdateTheather.UpdateTheatherCommand;
using WebApi.DBOperations.TheatherOperations.Commands.DeleteTheather;
using FluentValidation;

namespace WebApi.Controllers {
  [ApiController]
  [Route("[controller]s/[action]")]
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
      GetTheatherDetailQueryValidator validator = new GetTheatherDetailQueryValidator();
      validator.ValidateAndThrow(query);
      TheatherDetailViewModel result = query.Handle();
      return Ok(result);
    }


    [HttpPost]
    public IActionResult AddTheather([FromBody] CreateTheatherModel newTheater) {
      CreateTheatherCommand command = new CreateTheatherCommand(_context, _mapper);
      command.Model = newTheater;
      CreateTheatherCommandValidator validator = new CreateTheatherCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();   

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTheather(int id, [FromBody] UpdateTheatherModel newTheather) {
      UpdateTheatherCommand command = new UpdateTheatherCommand(_context);

      command.Model = newTheather;
      command.TheatherId = id;
      UpdateTheatherCommandValidator validator = new UpdateTheatherCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTheather(int id) {
      DeleteTheatherCommand command = new DeleteTheatherCommand(_context);
      command.TheatherId = id;
      DeleteTheatherCommandValidator validator = new DeleteTheatherCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();
      return Ok();
      
    }
  }
}