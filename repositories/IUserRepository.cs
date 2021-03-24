using RoBHo_UserService.Models;

namespace RoBHo_UserService.repositories
{
    public interface IUserRepository
    {
        User GetUserByCredentials(string username, string password);
        bool AddUser(User user);
        User GetById(int id);
    }
}
