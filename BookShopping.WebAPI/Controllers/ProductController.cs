using BookShopping.Model.Models;
using BookShopping.Service.Data;
using BookShopping.Service.Repository;
using BookShopping.Service.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShopping.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _productRepository.GetAll().Where(x => !x.IsDeleted);
            return Json(productList);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productRepository.Get(id);
            if (product.IsDeleted)
                return NotFound("No Product Found !");
            return Json(product);
        }
        [HttpPost]
        public IActionResult Add([FromBody]Product product)
        {
            if(product == null)
            {
                _productRepository.Add(product);
                return Ok("Product Added Successfully !");
            }
            return BadRequest("Product is null !");
        }
        [HttpPut]
        public IActionResult Edit([FromBody]Product product)
        {
            if(product == null)
            {
                _productRepository.Update(product);
                return Ok("Product Updated Successfully !");
            }
            return BadRequest("Product is null !");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var product = _productRepository.Get(id);
                product.IsDeleted = !product.IsDeleted;
                _productRepository.Update(product);
                return Ok("Product Deleted Successfully !");
            }
            return BadRequest("Invalid Id");
        }
    }
}
