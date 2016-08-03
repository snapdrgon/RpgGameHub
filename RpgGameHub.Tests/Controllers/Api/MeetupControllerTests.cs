using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RpgGameHub.Controllers.Api;
using RpgGameHub.Core.Models;
using RpgGameHub.Persistence;
using RpgGameHub.Persistence.Repositories;
using RpgGameHub.Tests.Extensions;
using System.Web.Http.Results;

namespace RpgGameHub.Tests.Controllers.Api
{
    [TestClass]
    public class MeetupControllerTests
    {
        private MeetupController _controller;
        private Mock<IMeetupRepository> _mockRepository;
        private string _userId;
        private string _userName;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IMeetupRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(m => m.Meetups).Returns(_mockRepository.Object);
            _controller = new MeetupController(mockUoW.Object);
            _userId = "1";
            _userName = "lynn@takware.com";
            _controller.MockCurrentUser(_userId, _userName);
        }
        [TestMethod]
        public void Cancel_ValidUser_IsCancelIsTrue()
        {
            var meetup = new Meetup { Id = 1, GamerId = "1" };
            _mockRepository.Setup(m => m.GetSingleMeetupAssociatedWithGameMaster(1, _userId)).Returns(meetup);
            var result = _controller.Cancel(1);
            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void Cancel_IsAlreadyCancelled_NotFound()
        {
            var meetup = new Meetup { Id = 1, GamerId = "1", IsCancelled = true };
            _mockRepository.Setup(m => m.GetSingleMeetupAssociatedWithGameMaster(1, _userId)).Returns(meetup);
            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_InValidUser_UnAuthorized()
        {
            var meetup = new Meetup { Id = 1, GamerId = "2" };
            _mockRepository.Setup(m => m.GetSingleMeetupAssociatedWithGameMaster(1, _userId)).Returns(meetup);
            var result = _controller.Cancel(1);
            result.Should().BeOfType<UnauthorizedResult>();
        }

        [TestMethod]
        public void Cancel_WrongMeetup_NotFound()
        {
            var meetup = new Meetup { Id = 2, GamerId = "1" };
            _mockRepository.Setup(m => m.GetSingleMeetupAssociatedWithGameMaster(1, _userId)).Returns(meetup);
            var result = _controller.Cancel(2);
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
