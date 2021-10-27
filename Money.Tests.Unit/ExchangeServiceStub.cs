namespace MoneyExercise
{
    public class ExchangeServiceStub : ForConvertingCurrencies
    {
        public decimal convert(decimal amount, Currency inputCurrency, Currency targetCurrency)
        {
            return amount * 2;
        }
    }
}
