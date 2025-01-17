﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frutin.Controllers
{
    public class ErrorController : Controller
    {
        // GET: NotFound
        [HandleError]
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}