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
                // File will be created with the Data received in the Response Body

                // Provide the File Name
                const string fileName = "DownloadFileWithFileIdentifier.csv";

                // Provide the path where the file needs to be downloaded
                // This can be either a relative path or an absolute path
                const string downloadFilePath = @".\Resource\" + fileName;

                var fileId = "dGVzdHJlc3Rfc3ViY3JpcHRpb25fdjI5ODktOTMwYWU5MmItOTcxMy00N2U4LWUwNTMtYTI1ODhlMGFjZDNjLnhtbC0yMDE5LTA5LTMw";
                var organizationId = "testrest";

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new SecureFileShareApi(clientConfig);

                var content = apiInstance.GetFileWithHttpInfo(fileId, organizationId);

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
