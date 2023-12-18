using Microsoft.AspNetCore.Mvc;
using project.business.Services.Interfaces;
using project.Core.Models;
using project.Core.Repositories.Interfaces;

namespace agencyproject12.Areas.manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryservice;
        public CategoryController(ICategoryService categoryservice)
        {
            _categoryservice=categoryservice;
        }
        public IActionResult Index()
        {
            var categories=_categoryservice.GetAllAsync();
            return View(categories);
        }
    }
}
