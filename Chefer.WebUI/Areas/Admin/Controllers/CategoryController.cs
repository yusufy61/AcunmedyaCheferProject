using System.Text.Json;
using Chefer.WebUI.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Chefer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _client;

        public CategoryController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7241/api/");
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("category");
            
            if (response.IsSuccessStatusCode)
                //Başarılı durum kodu 200 türü durum kodu
            {
                var categories = await response.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
                return View(categories);
            }

            return View();
        }
    }
}
