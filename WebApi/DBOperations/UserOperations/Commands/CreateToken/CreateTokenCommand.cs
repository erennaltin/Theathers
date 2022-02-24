using AutoMapper;
using WebApi.Models.Entities;
using WebApi.Repositories;
using WebApi.DBOperations.TokenOperations;
using WebApi.DBOperations.TokenOperations.Models;

namespace WebApi.DBOperations.UserOperations.CreateToken
{

    public class CreateTokenCommand
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UnitOfWork _uow;
        public CreateTokenModel Model { get; set; }
        public CreateTokenCommand(UnitOfWork uow, IMapper mapper, IConfiguration configuration)
        {
            _uow = uow;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var userRepo = _uow.GetRepository<User>();
            var user = userRepo.GetFirst(x => x.Email == Model.Email && x.Password == Model.Password);

            if (user is not null)
            {
                //token yarat
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

                userRepo.Update(user);
                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı Adı veya Şifre Hatalı!");
            }
        }

    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}