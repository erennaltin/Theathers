using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Repositories;
using WebApi.DBOperations.TokenOperations.Models;
using WebApi.DBOperations.UserOperations.CreateToken;
using WebApi.DBOperations.UserOperations.CreateUser;
using WebApi.DBOperations.UserOperations.RefreshToken;
using static WebApi.DBOperations.UserOperations.CreateUser.CreateUserCommand;

namespace WebApi.Controllers {

  [ApiController]
  [Route("[controller]s/[action]")]
  public class UserController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly UnitOfWork _uow;
    private readonly IConfiguration _configuration;

    public UserController(IConfiguration configuration, IMapper mapper, TheathersDbContext context)
    {
      _configuration = configuration;
      _mapper = mapper;
      _uow = new UnitOfWork(context);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_uow, _mapper);
            command.Model = newUser;
            command.Handle();

            return Ok();
        }

        [HttpPost()]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_uow, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();

            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_uow, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();

            return resultToken;
        }
  }
}