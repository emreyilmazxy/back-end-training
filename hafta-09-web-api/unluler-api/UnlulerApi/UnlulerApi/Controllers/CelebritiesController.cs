using Microsoft.AspNetCore.Mvc;
using UnlulerApi.Models;


namespace UnlulerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CelebritiesController : ControllerBase
    {
        private static List<Celebrity> celebrities = new List<Celebrity>
        {
            new Celebrity { Id = 1, Name = "Tarkan", Profession = "Pop Müzik Sanatçısı" },
            new Celebrity { Id = 2, Name = "Sıla", Profession = "Pop Müzik Sanatçısı" },
            new Celebrity { Id = 3, Name = "Kenan İmirzalioğlu", Profession = "Oyuncu" },
            new Celebrity { Id = 4, Name = "Bergüzar Korel", Profession = "Oyuncu" }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Celebrity>> Get()
        {
            return Ok(celebrities);
        }
        [HttpGet("{id}")]
        public ActionResult<Celebrity> Get(int id)
        {
            var celebrity = celebrities.FirstOrDefault(c => c.Id == id);
            if (celebrity == null)
            {
                return NotFound(new { Message = "Kişi bulunamadı." });
            }
            return Ok(celebrity);
        }
        [HttpPost]
        public ActionResult<Celebrity> Post([FromBody] Celebrity celebrity)
        {
            celebrity.Id = celebrities.Max(c => c.Id) + 1; // Yeni ID atama
            celebrities.Add(celebrity);
            return CreatedAtAction(nameof(Get), new { id = celebrity.Id }, celebrity);

        }
        // PUT: api/celebrities/5
        [HttpPut("{id}")]
        public ActionResult<Celebrity> Put(int id, [FromBody] Celebrity celebrity)
        {
            var existingCelebrity = celebrities.FirstOrDefault(c => c.Id == id);
            if (existingCelebrity == null)
            {
                return NotFound(new { Message = "Kişi bulunamadı." });
            }
            existingCelebrity.Name = celebrity.Name;
            existingCelebrity.Profession = celebrity.Profession;
            return NoContent();
        }

        // DELETE: api/celebrities/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var celebrity = celebrities.FirstOrDefault(c => c.Id == id);
            if (celebrity == null)
            {
                return NotFound(new { Message = "Kişi bulunamadı." });
            }
            celebrities.Remove(celebrity);
            return NoContent();
        }
    }
}
