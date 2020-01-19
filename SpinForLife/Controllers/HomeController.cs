using SpinForLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpinForLife.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();

            if (db.Events.FirstOrDefault(e => e.IsActive) != null)
            {
                var @event = db.Events.FirstOrDefault(e => e.IsActive);
                viewModel.Grid = @event.Grid;
                viewModel.Event = @event;
            }

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}