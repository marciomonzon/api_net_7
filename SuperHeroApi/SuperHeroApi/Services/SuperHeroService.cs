using SuperHeroApi.Data;

namespace SuperHeroApi.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return await GetAllHeroes();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public SuperHero GetSingleHero(int id)
        {
            var hero = _context.SuperHeroes.First(x => x.Id == id);

            if (hero == null)
                return new SuperHero();

            return hero;  
        }

        public List<SuperHero> UpdateHero(int id, SuperHero request)
        {
            var hero = _context.SuperHeroes.First(x => x.Id == id);

            if (hero == null)
                return new List<SuperHero>();

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            _context.SuperHeroes.Update(hero);
            _context.SaveChanges();

            return GetAllHeroes();
        }

        public List<SuperHero> DeleteHero(int id)
        {
            var hero = _context.SuperHeroes.First(x => x.Id == id);
            if (hero is null)
                return new List<SuperHero>();

            _context.SuperHeroes.Remove(hero);
            _context.SaveChanges();
            return GetAllHeroes();
        }
    }
}
