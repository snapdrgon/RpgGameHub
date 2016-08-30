using System.ComponentModel.DataAnnotations;

namespace RpgGameHub.Core.Models
{
    public enum RpgGameTypeEnum
    {
        [Display(Name = "Divinity Original Sin")]
        DivinityOS =1,
        [Display(Name = "Fallout")]
        Fallout = 2,
        [Display(Name = "Inquisition")]
        Inquisition =3,
        [Display(Name = "MassEffect")]
        MassEffect =4,
        [Display(Name = "Skyrim")]
        Skyrim =5,
    }
}