using EatZilla.Models.CoreClasses;
using EatZilla.Models.DataConnection;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EatZilla.Controllers
{
    public class DishController : Controller


    {
        [Key]
        public static int dishid;
        private readonly ApplicationDatabaseContext data;

        public DishController(ApplicationDatabaseContext db) {

            data = db;
        }


        public IActionResult Index()
        {
            List<Dish> dish = data.dishes.ToList();
            return View(dish);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(String dishname,String price)
        {
            int p = Convert.ToInt32(price);
            Dish dish = new Dish(dishid++,dishname,p);

            data.dishes.Add(dish);
            data.SaveChanges();

            return RedirectToAction("Index");


        }
        
    }
}
