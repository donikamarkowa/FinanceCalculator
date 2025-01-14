using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceCalculator.Entities
{
    public class Leasing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LeasingAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal InterestRate { get; set; }

        [Required]
        public int DurationMonths { get; set; }

        [Required]
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
