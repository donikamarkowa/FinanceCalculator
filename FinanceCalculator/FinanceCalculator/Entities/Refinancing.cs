using System.ComponentModel.DataAnnotations;

namespace FinanceCalculator.Entities
{
    public class Refinancing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "The current loan amount must be greater than 0.")]
        public decimal CurrentLoanAmount { get; set; }

        [Required]
        [Range(0.01, 100.0, ErrorMessage = "The interest rate must be between 0.01 and 100.")]
        public decimal NewInterestRate { get; set; }

        [Required]
        [Range(1, 360, ErrorMessage = "The duration must be between 1 and 360 months.")]
        public int NewDurationMonths { get; set; }

        public decimal MonthlyPayment { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal Savings { get; set; }
    }
}
