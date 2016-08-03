using Microsoft.AspNet.Identity;
using RpgGameHub.Core.Models;
using RpgGameHub.Core.ViewModels;
using RpgGameHub.Extensions;
using RpgGameHub.Persistence;
using System;
using System.Web.Mvc;

namespace RpgGameHub.Controllers
{
    public class MeetupController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public MeetupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var meetups = _unitOfWork.Meetups.GetUpComingMeetupsByGameMaster(userId);

            return View(meetups);
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
                Handle = User.Identity.GetHandle(),
                DateTime = viewModel.GetDateTime(),
                Details = viewModel.Details,
                Hub = viewModel.Hub,
                RgpGameId = Convert.ToByte(viewModel.RgpGame)
             
            };

            _unitOfWork.Meetups.Add(meetup);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Edit(int Id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            var userId = User.Identity.GetUserId();

            var meetup = _unitOfWork.Meetups.GetSingleMeetupAssociatedWithGameMaster(Id, userId);

            var viewModel = new MeetupFormViewModel
            {
                Details = meetup.Details,
                Hub = meetup.Hub,
                RgpGame = (RpgGameType)meetup.RgpGameId,
                Id = meetup.Id,
                Date = meetup.DateTime.ToString("d MMM yyyy"),
                Time = meetup.DateTime.ToString("HH:mm"),
                Heading = "Edit a Meetup"
            };

            return View("MeetupForm", viewModel);

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MeetupFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("MeetupForm", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var meetup = _unitOfWork.Meetups.GetSingleMeetupAssociatedWithGameMaster(viewModel.Id, userId);

            if (meetup == null)
                return HttpNotFound();

            if (meetup.GamerId != userId)
                return new HttpUnauthorizedResult();

            meetup.Hub = viewModel.Hub;
            meetup.Details = viewModel.Details;
            meetup.RgpGameId = (byte)viewModel.RgpGame;
            meetup.DateTime = viewModel.GetDateTime();

           _unitOfWork.Complete();

            return RedirectToAction("Mine", "Meetup");
        }

    }
}