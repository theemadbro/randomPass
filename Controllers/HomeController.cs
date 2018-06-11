using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using randomPass.Models;

namespace randomPass.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int? IntVariable = HttpContext.Session.GetInt32("count");
            if(IntVariable == null)
            {
                HttpContext.Session.SetInt32("count", 1);
                IntVariable = 1;
            }
            else
            {
                IntVariable++;
                int newvar;
                newvar = IntVariable ?? default(int);
                HttpContext.Session.SetInt32("count", newvar);
            }
        
            Random random = new Random();
            string opts = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] pass = new char[14];
            for (int i = 0; i<14; i++)
            {
                pass[i] = opts[random.Next(0, opts.Length)];
            }
            string ret = new string(pass);
            ViewBag.pass = ret;
            return View("Index", IntVariable);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
