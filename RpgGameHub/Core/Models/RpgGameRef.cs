using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpgGameHub.Core.Models
{
    public class RpgGameRef
    {
        [Key]
        [Column(Order = 1)]
        public int RpgGameId { get; set; }
        public string Url { get; set; }
    }
}