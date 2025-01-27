using FinanceCalculator.Services;

namespace FinanceCalculator.Tests
{
    public class CreditCalculationServiceTests
    {
        private readonly CreditCalculationService _service;

        public CreditCalculationServiceTests()
        {
            _service = new CreditCalculationService();
        }

        [Fact]
        public void CalculateMonthlyPayment_ZeroInterest_ReturnsCorrectValue()
        {
            // Arrange
            decimal amount = 15000m;
            decimal interestRate = 0m;
            int months = 24;

            // Act
            var result = _service.CalculateMonthlyPayment(amount, interestRate, months);

            // Assert
            Assert.Equal(15000m / 24, result);
        }

        [Fact]
        public void CalculateMonthlyPayment_ValidData_ReturnsCorrectValue()
        {
            // Arrange
            decimal amount = 15000m;
            decimal interestRate = 8m;
            int months = 24;

            // Act
            var result = _service.CalculateMonthlyPayment(amount, interestRate, months);

            // Assert
            var expected = 15000m * (interestRate / 100 / 12) /
                (1 - (decimal)Math.Pow((double)(1 + interestRate / 100 / 12), -months));
            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void CalculateMonthlyPayment_NegativeAmount_ThrowsArgumentException()
        {
            // Arrange
            decimal amount = -15000m;
            decimal interestRate = 8m;
            int months = 24;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _service.CalculateMonthlyPayment(amount, interestRate, months));
        }

        [Fact]
        public void CalculateMonthlyPayment_NegativeInterestRate_ThrowsArgumentException()
        {
            // Arrange
            decimal amount = 15000m;
            decimal interestRate = -8m;
            int months = 24;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _service.CalculateMonthlyPayment(amount, interestRate, months));
        }

        [Fact]
        public void CalculateMonthlyPayment_ZeroMonths_ThrowsArgumentException()
        {
            // Arrange
            decimal amount = 15000m;
            decimal interestRate = 8m;
            int months = 0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _service.CalculateMonthlyPayment(amount, interestRate, months));
        }

        [Fact]
        public void CalculateTotalPayment_ValidData_ReturnsCorrectValue()
        {
            // Arrange
            decimal monthlyPayment = 541.67m;
            int months = 24;

            // Act
            var result = _service.CalculateTotalPayment(monthlyPayment, months);

            // Assert
            Assert.Equal(monthlyPayment * months, result);
        }

        [Fact]
        public void CalculateTotalPayment_NegativeMonthlyPayment_ThrowsArgumentException()
        {
            // Arrange
            decimal monthlyPayment = -541.67m;
            int months = 24;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _service.CalculateTotalPayment(monthlyPayment, months));
        }

        [Fact]
        public void CalculateTotalInterest_ValidData_ReturnsCorrectValue()
        {
            // Arrange
            decimal totalPayment = 15660.48m;
            decimal amount = 15000m;

            // Act
            var result = _service.CalculateTotalInterest(totalPayment, amount);

            // Assert
            Assert.Equal(totalPayment - amount, result, 2);
        }

        [Fact]
        public void CalculateTotalInterest_NegativeTotalPayment_ThrowsArgumentException()
        {
            // Arrange
            decimal totalPayment = -15660.48m;
            decimal amount = 15000m;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _service.CalculateTotalInterest(totalPayment, amount));
        }

        [Fact]
        public void CalculateTotalInterest_NegativeAmount_ThrowsArgumentException()
        {
            // Arrange
            decimal totalPayment = 15660.48m;
            decimal amount = -15000m;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _service.CalculateTotalInterest(totalPayment, amount));
        }
    }
}
