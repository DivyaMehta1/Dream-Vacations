using DataAccessLayer.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserRepository
    {
        private readonly MyContext _context;
        public UserRepository()
        {
            _context = new MyContext();
        }
        /// <summary>
        /// Adds a New User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int CreateUser(Admins user)
        {
            var existingUser = _context.Users.FirstOrDefault(users => users.Username.ToUpper() == user.Username.ToUpper());
            if (existingUser != null)
            {
                return 0;
            }
            else
            {
                _context.Users.Add(user);
                var result = _context.SaveChanges();
                return result;
            }
        }
        /// <summary>
        /// Get AdminDetails with UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admins GetUser(Guid id)
        {
            var user = _context.Users.FirstOrDefault(users => users.Id == id);
            return user;
        }
        /// <summary>
        /// Validate a User with given Id & Password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public async Task<Admins> ValidateUser(string username, string userPassword)
        {

            var resultSet = _context.Users.FirstOrDefault(a => a.Username == username && a.Password == userPassword);
            if (resultSet == null)
            {
                await Task.CompletedTask;
                return resultSet;
            }
            else
            {
                return resultSet;
            }
        }
       




    }
}