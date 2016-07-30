using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RpgGameHub.Core.Models;
using RpgGameHub.Persistence;
using RpgGameHub.Persistence.Repositories;
using RpgGameHub.Tests.Extensions;
using System;
using System.Data.Entity;

namespace RpgGameHub.Tests.Persistence.Repositories
{
    [TestClass]
    public class MeetupRepositoryTests
    {
        private MeetupRepository _repository;
        private Mock<IApplicationDbContext> mockContext;
        private Mock<DbSet<Meetup>> _mockMeetups { get; set; }
        [TestInitialize]
        public void TestInitialize()
        {
            _mockMeetups = new Mock<DbSet<Meetup>>();
            mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Meetups).Returns(_mockMeetups.Object);
            _repository = new MeetupRepository(mockContext.Object);

        }
        [TestMethod]
        public void GetUpComingMeetups_GetMeetupEarlierDate_ShouldNotReturned()
        {
            var meetup = new Meetup() { DateTime = DateTime.Now.AddDays(-1), GamerId = "1" };
            _mockMeetups.SetSource(new[] { meetup });
            mockContext.Setup(c => c.Meetups).Returns(_mockMeetups.Object);
            var meetups = _repository.GetUpComingMeetups();
            meetups.Should().BeEmpty();

        }

        [TestMethod]
        public void GetUpComingMeetups_GetMeetupMeetingCancelled_ShouldNotReturned()
        {
            var meetup = new Meetup() { DateTime = DateTime.Now.AddDays(1), GamerId = "1", IsCancelled = true };
            _mockMeetups.SetSource(new[] { meetup });
            mockContext.Setup(c => c.Meetups).Returns(_mockMeetups.Object);
            var meetups = _repository.GetUpComingMeetups();
            meetups.Should().BeEmpty();

        }

        [TestMethod]
        public void GetUpComingMeetups_GetMeetupHappyPath_ShouldReturnData()
        {
            var meetup = new Meetup() { DateTime = DateTime.Now.AddDays(1), GamerId = "1" };
            _mockMeetups.SetSource(new[] { meetup });
            mockContext.Setup(c => c.Meetups).Returns(_mockMeetups.Object);
            var meetups = _repository.GetUpComingMeetups();
            meetups.Should().NotBeEmpty();

        }
        [TestMethod]
        public void GetUpComingMeetupsByGameMaster_GetMeetupHappyPath_ShouldReturnData()
        {
            var meetup = new Meetup() { DateTime = DateTime.Now.AddDays(1), GamerId = "1" };
            _mockMeetups.SetSource(new[] { meetup });
            mockContext.Setup(c => c.Meetups).Returns(_mockMeetups.Object);
            var meetups = _repository.GetUpComingMeetupsByGameMaster("1");
            meetups.Should().NotBeEmpty();

        }

        [TestMethod]
        public void GetUpComingMeetupsByGameMaster_InvalidUser_ShouldReturnData()
        {
            var meetup = new Meetup() { DateTime = DateTime.Now.AddDays(1), GamerId = "1" };
            _mockMeetups.SetSource(new[] { meetup });
            mockContext.Setup(c => c.Meetups).Returns(_mockMeetups.Object);
            var meetups = _repository.GetUpComingMeetupsByGameMaster("2");
            meetups.Should().BeEmpty();

        }

        [TestMethod]
        public void GetSingleMeetupAssociatedWithGameMaster_ValidUser_ShouldReturnData()
        {
            var meetup = new Meetup() { DateTime = DateTime.Now.AddDays(1), GamerId = "1", Id = 1 };
            _mockMeetups.SetSource(new[] { meetup });
            mockContext.Setup(c => c.Meetups).Returns(_mockMeetups.Object);
            var meetups = _repository.GetSingleMeetupAssociatedWithGameMaster(1, "1");
            meetups.Should().BeOfType<Meetup>();

        }

        [TestMethod]
        public void GetSingleMeetupAssociatedWithGameMaster_InvalidUser_ShouldBeEmpty()
        {
            var meetup = new Meetup() { DateTime = DateTime.Now.AddDays(1), GamerId = "1", Id = 1 };
            _mockMeetups.SetSource(new[] { meetup });
            mockContext.Setup(c => c.Meetups).Returns(_mockMeetups.Object);
            var meetups = _repository.GetSingleMeetupAssociatedWithGameMaster(1, "2");
            meetups.Should().BeNull();

        }


    }
}
