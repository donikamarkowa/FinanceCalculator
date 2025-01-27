using FinanceCalculator.Services;

public class RefinancingCalculationServiceTests
{
    private readonly RefinancingCalculationService _service;

    public RefinancingCalculationServiceTests()
    {
        _service = new RefinancingCalculationService();
    }

    [Fact]
    public void CalculateMonthlyPayment_ValidData_ReturnsCorrectValue()
    {
        // Arrange
        decimal loanAmount = 15000m;
        decimal interestRate = 4m;
        int durationMonths = 24;

        // Act
        var result = _service.CalculateMonthlyPayment(loanAmount, interestRate, durationMonths);

        // Assert
        Assert.Equal(651.37m, result, 2); 
    }


    [Fact]
    public void CalculateMonthlyPayment_InvalidData_ThrowsArgumentException()
    {
        // Arrange
        decimal loanAmount = -5000m;
        decimal interestRate = 4m;
        int durationMonths = 24;

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            _service.CalculateMonthlyPayment(loanAmount, interestRate, durationMonths));
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
        Assert.Equal(15660.48m, result, 2);
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
    public void CalculateSavings_ValidData_ReturnsCorrectValue()
    {
        // Arrange
        decimal currentLoanAmount = 20000m;
        decimal totalNewPayment = 15660.48m;

        // Act
        var result = _service.CalculateSavings(currentLoanAmount, totalNewPayment);

        // Assert
        Assert.Equal(4339.52m, result, 2);
    }

    [Fact]
    public void CalculateSavings_InvalidData_ThrowsArgumentException()
    {
        // Arrange
        decimal currentLoanAmount = -20000m;
        decimal totalNewPayment = 15660.48m;

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            _service.CalculateSavings(currentLoanAmount, totalNewPayment));
    }
}
