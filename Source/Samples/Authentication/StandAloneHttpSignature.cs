using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet.Samples.Authentication
{
    public class StandAloneHttpSignature
    {
        // Try with your own credentaials
        // Get Key ID, Secret Key and Merchant Id from EBC portal
        private static string merchantID = "testrest";
        private static string merchantKeyId = "08c94330-f618-42a3-b09d-e1e43be5efda";
        private static string merchantsecretKey = "yBJxy6LjM2TmcPGu+GaJrHtkke25fPpUX+UY6/L/1tE=";
        private static string requestHost = "apitest.cybersource.com";

        /// <summary>
        /// This Example illustrate two tests - HTTP get and post method with Cybersource Payments API.
        /// Each test will caluate HTTP Signature Digest and Authenticate Cybersource Payments API using HTTP Client
        /// CyberSource Business Center - https://ebc2test.cybersource.com/ebc2/
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
                string body = "{\n" +
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

                var statusCode = await CallCyberSourceAPI(body);

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
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// This demonstrates what a generic API request helper method would look like.
        /// </summary>
        /// <param name="request">Request to send to API endpoint</param>
        /// <returns>Task</returns>
        public static async Task<TaskStatus> CallCyberSourceAPI(string request)
        {
            TaskStatus responseCode;

            // HTTP GET request
            using (var client = new HttpClient())
            {
                string resource = "/reporting/v3/reports?startTime=2021-01-01T00:00:00.0Z&endTime=2021-01-02T23:59:59.0Z&timeQueryType=executedTime&reportMimeType=application/xml";

                /* Add Request Header :: "v-c-merchant-id" set value to Cybersource Merchant ID or v-c-merchant-id
                 * This ID can be found on EBC portal.
                 */
                client.DefaultRequestHeaders.Add("v-c-merchant-id", merchantID);

                /* Add Request Header :: "Date" The date and time that the message was originated from.
                 * "HTTP-date" format as defined by RFC7231.
                 */
                string gmtDateTime = DateTime.Now.ToUniversalTime().ToString("r");
                client.DefaultRequestHeaders.Add("Date", gmtDateTime);

                /* Add Request Header :: "Host"
                 * Sandbox Host: apitest.cybersource.com
                 * Production Host: api.cybersource.com
                 */
                client.DefaultRequestHeaders.Add("Host", requestHost);

                /* Add Request Header :: "Signature"
                 * Signature header contains keyId, algorithm, headers and signature as paramters
                 * method getSignatureHeader() has more details
                 */
                StringBuilder signature = GenerateSignature(request, string.Empty, string.Empty, gmtDateTime, "get", resource);
                client.DefaultRequestHeaders.Add("Signature", signature.ToString());

                Console.WriteLine("\nSample 1: GET call - CyberSource Reporting API");
                Console.WriteLine(" -- RequestURL -- ");
                Console.WriteLine("\tURL : " + "https://" + requestHost + resource);
                Console.WriteLine("\tMethod : GET");
                Console.WriteLine(" -- HTTP Headers -- ");
                Console.WriteLine("\tv-c-merchant-id : " + merchantID);
                Console.WriteLine("\tDate : " + gmtDateTime);
                Console.WriteLine("\tHost : " + requestHost);
                Console.WriteLine("\tSignature : " + signature.ToString());
                Console.WriteLine("\n -- Response Message --\n");

                using (var r = await client.GetAsync(new Uri("https://" + requestHost + resource)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                    responseCode = (TaskStatus)r.StatusCode;
                }
            }

            // HTTP POST request
            using (var client = new HttpClient())
            {
                string resource = "/pts/v2/payments";
                StringContent content = new StringContent(request);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); // content-type header

                /* Add Request Header :: "v-c-merchant-id" set value to Cybersource Merchant ID or v-c-merchant-id
                 * This ID can be found on EBC portal
                 */
                client.DefaultRequestHeaders.Add("v-c-merchant-id", merchantID);

                /* Add Request Header :: "Date" The date and time that the message was originated from.
                 * "HTTP-date" format as defined by RFC7231.
                 */
                string gmtDateTime = DateTime.Now.ToUniversalTime().ToString("r");
                client.DefaultRequestHeaders.Add("Date", gmtDateTime);

                /* Add Request Header :: "Host"
                 * Sandbox Host: apitest.cybersource.com
                 * Production Host: api.cybersource.com
                 */
                client.DefaultRequestHeaders.Add("Host", requestHost);

                /* Add Request Header :: "Digest"
                 * Digest is SHA-256 hash of payload that is BASE64 encoded
                 */
                var digest = GenerateDigest(request);
                client.DefaultRequestHeaders.Add("Digest", digest);

                /* Add Request Header :: "Signature"
                 * Signature header contains keyId, algorithm, headers and signature as paramters
                 * method getSignatureHeader() has more details
                 */
                StringBuilder signature = GenerateSignature(request, digest, string.Empty, gmtDateTime, "post", resource);
                client.DefaultRequestHeaders.Add("Signature", signature.ToString());

                Console.WriteLine("\n\nSample 2: POST call - CyberSource Payments API - Authorize a Credit Card");
                Console.WriteLine(" -- RequestURL -- ");
                Console.WriteLine("\tURL : " + "https://" + requestHost + resource);
                Console.WriteLine("\tMethod : POST");
                Console.WriteLine(" -- Request Payload --\n" + request);
                Console.WriteLine("\n -- HTTP Headers -- ");
                Console.WriteLine("\tv-c-merchant-id : " + merchantID);
                Console.WriteLine("\tDate : " + gmtDateTime);
                Console.WriteLine("\tHost : " + requestHost);
                Console.WriteLine("\tDigest : " + digest);
                Console.WriteLine("\tSignature : " + signature.ToString());
                Console.WriteLine("\n -- Response Message --\n");

                var response = await client.PostAsync("https://" + requestHost + resource, content);
                responseCode = (TaskStatus)response.StatusCode;
                string responsecontent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responsecontent);
            }

            return responseCode;
        }

        /// <summary>
        /// This method return Digest value which is SHA-256 hash of payload that is BASE64 encoded
        /// </summary>
        /// <param name="request">Value from which to generate digest</param>
        /// <returns>String referring to a digest</returns>
        public static string GenerateDigest(string request)
        {
            string digest = "DIGEST_PLACEHOLDER";

            try
            {
                // Generate the Digest
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] payloadBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(request));
                    digest = Convert.ToBase64String(payloadBytes);
                    digest = "SHA-256=" + digest;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.ToString());
            }

            return digest;
        }

        // This method returns value for paramter Signature which is then passed to Signature header
        // paramter 'Signature' is calucated based on below key values and then signed with SECRET KEY -
        // host: Sandbox (apitest.cybersource.com) or Production (api.cybersource.com) hostname
        // date: "HTTP-date" format as defined by RFC7231.
        // request-target: Should be in format of httpMethod: path
        //    Example: "post /pts/v2/payments"
        // Digest: Only needed for POST calls.
        //    digestString = BASE64( HMAC-SHA256 ( Payload ));
        //    Digest: “SHA-256=“ + digestString;
        // v-c-merchant-id: set value to Cybersource Merchant ID
        //    This ID can be found on EBC portal
        public static StringBuilder GenerateSignature(string request, string digest, string keyid, string gmtDateTime, string method, string resource)
        {
            StringBuilder signatureHeaderValue = new StringBuilder();
            string algorithm = "HmacSHA256";
            string postHeaders = "host date request-target digest v-c-merchant-id";
            string getHeaders = "host date request-target v-c-merchant-id";
            string url = "https://" + requestHost + resource;
            string getRequestTarget = method + " " + resource;
            string postRequestTarget = method + " " + resource;

            try
            {
                // Generate the Signature
                StringBuilder signatureString = new StringBuilder();
                signatureString.Append('\n');
                signatureString.Append("host");
                signatureString.Append(": ");
                signatureString.Append(requestHost);
                signatureString.Append('\n');
                signatureString.Append("date");
                signatureString.Append(": ");
                signatureString.Append(gmtDateTime);
                signatureString.Append('\n');
                signatureString.Append("request-target");
                signatureString.Append(": ");

                if (method.Equals("post"))
                {
                    signatureString.Append(postRequestTarget);
                    signatureString.Append('\n');
                    signatureString.Append("digest");
                    signatureString.Append(": ");
                    signatureString.Append(digest);
                }
                else
                {
                    signatureString.Append(getRequestTarget);
                }

                signatureString.Append('\n');
                signatureString.Append("v-c-merchant-id");
                signatureString.Append(": ");
                signatureString.Append(merchantID);
                signatureString.Remove(0, 1);

                byte[] signatureByteString = Encoding.UTF8.GetBytes(signatureString.ToString());

                byte[] decodedKey = Convert.FromBase64String(merchantsecretKey);

                HMACSHA256 aKeyId = new HMACSHA256(decodedKey);

                byte[] hashmessage = aKeyId.ComputeHash(signatureByteString);
                string base64EncodedSignature = Convert.ToBase64String(hashmessage);

                signatureHeaderValue.Append("keyid=\"" + merchantKeyId + "\"");
                signatureHeaderValue.Append(", algorithm=\"" + algorithm + "\"");

                if (method.Equals("post"))
                {
                    signatureHeaderValue.Append(", headers=\"" + postHeaders + "\"");
                }
                else if (method.Equals("get"))
                {
                    signatureHeaderValue.Append(", headers=\"" + getHeaders + "\"");
                }

                signatureHeaderValue.Append(", signature=\"" + base64EncodedSignature + "\"");

                // Writing Generated Token to file.
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"../../../Source/Resource/" + "signatureHeaderValue.txt", signatureHeaderValue.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.ToString());
            }

            return signatureHeaderValue;
        }

        // Converts byte to encrypted string
        public static string ByteToString(byte[] buff)
        {
            string sbinary = string.Empty;

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }

            return sbinary;
        }
    }
}
