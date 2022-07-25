using Microsoft.AspNetCore.Mvc;
namespace dotnetserver.Controllers


{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase     
    {


        // endpoint to return books 
        [HttpGet]
        public List<String> GetMyBooks()
        {

            var books = new List<String>
            {
                "book1","book2","book3","book4",
            };

            return books;
        }


        // endpoint to return superheros
        [HttpGet("supreHeros")]
        public ActionResult<List<SuperHeros>> GetMySuperHeros()
        {

            var heros = new List<SuperHeros>()
            {
                new SuperHeros(1, "john", "NYC"),
                new SuperHeros(2, "pole", "chicago"),

            };
            return Ok(heros);
        }

        // endpoint to return schools
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


        // endpoint to post  school
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

