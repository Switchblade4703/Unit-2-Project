using Microsoft.AspNetCore.Mvc;
using Unit_2_Project.Models;
namespace Unit_2_Project.Controllers
{
    public class CarController : Controller
    {
        private CarsDBContext context { get; set; }
        public CarController(CarsDBContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Cars());
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var car = context.Cars.Find(id);
            return View(car);
        }

        [HttpPost]
            public IActionResult Edit(Cars car)
            {
                if (ModelState.IsValid)
                {
                    if (car.Id == 0)
                        context.Cars.Add(car);
                    else
                        context.Cars.Update(car);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Action = (car.Id == 0) ? "Add" : "Edit";
                    return View(car);
                }
            }
            [HttpGet]
            public IActionResult Delete(int id)
            {
                var movie = context.Cars.Find(id);
                return View(movie);
            }

            [HttpPost]
            public IActionResult Delete(Cars car)
            {
                context.Cars.Remove(car);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
    }
    }

