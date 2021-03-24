using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RoBHo_UserService.Helpers;
using RoBHo_UserService.Models;
using RoBHo_UserService.repositories;

namespace RoBHo_UserService.Services
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _repository;

        public UserLogic(IUserRepository repository)
        {
            _repository = repository;
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
