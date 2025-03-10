Feature: PriceCalculator
    In order to travel from one city to another
    As a customer
    I want to know the price of the ticket

@PriceCalculation
Scenario Outline: Calculate the ticket price
    Given the distance is <distance> km
    And the bus type is <busType>
    When the price is calculated
    Then the result should be <expectedPrice>

    Examples:
      | distance | busType  | expectedPrice |
      | 0        | Standard | 2500          |
      | 99       | Standard | 3490          |
      | 100      | Luxory   | 4747          |
      | 500      | Luxory   | 9547          |
      | 501      | Mini     | 4522.4        |
      | 10000    | Mini     | 38718.8       |


Scenario: Calculate the ticket price with negative distance
    Given the distance is -1 km
    And the bus type is Standard
    When the price is calculated with a negative value
    Then we should get an error
