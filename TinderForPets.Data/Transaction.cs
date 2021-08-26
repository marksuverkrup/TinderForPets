using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderForPets.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey(nameof(Dog))]
        public int? PetId { get; set; }
        public virtual Dog Dog { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(AnimalShelter))]
        public int? ShelterId { get; set; }
        public virtual AnimalShelter AnimalShelter { get; set; }

        [Required]
        public DateTimeOffset TimeAdded { get; set; }
    }
}
