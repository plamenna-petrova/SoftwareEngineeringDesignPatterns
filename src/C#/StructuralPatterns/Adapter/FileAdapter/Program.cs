using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace FileAdapter
{
    public enum FileType
    {
        TXT,
        CSV,
        JSON,
        XML,
        PDF
    }

    public class Person
    {
        [Name("Identifier")]
        public int Id { get; set; }

        [Index(0)]
        public string Name { get; set; }

        [Index(2)]
        public bool IsLiving { get; set; }

        [Index(1)]
        public DateTime DateOfBirth { get; set; }
    }

    public interface IFileSaverTarget
    {
        void SaveToFile(List<Person> people);
    }

    public class FileSaverAdapter : IFileSaverTarget
    {
        private FileWriterAdaptee fileWriterAdaptee = new FileWriterAdaptee();

        public FileSaverAdapter(FileType fileType)
        {
            FileType = fileType;
        }

        public FileType FileType { get; private set; }

        public void SaveToFile(List<Person> people)
        {
            fileWriterAdaptee.WriteDataToFile(FileType, people);
            Console.WriteLine($"Successfully saved data to {FileType.ToString().ToLower()} file");
        }
    }

    public class FileWriterAdaptee
    {
        public void WriteDataToFile(FileType fileType, List<Person> people)
        {
            switch (fileType)
            {
                case FileType.TXT:
                    using (var txtStreamWriter = new StreamWriter("people.txt"))
                    {
                        foreach (var person in people)
                        {
                            var personPropertiesValues = person.GetType().GetProperties().Select(prop => prop.GetValue(person));
                            txtStreamWriter.WriteLine(string.Join("\t", personPropertiesValues));
                        }

                        txtStreamWriter.Close();
                    }
                    break;
                case FileType.CSV:
                    var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false
                    };

                    using (var csvStreamWriter = new StreamWriter("people.csv"))
                    using (var csvWriter = new CsvWriter(csvStreamWriter, csvConfiguration))
                    {
                        csvWriter.WriteRecords(people);
                    }
                    break;
                case FileType.JSON:
                    string serializedPeopleJSONString = JsonConvert.SerializeObject(people, Formatting.Indented);
                    File.WriteAllText("people.json", serializedPeopleJSONString);
                    break;
                case FileType.XML:
                    XDocument peopleXDocument = new XDocument();

                    XElement root = new XElement("Args");

                    List<XElement> peopleXElements = new List<XElement>();

                    foreach (var person in people)
                    {
                        XElement personXElement = new XElement(nameof(Person));

                        List<XElement> personXElements = new List<XElement>
                        {
                            new XElement(nameof(person.Id), person.Id),
                            new XElement(nameof(person.Name), person.Name),
                            new XElement(nameof(person.IsLiving), person.IsLiving),
                            new XElement(nameof(person.DateOfBirth), person.DateOfBirth)
                        };

                        personXElement.Add(personXElements);
                        peopleXElements.Add(personXElement);
                    }

                    root.Add(peopleXElements);

                    peopleXDocument.Add(root);

                    peopleXDocument.Save("people.xml");
                    break;
                case FileType.PDF:
                    var pdfFilePath = "people.pdf";

                    using (var fileStream = new FileStream(pdfFilePath, FileMode.Create))
                    {
                        using var pdfWriter = new PdfWriter(fileStream);
                        using var pdfDocument = new PdfDocument(pdfWriter);

                        var document = new Document(pdfDocument);

                        var pdfDocumentTable = new Table(typeof(Person).GetProperties().Length);

                        pdfDocumentTable.AddCell(nameof(Person.Id));
                        pdfDocumentTable.AddCell(nameof(Person.Name));
                        pdfDocumentTable.AddCell(nameof(Person.DateOfBirth));
                        pdfDocumentTable.AddCell(nameof(Person.IsLiving));

                        foreach (var person in people)
                        {
                            pdfDocumentTable.AddCell(person.Id.ToString());
                            pdfDocumentTable.AddCell(person.Name);
                            pdfDocumentTable.AddCell(person.DateOfBirth.ToShortDateString());
                            pdfDocumentTable.AddCell(person.IsLiving.ToString());
                        }

                        document.Add(pdfDocumentTable);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid file type!");
                    break;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person 
                { 
                    Id = 1, 
                    IsLiving = true, 
                    Name = "John", 
                    DateOfBirth = Convert.ToDateTime("03/05/2006") 
                },
                new Person 
                { 
                    Id = 2, 
                    IsLiving = true, 
                    Name = "Steve", 
                    DateOfBirth = Convert.ToDateTime("03/09/1998") 
                },
                new Person 
                { 
                    Id = 3, 
                    IsLiving = true, 
                    Name = "James", 
                    DateOfBirth = Convert.ToDateTime("03/08/1994") 
                }
            };

            IFileSaverTarget fileSaverTarget = new FileSaverAdapter(FileType.TXT);
            fileSaverTarget.SaveToFile(people);

            fileSaverTarget = new FileSaverAdapter(FileType.CSV);
            fileSaverTarget.SaveToFile(people);

            fileSaverTarget = new FileSaverAdapter(FileType.JSON);
            fileSaverTarget.SaveToFile(people);

            fileSaverTarget = new FileSaverAdapter(FileType.XML);
            fileSaverTarget.SaveToFile(people);

            fileSaverTarget = new FileSaverAdapter(FileType.PDF);
            fileSaverTarget.SaveToFile(people);
        }
    }
}
