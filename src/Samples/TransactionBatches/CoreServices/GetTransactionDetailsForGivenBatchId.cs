// Code Generated: getTransactionBatchDetails[Get transaction details for a given batch id]

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionBatches.CoreServices
{
    public class GetTransactionDetailsForGivenBatchId
    {
        public static void Run()
        {
            var id = "12345";

            // Provide the File Name
            const string fileName = "BatchDetailsReport.csv";

            // Provide the path where the file needs to be downloaded
            // This can be either a relative path or an absolute path
            const string downloadFilePath = @".\Resource\" + fileName;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TransactionBatchesApi(clientConfig);
                var content = apiInstance.GetTransactionBatchDetailsWithHttpInfo(id);

                File.WriteAllText(downloadFilePath, CreateXml(content.Data));

                Console.WriteLine("\nDetails downloaded at the below location:");
                Console.WriteLine($"{Path.GetFullPath(downloadFilePath)}\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
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