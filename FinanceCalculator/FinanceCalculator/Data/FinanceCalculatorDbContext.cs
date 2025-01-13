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

            // Config of the table Credir
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

        }

        public DbSet<Credit>? Credits { get; set; }
    }
}
