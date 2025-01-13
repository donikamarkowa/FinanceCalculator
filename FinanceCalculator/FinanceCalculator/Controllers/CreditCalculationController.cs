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

        // Инжектиране на зависимостите
        public CreditCalculationController(ICreditCalculationService creditCalculationService, FinanceCalculatorDbContext context)
        {
            _creditCalculationService = creditCalculationService;
            _context = context;
        }

        // Действие за показване на формата за въвеждане на данни
        public IActionResult Index()
        {
            return View();
        }

        // Действие за изчисляване на месечно плащане, общо плащане и лихви
        [HttpPost]
        public async Task<IActionResult> Calculate(Credit credit)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            try
            {
                // Изчисления
                credit.MonthlyPayment = _creditCalculationService.CalculateMonthlyPayment(credit.Amount, credit.InterestRate, credit.DurationMonths);
                credit.TotalPayment = _creditCalculationService.CalculateTotalPayment(credit.MonthlyPayment, credit.DurationMonths);
                credit.TotalInterest = _creditCalculationService.CalculateTotalInterest(credit.TotalPayment, credit.Amount);

                // Запазване в базата
                _context.Credits.Add(credit);
                await _context.SaveChangesAsync();

                return View("Result", credit);
            }
            catch (Exception)
            {
                // Обработка на грешки
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View("Index");
            }
        }
    }
}
