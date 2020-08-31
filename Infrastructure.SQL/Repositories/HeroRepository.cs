using System.Collections.Generic;
using System.Linq;
using Heroes.Core.DomainService;
using Heroes.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly DatabaseContext _dbContext;

        public HeroRepository(DatabaseContext context)
        {
            _dbContext = context;
        }

        public Hero CreateHero(Hero createdHero)
        {
            _dbContext.Attach(createdHero).State = EntityState.Added;
            _dbContext.SaveChanges();
            return createdHero;
        }

        public List<Hero> GetAllHeroes()
        {
            return _dbContext.Heroes.ToList();
        }

        public Hero GetHeroById(int id)
        {
            return _dbContext.Heroes.FirstOrDefault(h => h.Id == id);
        }

        public Hero UpdateHero(Hero updatedHero)
        {
            _dbContext.Attach(updatedHero).State = EntityState.Modified;
            _dbContext.Update(updatedHero);
            _dbContext.SaveChanges();
            return updatedHero;
        }

        public Hero DeleteHero(int id)
        {
            var heroToDelete = _dbContext.Remove(new Hero {Id = id}).Entity;
            _dbContext.SaveChanges();
            return heroToDelete;
        }
    }
}