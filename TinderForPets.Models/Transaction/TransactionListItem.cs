﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderForPets.Models.Transaction
{
    public class TransactionListItem
    {
        public int TransactionId { get; set; }
        public int PetId { get; set; }
        //public int UserId { get; set; }
        public int ShelterId { get; set; }
        public DateTimeOffset TimeAdded { get; set; }
    }
}