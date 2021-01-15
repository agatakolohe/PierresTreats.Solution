using Microsoft.AspNetCore.Mvc;
using Inventory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly InventoryContext _db;
        public HomeController(InventoryContext db)
        {
            _db = db;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            Dictionary<object, object> model = new Dictionary<object, object>();
            List<Treat> treats = _db.Treats.ToList();
            List<Flavor> flavors = _db.Flavors.ToList();
            model.Add("treats", treats);
            model.Add("flavors", flavors);
            return View(model);
        }
    }
}