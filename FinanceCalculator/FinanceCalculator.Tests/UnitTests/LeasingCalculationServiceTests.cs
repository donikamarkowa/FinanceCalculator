using FinanceCalculator.Services;

namespace FinanceCalculator.Tests
{
    public class LeasingCalculationServiceTests
    {
        private readonly LeasingCalculationService _service;

        public LeasingCalculationServiceTests()
        {
            _service = new LeasingCalculationService();
        }

        [Fact]
        public void CalculateMonthlyPayment_ValidData_ReturnsCorrectValue()
        {
            // Arrange
            decimal leasingAmount = 15000m;  
            decimal interestRate = 8m;  
            int durationMonths = 24;  
            decimal downPayment = 2000m;  

            decimal principal = leasingAmount - downPayment;  
            decimal monthlyInterestRate = interestRate / 100 / 12;  
            decimal expectedMonthlyPayment = principal * monthlyInterestRate /
                (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -durationMonths));

            // Act
            var result = _service.CalculateMonthlyPayment(leasingAmount, interestRate, durationMonths, downPayment);

            // Assert
            Assert.Equal(expectedMonthlyPayment, result, 2);
        }

        [Fact]
        public void CalculateMonthlyPayment_ZeroInterest_ReturnsCorrectValue()
        {
            // Arrange
            decimal leasingAmount = 15000m;
            decimal interestRate = 0m;
            int durationMonths = 24;
            decimal downPayment = 2000m;

            // Act
            var result = _service.CalculateMonthlyPayment(leasingAmount, interestRate, durationMonths, downPayment);

            // Assert
            Assert.Equal(13000m / 24, result, 2); 
        }


        [Fact]
        public void CalculateMonthlyPayment_InvalidData_ThrowsArgumentException()
        {
            // Arrange
            decimal leasingAmount = -5000m;
            decimal interestRate = 4m;
            int durationMonths = 24;
            decimal downPayment = 1000m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                _service.CalculateMonthlyPayment(leasingAmount, interestRate, durationMonths, downPayment));
        }

        [Fact]
        public void CalculateTotalPayment_ValidData_ReturnsCorrectValue()
        {
            // Arrange
            decimal monthlyPayment = 652.52m;
            int durationMonths = 24;

            // Act
            var result = _service.CalculateTotalPayment(monthlyPayment, durationMonths);

            // Assert
            Assert.Equal(15660.48m, result, 2); // Коригирайте в зависимост от реалните изчисления.
        }

        [Fact]
        public void CalculateTotalPayment_InvalidData_ThrowsArgumentException()
        {
            // Arrange
            decimal monthlyPayment = -100m;
            int durationMonths = 24;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                _service.CalculateTotalPayment(monthlyPayment, durationMonths));
        }

        [Fact]
        public void CalculateTotalInterest_ValidData_ReturnsCorrectValue()
        {
            // Arrange
            decimal totalPayment = 15660.48m;  
            decimal leasingAmount = 15000m;  
            decimal downPayment = 2000m;  

            // Act
            var result = _service.CalculateTotalInterest(totalPayment, leasingAmount, downPayment);

            // Assert
            Assert.Equal(2660.48m, result, 2);
        }

        [Fact]
        public void CalculateTotalInterest_InvalidData_ThrowsArgumentException()
        {
            // Arrange
            decimal totalPayment = -100m;
            decimal leasingAmount = 15000m;
            decimal downPayment = 2000m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                _service.CalculateTotalInterest(totalPayment, leasingAmount, downPayment));
        }
    }
}
