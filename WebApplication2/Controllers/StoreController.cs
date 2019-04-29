using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class StoreController : Controller
    {
        // GET: Chen
        public string Index()
        {
            return "Hello from Store.Index()";
        }
        //
        // GET: /Store/Browse
        public string Browse(string gen)
        {
            string mes = HttpUtility.HtmlEncode("browse gen="+gen);
            return mes;
        }
        //
        // GET: /Store/Details
        public string Details(int id)
        {
            return "Hello from Store.Details()"+id.ToString();
        }
    }
}