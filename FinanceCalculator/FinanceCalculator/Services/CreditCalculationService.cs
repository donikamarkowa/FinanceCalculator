namespace FinanceCalculator.Services
{
    public class CreditCalculationService : ICreditCalculationService
    {
        // Calculate monthly payment
        public decimal CalculateMonthlyPayment(decimal amount, decimal interestRate, int months)
        {
            decimal monthlyInterestRate = interestRate / 100 / 12; // monthly interest rate
            decimal denominator = (decimal)Math.Pow((double)(1 + monthlyInterestRate), months) - 1;
            decimal monthlyPayment = amount * monthlyInterestRate / (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -months));
            return monthlyPayment;
        }

        // Calculate total payment
        public decimal CalculateTotalPayment(decimal monthlyPayment, int months)
        {
            return monthlyPayment * months;
        }

        // Calculate Total Interest
        public decimal CalculateTotalInterest(decimal totalPayment, decimal amount)
        {
            return totalPayment - amount;
        }
    }
}
