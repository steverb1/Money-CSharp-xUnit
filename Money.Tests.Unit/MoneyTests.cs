using FluentAssertions;
using Money.Tests.Unit;
using Moq;
using Xunit;

namespace MoneyExercise.Tests.Unit
{
    public class MoneyTests
    {
        [Fact]
        public void OnePlusTwo_EqualsThree()
        {
            Money money1 = new Money(1.0m, Currency.USD);
            Money money2 = new Money(2.0m, Currency.USD);
            Money sum = money1.add(money2);

            Money expectedResult = new Money(3.0m, Currency.USD);
            Assert.Equal(sum, expectedResult);
        }

        [Fact]
        public void ThreePlusFive_EqualsEight()
        {
            Money money1 = new Money(3.0m, Currency.USD);
            Money money2 = new Money(5.0m, Currency.USD);
            Money sum = money1.add(money2);

            Money expectedResult = new Money(8.0m, Currency.USD);
            Assert.Equal(sum, expectedResult);
        }

        [Fact]
        public void ThreeUsdPlusFiveInr_ReturnsSumInInr_Stub()
        {
            Money money1 = new Money(3.0m, Currency.USD);
            Money money2 = new Money(5.0m, Currency.INR);
            money1.SetCurrencyConverter(new ExchangeServiceStub());
            Money sum = money1.add(money2);

            Money expectedResult = new Money(11.0m, Currency.INR);
            sum.Should().Be(expectedResult);
        }

        [Fact]
        public void ThreeUsdPlusFiveInr_ReturnsSumInInr_Mock()
        {
            Mock<ForConvertingCurrencies> mockService = new Mock<ForConvertingCurrencies>();
            mockService.Setup(s => s.convert(3.0M, Currency.USD, Currency.INR)).Returns(6.0m);

            Money money1 = new Money(3.0m, Currency.USD);
            Money money2 = new Money(5.0m, Currency.INR);
            money1.SetCurrencyConverter(mockService.Object);
            Money sum = money1.add(money2);

            Money expectedResult = new Money(11.0m, Currency.INR);
            Assert.Equal(sum, expectedResult);
            mockService.VerifyAll();
        }
    }
}
