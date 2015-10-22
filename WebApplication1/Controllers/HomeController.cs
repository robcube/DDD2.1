using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public JsonResult Get(int id)
        {
            return Json(GetData(id), JsonRequestBehavior.AllowGet);
        }

        public ExternalLoginViewModel GetData(int id)
        {
            var externalLoginVM = new ExternalLoginViewModel
            {
                Name = "Home",
                Url = "http://127.0.0.1",
                State = "CO"
            };

            switch (id)
            {
                case 1:
                    externalLoginVM = new ExternalLoginViewModel
                    {
                        Name = "Redmond",
                        Url = "http://microsoft.com",
                        State = "WA"
                    };
                    break;
                case 2:
                    externalLoginVM = new ExternalLoginViewModel
                    {
                        Name = "New York",
                        Url = "http://mhfi.com",
                        State = "NY"
                    };
                    break;
                default:
                    externalLoginVM = new ExternalLoginViewModel
                    {
                        Name = "Denver",
                        Url = "http://denverdevday.eventday.com",
                        State = "CO"
                    };
                    break;

            }
            return externalLoginVM;
        }
    }
}
