using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinderForPets.Data;
using TinderForPets.Models.Transaction;

namespace TinderForPets.Services
{
    public class TransactionService
    {
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                    PetId = model.PetId,
                    Id = model.UserId,
                    ShelterId = model.ShelterId,
                    TimeAdded = DateTimeOffset.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transactions
                        .Select(
                            e =>
                                new TransactionListItem
                                {
                                    TransactionId = e.TransactionId,
                                    PetId = e.Dog.PetId,
                                    UserId = e.ApplicationUser.Id,
                                    ShelterId = e.AnimalShelter.ShelterId,
                                    TimeAdded = e.TimeAdded,
                                    Name = e.Dog.Name,
                                    Breed = e.Dog.Breed,
                                    Location = e.AnimalShelter.Location,
                                }
                       );
                return query.ToArray();
            }
        }

        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == id);
                return
                    new TransactionDetail
                    {
                        TransactionId = entity.TransactionId,
                        PetId = entity.Dog.PetId,
                        //UserId = entity.ApplicationUser.Id,
                        //ShelterId = entity.AnimalShelter.ShelterId,
                        TimeAdded = entity.TimeAdded,
                        Name = entity.Dog.Name,
                        Breed = entity.Dog.Breed,
                        Location = entity.AnimalShelter.Location,
                    };
            }
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == model.TransactionId);
                entity.PetId = model.PetId;
                //entity.Id = model.UserId;
                entity.ShelterId = model.ShelterId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == transactionId);
                ctx.Transactions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
