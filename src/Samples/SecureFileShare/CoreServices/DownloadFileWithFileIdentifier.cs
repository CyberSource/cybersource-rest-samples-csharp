using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CyberSource.Api;
using CyberSource.Client;

namespace Cybersource_rest_samples_dotnet.Samples.SecureFileShare.CoreServices
{
    public class DownloadFileWithFileIdentifier
    {
        public static void Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(DownloadFileWithFileIdentifier)}");

            CyberSource.Client.Configuration clientConfig = null;
            ApiResponse<object> result = null;

            try
            {
                // File will be created with the Data received in the Response Body

                // Provide the File Name
                const string fileName = "DownloadFileWithFileIdentifier.csv";

                // Provide the path where the file needs to be downloaded
                // This can be either a relative path or an absolute path
                const string downloadFilePath = @".\Resource\" + fileName;

                var fileId = "VFJSUmVwb3J0LTc4NTVkMTNmLTkzOTgtNTExMy1lMDUzLWEyNTg4ZTBhNzE5Mi5jc3YtMjAxOC0xMC0yMA==";
                var organizationId = "testrest";

                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new SecureFileShareApi(clientConfig);

                result = apiInstance.GetFileWithHttpInfo(fileId, organizationId);

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
                Console.WriteLine($"\nException on calling the Sample Code({nameof(DownloadFileWithFileIdentifier)}):{e.Message}");
            }
            finally
            {
                if (clientConfig != null)
                {
                    // PRINTING REQUEST DETAILS
                    if (clientConfig.ApiClient.Configuration.RequestHeaders != null)
                    {
                        Console.WriteLine("\nAPI REQUEST HEADERS:");
                        foreach (var requestHeader in clientConfig.ApiClient.Configuration.RequestHeaders)
                        {
                            Console.WriteLine(requestHeader);
                        }
                    }

                    // PRINTING RESPONSE DETAILS
                    if (clientConfig.ApiClient.ApiResponse != null)
                    {
                        if (!string.IsNullOrEmpty(clientConfig.ApiClient.ApiResponse.StatusCode.ToString()))
                        {
                            Console.WriteLine($"\nAPI RESPONSE CODE: {clientConfig.ApiClient.ApiResponse.StatusCode}");
                        }

                        Console.WriteLine("\nAPI RESPONSE HEADERS:");

                        foreach (var responseHeader in clientConfig.ApiClient.ApiResponse.HeadersList)
                        {
                            Console.WriteLine(responseHeader);
                        }

                        Console.WriteLine("\nAPI RESPONSE BODY:");
                        Console.WriteLine(clientConfig.ApiClient.ApiResponse.Data);
                    }

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(DownloadFileWithFileIdentifier)}");
                }
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