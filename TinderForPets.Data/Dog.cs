using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderForPets.Data
{
    public class Dog
    {
        [Key]
        public int PetId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string HairType { get; set; }
        [Required]
        public int Age { get; set; }
        
        [ForeignKey(nameof(AnimalShelter))]
        public int ShelterId { get; set; }
        public virtual AnimalShelter AnimalShelter { get; set; }

    }
}
