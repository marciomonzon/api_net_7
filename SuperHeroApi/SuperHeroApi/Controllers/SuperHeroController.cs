using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Services;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHeroes()
        {
            var heroes = _superHeroService.GetAllHeroes();

            if(heroes.Count == 0)
                return NotFound("Sorry, No Heroes found!");

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var hero = _superHeroService.GetSingleHero(id);

            if (hero.Id == 0)
                return NotFound("Sorry, but this hero does not exist");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = _superHeroService.UpdateHero(id, request);

            if (result.Count == 0)
                return NotFound("Hero Not Found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);

            if (result.Count == 0)
                return NotFound("Hero Not Found");

            return Ok(result);
        }
    }
}
