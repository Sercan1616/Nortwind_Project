using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi;

namespace Application_UI_Web.Controllers
{
    public class HomeController : Controller
    {
        NorthwindApi northwind = new NorthwindApi();
        Product product = new Product();

        public ActionResult Index()
        {
            var getproduct = northwind.GetProducts().ToList();
            return View(getproduct);
        }

        
    }
}