using System;

namespace MoneyExercise
{
    public class Money
    {
        private decimal amount;
        private Currency currency;
        private ForConvertingCurrencies currencyConverter;

        public Money(decimal amount, Currency currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public void SetCurrencyConverter(ForConvertingCurrencies currencyConverter)
        {
            this.currencyConverter = currencyConverter;
        }

        public Money add(Money other)
        {
            decimal convertedAmount = amount;
            if (currency != other.currency)
            {
                convertedAmount = currencyConverter.convert(amount, currency, other.currency);
            }
            return new Money(convertedAmount + other.amount, other.currency);
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