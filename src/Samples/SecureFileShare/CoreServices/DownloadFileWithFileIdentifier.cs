using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.SecureFileShare.CoreServices
{
    public class DownloadFileWithFileIdentifier
    {
        public static void Run()
        {
            try
            {
                const string downloadFilePath = @"C:\CYBS\3935\Solutions\cybersource-rest-samples-csharp\src\report_DownloadFileWithFileIdentifier.csv";
                var fileId = "VFJSUmVwb3J0LTc4NTVkMTNmLTkzOTgtNTExMy1lMDUzLWEyNTg4ZTBhNzE5Mi5jc3YtMjAxOC0xMC0yMA==";
                var organizationId = "testrest";

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new SecureFileShareApi(clientConfig);

                var result = apiInstance.GetFileWithHttpInfo(fileId, organizationId);
                Console.WriteLine(result);
                File.WriteAllText(downloadFilePath, CreateXml(result.Data));
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
    }
}
