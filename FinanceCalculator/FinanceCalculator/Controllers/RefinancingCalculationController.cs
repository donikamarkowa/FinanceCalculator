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

        public RefinancingCalculationController(IRefinancingCalculationService refinancingService, FinanceCalculatorDbContext context)
        {
            _refinancingService = refinancingService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View("RefinancingIndex");
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(Refinancing refinancing)
        {
            if (!ModelState.IsValid)
            {
                return View("RefinancingIndex");
            }

            try
            {
                refinancing.MonthlyPayment = _refinancingService.CalculateMonthlyPayment(refinancing.CurrentLoanAmount, refinancing.NewInterestRate, refinancing.NewDurationMonths);
                refinancing.TotalPayment = _refinancingService.CalculateTotalPayment(refinancing.MonthlyPayment, refinancing.NewDurationMonths);
                refinancing.Savings = _refinancingService.CalculateSavings(refinancing.CurrentLoanAmount, refinancing.TotalPayment);

                _context.Refinancings!.Add(refinancing);
                await _context.SaveChangesAsync();

                return View("RefinancingResult", refinancing);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View("RefinancingIndex");
            }
        }
    }
}
