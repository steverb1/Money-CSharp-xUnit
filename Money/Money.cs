using System;

namespace MoneyExercise
{
    public class Money
    {
        private decimal amount;
        private Currency currency;

        public Money(decimal amount, Currency currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public Money add(Money other)
        {
            return new Money(amount + other.amount, Currency.USD);
        }

        public override bool Equals(object obj)
        {
            return obj is Money money &&
                   amount == money.amount &&
                   currency == money.currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(amount, currency);
        }
    }
}