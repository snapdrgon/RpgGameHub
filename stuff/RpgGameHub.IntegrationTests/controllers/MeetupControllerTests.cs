using FluentAssertions;
using NUnit.Framework;
using RpgGameHub.Controllers;
using RpgGameHub.Core.Models;
using RpgGameHub.IntegrationTests.Extensions;
using RpgGameHub.Persistence;
using RpgIntegration.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RpgGameHub.IntegrationTests.controllers
{
    [TestFixture]
    public class MeetupControllerTests
    {
        private MeetupController _controller;
        private ApplicationDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new ApplicationDbContext();
            _controller = new MeetupController(new UnitOfWork(_context));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test, Isolated]
        public void Mine_WhenCalled_ShouldReturnUpcomingMeetups()
        {
            //Arrange
            var user = _context.Users.First();
            //_controller.MockCurrentUser(user.Id, user.UserName);
            ControllerExtensions.MockCurrentUser(_controller, user.Id, user.UserName);
            var meetup = new Meetup { GamerId="1", DateTime = DateTime.Now.AddDays(1), Handle="snapdrgn", Details="stuff", RgpGameId=4 };
            _context.Meetups.Add(meetup);
            _context.SaveChanges();

            //Act
            var result = _controller.Mine();

            //Assert
            ((result as ViewResult).ViewData.Model as IEnumerable<Meetup>).Should().HaveCount(1);
        }

    }
}
