using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionSystem.Models
{
    class Pet
    {
        public int petId { get; set; }
        public string petName { get; set; }
        public int petAge { get; set; }
        public string petGender { get; set; }
        public string petClass { get; set; }
        public int isAdoption { get; set; }
    }
}
