using System;
using System.ComponentModel.DataAnnotations;

namespace RpgGameHub.Core.Models
{
    public class Meetup
    {
        public int Id { get; set; }

        public ApplicationUser Gamer { get; set; }

        [Required]
        public string GamerId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [StringLength(250)]
        public string Details { get; set; }

        [Required]
        public byte RgpGameId { get; set; }

        [Required]
        public string Handle { get; set; }
        public bool IsCancelled { get; set; } //taz change back to private once going to production

        public void Cancel()
        {
            IsCancelled = true;
        }
    }
}