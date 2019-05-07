using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class DownloadReport
    {
        public static void Run()
        {
            // File will be created with the Data received in the Response Body

            // Provide the File Name
            const string fileName = "DownloadReport.csv";

            // Provide the path where the file needs to be downloaded
            // This can be either a relative path or an absolute path
            const string downloadFilePath = @".\Resource\" + fileName;

            const string organizationId = "testrest";
            const string reportName = "Demo_Report";
            var reportDate = DateTime.ParseExact("2018-10-18", "yyyy-MM-dd", CultureInfo.InvariantCulture);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportDownloadsApi(clientConfig);

                var content = apiInstance.DownloadReportWithHttpInfo(reportDate, reportName, organizationId);

                File.WriteAllText(downloadFilePath, CreateXml(content.Data));

                Console.WriteLine("\nFile downloaded at the below location:");
                Console.WriteLine($"{Path.GetFullPath(downloadFilePath)}\n");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found: Kindly verify the path");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }

        private static string CreateXml(object obj)
        {
            var xmlDoc = new XmlDocument();   // Represents an XML document
            var xmlSerializer = new XmlSerializer(obj.GetType()); // Initializes a new instance of the XmlDocument class.

            // Creates a stream whose backing store is memory.
            using (var xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, obj);
                xmlStream.Position = 0;

                // Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerText;
            }
        }
    }
}
