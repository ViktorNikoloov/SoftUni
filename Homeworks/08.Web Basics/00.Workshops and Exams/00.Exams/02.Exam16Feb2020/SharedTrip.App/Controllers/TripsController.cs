﻿using System;
using System.Globalization;

using SIS.HTTP;

using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

using SharedTrip.App.Services.Trips;
using SharedTrip.App.ViewModels.Trips;

namespace SharedTrip.App.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Add(TripsInputModel model)
        {
            bool isParsed = DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            var userId = GetUserId();

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                return Error("Start point is required");
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                return Error("End point is required");
            }

            if (2 > model.Seats || model.Seats > 6)
            {
                return Error("Seat should be between 2 and 6");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 80)
            {
                return Error("Description is required and has max length of 80");
            }

            if (!isParsed)
            {
                return Error("Invalid Departure time. Please use this format (dd.MM.yyyy HH: mm)");
            }

            tripsService.Add(model, userId);

            return Redirect("/");
        }

        public HttpResponse All()
        {
            return View();
        }

        public HttpResponse Details()
        {
            return View();
        }
    }
}
