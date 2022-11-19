using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data;
using RealEstate.Model;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDataContext _context;
        public CategoriesController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Getall()
        {
            //return StatusCode(200);
          //  return StatusCode(StatusCodes.Status200OK);
            return Ok(_context.Categories);

        }
        [HttpGet("{id}")]
        public IActionResult GetBYid(int id)
        {
            Category c=_context.Categories.FirstOrDefault(x=>x.Id==id);
            if (c == null)
            {
                return NotFound("No record with id " + id);
            }
            return Ok(c);
            
        }
        [HttpGet("[Action]")]
        public IActionResult SortCategory()
        {
            return Ok(_context.Categories.OrderByDescending(x => x.Name));

        }
        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
           return Ok("Record created successfully");

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category cat)
        {
            Category category=_context.Categories.FirstOrDefault(x=>x.Id==id);
            if (category == null)
            {
                return NotFound("No record with id " + id);
            }
            category.Name = cat.Name;
            category.ImageUrl = cat.ImageUrl;
            _context.SaveChanges();
            return Ok("Record updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if(category==null)
            {
                return NotFound("No record with id "+id);
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Record Deleted  successfully");
        }
    }
}
