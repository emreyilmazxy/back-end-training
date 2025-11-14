using Asp.Versioning;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.Business.Operations.Product;
using OnlineShoppingApp.Business.Operations.Product.Dtos;
using OnlineShoppingApp.WebApi.Models;

namespace OnlineShoppingApp.WebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz ürün ID");
            }
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            return Ok(product);
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct(AddProductRequest requestProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addProductDto = new AddProductDto
            {
                CategoryId = requestProduct.CategoryId,
                ProductName = requestProduct.ProductName,
                Price = requestProduct.Price,
                StockQuantity = requestProduct.StockQuantity
            };

            var result = await _productService.AddProductAsync(addProductDto);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }
            return CreatedAtAction(nameof(GetProductById), new { id = result.Data.Id }, result);
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var items = await _productService.GetAllAsync();
            if (items == null || !items.Any())
            {
                return NotFound("Ürün bulunamadı");
            }
            return Ok(items);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz ürün ID");
            }
            var result = await _productService.DeleteProductAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = result.Message });

        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateProduct(int id,UpdateProductRequest updateProductRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateProductDto = new UpdateProductDto
            {
                Id = id,
                CategoryId = updateProductRequest.CategoryId,
                ProductName = updateProductRequest.ProductName,
                Price = updateProductRequest.Price,
                StockQuantity = updateProductRequest.StockQuantity
            };
            var result = await _productService.UpdateProductAsync(updateProductDto);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }
            return NoContent();
        }

        [HttpPatch]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PatchProduct(int id,  PatchProductRequest request)
        {
           if(request is null)
                return BadRequest(new { message =" geçersiz istek"});
           if (request.Price <0)
                return BadRequest(new { message = "Fiyat negatif olamaz" });

            var dto = new PatchProductDto
            {
                Id = id,
                Price = request.Price,
                StockQuantity = request.StockQuantity
            };

            var result = await _productService.ApplyPartialUpdateAsync(dto);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }
            return NoContent();

        }

    }// ProductsController done
}
