using Microsoft.AspNet.Identity;
using SpinForLife.Helpers;
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
        private UserRoleHelper roleHelper = new UserRoleHelper();
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();

            if (db.Events.FirstOrDefault(e => e.IsActive) != null)
            {
                var @event = db.Events.FirstOrDefault(e => e.IsActive);
                viewModel.Grid = @event.Grid;
                viewModel.Event = @event;
            }

            if (User.Identity.GetUserId() != null)
            {
                var userId = User.Identity.GetUserId();
                viewModel.User = db.Users.Find(userId);

                if (roleHelper.ListUserRoles(userId).FirstOrDefault() == "Admin")
                {
                    viewModel.UserIsAdmin = true;
                }
                else
                {
                    viewModel.UserIsAdmin = false;
                }
            }

            viewModel.AllTeams = db.Teams.ToList();

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

        public ActionResult JoinOpenSection(int id)
        {
            var openBike = db.OpenBikeSections.Find(id);
            var user = db.Users.Find(User.Identity.GetUserId());
            user.Team = null;

            if (openBike.OpenSlots > 0)
            {
                openBike.Riders.Add(user);
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LeaveOpenSection(int id)
        {
            var openBike = db.OpenBikeSections.Find(id);
            var user = db.Users.Find(User.Identity.GetUserId());

            openBike.Riders.Remove(user);

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}