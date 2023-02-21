using System.Collections.Generic;

namespace PetAdoptionREST.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Pet pet { get; set; }

        public User user { get; set; }
        public List<Pet> listPet { get; set; }

        public List<User> listUser { get; set; }
    }
}

