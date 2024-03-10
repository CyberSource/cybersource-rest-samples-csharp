using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet.Samples.Authentication
{
    public class StandAloneJWT
    {
        private static string merchantID = "testrest";
        private static string requestHost = "apitest.cybersource.com";

        /// <summary>
        /// This is standalone code that show cases how to generate headers for CyberSource REST API - POST and GET calls.
        /// This sample code has sample Mercahnt credentails (testrest) with .p12(At same dir level) that you can also use for testing.
        /// CyberSource Business Center - https://ebc2test.cybersource.com/ebc2/
        /// Instructions on generating your own .P12 from CyberSource Business Center - https://developer.cybersource.com/api/developer-guides/dita-gettingstarted/authentication/createCertSharedKey.html
        /// Also,To understand details about CyberSource JWT headers, please check Authentication guide - https://developer.cybersource.com/api/developer-guides/dita-gettingstarted/authentication/GenerateHeader/jwtTokenAuthentication.html
        /// This sample app demonstrates calling the CyberSource REST API to fetch report and charge a credit card
        /// including building the JWT token for API authentication
        /// </summary>
        public static void Run()
        {
            RunAsync().Wait();
        }

        /// <summary>
        /// This method defines the API requests and then makes the individual calls to complete the payment transactions.
        /// </summary>
        /// <returns>Task</returns>
        public static async Task RunAsync()
        {
            try
            {
                string request = "{\n" +
                "  \"clientReferenceInformation\": {\n" +
                "    \"code\": \"TC50171_3\"\n" +
                "  },\n" +
                "  \"processingInformation\": {\n" +
                "    \"commerceIndicator\": \"internet\"\n" +
                "  },\n" +
                "  \"orderInformation\": {\n" +
                "    \"billTo\": {\n" +
                "      \"firstName\": \"john\",\n" +
                "      \"lastName\": \"doe\",\n" +
                "      \"address1\": \"201 S. Division St.\",\n" +
                "      \"postalCode\": \"48104-2201\",\n" +
                "      \"locality\": \"Ann Arbor\",\n" +
                "      \"administrativeArea\": \"MI\",\n" +
                "      \"country\": \"US\",\n" +
                "      \"phoneNumber\": \"999999999\",\n" +
                "      \"email\": \"test@cybs.com\"\n" +
                "    },\n" +
                "    \"amountDetails\": {\n" +
                "      \"totalAmount\": \"10\",\n" +
                "      \"currency\": \"USD\"\n" +
                "    }\n" +
                "  },\n" +
                "  \"paymentInformation\": {\n" +
                "    \"card\": {\n" +
                "      \"expirationYear\": \"2031\",\n" +
                "      \"number\": \"5555555555554444\",\n" +
                "      \"securityCode\": \"123\",\n" +
                "      \"expirationMonth\": \"12\",\n" +
                "      \"type\": \"002\"\n" +
                "    }\n" +
                "  }\n" +
                "}";
                var statusCode = await CallCyberSourceAPI(request);

                if ((int)statusCode >= 200 && (int)statusCode <= 299)
                {
                    Console.WriteLine(string.Format("STATUS : SUCCESS (HTTP Status = {0})", (int)statusCode));
                }
                else
                {
                    Console.WriteLine(string.Format("STATUS : ERROR (HTTP Status = {0})", (int)statusCode));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR : " + e.Message);
            }
        }

        /// <summary>
        /// This demonstrates what a generic API request helper method would look like.
        /// </summary>
        /// <param name="request">Request to send to API endpoint<</param>
        /// <returns>Task</returns>
        public static async Task<TaskStatus> CallCyberSourceAPI(string request)
        {
            TaskStatus responseCode;

            // HTTP GET request
            using (var client = new HttpClient())
            {
                string resource = "/reporting/v3/reports?startTime=2021-02-01T00:00:00.0Z&endTime=2021-02-02T23:59:59.0Z&timeQueryType=executedTime&reportMimeType=application/xml";

                Console.WriteLine("\nSample 1: GET call - CyberSource Reporting API");
                Console.WriteLine(" -- RequestURL -- ");
                Console.WriteLine("\tURL : " + "https://" + requestHost + resource);

                var jwtToken = GenerateJWT(request, "GET");
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/hal+json")); // ACCEPT header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                using (var r = await client.GetAsync(new Uri("https://" + requestHost + resource)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    Console.WriteLine("\n -- Response Message --\n\n" + result);
                }
            }

            // HTTP POST request
            using (var client = new HttpClient())
            {
                string resource = "/pts/v2/payments";

                Console.WriteLine("\n\nSample 2: POST call - CyberSource Payments API - Authorize a Credit Card");
                Console.WriteLine(" -- RequestURL -- ");
                Console.WriteLine("\tURL : " + "https://" + requestHost + resource);

                var jwtToken = GenerateJWT(request, "POST");

                StringContent content = new StringContent(request);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); // Content-Type header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                var response = await client.PostAsync("https://" + requestHost + resource, content);
                responseCode = (TaskStatus)response.StatusCode;
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("\n -- Response Message --\n\n" + responseContent + "\n");
            }

            return responseCode;
        }

        /// <summary>
        /// This method demonstrates the creation of the JWT Authentication credential
        /// Takes Request Paylaod and Http method(GET/POST) as input.
        /// </summary>
        /// <param name="request">Value from which to generate JWT</param>
        /// <param name="method">The HTTP Verb that is needed for generating the credential</param>
        /// <returns>String containing the JWT Authentication credential</returns>
        public static string GenerateJWT(string request, string method)
        {
            string digest;
            string token = "TOKEN_PLACEHOLDER";

            try
            {
                // Generate the hash for the payload
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] payloadBytes = sha256Hash.ComputeHash(Encoding.ASCII.GetBytes(request));
                    digest = Convert.ToBase64String(payloadBytes);
                }

                Console.WriteLine("\tMethod : " + method);

                // Create the JWT payload (aka claimset / JWTBody)
                string jwtBody = "0";

                if (method.Equals("POST"))
                {
                    jwtBody = "{\n\"digest\":\"" + digest + "\", \"digestAlgorithm\":\"SHA-256\", \"iat\":\"" + DateTime.Now.ToUniversalTime().ToString("r") + "\"}";
                }
                else if (method.Equals("GET"))
                {
                    jwtBody = "{\"iat\":\"" + DateTime.Now.ToUniversalTime().ToString("r") + "\"}";
                }

                Console.WriteLine("\tJWT BODY : " + jwtBody);

                // P12 certificate public key is sent in the header and the private key is used to sign the token
                X509Certificate2 x5Cert = new X509Certificate2(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"../../../Source/Resource", $"testrest.p12"), merchantID, X509KeyStorageFlags.MachineKeySet);

                // Extracting Public Key from .p12 file
                string x5cPublicKey = Convert.ToBase64String(x5Cert.RawData);

                // Extracting Private Key from .p12 file
                var privateKey = x5Cert.GetRSAPrivateKey();

                // Extracting serialNumber
                string serialNumber = null;
                string serialNumberPrefix = "SERIALNUMBER=";

                string principal = x5Cert.Subject;

                int beg = principal.IndexOf(serialNumberPrefix);
                if (beg >= 0)
                {
                    int x5cBase64List = principal.IndexOf(",", beg);
                    if (x5cBase64List == -1)
                    {
                        x5cBase64List = principal.Length;
                    }

                    serialNumber = principal.Substring(serialNumberPrefix.Length, x5cBase64List - serialNumberPrefix.Length);
                }

                // Create the JWT Header custom fields
                var x5cList = new List<string>()
                {
                    x5cPublicKey
                };
                var cybsHeaders = new Dictionary<string, object>()
                {
                    { "v-c-merchant-id", merchantID },
                    { "x5c", x5cList } 
                };

                // JWT token is Header plus the Body plus the Signature of the Header & Body
                // Here the Jose-JWT helper library (https://github.com/dvsekhvalnov/jose-jwt) is used create the JWT
                token = Jose.JWT.Encode(jwtBody, privateKey, Jose.JwsAlgorithm.RS256, cybsHeaders);

                // Writing Generated Token to file.
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"../../../Source/Resource", $"jwsToken.txt"), token);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.ToString());
            }

            Console.WriteLine(" -- Token --\n\n" + token + "\n");
            return token;
        }
    }
}
