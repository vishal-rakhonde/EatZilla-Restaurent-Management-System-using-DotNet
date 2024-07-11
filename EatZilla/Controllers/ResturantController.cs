using EatZilla.Models.CoreClasses;
using EatZilla.Models.DataConnection;
using Microsoft.AspNetCore.Mvc;

namespace EatZilla.Controllers
{
    public class ResturantController : Controller

    {
        private readonly ApplicationDatabaseContext data;

        public ResturantController(ApplicationDatabaseContext db)
        {
            data = db;
            
        }

        public IActionResult Index()

        {
            List<Resturant> list = data.resturants.ToList();
            
            return View(list);
        }
    }
}
