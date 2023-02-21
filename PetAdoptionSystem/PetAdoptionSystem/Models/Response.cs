using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionSystem.Models
{
    class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Pet pet { get; set; }

        public User user { get; set; }
        public List<Pet> listPet { get; set; }

        public List<User> listUser { get; set; }
    }
}
