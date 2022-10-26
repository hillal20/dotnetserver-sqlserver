using Microsoft.AspNetCore.Mvc;
namespace dotnetserver.Controllers


{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase     
    {


        // we need to generate an instance of the repository
      private readonly   Repository repository;

        public BooksController(Repository repository)
        {
            this.repository = repository;
        }



        /////////////////////////////////////////////////////////////////////////////////////////////// endpoint to return books 
        [HttpGet]
        public List<String> GetMyBooks()
        {

            var books = new List<String>
            {
                "book1","book2","book3","book4",
            };

            return books;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////// endpoint to return superheros
        [HttpGet("supreHeros")]
        public async Task<ActionResult<List<SuperHeros>>> GetMySuperHeros()
        {

            var heros = new List<SuperHeros>()
            {
                new SuperHeros(1, "john", "NYC"),
                new SuperHeros(2, "pole", "chicago"),

            };

            // return Ok(heros);
            return Ok(await repository.superHeroses.ToArrayAsync());
        }

        ///////////////////////////////////////////////////////////////////////////////////////////// endpoint to return a single superhero
        [HttpGet("superHeros/{id}")]
        public async Task<ActionResult<SuperHeros>> GetSingleSuperHero(int id)
        {
            var hero = await repository.superHeroses.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("hero not found");

            }
            else return Ok(hero);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////// end point to add new superhero
        [HttpPost("addSuperHero")]
        public async Task<ActionResult<List<SuperHeros>>> AddSuperHero(SuperHeros hero)
        {

           repository.superHeroses.Add(hero);
            await repository.SaveChangesAsync();
           
            return Ok(await repository.superHeroses.ToListAsync());
        }


        /////////////////////////////////////////////////////////////////////////////////////////////// end point to add new superhero
        [HttpPost("updateSuperHero")]
        public async Task<ActionResult<List<SuperHeros>>> UpdateSuperHero(SuperHeros hero)
        {

           var dbHero = await  repository.superHeroses.FindAsync(hero.Id);
            if (dbHero == null) return BadRequest("hero can not be updated");

            dbHero.City = hero.City;

            await repository.SaveChangesAsync();

            return Ok(await repository.superHeroses.ToListAsync());
        }


        /////////////////////////////////////////////////////////////////////////////////////////////// enpoint to delete a hero
        [HttpPost("removeSuperHero/{id}")]
        public async Task<ActionResult<List<SuperHeros>>> RemoveSuperHero(int id)
        {

            var dbHero = await repository.superHeroses.FindAsync(id);
            if (dbHero == null) return BadRequest("hero can not be found");

            repository.Remove(dbHero);

            await repository.SaveChangesAsync();

            return Ok(await repository.superHeroses.ToListAsync());
        }

        /////////////////////////////////////////////////////////////////////////////////////////////  endpoint to return schools
        [HttpGet("schools")]
        public ActionResult<List<Schools>> GetMySchools()
        {

            var schools = new List<Schools>()
            {
                // this syntax is for initiating objects and setting the properties
                // via the setters and gettes 
                new Schools
                {
                    Name = "NYU",
                    Rating = 7
                },
                new Schools
                {
                    Name = "CIU",
                    Rating = 9
                }

            };
            return Ok(schools);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////// endpoint to post  school
        [HttpPost("schools")]
        public ActionResult<List<Schools>> PostSchool(Schools schools)
        {

            List<Schools> list  = new List<Schools>();
            list.Add(schools);
            // we could send a bad request
            // return BadRequest("this shool is wrong ")
            return Ok(list);
        }

    }

}

