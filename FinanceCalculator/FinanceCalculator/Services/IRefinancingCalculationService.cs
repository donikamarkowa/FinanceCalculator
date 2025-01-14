namespace FinanceCalculator.Services
{
    public interface IRefinancingCalculationService
    {
        decimal CalculateMonthlyPayment(decimal loanAmount, decimal interestRate, int durationMonths);
        decimal CalculateTotalPayment(decimal monthlyPayment, int durationMonths);
        decimal CalculateSavings(decimal currentLoanAmount, decimal totalNewPayment);
    }
}
