using Microsoft.AspNetCore.Mvc;
using PetAdoptionREST.Models;
using System.Data.SqlClient;

namespace PetAdoptionREST.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PetController : ControllerBase
        {
            private readonly IConfiguration _configuraion; //receive and request the connection state with sql server
            public PetController(IConfiguration configuration)
            {
                _configuraion = configuration;
            }
            //To read the data from the Server petTable
            [HttpGet]
            [Route("GetAllPet")]
            public Response GetAllPet()
            {
                SqlConnection con = new SqlConnection(_configuraion.GetConnectionString("PetCon").ToString());
                Response response = new Response();
                PetApplications api = new PetApplications();
                response = api.GetAllPet(con);
                return response;
            }

            [HttpGet]
            [Route("GetAllPetById/{id}")]
            public Response GetAllProductById(int id)
            {
                SqlConnection con = new SqlConnection(_configuraion.GetConnectionString("PetCon").ToString());
                Response response = new Response();
                PetApplications api = new PetApplications();
                response = api.GetAllPetById(con, id);
                return response;
            }

            //To Insert Data in my petTable
            [HttpPost]
            [Route("AddPet")]
            public Response AddPet(Pet pet)
            {
                SqlConnection con = new SqlConnection(_configuraion.GetConnectionString("PetCon").ToString());
                Response response = new Response();
                PetApplications api = new PetApplications();
                response = api.AddPet(con, pet);
                return response;
            }

            [HttpPut]
            [Route("UpdatePet")]
            public Response UpdatePet(Pet pet)
            {
                SqlConnection con = new SqlConnection(_configuraion.GetConnectionString("PetCon").ToString());
                Response response = new Response();
                PetApplications api = new PetApplications();
                response = api.UpdatePet(con, pet);
                return response;
            }

            [HttpDelete]
            [Route("DeletePetById/{id}")]
            public Response DeletePet(int id)
            {
                SqlConnection con = new SqlConnection(_configuraion.GetConnectionString("PetCon").ToString());
                Response response = new Response();
                PetApplications api = new PetApplications();
                response = api.DeletePet(con, id);
                return response;
            }
        }
}
