﻿using System.Web.Mvc;
namespace MovieTicketBooking.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }
    }
}