#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aljuvifoods_webapi.Models;
using aljuvifoods_webapi.Repository;
using aljuvifoods_webapi.DTOs.Product;
using AutoMapper;

namespace aljuvifoods_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public ProductsController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseProduct>> GetProducts([FromQuery]int categoryId)
        {
            var response = new ResponseProduct();
            if(categoryId == 0)
            {
                response.Products = await _context.Products.Include(p=>p.ProductCategory).ToListAsync();
                response.Total=response.Products.Count;
                return response;
            }
                

            var Products = await _context.Products.Where(p=>p.CategoryId == categoryId).ToListAsync();
            response.Products = Products;
            response.Total=Products.Count;
            return response;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, ProductUDTO updateProduct)
        {
            var productHelper = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(productHelper == null)
                return NotFound();
            //context.SystemUser.Update(newUser);
            var product = mapper.Map<Product>(updateProduct);
            product.Id = id;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductCDTO productCDTO)
        {
            var product = mapper.Map<Product>(productCDTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        [HttpGet("description")]
        public async Task<IActionResult> GetByDescription(string description)
        {
            var des = await _context.Products.Where(x => x.Description == description).ToListAsync();
            if (des == null)
                return NotFound();
            return Ok(des);
        }
        [HttpGet("categoryId")]
        public async Task<IActionResult> GetByDescription(int categoryId)
        {
            var category = await _context.Categories.Where(x => x.Id == categoryId).ToListAsync();
            if (category == null)
                return NotFound();
            return Ok(category);
        }
    }
}
