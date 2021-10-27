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
    }
}
