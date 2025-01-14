using FinanceCalculator.Entities;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace FinanceCalculator.Data
{
    public class FinanceCalculatorDbContext : DbContext
    {
        public FinanceCalculatorDbContext(DbContextOptions<FinanceCalculatorDbContext> options)
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Config of the table Credit
            modelBuilder.Entity<Credit>(entity =>
            {
                entity.HasKey(e => e.Id); // Primary key

                entity.Property(e => e.Amount)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)"); // Amount of the credit

                entity.Property(e => e.InterestRate)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)"); // Interest rate

                entity.Property(e => e.MonthlyPayment)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)"); // Monthly payment

                entity.Property(e => e.TotalPayment)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)"); // Total payment

                entity.Property(e => e.TotalInterest)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)"); // Total interest

                entity.Property(e => e.DurationMonths)
                      .IsRequired(); // Duration in months
            });

            // Config of the table Refinancing
            modelBuilder.Entity<Refinancing>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CurrentLoanAmount)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.NewInterestRate)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.NewDurationMonths)
                      .IsRequired();

                entity.Property(e => e.MonthlyPayment)
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.TotalPayment)
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Savings)
                      .HasColumnType("decimal(18,2)");
            });

            // Config of the table Leasing
            modelBuilder.Entity<Leasing>(entity =>
            {
                entity.HasKey(e => e.Id); // Primary key

                entity.Property(e => e.LeasingAmount)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)"); // Leasing amount

                entity.Property(e => e.InterestRate)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)"); // Interest rate

                entity.Property(e => e.DurationMonths)
                      .IsRequired(); // Duration in months

                entity.Property(e => e.DownPayment)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)"); // Down payment

                entity.Property(e => e.MonthlyPayment)
                      .HasColumnType("decimal(18,2)"); // Monthly payment

                entity.Property(e => e.TotalPayment)
                      .HasColumnType("decimal(18,2)"); // Total payment

                entity.Property(e => e.TotalInterest)
                      .HasColumnType("decimal(18,2)"); // Total interest
            });

        }

        public DbSet<Credit>? Credits { get; set; }
        public DbSet<Refinancing>? Refinancings { get; set; }
        public DbSet<Leasing>? Leasings { get; set; }
    }
}
