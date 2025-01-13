using FinanceCalculator.Data;
using FinanceCalculator.Entities;
using FinanceCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCalculator.Controllers
{
    public class CreditCalculationController : Controller
    {
        private readonly ICreditCalculationService _creditCalculationService;
        private readonly FinanceCalculatorDbContext _context;

        // Inject dependencies
        public CreditCalculationController(ICreditCalculationService creditCalculationService, FinanceCalculatorDbContext context)
        {
            _creditCalculationService = creditCalculationService;
            _context = context;
        }

        // Action to display the data entry form
        public IActionResult Index()
        {
            return View();
        }

        // Action to calculate monthly payment, total payment and interest
        [HttpPost]
        public async Task<IActionResult> Calculate(Credit credit)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            try
            {
                credit.MonthlyPayment = _creditCalculationService.CalculateMonthlyPayment(credit.Amount, credit.InterestRate, credit.DurationMonths);
                credit.TotalPayment = _creditCalculationService.CalculateTotalPayment(credit.MonthlyPayment, credit.DurationMonths);
                credit.TotalInterest = _creditCalculationService.CalculateTotalInterest(credit.TotalPayment, credit.Amount);

                // Save to database
                _context.Credits!.Add(credit);
                await _context.SaveChangesAsync();

                return View("Result", credit);
            }
            catch (Exception)
            {
                // Handle errors
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View("Index");
            }
        }
    }
}
