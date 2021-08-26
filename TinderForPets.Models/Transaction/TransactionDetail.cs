using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderForPets.Models.Transaction
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }
        public int PetId { get; set; }
        public string UserId { get; set; }
        public int ShelterId { get; set; }
        public DateTimeOffset TimeAdded { get; set; }

        public string Name { get; set; }
        public string Breed { get; set; }
        public string Location { get; set; }
    }
}
