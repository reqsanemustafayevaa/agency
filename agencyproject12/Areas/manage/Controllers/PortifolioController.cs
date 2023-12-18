using Microsoft.AspNetCore.Mvc;
using project.business.Exceptions;
using project.business.Services.Interfaces;
using project.Core.Models;

namespace agencyproject12.Areas.manage.Controllers
{
    [Area("manage")]
    public class PortifolioController : Controller
    {
        private readonly IPortifolioService _portifolioService;
        public PortifolioController(IPortifolioService portifolioservice)
        {
            _portifolioService=portifolioservice;
        }
        public async Task<IActionResult> Index()
        {
            var portifolios =await _portifolioService.GetAllAsync();
            return View(portifolios);
        }
        public async Task< IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Portiofolio portiofolio)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _portifolioService.CreateAsync(portiofolio);
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
            return RedirectToAction("Index");


        }
        public async  Task<IActionResult> Update(int id)
        {
            var existportifolio =await _portifolioService.GetByIdAsync(id);
            if(existportifolio == null)
            {
                return NotFound();
            }
            return View(existportifolio); 
        }
        


    }
}
