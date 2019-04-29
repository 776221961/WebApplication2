using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        jxcEntities1 jxcuser = new jxcEntities1();
        Users user = new Users();
        public ActionResult Index()
        {

            var listone = new List<int>();
            for(int i=0;i<10;i++)
            {
                listone.Add(i);
            }
            ViewBag.list = listone;
            ViewBag.name = "chensubo";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "my page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Message()
        {
            var user1 = jxcuser.Users.Where(u => u.UserID > 2);
            ViewBag.Message = "部分视图";
            ViewBag.userlist = user1;
            return PartialView();
        }
        public ActionResult mainform()
        {
            var name = Request["name"];
            var pwd = Request["pwd"];
            Users ua = new Users();
             var a=   jxcuser.Users.Where(u=>u.UserName==name);
            ua = a.FirstOrDefault() as Users;
            if ((ua!=null) &&( ua.UserID>0))
            {
                ViewBag.user = ua;
              
                return View(ua);
            }else
            {
                ViewBag.message = "";
                return View("~/Views/Shared/Error.cshtml");
            }
          
          
        }
    }
}