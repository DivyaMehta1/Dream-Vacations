using SharedProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Repository
{
    public class UserRepository
    {
        private readonly MyContext _context;
        public UserRepository()
        {
            _context = new MyContext();
        }
        public int CreateUser(Users user)
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
        public Users GetUser(Guid userid)
        {
            var user = _context.Users.FirstOrDefault(users => users.Id == userid);
            return user;
        }

        public bool ValidateUser(string username, string userPassword)
        {

            var resultSet = _context.Users.FirstOrDefault(a => a.Username == username && a.Password == userPassword);
            if (resultSet == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool isAdmin(Guid id)
        { 
        var user =_context.Users.FirstOrDefault(users=>users.Id==id);
            return user.IsAdmin ? true : false;
            
        }




    }
}