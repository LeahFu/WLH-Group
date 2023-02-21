namespace PetAdoptionREST.Models
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userPwd { get; set; }
        public string userAddress { get; set; }
        public int userAge { get; set; }
        public string userEmail { get; set; }
        public int isAdmin { get; set; }
        
    }
}
