using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderForPets.Models.Dog
{
    public class DogListItem
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int ShelterId { get; set; }
        public string Location { get; set; }
    }
}
