namespace SuperHeroApi.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero> GetSingleHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>> UpdateHero(int id, SuperHero hero);
        Task<List<SuperHero>> DeleteHero(int id);
    }
}
