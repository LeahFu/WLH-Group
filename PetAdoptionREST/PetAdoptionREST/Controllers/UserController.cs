using Microsoft.AspNetCore.Mvc;
using PetAdoptionREST.Models;
using System.Data.SqlClient;

namespace PetAdoptionREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IConfiguration _configuration;//
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public Response GetAllUsers()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("PetCon").ToString());
            Response response = new Response();
            UserApplication userApplication = new UserApplication();
            response = userApplication.GetAllUsers(con);
            return response;
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public Response GetUserById(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("PetCon").ToString());
            Response response = new Response();
            UserApplication userApplication = new UserApplication();
            response = userApplication.GetUserById(con, id);
            return response;
        }

        [HttpPost]
        [Route("AddUser")]
        public Response AddUser(User user)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("PetCon").ToString());
            Response response = new Response();
            UserApplication userApplication = new UserApplication();
            response = userApplication.AddUser(con, user);
            return response;
        }

        [HttpPut]
        [Route("UpdateUser")]
        public Response UpdateUser(User user)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("PetCon").ToString());
            Response response = new Response();
            UserApplication userApplication = new UserApplication();
            response = userApplication.UpdateUser(con, user);
            return response;
        }

        [HttpDelete]
        [Route("DeleteUserById/{id}")]
        public Response DeleteUserById(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("PetCon").ToString());
            Response response = new Response();
            UserApplication userApplication = new UserApplication();
            response = userApplication.DeleteUserById(con, id);
            return response;
        }
    }
}
