﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMVIETTOUR.Controllers.Other
{
    [Authorize]
    public class CalculatorManageController : Controller
    {
        // GET: CalculatorManage
        public ActionResult Index()
        {
            return View();
        }
    }
}