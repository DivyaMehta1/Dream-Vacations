using BusinessLayer.Models;
using BusinessLayer.Services;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;


namespace DreamVacations_CampBookingSite.Controllers
{

    [RoutePrefix("Api/user")]
    public class UsersController : ApiController
    {
        private readonly UserServices userServices;
        public UsersController()
        {
            userServices = new UserServices();
        }

        /// <summary>
        /// Get UserDetails with UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsers/{id}")]
        [ResponseType(typeof(UsersDTO))]
        public IHttpActionResult GetUser(Guid id)
        {
            UsersDTO users = userServices.GetUser(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        /// <summary>
        /// Adds a New User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("NewUser")]
        public IHttpActionResult PostUsers(UsersDTO user)
        {
            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (userServices.AddUser(user))
            {
                return Ok(user);
            }
            else
            {
                return StatusCode(HttpStatusCode.NotModified);
            }
        }

    }
}