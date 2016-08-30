using RpgGameHub.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RpgGameHub.Core.ViewModels
{
    sealed public class ValidRpgGame : ValidationAttribute
    {
        const string ErrorMessageRpgGameString = "You must select a Game.";
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            var isValid = (RpgGameTypeEnum)value >= RpgGameTypeEnum.DivinityOS;
            return (isValid);
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageRpgGameString, name);
        }

    }
}