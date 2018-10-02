using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CybsPayments
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
        private static readonly List<string> SampleClassesPathList = new List<string>();

        // Name of the Sample Code File to run for the current execution
        private static string _sampleToRun = string.Empty;

        public static void Main(string[] args)
        {
            // Set Network Settings (To Avoid SSL/TLS Secure Channel Error)
            SetNetworkSettings();

            InitializeApiList();
            InitializeSampleClassesPathList();

            // Take the Input from user for which sample code to run
            SelectMethod();

            // Run the Sample Code as per user input
            RunSample(_sampleToRun);
        }

        public static void RunSample(string sampleClassName)
        {
            Console.WriteLine("\n");
            Type className = null;

            foreach (var path in SampleClassesPathList)
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

        private static void SelectMethod()
        {
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------");
            Console.WriteLine(" -                                    Code Sample Names                                            -");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------");
            ShowMethods();
            Console.WriteLine(string.Empty);
            Console.Write("Type a sample name & then press <Return> : ");

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

                foreach (var api in ApiList.Where(api => api.ApiFamily == apiFamily))
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
        }

        private static void InitializeApiList()
        {
            const string apiList =
                "Payments:AuthorizationOnly|Payments:AuthReversal|Payments:CapturePayment|Payments:StandaloneCredit|Payments:FollowOnCredit" +
                "|Payments:VoidAPayment|Payments:AuthorizationOnlyInternet|Payments:RetailPosStandardKey|Payments:RetailPosStandardSwipe" +
                "|Payments:RetailEmvContact|Payments:AuthorizationOnlyNonRetail|Payments:AuthorizationOnlyCommerceIndicatorMoto" +
                "|Payments:RecurringIndicator|Payments:AltTestHaveQuestions|Payments:MirvAuthReversal|Payments:OriginalRequestAuth|Payments:Void" +
                "|Payments:PaymentNetworkTokenization|Payments:CyberSourcePaymentTokenization|Payments:Emv|Payments:Bluefin" +
                "|Payments:AuthorizeSamsungPayCyberSourceDecryption|Payments:SamsungPayRetailEmvMsd" +
                "|Payments:SamsungPayRetailRetailEmvContactless|Payments:SamsungPayRetailRetailEmvCcontact" +
                "|Payments:AuthorizeSamsungPayMerchantDecryption|Payments:ChasePay|Payments:AuthorizeApplePayCyberSourceDecryption" +
                "|Payments:ApplePay|Payments:AuthorizeApplePayMerchantDecryption|Payments:AuthorizeGooglePayCyberSourceDecryption" +
                "|Payments:GooglePay|Payments:AuthorizeGooglePayMerchantDecryption|Payments:AuthorizeAndroidPayCyberSourceDecryption" +
                "|Payments:AndroidPay|Payments:AuthorizeAndroidPayMerchantDecryption|Payments:Visa|Payments:MasterCard|Payments:MaestroSecureCode" +
                "|Payments:SoloUk|Payments:AvsUsAmericanExpress|Payments:AvsUsDiscover|Payments:AvsUsMasterCard|Payments:AvsUsVisa" +
                "|Payments:AvsNonUsSoloUk|Payments:AvsNonUsMaestroInternational|Payments:AvsNonUsAmexOptima|Payments:AvsNonUsMaestroUkDomestic" +
                "|Payments:AvsNonUsVisa|Payments:AvsRelaxNonRetail|Payments:AvsRelaxRetail|Payments:CvnVisaCvv2|Payments:CvnMaestroUkDomestic" +
                "|Payments:CvnAmexCid|Payments:CvnDiscoverCid|Payments:CvnMaestroInternationalCopy|Payments:CvnMasterCardCvc2" +
                "|Payments:AuthorizationOnly0ExponentCurrencies|Payments:AuthorizationOnly2ExponentCurrencies|Payments:Pcl2AmericanExpress" +
                "|Payments:Pcl2MasterCard|Payments:Pcl2Visa|Payments:Pcl3Visa|Payments:Pcl3MasterCard|Payments:BasicPaymentAuthorization" +
                "|Payments:VoiceAuthReferral|Payments:MasterCardSecureCode|Payments:GetPayment|Payments:Dollar0Authorization" +
                "|Payments:Dollar0AuthorizationMasterCard|Payments:CurrenciesSupported|Payments:ApRecurringIndicator|Payments:PartialAuthorization" +
                "|Payments:AmericanExpressSafeKey|Payments:AvsOnly|Payments:ForcedCaptures|Payments:JcbjSecure|Payments:LeveliiData" +
                "|Payments:EcisSupported|Payments:LeveliiiData|Payments:MasterCardSecureCode2|Payments:MerchantDescriptorsAuth" +
                "|Payments:RecurringBilling|Payments:VerbalAuthorizationsCapture|Payments:ServiceFees|Payments:VerifiedByVisa" +
                "|Payments:ScAuthorizationOnly|Payments:ScCapturePayment|Payments:ScVisaBillPayment|Payments:ScBillAmtGreaterThanAuthAmt" +
                "|Payments:ScPartialBills|Payments:CpStandaloneCredit|Payments:CpFollowOnCredit|Payments:CpPartialCredits|Payments:RefundPayment" +
                "|Payments:AuthReversalFull|Payments:VtVoidAPayment|Payments:VtVoidAPaymentZeroDollar|Payouts:Payouts|Flex:GenerateKey|Flex:TokenizeCard" +
                "|Payments_Core:AuthReversalSample|Payments_Core:CreateCreditSample|Payments_Core:GetCaptureSample|Payments_Core:GetCreditSample" +
                "|Payments_Core:GetPaymentSample|Payments_Core:GetRefundSample|Payments_Core:GetReversalSample|Payments_Core:GetVoidSample" +
                "|Payments_Core:RefundCaptureSample|Payments_Core:RefundPaymentSample|Payments_Core:VoidCaptureSample|Payments_Core:VoidCreditSample" +
                "|Payments_Core:VoidPaymentSample|Payments_Core:VoidRefundSample|TMS:CreateInstrumentIdentifier|TMS:RetrieveInstrumentIdentifier";

            var apis = apiList.Split('|');

            foreach (var api in apis)
            {
                var apiFamily = api.Split(':')[0];
                var apiFunctionCall = api.Split(':')[1];
                ApiFunctionCalls.Add(apiFunctionCall);

                var newApi = new Api
                {
                    ApiFamily = apiFamily,
                    ApiFunctionCall = apiFunctionCall
                };

                ApiList.Add(newApi);
            }

            // Remove Code before deployment.
            // Console.WriteLine();
            // Console.WriteLine(ApiList.Count);
            // Console.WriteLine();
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
            // make sure you put a dot . at the end of the path
            SampleClassesPathList.Add("CybsPayments.Payments.All_Services.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Simple_Auth.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Merchant_Initiated_Reversals_and_Voids.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Network_Tokenization.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.POS_Transactions.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Digital_Payments.SamSung_Pay.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Digital_Payments.Chase_Pay.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Digital_Payments.ApplePay.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Digital_Payments.Google_Pay.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Digital_Payments.AndroidPay.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Card_Brand.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.AVS_US_Supported_Card_Types.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.AVS_Non_US_Supported_Card_Types.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.AVS_Relax.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.CVN.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Currency_Support.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Purchase_Cards_Level_2.");
            SampleClassesPathList.Add("CybsPayments.Payments.Authorize_Payment.Purchase_Cards_Level_3.");
            SampleClassesPathList.Add("CybsPayments.Payments.Capture_Payment.Simple_Capture.");
            SampleClassesPathList.Add("CybsPayments.Payments.Credit_Payment.");
            SampleClassesPathList.Add("CybsPayments.Payments.Refund_Payment.");
            SampleClassesPathList.Add("CybsPayments.Payments.Reverse_Payment.");
            SampleClassesPathList.Add("CybsPayments.Payments.Void_Transactions.Void_a_Payment.");
            SampleClassesPathList.Add("CybsPayments.Payouts.");
            SampleClassesPathList.Add("CybsPayments.Flex.");
            SampleClassesPathList.Add("CybsPayments.Payments_Core.");
            SampleClassesPathList.Add("CybsPayments.TMS.");
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
