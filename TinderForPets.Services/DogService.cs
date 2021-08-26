using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinderForPets.Data;
using TinderForPets.Models.Dog;

namespace TinderForPets.Services
{
    public class DogService
    {
        public bool CreateDog(DogCreate model)
        {
            var entity =
                new Dog()
                {
                    Name = model.Name,
                    Breed = model.Breed,
                    HairType = model.HairType,
                    Age = model.Age,
                    ShelterId = model.ShelterId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dogs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DogListItem> GetDogs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Dogs
                        .Select(
                            e =>
                                new DogListItem
                                {
                                    PetId = e.PetId,
                                    Name = e.Name,
                                    ShelterId = e.AnimalShelter.ShelterId,
                                    Location = e.AnimalShelter.Location,
                                }
                       );
                return query.ToArray();
            }
        }

        public DogDetail GetDogById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.PetId == id);
                return
                    new DogDetail
                    {
                        PetId = entity.PetId,
                        Name = entity.Name,
                        Location = entity.AnimalShelter.Location,
                        Breed = entity.Breed,
                        HairType = entity.HairType,
                        Age = entity.Age,
                        ShelterId = entity.AnimalShelter.ShelterId
                    };
            }
        }

        public bool UpdateDog(DogEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.PetId == model.PetId);
                entity.Name = model.Name;
                entity.Breed = model.Breed;
                entity.HairType = model.HairType;
                entity.Age = model.Age;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDog(int dogId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.PetId == dogId);
                ctx.Dogs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
