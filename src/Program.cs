using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Cybersource_rest_samples_dotnet
{
    public class Program
    {
        // Create Dictionary object to be passed to the Merchant Config constructor
        // This Contains all Merchant level configurations like Merchant Key ID etc
        private static readonly IReadOnlyDictionary<string, string> ConfigDictionary = new Configuration().GetConfiguration();

        // List of all the all the APIs
        private static readonly List<Api> ApiList = new List<Api>();

        // List of Sample Code name for each API Call
        private static readonly List<string> ApiFunctionCalls = new List<string>();

        // List of Location Path for the Directories containing Sample Codes
        // The Paths are used to Call the Class File Dynamically (using Reflections) avoiding long switch case statements
        private static readonly List<string> SampleCodeClassesPathList = new List<string>();

        // Name of the Sample Code File to run for the current execution
        private static string _sampleToRun = string.Empty;

        public static void Main(string[] args)
        {
            // Set Network Settings (To Avoid SSL/TLS Secure Channel Error)
            SetNetworkSettings();

            // Initialize Api List and the paths of all the sample codes
            InitializeApiList();
            InitializeSampleClassesPathList();

            // Display all sample codes available to run
            ShowMethods();

            // Take the Input from user for which sample code to run
            SelectMethod();

            // Run the Sample Code as per user input
            RunSample(_sampleToRun);
        }

        public static void RunSample(string sampleClassName)
        {
            try
            {
                Console.WriteLine("\n");
                Type className = null;

                foreach (var path in SampleCodeClassesPathList)
                {
                    className = Type.GetType(path + sampleClassName);

                    if (className != null)
                    {
                        break;
                    }
                }

                if (className == null)
                {
                    Console.WriteLine("No Sample Code Found with the name: {0}", sampleClassName);
                    return;
                }

                var obj = Activator.CreateInstance(className);
                var methodInfo = className.GetMethod("Run");
                if (methodInfo != null)
                {
                    methodInfo.Invoke(obj, new object[] { ConfigDictionary });
                }
                else
                {
                    Console.WriteLine("No Run Method Found in the class: {0}", sampleClassName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in RunSample() Method: " + e.Message);

                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + e.InnerException.Message);
                    Console.WriteLine(e.InnerException.StackTrace);
                }

                Console.WriteLine(e.StackTrace);
            }
        }

        private static void SelectMethod()
        {
            var inputChar = Console.ReadKey();
            var inputString = new StringBuilder();

            while (inputChar.Key != ConsoleKey.Enter)
            {
                if (inputChar.Key == ConsoleKey.Tab)
                {
                    var bestMatch = GetBestMatch(inputString.ToString());
                    HandleTabInput(inputString, bestMatch);
                }
                else
                {
                    HandleKeyInput(inputString, inputChar);
                }

                inputChar = Console.ReadKey();
            }

            _sampleToRun = inputString.ToString();
        }

        private static void HandleTabInput(StringBuilder builder, string bestMatch)
        {
            if (string.IsNullOrEmpty(bestMatch))
            {
                return;
            }

            ClearCurrentLine();
            builder.Clear();

            Console.Write("Type a sample name & then press <Return> : " + bestMatch);
            builder.Append(bestMatch);
        }

        private static void HandleKeyInput(StringBuilder builder, ConsoleKeyInfo input)
        {
            var currentInput = builder.ToString();
            if (input.Key == ConsoleKey.Backspace && currentInput.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
                ClearCurrentLine();

                currentInput = currentInput.Remove(currentInput.Length - 1);
                Console.Write("Type a sample name & then press <Return> : " + currentInput);
            }
            else
            {
                var key = input.KeyChar;
                builder.Append(key);
            }
        }

        private static void ClearCurrentLine()
        {
            var currentLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLine);
        }

        private static void ShowMethods()
        {
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------");
            Console.WriteLine(" -                                    Code Sample Names                                            -");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------");

            var apiFamilies = new List<string>();

            foreach (var api in ApiList.Where(api => !apiFamilies.Contains(api.ApiFamily)))
            {
                apiFamilies.Add(api.ApiFamily);
            }

            foreach (var apiFamily in apiFamilies)
            {
                Console.WriteLine(" " + apiFamily.ToUpper() + " API'S   ");
                Console.WriteLine(" ---------------------------------------------------------------------------------------------------");

                var lineCharsCount = 0;
                const int nextLineCharsMaxCount = 85;
                var apirow = " - ";

                foreach (var api in ApiList.Where(api => api.ApiFamily == apiFamily).OrderBy(api => api.ApiFunctionCall))
                {
                    if (lineCharsCount + api.ApiFunctionCall.Length < nextLineCharsMaxCount)
                    {
                        apirow += " " + api.ApiFunctionCall + " | ";
                    }
                    else
                    {
                        Console.WriteLine(apirow);
                        apirow = " -  " + api.ApiFunctionCall + " | ";
                        lineCharsCount = 0;
                    }

                    lineCharsCount = lineCharsCount + api.ApiFunctionCall.Length;
                }

                Console.WriteLine(apirow);
                Console.WriteLine(" ---------------------------------------------------------------------------------------------------");
            }

            Console.WriteLine(string.Empty);
            Console.Write("Type a sample name & then press <Return> : ");
        }

        private static void InitializeApiList()
        {
            /*
             Initialization of Api List contains Following steps:-

                1. Find the Api Families (Folders inside the main 'Samples' Folder)

                For Each Api Family:-
                2. Fetch all the Files Paths inside Api Family folder (and all of its subfoldes)
                3. Create Api Object by providing value of Api Family and File Name (Extracted from File path).
                4. Add the Api Object to the ApiList List.
             */

            // 1. Find the Api Families (Folders inside the main 'Samples' Folder)
            const string pathOfSamplesFolder = @"C:\Users\glondhe\Documents\MAPPD-Projects\Rest-API\Authentication-sample-code\ClientSDK\cybersource-rest-samples-csharp\Samples\src\Samples";
            var dirList = Directory.GetDirectories(pathOfSamplesFolder, "*");
            var apiFamilies = new List<string>();

            foreach (var dir in dirList)
            {
                var dirModified = dir.Replace(' ', '_');
                dirModified = dirModified.Substring(pathOfSamplesFolder.Length + 1);
                dirModified = dirModified.Replace(@"\", ".");

                apiFamilies.Add(dirModified);
            }

            foreach (var apiFamily in apiFamilies)
            {
                // 2.Fetch all the Files Paths inside Api Family folder (and all of its subfoldes)
                var allfiles = Directory.GetFileSystemEntries(pathOfSamplesFolder + @"\" + apiFamily, "*.cs*", SearchOption.AllDirectories);

                foreach (var file in allfiles)
                {
                    var lastBackSlashIndex = file.LastIndexOf(@"\", StringComparison.Ordinal);
                    var firstPart = file.Remove(lastBackSlashIndex);
                    var secondPart = file.Substring(lastBackSlashIndex + 1, file.Length - firstPart.Length - 4);

                    ApiFunctionCalls.Add(secondPart);

                    // 3.Create Api Object by providing value of Api Family and File Name(Extracted from File path).
                    var newApi = new Api
                    {
                        ApiFamily = apiFamily,
                        ApiFunctionCall = secondPart
                    };

                    // 4.Add the Api Object to the ApiList List.
                    ApiList.Add(newApi);
                }
            }

            CheckDuplicateSampleCodes();
        }

        private static void CheckDuplicateSampleCodes()
        {
            // Verify if this Api Already exists in the Api List or not (FunctionCall must be unique)
            var duplicateListOutput = "Following Duplicate Sample Codes Found: ";
            bool duplicateFound = false;
            foreach (var apiFuncCall in ApiFunctionCalls)
            {
                if (ApiFunctionCalls.FindAll(x => x == apiFuncCall).Count > 1)
                {
                    duplicateListOutput += apiFuncCall + ", ";
                    duplicateFound = true;
                }
            }

            if (duplicateFound)
            {
                Console.WriteLine();
                Console.WriteLine("WARNING:");
                Console.WriteLine(duplicateListOutput);
                Console.WriteLine();
            }
        }

        private static void InitializeSampleClassesPathList()
        {
            const string pathOfSamplesFolder = @"C:\Users\glondhe\Documents\MAPPD-Projects\Rest-API\Authentication-sample-code\ClientSDK\cybersource-rest-samples-csharp\Samples\src\Samples";
            const string projectNamespace = "Cybersource_rest_samples_dotnet";

            // dirList has got all the folders and sub-folders for the Samples Folder Path
            var dirList = Directory.GetDirectories(pathOfSamplesFolder, "*", SearchOption.AllDirectories);
            foreach (var dir in dirList)
            {
                /*
                    Once we have the path of each folder,
                    we can use that to create the namespace names of all the sample codes,
                    inside the folder [Samples].
                */
                var dirModified = dir.Replace(' ', '_');
                dirModified = dirModified.Substring(pathOfSamplesFolder.Length + 1);
                dirModified = dirModified.Replace(@"\", ".");

                // SampleCodeClassesPathList is the complete list of all the possible namespaces for all the sample codes
                SampleCodeClassesPathList.Add(projectNamespace + ".Samples." + dirModified + ".");
            }
        }

        private static void SetNetworkSettings()
        {
            // setting servicepointmanager configs for SSL/TSL / Proxy issues
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
        }

        private static string GetBestMatch(string input)
        {
            var matchList = new List<string>();
            var bestMatches = new Dictionary<string, int>();
            var maxCharMatchCount = 0;

            foreach (var api in ApiList)
            {
                var charNo = 0;
                var charMatchCount = 0;
                var apiFunctionCall = api.ApiFunctionCall;

                while (charNo < input.Length && charNo < apiFunctionCall.Length)
                {
                    if (input[charNo] == apiFunctionCall[charNo])
                    {
                        charMatchCount++;
                    }
                    else
                    {
                        break;
                    }

                    charNo++;
                }

                if (charMatchCount > 0)
                {
                    bestMatches.Add(apiFunctionCall, charMatchCount);

                    if (charMatchCount > maxCharMatchCount)
                    {
                        maxCharMatchCount = charMatchCount;
                    }
                }
            }

            foreach (var api in bestMatches)
            {
                if (api.Value == maxCharMatchCount)
                {
                    matchList.Add(api.Key);
                    break; // just adding one best matching value is enough
                }
            }

            return matchList.FirstOrDefault();
        }
    }
}