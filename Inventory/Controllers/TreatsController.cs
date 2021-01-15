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

        public ActionResult Details(int id)
        {
            var thisTreat = _db.Treats
                .Include(treat => treat.Flavors)
                .ThenInclude(join => join.Flavor)
                .Include(treat => treat.User)
                .FirstOrDefault(treat => treat.TreatId == id);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsCurrentUser = userId != null ? userId == thisTreat.User.Id : false;
            return View(thisTreat);
        }

        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var thisTreat = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(treat => treat.TreatId == id);
            if (thisTreat == null)
            {
                return RedirectToAction("Details", new { id = id });
            }
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorDescription");
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult Edit(Treat treat, int FlavorId)
        {
            if (FlavorId != 0)
            {
                var returnedJoined = _db.FlavorTreat.Any(join => join.TreatId == treat.TreatId && join.FlavorId == FlavorId);
                if (!returnedJoined)
                {
                    _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId });
                }
            }
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<ActionResult> AddFlavor(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Treat thisTreat = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(treat => treat.TreatId == id);
            if (thisTreat == null)
            {
                return RedirectToAction("Details", new { id = id });
            }
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorDescription");
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult AddFlavor(Treat treat, int FlavorId)
        {
            if (FlavorId != 0)
            {
                _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}