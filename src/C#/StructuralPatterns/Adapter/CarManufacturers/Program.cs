using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using Newtonsoft.Json;

namespace CarManufacturers
{
    public class Manufacturer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }
    }

    public static class ManufacturerDataProvider
    {
        public static List<Manufacturer> GetManufacturers() =>
            new List<Manufacturer>
            {
                new Manufacturer { City = "Italy", Name = "Alfa Romeo", Year = 2016 },
                new Manufacturer { City = "UK", Name = "Aston Martin", Year = 2018 },
                new Manufacturer { City = "USA", Name = "Dodge", Year = 2017 },
                new Manufacturer { City = "Japan", Name = "Subaru", Year = 2016 },
                new Manufacturer { City = "Germany", Name = "BMW", Year = 2015 }
            };
    }

    public class XmlConverter
    {
        public XDocument GetXML()
        {
            XDocument xDocument = new XDocument();
            XElement manufacturersRootXElement = new XElement("Manufacturers");

            IEnumerable<XElement> manufacturersXElements = ManufacturerDataProvider.GetManufacturers()
                .Select(m => new XElement(nameof(Manufacturer),
                    new XAttribute(nameof(Manufacturer.City), m.City),
                    new XAttribute(nameof(Manufacturer.Name), m.Name),
                    new XAttribute(nameof(Manufacturer.Year), m.Year)
                ));

            manufacturersRootXElement.Add(manufacturersXElements);
            xDocument.Add(manufacturersRootXElement);

            Console.WriteLine(xDocument);

            return xDocument;
        }
    }

    public interface IXMLToJsonTarget
    {
        void ConvertXMLToJson();
    }

    public class XMLToJsonAdapter : IXMLToJsonTarget
    {
        private readonly XmlConverter xmlConverter;

        public XMLToJsonAdapter(XmlConverter xmlConverter)
        {
            this.xmlConverter = xmlConverter;
        }

        public void ConvertXMLToJson()
        {
            IEnumerable<Manufacturer> manufacturersToConvertToJSON = xmlConverter.GetXML()
                .Elements("Manufacturers")
                .Elements("Manufacturer")
                .Select(m => new Manufacturer
                {
                    City = m.Attribute("City").Value,
                    Name = m.Attribute("Name").Value,
                    Year = Convert.ToInt32(m.Attribute("Year").Value)
                });

            new JsonConverterAdaptee(manufacturersToConvertToJSON).ConvertToJson();
        }
    }

    public class JsonConverterAdaptee
    {
        private IEnumerable<Manufacturer> manufacturers;

        public JsonConverterAdaptee(IEnumerable<Manufacturer> manufacturers)
        {
            this.manufacturers = manufacturers;
        }

        public void ConvertToJson()
        {
            string serializedManufacturersJSONString = JsonConvert.SerializeObject(manufacturers, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine("\nPrinting JSON array\n");
            Console.WriteLine(serializedManufacturersJSONString);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            XmlConverter xmlConverter = new XmlConverter();
            IXMLToJsonTarget xmlToJsonTarget = new XMLToJsonAdapter(xmlConverter);
            xmlToJsonTarget.ConvertXMLToJson();
        }
    }
}
