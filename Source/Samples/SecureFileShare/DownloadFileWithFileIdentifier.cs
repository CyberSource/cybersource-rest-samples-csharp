using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.SecureFileShare
{
    public class DownloadFileWithFileIdentifier
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static void Run()
        {
            var fileId = "QmF0Y2hGaWxlc0RldGFpbFJlcG9ydC5jc3YtMjAyMC0wMS0zMA==";
            const string fileName = "DownloadedFileWithFileID.csv";
            const string downloadFilePath = @".\Resource\" + fileName;
            string organizationId = "testrest";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new SecureFileShareApi(clientConfig);
                var content = apiInstance.GetFileWithHttpInfo(fileId, organizationId);

                // START : FILE DOWNLOAD FUNCTIONALITY
                File.WriteAllText(downloadFilePath, CreateXml(content.Data));

                Console.WriteLine("\nFile Downloaded at the following location : ");
                Console.WriteLine($"{Path.GetFullPath(downloadFilePath)}\n");
                WriteLogAudit(apiInstance.GetStatusCode());
                // END : FILE DOWNLOAD FUNCTIONALITY
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found : Kindly verify the path.");
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
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
