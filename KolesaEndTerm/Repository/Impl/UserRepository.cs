using System.Collections.Generic;
using KolesaEndTerm.Data;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private IUserRepository _userRepositoryImplementation;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            var c = _context.Users.Attach(user);
            c.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return null;
            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }
    }
}