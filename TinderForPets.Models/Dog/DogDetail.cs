using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderForPets.Models.Dog
{
    public class DogDetail
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string HairType { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public int ShelterId { get; set; }
    }
}
