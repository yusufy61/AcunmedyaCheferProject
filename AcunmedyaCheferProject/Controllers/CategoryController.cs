using AcunmedyaCheferProject.Data;
using AcunmedyaCheferProject.DTOs.CategoryDTOs;
using AcunmedyaCheferProject.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcunmedyaCheferProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CheferContext _context;
        private readonly IMapper _mapper;
        public CategoryController(CheferContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }


        [HttpPost]
        public IActionResult Create(CreateCategoryDTO createCategoryDTO)
        {
            var category = _mapper.Map<Category>(createCategoryDTO);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDTO updateCategoryDTO)
        {
            var category = _context.Categories.Find(updateCategoryDTO.Id);
            if (category == null)
            {
                return BadRequest("Kategori bulunamadı");
            }
            category.Name = updateCategoryDTO.Name;

            _context.Update(category);
            _context.SaveChanges();
            return Ok("Kategori başarıyla güncellendi");
        }

        //api/Categories/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return BadRequest("Kategori bulunamadı");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Kategori başarıyla silindi");
        }
    }
}