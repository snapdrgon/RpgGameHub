using RpgGameHub.Core.Models;
using System.Collections.Generic;

namespace RpgGameHub.Core.ViewModels
{
    public class MeetupViewModel
    {
        public bool ShowActions { get; set; }

        public string GameGeek { get; set; }
        public IEnumerable<Meetup> upcomingMeetups { get; set; }
        public IEnumerable<GameFan> GameFans { get; set; }
        public RpgGameType RgpGame { get; set; }

        public string Heading { get; set; }
    }
}