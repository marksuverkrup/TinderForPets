using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderForPets.Data
{
    public class AnimalShelter
    {
        [Key]
        public int ShelterId { get; set; }
        //[Required]
        //public Guid AnimalOwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public DateTimeOffset TimeAdded { get; set; }
        public DateTimeOffset? TimeModified { get; set; }

    }
}
