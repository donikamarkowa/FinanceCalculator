using FinanceCalculator.Data;
using FinanceCalculator.Entities;
using FinanceCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCalculator.Controllers
{
    public class RefinancingCalculationController : Controller
    {
        private readonly IRefinancingCalculationService _refinancingService;
        private readonly FinanceCalculatorDbContext _context;

        // Inject dependencies
        public RefinancingCalculationController(IRefinancingCalculationService refinancingService, FinanceCalculatorDbContext context)
        {
            _refinancingService = refinancingService;
            _context = context;
        }


        // Action to display the data entry form
        public IActionResult Index()
        {
            return View("RefinancingIndex");
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(Refinancing refinancing)
        {
            if (!ModelState.IsValid)
            {
                return View("RefinancingIndex", refinancing);
            }

            try
            {

                // Calculate the monthly payment
                refinancing.MonthlyPayment = _refinancingService.CalculateMonthlyPayment(refinancing.CurrentLoanAmount, refinancing.NewInterestRate, refinancing.NewDurationMonths);

                // Calculate the total payment
                refinancing.TotalPayment = _refinancingService.CalculateTotalPayment(refinancing.MonthlyPayment, refinancing.NewDurationMonths);

                // Calculate the savings from refinancing
                refinancing.Savings = _refinancingService.CalculateSavings(refinancing.CurrentLoanAmount, refinancing.TotalPayment);

                // Add the refinancing record to the database
                _context.Refinancings!.Add(refinancing);
                await _context.SaveChangesAsync();

                return View("RefinancingResult", refinancing);
            }
            catch (Exception)
            {
                // If an error occurs, add a model error and return the user to the form
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View("RefinancingIndex");
            }
        }
    }
}
