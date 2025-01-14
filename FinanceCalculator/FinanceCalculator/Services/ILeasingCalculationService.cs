namespace FinanceCalculator.Services
{
    public interface ILeasingCalculationService
    {
        decimal CalculateMonthlyPayment(decimal leasingAmount, decimal interestRate, int durationMonths, decimal downPayment);
        decimal CalculateTotalPayment(decimal monthlyPayment, int durationMonths);
        decimal CalculateTotalInterest(decimal totalPayment, decimal leasingAmount, decimal downPayment);
    }
}
