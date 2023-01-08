using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProductAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ProductAPI.Models;
using ProductAPI.ModelRequest;

namespace ProductAPI.Controllers
{
    [Route("api/Category")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly DataDbcontext _context;
        private readonly IMapper _mapper;
        public CategoryController(DataDbcontext product,
            IMapper mapper)
        {
            _context = product;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetReviewers()
        {
            var reviewers = _mapper.Map<List<CreateCategoryModel>>(_context.Category.ToList());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewers);
        }
        [AllowAnonymous]
        [HttpGet("GetCategoryById")]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_context.Category.Any(r => r.CategoryId == categoryId))
                return NotFound();

            var reviewer = _mapper.Map<CreateCategoryModel>(_context.Category
                .Where(r => r.CategoryId == categoryId).FirstOrDefault());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }
        [HttpGet("{categoryId:int}/product")]
        [AllowAnonymous]
        public IActionResult GetProductByACategory(int categoryId)
        {
            if (!_context.Category.Any(r => r.CategoryId == categoryId))
                return NotFound();

            var reviews = _mapper.Map<List<CreateProductRequest>>(_context.Product.Where(r => r.CategoryId == categoryId).ToList());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }
        [HttpPost("createCategory")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReviewerAsync([FromBody] CreateCategoryModel reviewerCreate)
        {
            var reviewerMap = _mapper.Map<Category>(reviewerCreate);
            await _context.Category.AddAsync(reviewerMap);
            await _context.SaveChangesAsync(); 
            return Ok("Successfully created");
        }

        [Authorize(Roles = "User")]
        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReviewer(int categoryId, [FromBody] CreateCategoryModel updatedCategory)
        {
            if (updatedCategory == null)
                return BadRequest(ModelState);

            if (categoryId != updatedCategory.Id)
                return BadRequest(ModelState);

            if (!_context.Category.Any(r => r.CategoryId == categoryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var categoryMap = _mapper.Map<Category>(updatedCategory);
            _context.Category.Update(categoryMap);
            var saved = _context.SaveChanges();
            bool c = saved > 0 ? true : false;
            if (!c)
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [Authorize(Roles = "User")]
        [HttpDelete("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteReviewer(int categoryId)
        {
            if (!_context.Category.Any(r => r.CategoryId == categoryId))
            {
                return NotFound();
            }

            var categoryToDelete = _context.Category
              .Where(r => r.CategoryId == categoryId).FirstOrDefault();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _context.Category.RemoveRange(categoryToDelete);
            var saved = _context.SaveChanges();
            bool c = saved > 0 ? true : false;
            if (!c)
            {
                ModelState.AddModelError("", "Something went wrong deleting reviewer");
            }

            return NoContent();
        }
    }
}
