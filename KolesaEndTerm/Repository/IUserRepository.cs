using System.Collections.Generic;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        User Add(User user);
        User Update(User user);
        User Delete(int id);
    }
}