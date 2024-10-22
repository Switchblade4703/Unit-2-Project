using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unit_2_Project.Models;

namespace Unit_2_Project.Controllers
{
    public class HomeController : Controller
    {
        private CarsDBContext context { get; set; }

        public HomeController(CarsDBContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var Cars = context.Cars.OrderBy(c => c.Id).ToList();
            return View(Cars);
        }
    }
}
