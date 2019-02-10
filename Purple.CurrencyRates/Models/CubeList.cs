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
         FileName:  "CubeList.cs",                    
         DateTime:  "2/10/2019 3:48:24 PM"                                    
     }                                                          
╚═══════════════════════════════════════════════════════════════╝
╔═══════════════════════════════════════════════════════════════╗
║    Copyright (c) 2019 PurpleSoft S.r.l. All Rights Reserved   ║
╚═══════════════════════════════════════════════════════════════╝
*/

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Purple.CurrencyRates.Models
{
    public class CubeList
    {
        [XmlAttribute(AttributeName = "time")]
        public DateTime ExchangeDate { get; set; }

        [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public List<Cube> Cubes { get; set; }
    }
}