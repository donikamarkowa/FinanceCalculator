using FinanceCalculator.Entities;
using FinanceCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCalculator.Controllers
{
    public class LeasingCalculationController : Controller
    {
        private readonly ILeasingCalculationService _leasingService;

        public LeasingCalculationController(ILeasingCalculationService leasingService)
        {
            _leasingService = leasingService;
        }

        public IActionResult Index()
        {
            return View("LeasingIndex");
        }

        [HttpPost]
        public IActionResult Calculate(Leasing leasing)
        {
            if (!ModelState.IsValid)
            {
                return View("LeasingIndex");
            }

            try
            {
                leasing.MonthlyPayment = _leasingService.CalculateMonthlyPayment(
                    leasing.LeasingAmount,
                    leasing.InterestRate,
                    leasing.DurationMonths,
                    leasing.DownPayment
                );
                leasing.TotalPayment = _leasingService.CalculateTotalPayment(leasing.MonthlyPayment, leasing.DurationMonths);
                leasing.TotalInterest = _leasingService.CalculateTotalInterest(
                    leasing.TotalPayment, leasing.LeasingAmount, leasing.DownPayment
                );

                return View("LeasingResult", leasing);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View("LeasingIndex");
            }
        }
    }
}
