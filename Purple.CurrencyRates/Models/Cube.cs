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
         FileName:  "Cube.cs",                    
         DateTime:  "2/10/2019 3:38:24 PM"                                    
     }                                                          
╚═══════════════════════════════════════════════════════════════╝
╔═══════════════════════════════════════════════════════════════╗
║    Copyright (c) 2019 PurpleSoft S.r.l. All Rights Reserved   ║
╚═══════════════════════════════════════════════════════════════╝
*/

using System.Xml.Serialization;

namespace Purple.CurrencyRates.Models
{
    [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public class Cube
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }

        [XmlAttribute(AttributeName = "rate")]
        public decimal Rate { get; set; }
    }
}