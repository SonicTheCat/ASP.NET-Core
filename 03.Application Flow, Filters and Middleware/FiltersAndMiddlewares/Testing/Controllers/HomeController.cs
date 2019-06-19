using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Filters;
using Testing.Models;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {

        [MyResourceFilter]
        [MyResultFilter]
        [MyExceptionFilter]
        [AddHeaderActionFilter]
        [MyAuthorizeFilter]
        public IActionResult Index()
        {
            //throw new Exception(); 
            return View();
        }

       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
