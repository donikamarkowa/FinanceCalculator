namespace FinanceCalculator.Services
{
    public class LeasingCalculationService : ILeasingCalculationService
    {
        public decimal CalculateMonthlyPayment(decimal leasingAmount, decimal interestRate, int durationMonths, decimal downPayment)
        {
            decimal principal = leasingAmount - downPayment;
            decimal monthlyInterestRate = interestRate / 100 / 12;
            decimal monthlyPayment = principal * monthlyInterestRate /
                (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -durationMonths));
            return monthlyPayment;
        }

        public decimal CalculateTotalPayment(decimal monthlyPayment, int durationMonths)
        {
            return monthlyPayment * durationMonths;
        }

        public decimal CalculateTotalInterest(decimal totalPayment, decimal leasingAmount, decimal downPayment)
        {
            return totalPayment - (leasingAmount - downPayment);
        }
    }
}
