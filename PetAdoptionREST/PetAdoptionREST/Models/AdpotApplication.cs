using System.Data.SqlClient;
using System.Data;

namespace PetAdoptionREST.Models
{
    public class AdpotApplication
    {
        public Response GetAllPet(SqlConnection con)
        {
            Response response = new Response();
            string Query = "Select * from petTable";
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Pet> listPet = new List<Pet>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Pet pet = new Pet();//Creating the class Object
                    pet.petId = (int)dt.Rows[i]["petId"];
                    pet.petName = (string)dt.Rows[i]["petName"];
                    pet.petAge = (int)dt.Rows[i]["petAge"];
                    pet.petGender = (string)dt.Rows[i]["petGender"];
                    pet.petClass = (string)dt.Rows[i]["petClass"];
                    pet.isAdoption = (int)dt.Rows[i]["isAdoption"]; ;

                    listPet.Add(pet);
                }
            }
            if (listPet.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Pet Retrieved Perfectly";
                response.listPet = listPet;
            }
            else //Only works if your data table is Empty or your connention fails
            {
                response.StatusCode = 100;
                response.StatusMessage = "No pet Found";
                response.listPet = null;
            }
            return response;
        }

        public Response GetAllPetById(SqlConnection con, int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from petTable Where petId = '" + id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Pet pet = new Pet();
                pet.petId = (int)dt.Rows[0]["petId"];
                pet.petName = (string)dt.Rows[0]["petName"];
                pet.petAge = (int)dt.Rows[0]["petAge"];
                pet.petGender = (string)dt.Rows[0]["petGender"];
                pet.petClass = (string)dt.Rows[0]["petClass"];
                pet.isAdoption = (int)dt.Rows[0]["isAdoption"];
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.pet = pet;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listPet = null;
            }
            return response;
        }

        public Response AdoptPet(SqlConnection con, Pet pet)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand
            ("Update petTable set isAdpotion = 1 where petName='" + pet.petName + "', petAge='" + pet.petAge + "', petGender='" + pet.petGender
            + "', petClass='" + pet.petClass + "', isAdoption='" + pet.isAdoption
            + "' Where petId='" + pet.petId + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Pet Added";
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";
            }
            return response;
        }

    }
}
