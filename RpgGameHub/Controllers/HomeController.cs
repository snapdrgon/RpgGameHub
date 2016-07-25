using Microsoft.AspNet.Identity;
using RpgGameHub.Core.ViewModels;
using RpgGameHub.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;

namespace RpgGameHub.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var upcomingMeetups = _context.Meetups.Where(
                m=>m.DateTime > DateTime.Now
                && !m.IsCancelled).ToList();

            var viewModel = new MeetupViewModel
            {
                Heading = "Upcoming Meetups",
                upcomingMeetups = upcomingMeetups
            };

            return View("Meetups", viewModel);
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