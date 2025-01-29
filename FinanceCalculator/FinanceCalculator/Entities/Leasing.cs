using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceCalculator.Entities
{
    public class Leasing
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Leasing amount is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Leasing amount must be greater than 0.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LeasingAmount { get; set; }

        [Required(ErrorMessage = "Interest rate is required.")]
        [Range(0.01, 100, ErrorMessage = "Interest rate must be between 0.01% and 100%.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal InterestRate { get; set; }


        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be at least 1 month.")]
        public int DurationMonths { get; set; }


        [Required(ErrorMessage = "Down payment is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Down payment cannot be negative.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DownPayment { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyPayment { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPayment { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalInterest { get; set; }
    }
}
