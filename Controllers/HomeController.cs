using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webApp1.Models;
using Newtonsoft.Json;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace webApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private string GCD(long n1, long n2, long n3, long n4, int len)
        {
            
                if (n2 == 0)
                {
                Thread.Sleep(len * 1000);
                var ans = String.Format("GCD of {0}, {1} is: {2}", n3, n4, n1);

                
                    return ans;
                }
                else
                {
                    return GCD(n2, n1 % n2, n3, n4, len);
                }

        }

        public IActionResult Index()
        {
            return View();
        }
        private static InputNumbers _inputNumbers = new InputNumbers();


        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PrivacyAsync(InputNumbers inputNumbers)
        {
            if (ModelState.IsValid) {
                _inputNumbers.firstNum = inputNumbers.firstNum;
                _inputNumbers.secondNum = inputNumbers.secondNum;
                var len = inputNumbers.firstNum.ToString().Length;
                string ans = GCD(inputNumbers.firstNum, inputNumbers.secondNum, inputNumbers.firstNum, inputNumbers.secondNum, len);
                await Response.WriteAsync((string)ans);
                return View();
            }
            else
            {
                return View(inputNumbers);
            }
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
