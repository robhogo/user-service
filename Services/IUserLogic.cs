using RoBHo_UserService.Models;
using RoBHo_UserService.Request;

namespace RoBHo_UserService.Services
{
    public interface IUserLogic
    {
        User GetById(int id);
    }
}
