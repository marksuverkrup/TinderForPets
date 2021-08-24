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
                    //UserId = model.UserId,
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
                                    PetId = e.PetId,
                                    //UserId = e.UserId,
                                    ShelterId = e.ShelterId,
                                    TimeAdded = e.TimeAdded,
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
                        PetId = entity.PetId,
                        //UserId = e.UserId,
                        ShelterId = entity.ShelterId,
                        TimeAdded = entity.TimeAdded
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
                //entity.UserId = model.UserId;
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
