namespace FinanceCalculator.Services
{
    public class CreditCalculationService : ICreditCalculationService
    {
        public decimal CalculateMonthlyPayment(decimal amount, decimal interestRate, int months)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.");
            if (interestRate < 0) throw new ArgumentException("Interest rate must not be negative.");
            if (months <= 0) throw new ArgumentException("Number of months must be greater than zero.");

            decimal monthlyInterestRate = interestRate / 100 / 12; // monthly interest rate

            // If interest rate is 0, the formula will be different (simple division)
            if (monthlyInterestRate == 0)
            {
                return amount / months;
            }

            decimal denominator = (decimal)Math.Pow((double)(1 + monthlyInterestRate), months) - 1;
            decimal monthlyPayment = amount * monthlyInterestRate / (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -months));

            return monthlyPayment;
        }

        public decimal CalculateTotalPayment(decimal monthlyPayment, int months)
        {
            if (monthlyPayment <= 0) throw new ArgumentException("Monthly payment must be greater than zero.");
            if (months <= 0) throw new ArgumentException("Number of months must be greater than zero.");

            return monthlyPayment * months;
        }

        public decimal CalculateTotalInterest(decimal totalPayment, decimal amount)
        {
            if (totalPayment <= 0) throw new ArgumentException("Total payment must be greater than zero.");
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.");

            return totalPayment - amount;
        }
    }
}
