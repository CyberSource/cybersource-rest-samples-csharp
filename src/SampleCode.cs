using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using NLog;

namespace Cybersource_rest_samples_dotnet
{
    public class SampleCode
    {
        private static readonly string PathOfSamplesFolder = $"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}Samples";

        private static readonly string ProjectNamespace = "Cybersource_rest_samples_dotnet";

        // List of all the all the APIs
        private static readonly List<Api> ApiList = new List<Api>();

        // List of Sample Code name for each API Call
        private static readonly List<string> ApiFunctionCalls = new List<string>();

        // List of Location Path for the Directories containing Sample Codes
        // The Paths are used to Call the Class File Dynamically (using Reflections) avoiding long switch case statements
        private static readonly List<string> SampleCodeClassesPathList = new List<string>();

        // Name of the Sample Code File to run for the current execution
        private static string _sampleToRun = string.Empty;

        // NLog Logger object
        private static Logger logger;

        public static void Main(string[] args)
        {
            // initializing logger object
            // LogManager.DisableLogging();
            logger = LogManager.GetCurrentClassLogger();
            logger.Trace("\n");
            logger.Trace("PROGRAM EXECUTION BEGINS");

            // Set Network Settings (To Avoid SSL/TLS Secure Channel Error)
            SetNetworkSettings();

            // Initialize Api List and the paths of all the sample codes
            InitializeApiList();
            InitializeSampleClassesPathList();

            if (args.Length == 1)
            {
                // Run the Sample Code as per input in the command line
                RunSample(args[0]);
                return;
            }

            // Display all sample codes available to run
            ShowMethods();

            // Run the Sample Code as per user input
            RunSample();

            logger.Trace("PROGRAM EXECUTION ENDS");
        }

        public static void RunSample(string cmdLineArg = null)
        {
            try
            {
                _sampleToRun = string.IsNullOrEmpty(cmdLineArg) ? Console.ReadLine() : cmdLineArg;
                logger.Trace($"Input provided for Sample Code to Run: {_sampleToRun}");

                Console.WriteLine("\n");
                Type className = null;

                foreach (var path in SampleCodeClassesPathList)
                {
                    className = Type.GetType(path + _sampleToRun);

                    if (className != null)
                    {
                        logger.Trace($"Sample Code found in the namespace: {path}");
                        break;
                    }
                }

                if (className == null)
                {
                    logger.Warn("No Sample Code Found with the name: {0}", _sampleToRun);
                    Console.WriteLine("No Sample Code Found with the name: {0}", _sampleToRun);

                    if (cmdLineArg == null)
                    {
                        ShowMethods();
                        RunSample();
                    }

                    return;

                }

                var obj = Activator.CreateInstance(className);
                var methodInfo = className.GetMethod("Run");
                if (methodInfo != null)
                {
                    logger.Trace($"Invoking Run() method of {_sampleToRun}");
                    methodInfo.Invoke(obj, null);
                }
                else
                {
                    logger.Warn($"No Run Method Found in the class: {_sampleToRun}");
                    Console.WriteLine("No Run Method Found in the class: {0}", _sampleToRun);

                    if (cmdLineArg == null)
                    {
                        ShowMethods();
                        RunSample();
                    }

                    return;
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

            if (cmdLineArg == null)
            {
                ShowMethods();
                RunSample();
            }
        }

        private static void ShowMethods()
        {
            logger.Trace("Beginning to Show All Sample Codes on Console");

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
                logger.Trace($"Showing Sample Codes for Api Family: {apiFamily}");

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

            logger.Trace("All Sample Codes Shown on Console");
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
            logger.Trace($"Samples Folder At:{Path.GetFullPath(PathOfSamplesFolder)}");

            var dirList = Directory.GetDirectories(PathOfSamplesFolder, "*");
            var apiFamilies = new List<string>();

            foreach (var dir in dirList)
            {
                var dirModified = dir.Replace(' ', '_');
                dirModified = dirModified.Substring(PathOfSamplesFolder.Length + 1);
                dirModified = dirModified.Replace(@"\", ".");

                apiFamilies.Add(dirModified);
            }

            foreach (var apiFamily in apiFamilies)
            {
                // 2.Fetch all the Files Paths inside Api Family folder (and all of its subfoldes)
                var allfiles = Directory.GetFileSystemEntries(PathOfSamplesFolder + @"\" + apiFamily, "*.cs*", SearchOption.AllDirectories);

                logger.Trace($"Api Family: {apiFamily}");
                logger.Trace($"Total Sample Codes Detected: {allfiles.Count()}");

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
                logger.Warn("DUPLICATE SAMPLE CODES DETECTED!");
                Console.WriteLine();
                Console.WriteLine("WARNING:");
                Console.WriteLine(duplicateListOutput);
                Console.WriteLine();
            }
        }

        private static void InitializeSampleClassesPathList()
        {
            // dirList has got all the folders and sub-folders for the Samples Folder Path
            var dirList = Directory.GetDirectories(PathOfSamplesFolder, "*", SearchOption.AllDirectories);
            logger.Trace($"Project Namespace value provided: {ProjectNamespace}");

            foreach (var dir in dirList)
            {
                /*
                    Once we have the path of each folder,
                    we can use that to create the namespace names of all the sample codes,
                    inside the folder [Samples].
                */
                var dirModified = dir.Replace(' ', '_');
                dirModified = dirModified.Substring(PathOfSamplesFolder.Length + 1);
                dirModified = dirModified.Replace(@"\", ".");

                // SampleCodeClassesPathList is the complete list of all the possible namespaces for all the sample codes
                SampleCodeClassesPathList.Add(ProjectNamespace + ".Samples." + dirModified + ".");
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
    }
}