namespace MoneyExercise
{
    public interface ForConvertingCurrencies
    {
        decimal convert(decimal amount, Currency inputCurrency, Currency targetCurrency);
    }
}
