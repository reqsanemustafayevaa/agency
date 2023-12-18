using Microsoft.AspNetCore.Mvc;

namespace agencyproject12.Areas.manage.Controllers
{
    [Area("manage")]
    public class DashBoardController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
