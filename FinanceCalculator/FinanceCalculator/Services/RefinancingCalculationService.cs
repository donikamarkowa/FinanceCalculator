namespace FinanceCalculator.Services
{
    public class RefinancingCalculationService : IRefinancingCalculationService
    {
        public decimal CalculateMonthlyPayment(decimal loanAmount, decimal interestRate, int durationMonths)
        {
            if (loanAmount <= 0 || interestRate <= 0 || durationMonths <= 0)
            {
                throw new ArgumentException("Loan amount, interest rate, and duration must be greater than 0.");
            }

            var monthlyRate = interestRate / 100 / 12;
            return loanAmount * monthlyRate / (1 - (decimal)Math.Pow((double)(1 + monthlyRate), -durationMonths));
        }

        public decimal CalculateTotalPayment(decimal monthlyPayment, int durationMonths)
        {
            if (monthlyPayment <= 0 || durationMonths <= 0)
            {
                throw new ArgumentException("Monthly payment and duration must be greater than 0.");
            }

            return monthlyPayment * durationMonths;
        }

        public decimal CalculateSavings(decimal currentLoanAmount, decimal totalNewPayment)
        {
            if (currentLoanAmount < 0 || totalNewPayment < 0)
            {
                throw new ArgumentException("Loan amount and total payment must not be negative.");
            }

            return currentLoanAmount - totalNewPayment;
        }
    }
}
