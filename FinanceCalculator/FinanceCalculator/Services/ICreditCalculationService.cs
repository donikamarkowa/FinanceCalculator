namespace FinanceCalculator.Services
{
    public interface ICreditCalculationService
    {
        public decimal CalculateMonthlyPayment(decimal amount, decimal interestRate, int months);
        public decimal CalculateTotalPayment(decimal monthlyPayment, int months);
        public decimal CalculateTotalInterest(decimal totalPayment, decimal amount);
    }
}
