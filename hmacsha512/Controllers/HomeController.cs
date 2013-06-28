using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace hmacsha512.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult hmac(string sig, string token)
        {
            var signature = string.Empty;
            using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(token)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(sig));
                signature = Convert.ToBase64String(hash);
            }

            return Json(signature);
        }
    }
}
