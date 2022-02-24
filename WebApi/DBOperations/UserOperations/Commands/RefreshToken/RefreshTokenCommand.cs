using WebApi.Models.Entities;
using WebApi.Repositories;
using WebApi.DBOperations.TokenOperations;
using WebApi.DBOperations.TokenOperations.Models;

namespace WebApi.DBOperations.UserOperations.RefreshToken
{

    public class RefreshTokenCommand
    {
        private readonly IConfiguration _configuration;
        private readonly UnitOfWork _uow;
        public string RefreshToken { get; set; }
        public RefreshTokenCommand(UnitOfWork uow, IConfiguration configuration)
        {
            _uow = uow;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var userRepo = _uow.GetRepository<User>();
            var user = userRepo.GetFirst(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
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
                throw new InvalidOperationException("Valid bir refresh token bulunamadı!");
            }
        }

    }
}