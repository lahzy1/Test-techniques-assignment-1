using Xunit;

namespace BusCompany.UnitTests
{
    public class PriceCalculatorTests
    {
        PriceCalculator calculator;

        public PriceCalculatorTests(){
            calculator = new PriceCalculator();
        }

        [Theory]
        [InlineData(0, BusType.Standard, 2500)]
        [InlineData(99, BusType.Standard, 3490)]
        [InlineData(100, BusType.Luxory, 4747)]
        [InlineData(500, BusType.Luxory, 9547)]
        [InlineData(501, BusType.Mini, 4522.4)]
        [InlineData(10000, BusType.Mini, 38718.8)]
        public void CalculatePrice_ValidInlineData_PriceIsCorrect(int distance, BusType busType, decimal expectedPrice)
        {
            //Act
            decimal price = calculator.CalculatePrice(distance, busType);
            
            //Assert
            Assert.Equal(expectedPrice, price);
        }

        [Fact]
        public void CalculatePrice_NegativeDistance_ThrowsException()
        {
            Assert.Throws<System.ArgumentException>(() => calculator.CalculatePrice(-1, BusType.Standard));
        }
    }
}
