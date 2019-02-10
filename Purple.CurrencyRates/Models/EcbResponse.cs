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
         FileName:  "EcbResponse.cs",                    
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
    [XmlRoot(ElementName = "Envelope", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
    public class EcbResponse
    {
        [XmlElement(ElementName = "subject", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public string Subject { get; set; }

        [XmlElement(ElementName = "Sender", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public Sender Sender { get; set; }

        [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public CubeWrapper CubeWrapper { get; set; }

        [XmlAttribute(AttributeName = "gesmes", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Gesmes { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}