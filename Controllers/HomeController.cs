using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RandomPass.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int passCount = 0;
            HttpContext.Session.SetInt32("passCount", passCount);
            return View();
        }

        [HttpGet("generate")]
        public JsonResult GetCode()
        {
            int? _passCount = HttpContext.Session.GetInt32("passCount");
            _passCount ++;
            int passCount = new int();
            if(_passCount.HasValue)
            {
                passCount = _passCount.Value;
            }
            HttpContext.Session.SetInt32("passCount", passCount);
            string NewCode = new string("");
            string chars = "1234567890QWERTYIOPASDFGHJKLZXCVBNM";
            Random rand = new Random();
            for(int idx = 0; idx<14; idx++)
            {
                NewCode += chars[rand.Next(0, chars.Length)];
            }
            var CodeCount = new 
            {
                Count = passCount,
                Code = NewCode
            };
            ViewBag.NewCode = NewCode;
            ViewBag.PassCount = passCount;
            System.Console.WriteLine(NewCode);
            return Json(CodeCount);
            
        }
        public ActionResult Generate()
        {
            System.Console.WriteLine("##########################################");
            return PartialView("GenPartial");
        }
    }
}
