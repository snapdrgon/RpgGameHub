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
    public class GameFanControllerTests
    {
        private GameFanController _controller;
        private Mock<IGameFanRepository> _mockRepository;
        private string _userId;
        private string _userName;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IGameFanRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(m => m.GameFans).Returns(_mockRepository.Object);
            _controller = new GameFanController(mockUoW.Object);
            _userId = "1";
            _userName = "lynn@takware.com";
            _controller.MockCurrentUser(_userId, _userName);
        }

        [TestMethod]
        public void AddGameFan_DoesNotShowAsAttending_OkResult()
        {
            var result = _controller.AddGameFan(1);
            result.Should().BeOfType<OkResult>();

        }
        [TestMethod]
        public void AddGameFan_AlreadyAttending_BadRequestErrorMessageResult()
        {
            _mockRepository.Setup(r => r.GetGameFanAttendingMeetupFlag(1, _userId)).Returns(true);
            var result = _controller.AddGameFan(1);
            result.Should().BeOfType<BadRequestErrorMessageResult>();

        }

        [TestMethod]
        public void RemoveGameFan_GameFanExists_OkResult()
        {
            _mockRepository.Setup(r => r.GetGameFanSingleForMeetup(1, _userId))
            .Returns(new GameFan { GamerId = _userId, MeetupId = 1 });

            var result = _controller.DeleteGameFan(1);

            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void RemoveGameFan_GameFanDoesNotExists_BadRequestErrorResult()
        {
            var result = _controller.DeleteGameFan(1);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }
    }
}
