using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinderForPets.Data;
using TinderForPets.Models.AnimalShelter;

namespace TinderForPets.Services
{
    public class AnimalShelterService
    {
        //private readonly Guid _userId;
        //public AnimalShelterService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateAnimalShelter(AnimalShelterCreate model)
        {
            var entity =
                new AnimalShelter()
                {
                    //OwnerId = _userId,
                    Name = model.Name,
                    Description = model.Description,
                    Location = model.Location,
                    Capacity = model.Capacity,
                    TimeAdded = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.AnimalShelters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AnimalShelterListItem> GetAnimalShelters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .AnimalShelters
                        //.Where(e => e.ShelterId == ShelterId)
                        .Select(
                            e =>
                                new AnimalShelterListItem
                                {
                                    ShelterId = e.ShelterId,
                                    Name = e.Name,
                                    Location = e.Location,
                                    TimeAdded = e.TimeAdded
                                }
                       );
                return query.ToArray();
            }
        }

        public AnimalShelterDetail GetAnimalShelterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AnimalShelters
                        .Single(e => e.ShelterId == id /*&& e.OwnerId == _userId*/);
                return
                    new AnimalShelterDetail
                    {
                        ShelterId = entity.ShelterId,
                        Name = entity.Name,
                        Description = entity.Description,
                        Location = entity.Location,
                        Capacity = entity.Capacity,
                        TimeAdded = entity.TimeAdded,
                        TimeModified = entity.TimeModified
                    };
            }
        }

        public bool UpdateAnimalShelter(AnimalShelterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AnimalShelters
                        .Single(e => e.ShelterId == model.ShelterId /*&& e.OwnerId == _userId*/);
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Location = model.Location;
                entity.Capacity = model.Capacity;
                entity.TimeModified = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAnimalShelter(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AnimalShelters
                        .Single(e => e.ShelterId == noteId /*&& e.OwnerId == _userId*/);
                ctx.AnimalShelters.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
