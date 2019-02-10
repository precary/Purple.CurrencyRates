using System;
using Purple.CurrencyRates.Client;
using Xunit;

namespace Purple.CurrencyRates.Test
{
    public class CurrencyRatesTest
    {
        [Fact]
        public void GetLatestEuroRates()
        {
            var res = EcbClient.GetLatestEuroRates();
            Assert.NotEmpty(res);
        }

        [Fact]
        public void GetAvailableCurrencies()
        {
            var res = EcbClient.GetAvailableCurrencies();
            Assert.NotEmpty(res);
        }

        [Fact]
        public void ConvertCurrencies()
        {
            var eur = 100;
            var eur_usd = EcbClient.Convert(eur, "EUR","USD");
            var eur_gbp = EcbClient.Convert(eur, "EUR","GBP");
            var eur_chf = EcbClient.Convert(eur, "EUR","CHF");

            var usdQ = 100;
            var usd_eur = EcbClient.Convert(usdQ, "USD", "EUR");
            var usd_gbp = EcbClient.Convert(usdQ, "USD", "GBP");
            var usd_chf = EcbClient.Convert(usdQ, "USD", "CHF");



            Assert.True(eur_usd > eur);
            Assert.True(eur_gbp < eur);
            Assert.True(eur_chf > eur);

            Assert.Throws<ArgumentException>(() => { EcbClient.Convert(100, "THC", "TNT"); });


        }
    }
}
