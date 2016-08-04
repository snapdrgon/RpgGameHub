using System;

namespace RpgGameHub.Core.Dtos
{
    public class MeetupDto
    {
        public string Handle { get; set; }
        public DateTime DateTime { get; set; }
        public string Details { get; set; }
        public string Hub { get; set; }
        public byte RgpGameId { get; set; }
        public bool IsCancelled { get; set; } 
    }
}