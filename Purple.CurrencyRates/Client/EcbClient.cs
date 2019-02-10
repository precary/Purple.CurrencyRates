/*
╔═══════════════════════════════════════════════════════════════╗
║         ____                   __    _____       ______       ║
║        / __ \__  ___________  / /__ / ___/____  / __/ /_      ║
║       / /_/ / / / / ___/ __ \/ / _ \\__ \/ __ \/ /_/ __/      ║
║      / ____/ /_/ / /  / /_/ / /  __/__/ / /_/ / __/ /_        ║
║     /_/    \__,_/_/  / .___/_/\___/____/\____/_/  \__/        ║
║                     /_/                                       ║
╚═══════════════════════════════════════════════════════════════╝
╔═══════════════════════════════════════════════════════════════╗
║    {                                                          ║
║        Author:     "Tiziano C.",                              ║
║        Company:    "PurpleSoft S.r.l.",                       ║
║        Email:      "developers@purplesoft.io",                ║
║        WebSite:    "https://purplesoft.io"                    ║
║    }                                                          ║
╚═══════════════════════════════════════════════════════════════╝
╔═══════════════════════════════════════════════════════════════╗
     {                                                          
         FileName:  "EcbClient.cs",                    
         DateTime:  "2/9/2019 8:38:24 PM"                                    
     }                                                          
╚═══════════════════════════════════════════════════════════════╝
╔═══════════════════════════════════════════════════════════════╗
║    Copyright (c) 2019 PurpleSoft S.r.l. All Rights Reserved   ║
╚═══════════════════════════════════════════════════════════════╝
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Purple.CurrencyRates.Models;

namespace Purple.CurrencyRates.Client
{
    public static class EcbClient
    {
        public const string EcbXmlUri = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
        public static EcbResponse CachedResponse { get; set; }
        public static List<Cube> GetLatestEuroRates()
        {
            using (var xml = XmlReader.Create(EcbXmlUri))
            {
                var xs = new XmlSerializer(typeof(EcbResponse));
                if (xs.CanDeserialize(xml))
                {
                    CachedResponse = xs.Deserialize(xml) as EcbResponse;
                }
            }
            return CachedResponse?.CubeWrapper.CubeList.Cubes;
        }
        public static List<string> GetAvailableCurrencies()
        {
           InitializeCache();

            return CachedResponse?.CubeWrapper.CubeList.Cubes.Select(s => s.Currency).OrderBy(o => o).ToList();
        }

        public static decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            InitializeCache();

            fromCurrency = fromCurrency.ToUpper();
            toCurrency = toCurrency.ToUpper();

            var fcc = CachedResponse?.CubeWrapper.CubeList.Cubes.FirstOrDefault(f => f.Currency.ToUpper() == fromCurrency);

            var tcc = CachedResponse?.CubeWrapper.CubeList.Cubes.FirstOrDefault(f => f.Currency.ToUpper() == toCurrency);

            if ((fcc == null && fromCurrency != "EUR") || (tcc == null && toCurrency != "EUR"))
                throw new ArgumentException("Selected currency not exists!");

            if (toCurrency == "EUR")
            {
                if (fromCurrency == "EUR")
                {
                    return amount;
                }
                return amount / fcc.Rate;
            }

            if (fromCurrency == "EUR")
            {
                return amount * tcc.Rate;
            }
            return (tcc.Rate * amount) / fcc.Rate;

        }

        private static void InitializeCache()
        {
            if (CachedResponse == null)
                GetLatestEuroRates();
        }
    }
}
