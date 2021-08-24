using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderForPets.Models.AnimalShelter
{
    public class AnimalShelterDetail
    {
        public int ShelterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset TimeAdded { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? TimeModified { get; set; }
    }
}
