﻿using Microsoft.AspNet.Identity;
using RpgGameHub.Core.ViewModels;
using RpgGameHub.Persistence;
using System.Web.Mvc;

namespace RpgGameHub.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {

            var viewModel = new MeetupViewModel
            {
                Heading = "Upcoming Meetups",
                GameGeek = User.Identity.GetUserId(),
                upcomingMeetups = _unitOfWork.Meetups.GetUpComingMeetups(),
                GameFans = _unitOfWork.GameFans.GetAllGameFans(),
                ShowActions = User.Identity.IsAuthenticated              
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