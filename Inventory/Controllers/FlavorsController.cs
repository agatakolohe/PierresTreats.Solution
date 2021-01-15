using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Inventory.Models;

namespace Inventory.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly InventoryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public FlavorsController(UserManager<ApplicationUser> userManager, InventoryContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public ActionResult Index()
        {
            var allFlavors = _db.Flavors.ToList();
            return View(allFlavors);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Flavor flavor, int TreatId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            flavor.User = currentUser;
            _db.Flavors.Add(flavor);
            if (TreatId != 0)
            {
                _db.FlavorTreat.Add(new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisFlavor = _db.Flavors
                .Include(flavor => flavor.Treats)
                .ThenInclude(join => join.Treat)
                .Include(flavor => flavor.User)
                .FirstOrDefault(flavor => flavor.FlavorId == id);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsCurrentUser = userId != null ? userId == thisFlavor.User.Id : false;
            return View(thisFlavor);
        }


    }
}