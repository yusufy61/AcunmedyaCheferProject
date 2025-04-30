using AcunmedyaCheferProject.Data;
using AcunmedyaCheferProject.DTOs.ProductDTOs;
using AcunmedyaCheferProject.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcunmedyaCheferProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CheferContext _context;
        private readonly IMapper _mapper;
        public ProductsController(CheferContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GelAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return BadRequest("Ürün bulunamadı");
            }
            return Ok(product);
        }

        [HttpPut]
        public IActionResult Update(UpdateProductDTO updateProductDTO)
        {
            var product = _context.Products.Find(updateProductDTO.ProductId);
            if (product == null)
            {
                return BadRequest("Güncellenecek ürün bulunamadı");
            }
            var updatedProduct = _mapper.Map(updateProductDTO,product);

            _context.Update(updatedProduct);
            _context.SaveChanges();
            return Ok("Ürün başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return BadRequest("Silinecek ürün bulunamadı");
            }

            _context.Remove(product);
            _context.SaveChanges();
            return Ok("Ürün başarıyla eklendi");
        }
    }
}
