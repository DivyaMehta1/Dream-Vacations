using BusinessLayer.Mappers;
using BusinessLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserServices
    {
        private readonly UserRepository userRepository;
        public UserServices()
        {
            userRepository = new UserRepository();
        }
        /// <summary>
        /// Adds a New User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(UsersDTO user)
        {
     
            Admins userToAdd = new Admins();
            userToAdd.Username = user.Username;
            userToAdd.Password = user.Password;
            var result = userRepository.CreateUser(userToAdd);
            return result > 0;
        }
        public async Task<Admins> ValidateUser(string username, string userPassword)
        {
            return await userRepository.ValidateUser(username, userPassword);
        }

        /// <summary>
        /// Get UserDetails with UserId
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public UsersDTO GetUser(Guid userid)
        {
            Mapper mapper = new Mapper();
            return mapper.MapToDTO(userRepository.GetUser(userid));
            
        }
    }
}