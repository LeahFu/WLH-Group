namespace PetAdoptionREST.Models
{
    public class Pet
    {
        public int petId { get; set; }
        public string petName { get; set; }
        public int petAge { get; set; }
        public string petGender { get; set; }
        public string petClass { get; set; }
        public int isAdoption { get; set; }
    }
}
