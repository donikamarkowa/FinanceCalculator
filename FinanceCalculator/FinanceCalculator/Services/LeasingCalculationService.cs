namespace FinanceCalculator.Services
{
    public class LeasingCalculationService : ILeasingCalculationService
    {
        public decimal CalculateMonthlyPayment(decimal leasingAmount, decimal interestRate, int durationMonths, decimal downPayment)
        {
            if (leasingAmount <= 0 || interestRate < 0 || durationMonths <= 0 || downPayment < 0)
                throw new ArgumentException("Invalid input parameters");

            decimal principal = leasingAmount - downPayment;
            decimal monthlyInterestRate = interestRate / 100 / 12;

            // If the interest rate is 0 or very close to zero
            if (monthlyInterestRate == 0)
            {
                // If the interest is 0 or very small, we simply distribute the principal amount evenly
                return decimal.Round(principal / durationMonths, 2);
            }

            decimal monthlyPayment = principal * monthlyInterestRate /
                (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -durationMonths));

            return decimal.Round(monthlyPayment, 2);
        }

        public decimal CalculateTotalPayment(decimal monthlyPayment, int durationMonths)
        {
            if (monthlyPayment <= 0 || durationMonths <= 0)
                throw new ArgumentException("Invalid input parameters");

            return monthlyPayment * durationMonths;
        }

        public decimal CalculateTotalInterest(decimal totalPayment, decimal leasingAmount, decimal downPayment)
        {
            if (totalPayment <= 0 || leasingAmount <= 0 || downPayment < 0)
                throw new ArgumentException("Invalid input parameters");

            decimal principal = leasingAmount - downPayment;
            decimal interest = totalPayment - principal; 

            return decimal.Round(interest, 2);
        }
    }
}
