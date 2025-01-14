namespace FinanceCalculator.Services
{
    public interface ICreditCalculationService
    {
        decimal CalculateMonthlyPayment(decimal amount, decimal interestRate, int months);
        decimal CalculateTotalPayment(decimal monthlyPayment, int months);
        decimal CalculateTotalInterest(decimal totalPayment, decimal amount);
    }
}
