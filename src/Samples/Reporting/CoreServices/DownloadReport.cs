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
            const string reportName = "testrest_v2";
            var reportDate = "2018-09-02";

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportDownloadsApi(clientConfig);

                var result = apiInstance.DownloadReportWithHttpInfo(reportDate, reportName, organizationId);
                Console.WriteLine(result);

                File.WriteAllText(downloadFilePath, CreateXml(result.Data));
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
                return xmlDoc.InnerXml;
            }
        }

        //private static object CreateObject(string xmlString, object obj)
        //{
        //    var oXmlSerializer = new XmlSerializer(obj.GetType());

        //    // The StringReader will be the stream holder for the existing XML file
        //    obj = oXmlSerializer.Deserialize(new StringReader(xmlString));

        //    // initially deserialized, the data is represented by an object without a defined type
        //    return obj;
        //}

        //private class Report
        //{
        //    public string ReportName { get; set; }

        //    public string Type { get; set; }

        //    public string OrganizationID { get; set; }

        //    public string ReportStartDate { get; set; }

        //    public string ReportEndDate { get; set; }

        //    public Request Request { get; set; }
        //}

        //private class Request
        //{
        //    public string RequestID { get; set; }

        //    public string RequestDate { get; set; }

        //    public string MerchantID { get; set; }
        //}
    }
}
