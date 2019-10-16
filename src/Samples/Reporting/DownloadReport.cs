using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class DownloadReport
    {
        public static void Run()
        {
            const string fileName = "DownloadedReport.csv";
            const string downloadFilePath = @".\Resource\" + fileName;
            string organizationId = "testrest";
            var reportDate = DateTime.ParseExact("2018-09-30", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string reportName = "Demo_Report";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReportDownloadsApi(clientConfig);
                var content = apiInstance.DownloadReportWithHttpInfo(reportDate, reportName, organizationId);

                // START : FILE DOWNLOAD FUNCTIONALITY
                File.WriteAllText(downloadFilePath, CreateXml(content.Data));

                Console.WriteLine("\nFile Downloaded at the following location : ");
                Console.WriteLine($"{Path.GetFullPath(downloadFilePath)}\n");
                // END : FILE DOWNLOAD FUNCTIONALITY
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found : Kindly verify the path.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }

        // START : STREAM SERIALIZER METHOD
        private static string CreateXml(object obj)
        {
            var xmlDoc = new XmlDocument(); // Represents an XML Document
            var xmlSerializer = new XmlSerializer(obj.GetType()); // Initializes a new instance of the XmlDocument class

            // Creates a stream whose backing store is memory
            using (var xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, obj);
                xmlStream.Position = 0;

                // Loads the XML document from the specified string
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerText;
            }
        }
        // END : STREAM SERIALIZER METHOD
    }
}
