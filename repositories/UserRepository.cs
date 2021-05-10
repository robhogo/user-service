using RoBHo_UserService.Contexts;
using RoBHo_UserService.Models;
using System.Linq;

namespace RoBHo_UserService.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserServiceContext _context;

        public UserRepository(UserServiceContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByCredentials(string username)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username);
        }
    }
}
