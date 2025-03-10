using System;
using Reqnroll;
using Xunit;

namespace BusCompany.Specs.StepDefinitions;

[Binding]
public sealed class PriceCalculatorStepDefinitions
{
    private readonly PriceCalculator _priceCalculator = new PriceCalculator();
    private int _distance;
    private BusType _busType;
    private decimal _actualPrice;
    private Action _action;

    [Given(@"the distance is (.*) km")]
    public void GivenTheDistanceIsKm(int distance)
    {
        _distance = distance;
    }
    
    [Given(@"the bus type is (.*)")]
    public void GivenTheBusTypeIs(BusType busType)
    {
        _busType = busType;
    }
    
    [When(@"the price is calculated")]
    public void WhenThePriceIsCalculated()
    {
        _actualPrice = _priceCalculator.CalculatePrice(_distance, _busType);
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(decimal expectedPrice)
    {
        Assert.Equal(expectedPrice, _actualPrice);
    }

    [When(@"the price is calculated with a negative value")]
    public void WhenThePriceIsCalculatedWithANegativeValue()
    {
        _action = () => _actualPrice = _priceCalculator.CalculatePrice(_distance, _busType);
    }

    [Then(@"we should get an error")]
    public void ThenWeShouldGetAnError()
    {
        Assert.Throws<ArgumentException>(_action);
    }
}
