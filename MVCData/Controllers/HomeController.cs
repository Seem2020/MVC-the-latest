﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCData.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Assignments()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}