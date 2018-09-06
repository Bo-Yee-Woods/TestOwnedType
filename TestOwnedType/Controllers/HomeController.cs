using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestOwnedType.Cases;
using TestOwnedType.Cases.Three;
using TestOwnedType.Models;
using TestOwnedType.Models.DTOs;

namespace TestOwnedType.Controllers
{
    [ApiController]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly MyDbContext _myDbContext;

        public HomeController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpPost("Test")]        
        public async Task<IActionResult> Test(PaymentRecordDTO paymentRecordDTO)
        {
            var computedStampDutyValueObject = new ComputedStampDuty(
                    paymentRecordDTO.ComputedStampDuty.PropertyType,
                    paymentRecordDTO.ComputedStampDuty.BuyersStampDuty,
                    paymentRecordDTO.ComputedStampDuty.AdditionalBuyersStampDuty
                );

            var paymentRecordEntity = new PaymentRecordEntity(
                    paymentRecordDTO.DocumentRefNo, 
                    paymentRecordDTO.TotalAmount,
                    computedStampDutyValueObject);

            _myDbContext.Add(paymentRecordEntity);

            await _myDbContext.SaveChangesAsync();

            return Ok();
        } 

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
