using AutoMapper;
using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.DBOperations.UserOperations.CreateUser
{

    public class CreateUserCommand
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        public CreateUserModel Model { get; set; }
        public CreateUserCommand(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Handle()
        {
            var userRepo = _uow.GetRepository<User>();
            var user = userRepo.GetFirst(x => x.Email == Model.Email);

            if (user is not null)
            {
                throw new InvalidOperationException("Eklenecek kullanıcı zaten mevcut");
            }
            user = _mapper.Map<User>(Model); 

            userRepo.Insert(user);
        }

        public class CreateUserModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}