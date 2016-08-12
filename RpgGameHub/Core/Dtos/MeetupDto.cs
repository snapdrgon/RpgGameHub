namespace RpgGameHub.Core.Dtos
{
    public class MeetupDto
    {
        public string Handle { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Details { get; set; }
        public string Hub { get; set; }
        public string RgpGameName { get; set; }
        public string Url { get; set; }
        public bool Attending { get; set; }
        public bool IsCancelled { get; set; } 
    }
}