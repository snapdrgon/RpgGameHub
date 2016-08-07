using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpgGameHub.Core.Models
{
    public class GameFan
    {

        [Key]
        [Column(Order = 1)]
        public int MeetupId { get; set; }
        public Meetup Meetup { get; set; }

        [Key]
        [Column(Order = 2)]
        public string GamerId { get; set; }
        public ApplicationUser Gamer { get; set; }
    }
}