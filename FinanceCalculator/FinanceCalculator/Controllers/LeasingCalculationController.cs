using FinanceCalculator.Data;
using FinanceCalculator.Entities;
using FinanceCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCalculator.Controllers
{
    public class LeasingCalculationController : Controller
    {
        private readonly ILeasingCalculationService _leasingService;
        private readonly FinanceCalculatorDbContext _context;


        // Inject dependencies
        public LeasingCalculationController(ILeasingCalculationService leasingService, FinanceCalculatorDbContext context)
        {
            _leasingService = leasingService;
            _context = context;
        }

        // Action to display the data entry form
        public IActionResult Index()
        {
            return View("LeasingIndex");
        }

        [HttpPost]
        public async Task<IActionResult> CalculateAsync(Leasing leasing)
        {
            if (!ModelState.IsValid)
            {
                return View("LeasingIndex", leasing);
            }

            try
            {
                // Calculate the monthly payment using the leasing service
                leasing.MonthlyPayment = _leasingService.CalculateMonthlyPayment(
                    leasing.LeasingAmount,
                    leasing.InterestRate,
                    leasing.DurationMonths,
                    leasing.DownPayment
                );
                // Calculate the total payment based on the monthly payment and duration
                leasing.TotalPayment = _leasingService.CalculateTotalPayment(leasing.MonthlyPayment, leasing.DurationMonths);
                leasing.TotalInterest = _leasingService.CalculateTotalInterest(
                    leasing.TotalPayment, leasing.LeasingAmount, leasing.DownPayment
                );

                // Save the leasing data to the database
                _context.Leasings!.Add(leasing); // Add the leasing object to the database context
                await _context.SaveChangesAsync();

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
