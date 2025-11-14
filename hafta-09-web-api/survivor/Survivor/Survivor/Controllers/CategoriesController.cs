using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survivor.Data;
using Survivor.Dto;
using Survivor.Models;
using System.ComponentModel;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        public readonly SurvivorDbcontext _context;

        public CategoriesController(SurvivorDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryListDto>>> GetAll()
        {
            var categories = await _context.Categories
                .Where(c => !c.IsDeleted)
                .Select(c => new CategoryListDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            if (categories == null || categories.Count == 0)
            {
                return NotFound("No categories found.");
            }

            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailDto>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid category ID.");
            }

            var category = await _context.Categories
                .Where(c => c.Id == id && !c.IsDeleted)
                .Select(c => new CategoryDetailDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            return Ok(category);
        }


        [HttpPost]
        public async Task<ActionResult<CategoryEntity>> Create(CreateCategoryDto categoryy) // Create a new category
        {
            if (string.IsNullOrWhiteSpace(categoryy.Name))
            {
                return BadRequest("Category name cannot be empty.");
            }
          
            CategoryEntity category2 = new CategoryEntity
            {
                Name = categoryy.Name,
                IsDeleted = false
            };
           
            _context.Categories.Add(category2);
            await _context.SaveChangesAsync();
             
            return CreatedAtAction(nameof(GetById), new { id = category2.Id }, category2);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto dto)
        {
            if (id <= 0 || dto == null)
                return BadRequest("Invalid category ID or data.");

            var existingCategory = await _context.Categories.FindAsync(id);

            if (existingCategory == null || existingCategory.IsDeleted)
                return NotFound($"Category with ID {id} not found.");

            existingCategory.Name = dto.Name;
            

            await _context.SaveChangesAsync();
            return NoContent(); // Güncelleme başarılı, içerik yok
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) // Delete category by ID
        {
            if (id <= 0)
            {
                return BadRequest("Invalid category ID.");
            }
            var category2 = await _context.Categories.FindAsync(id);
            if (category2 == null || category2.IsDeleted)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            category2.IsDeleted = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<CategoryEntity> jsonPatch) // Soft delete category by ID
        {
            if (id <= 0 || jsonPatch == null)   
                return BadRequest("Invalid category ID or patch document.");
            var category2 = await _context.Categories.FindAsync(id);
            if (category2 == null || category2.IsDeleted)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            jsonPatch.ApplyTo(category2);
           await _context.SaveChangesAsync();
             return NoContent();
        }
    }
}
