using GigHub.Core.ViewModels;
using RpgGameHub.Controllers;
using RpgGameHub.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace RpgGameHub.Core.ViewModels
{
    public class MeetupFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        public string Heading { get; set; }

        public string Details { get; set; }

        public string Hub { get; set; }

        [Required]
        [ValidRpgGame]
        public RpgGameTypeEnum? RgpGame { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<MeetupController, ActionResult>> update =
                   (c => c.Update(this));

                Expression<Func<MeetupController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;

            }
        }
    }
}