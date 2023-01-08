using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.DTo;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ProductAPI.Models;
using ProductAPI.ModelRequest;
using ProductAPI.Service;
using ProductAPI.ViewModel;

namespace ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpPost("CreateProduct")]
        public ResponsePostView CreateProduct([FromBody] CreateProductRequest request)
        {
            var result = _productService.CreateProduct(request);
            return result;
        }
        [AllowAnonymous]
        [HttpPost("UpdateProduct")]
        public ResponsePostView UpdateProduct(CreateProductRequest request)
        {
            var result = _productService.UpdateProduct(request);
            return result;
        }
        [AllowAnonymous]
        [HttpPost("DeleteProduct")]
        public ResponsePostView DeleteProduct(int productId)
        {
            var result = _productService.DeleteProduct(productId);
            return result;
        }
        [AllowAnonymous]
        [HttpPost("GetListProductByCategoryId")]
        public ResponseViewModel GetListProductByCategoryId(int categoyId)
        {
            var result = _productService.GetListProductByCategoryId(categoyId);
            return result;
        }

        /* [AllowAnonymous]
         [HttpGet]
         public IActionResult GetReviews()
         {
             var reviews = _mapper.Map<List<CreateProductRequest>>(_context.Product.ToList());

             if (!ModelState.IsValid)
                 return BadRequest(ModelState);
             return Ok(reviews);
         }

         [AllowAnonymous]
         [HttpGet("{productId}")]
         [ActionName("GetReviewsForAProduct")]
         public async Task<IActionResult> GetReviewsForAProduct([FromRoute] int productId)
         {
             var reviews = await _context.Product.FirstOrDefaultAsync(x => x.ProductId == productId);
             if (reviews != null)
             {
                 return Ok(reviews);
             }
             return NotFound("Product Not Found");
         }

         [Authorize(Roles = "Admin")]
         [HttpPost]
         [ProducesResponseType(204)]
         [ProducesResponseType(400)]
         public async Task<IActionResult> CreateProductAsync( [FromBody] CreateProductRequest ownerCreate)
         {

             var ownerMap = _mapper.Map<Product>(ownerCreate);
             //ownerMap.Category = _context.Category.Where(p => p.Id == product.CategoryId).Include(e => e.Product).FirstOrDefault();
             Category newcategory = _context.Category.Single(c => c.CategoryId == ownerMap.CategoryId);
             await _context.Product.AddAsync(ownerMap);
             await _context.SaveChangesAsync();
             //return Ok("Successfully created");
             return CreatedAtAction(nameof(GetReviewsForAProduct), ownerMap.ProductId, ownerMap);
         }
         [Authorize(Roles = "Admin")]
         [HttpPut("{productId}")]
         [ProducesResponseType(400)]
         [ProducesResponseType(204)]
         [ProducesResponseType(404)]
         public async Task<IActionResult> UpdateProductAsync(int productId, [FromBody] CreateProductRequest updatedProduct)
         {
             if (updatedProduct == null)
                 return BadRequest(ModelState);

             if (productId != updatedProduct.Id)
                 return BadRequest(ModelState);

             if (!_context.Product.Any(r => r.ProductId == productId))
                 return NotFound();

             if (!ModelState.IsValid)
                 return BadRequest();

             var productMap = _mapper.Map<Product>(updatedProduct);

             _context.Product.Update(productMap);
             _context.SaveChanges();

             return NoContent();
         }
         [Authorize(Policy = "UserDelete")]
         [HttpDelete("{productId}")]
         [ProducesResponseType(400)]
         [ProducesResponseType(204)]
         [ProducesResponseType(404)]
         public IActionResult DeleteReview(int productId)
         {
             if (!_context.Product.Any(r => r.ProductId == productId))
             {
                 return NotFound();
             }

             var reviewToDelete = _context.Product.Where(r => r.ProductId == productId).FirstOrDefault();

             if (!ModelState.IsValid)
                 return BadRequest(ModelState);
             _context.Product.RemoveRange(reviewToDelete);
             var saved = _context.SaveChanges();
             bool c = saved > 0 ? true : false;
             if (!c)
             {
                 ModelState.AddModelError("", "Something went wrong deleting owner");
             }
             return NoContent();
         }
         [AllowAnonymous]
         [HttpGet("{productId}/category")]
         public async Task<IActionResult> GetCateByAPro2([FromRoute] int productId)
         {
             if (!_context.Product.Any(r => r.ProductId == productId))
                 return NotFound();
             var reviews = await _context.Product.FirstOrDefaultAsync(x => x.ProductId == productId);
             var reviews2 = _mapper.Map<List<CategoryDto>>(_context.Category.Where(r => r.CategoryId == reviews.CategoryId).ToList());
             return Ok(reviews2);
         }*/

    }
}
