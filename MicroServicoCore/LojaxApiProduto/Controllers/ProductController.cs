using AutoMapper;
using LojaxApiProduto.Data.ValueObjects;
using LojaxApiProduto.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LojaxApiProduto.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private  IProductRepository _repository;
         

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new
               ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = _repository.FindAll();
             
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}