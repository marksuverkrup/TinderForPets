using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderForPets.Models.AnimalShelter
{
    public class AnimalShelterListItem
    {
        public int ShelterId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset TimeAdded { get; set; }

    }
}
