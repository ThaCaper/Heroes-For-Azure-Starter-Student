using System.Collections.Generic;
using System.Linq;
using Heroes.Core.DomainService;
using Heroes.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Repositories
{
    public class PetRepository : IPetRepository
    {

        private readonly DatabaseContext _context;

        public PetRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Pet CreatePet(Pet createdPet)
        {
            _context.Attach(createdPet).State = EntityState.Added;
            _context.SaveChanges();
            return createdPet;
        }

        public Pet DeletePet(int id)
        {
            var coverToRemove = _context.Remove(new Pet { Id = id }).Entity;
            _context.SaveChanges();
            return coverToRemove;
        }

        public List<Pet> GetAllPet()
        {
            return _context.Pets.ToList();
        }

        public Pet GetPetById(int id)
        {
            return _context.Pets.FirstOrDefault(c => c.Id == id);
        }

        public Pet UpdatePet(Pet updatedPet)
        {
            _context.Attach(updatedPet).State = EntityState.Modified;
            _context.Update(updatedPet);
            _context.SaveChanges();
            return updatedPet;
        }
    }
}