using System.Data;
using System.Data.SqlClient;

namespace PetAdoptionREST.Models
{
    public class UserApplication
    {
        public Response GetAllUsers(SqlConnection con)
        {
            Response response = new Response();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from UserTable", con);
            DataTable dataTable = new DataTable();
            List<User> userList = new List<User>();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    User user = new User();
                    user.userId= (int)dataTable.Rows[i]["userId"];
                    user.userName= (string)dataTable.Rows[i]["userName"];
                    user.userPwd= (string)dataTable.Rows[i]["userPwd"];
                    user.userAddress= (string)dataTable.Rows[i]["userAddress"];
                    user.userAge= (int)dataTable.Rows[i]["userAge"];
                    user.userEmail= (string)dataTable.Rows[i]["userEmail"];
                    user.isAdmin= (int)dataTable.Rows[i]["isAdmin"];
                    userList.Add(user);
                }
            }
            if (userList.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "OK";
                response.listUser = userList;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No user found";
                response.listUser = null;
            }
            return response;
        }

        public Response AddUser(SqlConnection con, User user)
        {
            Response response = new Response();
            string Query = "Insert into UserTable(userId,userName,userPwd,userAddress,userAge,userEmail,isAdmin) values(@userId,@userName,@userPwd,@userAddress,@userAge,@userEmail,@isAdmin)";
            SqlCommand cmd = new SqlCommand(Query, con);
            //SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //DataTable dataTable = new DataTable();
            cmd.Parameters.AddWithValue("@userId", user.userId);
            cmd.Parameters.AddWithValue("@userName", user.userName);
            cmd.Parameters.AddWithValue("@userPwd", user.userPwd);
            cmd.Parameters.AddWithValue("@userAddress", user.userAddress);
            cmd.Parameters.AddWithValue("@userAge", user.userAge);
            cmd.Parameters.AddWithValue("@userEmail", user.userEmail);
            cmd.Parameters.AddWithValue("@isAdmin", user.isAdmin);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Insert Properly";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data Inserted";
            }

            return response;
        }

        public Response GetUserById(SqlConnection con, int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from UserTable Where userId = '" + id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                User user= new User();
                user.userId= (int)dt.Rows[0]["userId"];
                user.userName = (string)dt.Rows[0]["userName"];
                user.userPwd = (string)dt.Rows[0]["userPwd"];
                user.userAddress = (string)dt.Rows[0]["userAddress"];
                user.userAge = (int)dt.Rows[0]["userAge"];
                user.userEmail = (string)dt.Rows[0]["userEmail"];
                user.isAdmin=(int)dt.Rows[0]["isAdmin"];


                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.user = user;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.user = null;
            }
            return response;
        }

        public Response UpdateUser(SqlConnection con, User user)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update UserTable set userName='" + user.userName + "', " +
                "userPwd='" + user.userPwd +
                "', userAddress='" + user.userAddress +
                "', userAge='" + user.userAge +
                "', userEmail='" + user.userEmail +
                "', isAdmin='" + user.isAdmin +
                "' Where userId='" + user.userId + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User updated";
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data updated";

            }
            return response;
        }

        public Response DeleteUserById(SqlConnection con, int Id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from UserTable where userId='" + Id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User Deleted";
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Deleted";

            }
            return response;
        }
    }
}
