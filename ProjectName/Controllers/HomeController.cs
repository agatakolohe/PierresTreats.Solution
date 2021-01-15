using Microsoft.AspNetCore.Mvc;
using ProjectName.Models; TODO
using System.Collections.Generic;

namespace ProjectName.Controllers TODO
{
    public class HomeController : Controller
{

    [HttpGet("/")]
    public ActionResult Index()
    {
        return View();
    }
}
}