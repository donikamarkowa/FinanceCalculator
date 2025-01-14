namespace FinanceCalculator.Services
{
    public class RefinancingCalculationService : IRefinancingCalculationService
    {
        public decimal CalculateMonthlyPayment(decimal loanAmount, decimal interestRate, int durationMonths)
        {
            var monthlyRate = interestRate / 100 / 12;
            return loanAmount * monthlyRate / (1 - (decimal)Math.Pow((double)(1 + monthlyRate), -durationMonths));
        }

        public decimal CalculateTotalPayment(decimal monthlyPayment, int durationMonths)
        {
            return monthlyPayment * durationMonths;
        }

        public decimal CalculateSavings(decimal currentLoanAmount, decimal totalNewPayment)
        {
            return currentLoanAmount - totalNewPayment;
        }
    }
}
