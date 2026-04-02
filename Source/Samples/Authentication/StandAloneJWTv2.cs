using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Cybersource_rest_samples_dotnet.Samples.Authentication
{
    public class StandAloneJWTv2
    {
        private static string merchantID = "testrest";
        private static string requestHost = "apitest.cybersource.com";

        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

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

                if (statusCode >= 200 && statusCode <= 299)
                {
                    Console.WriteLine(string.Format("STATUS : SUCCESS (HTTP Status = {0})", statusCode));
                }
                else
                {
                    Console.WriteLine(string.Format("STATUS : ERROR (HTTP Status = {0})", statusCode));
                }

                WriteLogAudit(statusCode);
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
        public static async Task<int> CallCyberSourceAPI(string request)
        {
            TaskStatus responseCodeGet, responseCodePost;

            // HTTP GET request
            using (var client = new HttpClient())
            {
                string resource = "/tms/v2/customers/AB695DA801DD1BB6E05341588E0A3BDC/shipping-addresses/AB6A54B97C00FCB6E05341588E0A3935";

                Console.WriteLine("\nSample 1: GET call - CyberSource TMS API");
                Console.WriteLine(" -- RequestURL -- ");
                Console.WriteLine("\tURL : " + "https://" + requestHost + resource);

                var jwtToken = GenerateJWTv2(request, "GET", resource);
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json")); // ACCEPT header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                using (var r = await client.GetAsync(new Uri("https://" + requestHost + resource)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    Console.WriteLine("\n -- Response Message --\n\n" + result);
                    responseCodeGet = (TaskStatus)r.StatusCode;
                }
            }

            // HTTP POST request
            using (var client = new HttpClient())
            {
                string resource = "/pts/v2/payments";

                Console.WriteLine("\n\nSample 2: POST call - CyberSource Payments API - Authorize a Credit Card");
                Console.WriteLine(" -- RequestURL -- ");
                Console.WriteLine("\tURL : " + "https://" + requestHost + resource);

                var jwtToken = GenerateJWTv2(request, "POST", resource);

                StringContent content = new StringContent(request);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); // Content-Type header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                var response = await client.PostAsync("https://" + requestHost + resource, content);
                responseCodePost = (TaskStatus)response.StatusCode;
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("\n -- Response Message --\n\n" + responseContent + "\n");
            }

            if (((int)responseCodePost >= 200 && (int)responseCodePost <= 299) && ((int)responseCodePost >= 200 && (int)responseCodePost <= 299))
            {
                return 200;
            }
            else
            {
                return 400;
            }
        }

        /// <summary>
        /// Extracts the serial number from X.509 certificate for JWT v2 kid header
        /// </summary>
        /// <param name="certificate">X509Certificate2 object</param>
        /// <returns>Certificate serial number as string</returns>
        private static string ExtractSerialNumber(X509Certificate2 certificate)
        {
            try
            {
                // Try to extract from subject field first
                string serialNumberPrefix = "SERIALNUMBER=";
                string principal = certificate.Subject;

                int beg = principal.IndexOf(serialNumberPrefix);
                if (beg >= 0)
                {
                    int end = principal.IndexOf(",", beg);
                    if (end == -1)
                    {
                        end = principal.Length;
                    }
                    return principal.Substring(beg + serialNumberPrefix.Length, end - beg - serialNumberPrefix.Length);
                }

                // Fallback to certificate serial number
                return certificate.SerialNumber;
            }
            catch (Exception)
            {
                // Fallback to certificate serial number
                return certificate.SerialNumber;
            }
        }

        /// <summary>
        /// Extracts resource path without query parameters for JWT v2
        /// </summary>
        /// <param name="resourcePath">Full resource path with potential query parameters</param>
        /// <returns>Clean resource path without query parameters</returns>
        private static string ExtractResourcePath(string resourcePath)
        {
            if (string.IsNullOrEmpty(resourcePath))
            {
                return string.Empty;
            }

            // Split the string to remove the query params
            var parts = resourcePath.Split('?');
            return parts[0];
        }

        /// <summary>
        /// Generates JWT v2 payload with all required claims
        /// </summary>
        /// <param name="request">Request payload data</param>
        /// <param name="method">HTTP method</param>
        /// <param name="resourcePath">API resource path</param>
        /// <returns>JObject containing JWT v2 payload</returns>
        private static JObject GetJWTv2PayloadClaimSet(string request, string method, string resourcePath)
        {
            var jwtPayload = new JObject();

            // Setting the JWT digest and digest Algorithm when a POST, PUT, or PATCH request is made
            if (method.Equals("POST", StringComparison.OrdinalIgnoreCase) || 
                method.Equals("PUT", StringComparison.OrdinalIgnoreCase) || 
                method.Equals("PATCH", StringComparison.OrdinalIgnoreCase))
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] payloadBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(request));
                    string digest = Convert.ToBase64String(payloadBytes);
                    jwtPayload["digest"] = digest;
                    jwtPayload["digestAlgorithm"] = "SHA-256";
                }
            }

            // Set the iat and exp claims using epoch timestamps
            var currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            jwtPayload["iat"] = currentTime;
            jwtPayload["exp"] = currentTime + 120; // The token is set to expire 2 minutes after creation

            // Set the request method, host and resource path in the JWT body as per the specification for all request types
            jwtPayload["request-method"] = method.ToUpper();
            jwtPayload["request-host"] = requestHost;
            jwtPayload["request-resource-path"] = ExtractResourcePath(resourcePath);

            // Set issuer claim - Using merchant ID for non-metaKey implementation. (Use portfolio ID if metaKey is being used).
            jwtPayload["iss"] = merchantID;

            // Generate unique JWT ID
            jwtPayload["jti"] = Guid.NewGuid().ToString();

            // Set JWT version and merchant ID
            jwtPayload["v-c-jwt-version"] = "2";
            jwtPayload["v-c-merchant-id"] = merchantID;

            return jwtPayload;
        }

        /// <summary>
        /// Generates JWT v2 header with kid instead of x5c
        /// </summary>
        /// <param name="certificate">X509Certificate2 object</param>
        /// <returns>Dictionary containing JWT v2 header claims</returns>
        private static Dictionary<string, object> GetJWTv2HeaderClaimSet(X509Certificate2 certificate)
        {
            var serialNumber = ExtractSerialNumber(certificate);

            var jwtHeaders = new Dictionary<string, object>
            {
                { "kid", serialNumber },
                { "typ", "JWT" }
            };

            return jwtHeaders;
        }

        /// <summary>
        /// This method demonstrates the creation of the JWT v2 Authentication credential
        /// Takes Request Payload, Http method, and resource path as input.
        /// </summary>
        /// <param name="request">Value from which to generate JWT</param>
        /// <param name="method">The HTTP Verb that is needed for generating the credential</param>
        /// <param name="resourcePath">The API resource path</param>
        /// <returns>String containing the JWT v2 Authentication credential</returns>
        public static string GenerateJWTv2(string request, string method, string resourcePath)
        {
            string token = "";

            try
            {
                Console.WriteLine("\tMethod : " + method);

                // Generate JWT v2 payload with all required claims
                var jwtPayload = GetJWTv2PayloadClaimSet(request, method, resourcePath);

                Console.WriteLine("\tJWT v2 BODY : " + jwtPayload.ToString(Newtonsoft.Json.Formatting.None));

                var filename = "testrest.p12"; // This is the full filename of the PKCS12 file.
                var filePath = "../../../Source/Resource"; // This is the relative path to the directory containing the PKCS12 file from the current sample code file.
                // Load P12 certificate
                X509Certificate2 x5Cert = new X509Certificate2(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath, filename), 
                    merchantID, 
                    X509KeyStorageFlags.MachineKeySet);

                // Get private key for signing
                var privateKey = x5Cert.GetRSAPrivateKey();

                // Generate JWT v2 header with kid
                var jwtHeaders = GetJWTv2HeaderClaimSet(x5Cert);

                // Create JWT v2 token
                var jwtBody = jwtPayload.ToString(Newtonsoft.Json.Formatting.None);
                token = Jose.JWT.Encode(jwtBody, privateKey, Jose.JwsAlgorithm.RS256, jwtHeaders);

                // Writing Generated Token to file
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"../../../Source/Resource", $"jwsToken.txt"), token);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.ToString());
            }

            Console.WriteLine(" -- JWT v2 Token --\n\n" + token + "\n");
            return token;
        }
    }
}
