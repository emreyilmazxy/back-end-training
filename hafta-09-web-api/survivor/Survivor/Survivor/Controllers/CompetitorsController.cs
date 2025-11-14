using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.OpenApi.Any;
using Survivor.Data;
using Survivor.Dto;
using Survivor.Models;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {

        private readonly SurvivorDbcontext _context;

        public CompetitorsController(SurvivorDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitorListDto>>> GetAll() // Get all competitors
        {
            var competitors = await _context.Competitors
                .Include(c => c.Category) // Eager Loading
                .Where(c => !c.IsDeleted)
                .Select(c => new CompetitorListDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CategoryName = c.Category.Name
                })
                .ToListAsync();

            if (competitors == null || competitors.Count == 0)
            {
                return NotFound("No competitors found.");
            }

            return Ok(competitors);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitorListDto>> GetById(int id) // Get competitor by id
        {
            var competitor = await _context.Competitors
                .Include(c => c.Category)
                .Where(c => c.Id == id && !c.IsDeleted)
                .Select(c => new CompetitorListDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CategoryName = c.Category.Name
                })
                .FirstOrDefaultAsync();

            if (competitor == null)
                return NotFound($"Competitor with ID {id} not found.");

            return Ok(competitor);
        }

        [HttpGet("categories/{CategoryId}/competitors")]
        public async Task<ActionResult<IEnumerable<CompetitorListDto>>> GetByCategoryId(int CategoryId) // Get competitors by category ID
        {
            var competitors = await _context.Competitors
        .Include(c => c.Category)
        .Where(c => c.CategoryId == CategoryId && !c.IsDeleted)
        .Select(c => new CompetitorListDto
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
            CategoryName = c.Category.Name
        })
        .ToListAsync();

            if (competitors == null || competitors.Count == 0)
            {
                return NotFound($"No competitors found for category ID {CategoryId}.");
            }

            return Ok(competitors);
        }
        [HttpPost]
        public async Task<ActionResult<CompetitorEntity>> CreateCompetitor(CreateCompetitorDto competitor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var  competitor2 = new CompetitorEntity
            {
                FirstName = competitor.FirstName,
                LastName = competitor.LastName,
                CategoryId = competitor.CategoryId,
                IsDeleted = false
            };


            _context.Competitors.Add(competitor2);

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = competitor2.Id }, competitor);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompetitor(int id, [FromBody] CreateCompetitorDto dto)
        {
            var existingCompetitor = await _context.Competitors.FindAsync(id);
            if (existingCompetitor == null)
                return NotFound($"Competitor with ID {id} not found.");

            // Kategori var mı kontrolü
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId && !c.IsDeleted);
            if (!categoryExists)
                return BadRequest($"Category with ID {dto.CategoryId} does not exist.");

            // Güncelleme işlemi
            existingCompetitor.FirstName = dto.FirstName;
            existingCompetitor.LastName = dto.LastName;
            existingCompetitor.CategoryId = dto.CategoryId;
            existingCompetitor.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(existingCompetitor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id) // Delete competitor by ID
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
                return NotFound($"Competitor with ID {id} not found.");

            competitor.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<IEnumerable<CompetitorEntity>>> patch(int id, JsonPatchDocument patch)
        { 
           var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
            {
                return NotFound($"Competitor with ID {id} not found.");
            }
            patch.ApplyTo(competitor);
            
            await _context.SaveChangesAsync();
            return Ok(competitor);

        }
            
            

}

}
