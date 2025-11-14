using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrazyMusicians.Models;
using Microsoft.AspNetCore.JsonPatch;




namespace CrazyMusicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrazyMusiciansController : ControllerBase
    {
        public static List<CrazyMusician> musicians = new List<CrazyMusician>
{
    new CrazyMusician { Id = 1, Name = "Ahmet Çalgı", Profession = "Ünlü Çalgı Çalar", FunTrait = "Her zaman yanlış nota çalar, ama çok eğlenceli" },
    new CrazyMusician { Id = 2, Name = "Zeynep Melodi", Profession = "Popüler Melodi Yazarı", FunTrait = "Şarkıları yanlış anlaşılır ama çok popüler" },
    new CrazyMusician { Id = 3, Name = "Cemil Akor", Profession = "Çılgın Akorist", FunTrait = "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli" },
    new CrazyMusician { Id = 4, Name = "Fatma Nota", Profession = "Sürpriz Nota Üreticisi", FunTrait = "Nota üretirken sürekli sürprizler hazırlar" },
    new CrazyMusician { Id = 5, Name = "Hasan Ritim", Profession = "Ritim Canavarı", FunTrait = "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir" },
    new CrazyMusician { Id = 6, Name = "Elif Armoni", Profession = "Armoni Ustası", FunTrait = "Armonilerini bazen yanlış çalar, ama çok yaratıcıdır" },
    new CrazyMusician { Id = 7, Name = "Ali Perde", Profession = "Perde Uygulayıcı", FunTrait = "Her perdeyi farklı şekilde çalar, her zaman sürprizlidir" },
    new CrazyMusician { Id = 8, Name = "Ayşe Rezonans", Profession = "Rezonans Uzmanı", FunTrait = "Rezonans konusunda uzman, ama bazen çok gürültü çıkarır" },
    new CrazyMusician { Id = 9, Name = "Murat Ton", Profession = "Tonlama Meraklısı", FunTrait = "Tonlamalarındaki farklılıklar bazen komik, ama oldukça ilginç" },
    new CrazyMusician { Id = 10, Name = "Selin Akor", Profession = "Akor Sihirbazı", FunTrait = "Akorları değiştirdiğinde bazen sihirli bir hava yaratır" }
};

        [HttpGet]
        public ActionResult<IEnumerable<CrazyMusician>> Get()
        {

            return Ok(musicians);
        }

        [HttpGet("{id}")]
        public ActionResult<CrazyMusician> GetById(int id)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound();
            }
            return Ok(musician);
        }

        [HttpPost]
        public ActionResult<CrazyMusician> Post([FromBody] CrazyMusician musician)
        {
            new CrazyMusician
            {
                Id = musicians.Count + 1,
                Name = musician.Name,
                Profession = musician.Profession,
                FunTrait = musician.FunTrait
            };
            musicians.Add(musician);
            return CreatedAtAction(nameof(GetById), new { id = musician.Id }, musician);
        }

        [HttpPut("{id}")]
        public ActionResult<CrazyMusician> Put(int id, [FromBody] CrazyMusician musician)
        {
            var existingMusician = musicians.FirstOrDefault(m => m.Id == id);
            if (existingMusician == null)
            {
                return NotFound();
            }
            existingMusician.Name = musician.Name;
            existingMusician.Profession = musician.Profession;
            existingMusician.FunTrait = musician.FunTrait;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound();
            }
            musicians.Remove(musician);
            return NoContent();
        }
        [HttpGet("Search")]
        public ActionResult<IEnumerable<CrazyMusician>> Search([FromQuery] string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return BadRequest("yanlış bir girdi girildi");
            }
            var results = musicians.Where(m => m.Name.Contains(Name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!results.Any())
            {
                return NotFound("bulunamadı");
            }
            return Ok(results);

        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<CrazyMusician> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
                return NotFound();

            patchDoc.ApplyTo(musician);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();

        }
    }
}