﻿using BusinessLayer.Concrete;
using DataAccessLayerr.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        
        public ActionResult Index()
        {
            return View();
        }
    }
}