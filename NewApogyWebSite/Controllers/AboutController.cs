﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewApogyWebSite.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult AboutUs()
        {
            ViewBag.Title = "About Apogy";

            return View();
        }
        public ActionResult Platform()
        {
            ViewBag.Title = "Platform";

            return View();
        }
        public ActionResult Security()
        {
            ViewBag.Title = "Security";

            return View();
        }
        public ActionResult Service()
        {
            ViewBag.Title = "Service";

            return View();
        }
        public ActionResult Support()
        {
            ViewBag.Title = "Support";

            return View();
        }
        public ActionResult Training()
        {
            ViewBag.Title = "Training";

            return View();
        }
        //public ActionResult Awards()
        //{
        //    ViewBag.Title = "Awards";

        //    return View();
        //}
    }
}
