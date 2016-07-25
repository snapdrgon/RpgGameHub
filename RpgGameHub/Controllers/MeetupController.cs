using Microsoft.AspNet.Identity;
using RpgGameHub.Core.Models;
using RpgGameHub.Core.ViewModels;
using RpgGameHub.Persistence;
using System;
using System.Web.Mvc;

namespace RpgGameHub.Controllers
{
    public class MeetupController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MeetupController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MeetupFormViewModel
            {
                Heading = "Add a Meetup",
                 
            };
            return View("MeetupForm", viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetupFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            var meetup = new Meetup
            {
                GamerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                Details = viewModel.Details,
                RgpGameId = Convert.ToByte(viewModel.RgpGame)
             
            };

            _context.Meetups.Add(meetup);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}