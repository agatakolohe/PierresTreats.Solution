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
    public class TreatsController : Controller
    {
        private readonly InventoryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController(UserManager<ApplicationUser> userManager, InventoryContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Index()
        {
            var allTreats = _db.Treats.ToList();
            return View(allTreats);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorDescription");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Treat treat, int FlavorId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            treat.User = currentUser;
            _db.Treats.Add(treat);
            if (FlavorId != 0)
            {
                _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}