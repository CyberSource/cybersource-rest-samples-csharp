using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace httpSignature
{
    class Program
    {
        static HttpClient client = new HttpClient();

        /* Try with your own credentaials
         * get  Key ID, Secret Key and Merchant Id from EBC portal*/
        static String merchantID = "testrest";
        static String merchantKeyId = "08c94330-f618-42a3-b09d-e1e43be5efda";
        static String merchantsecretKey = "yBJxy6LjM2TmcPGu+GaJrHtkke25fPpUX+UY6/L/1tE=";
        static String requestHost = "apitest.cybersource.com";

        /* <summary>
         * This is the main method for the console application.
         * This Example illustrate two tests - HTTP get and post method with Cybersource Payments API.
         * Each test will caluate HTTP Signature Digest and Authenticate Cybersource Payments API using HTTP Client 
         * </summary>
         * <param name="args"></param> */
        static void Main(string[] args)
        {
            RunAsync().Wait();

        }

        /* <summary>
         * This method defines the API requests and then makes the individual calls to complete the payment transactions.
         * </summary>
         * <returns></returns> */
        static async Task RunAsync()
        {
            try
            {
                //string readText = File.ReadAllText("..\\request.json", Encoding.getEncoding("UTF-8"));
                //Console.OutputEncoding = Encoding.UTF8;
                //Console.WriteLine("readText1::" + readText);


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
                Console.WriteLine(string.Format("Created (HTTP Status = {0})", (int)statusCode));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press Return to end...");
            Console.ReadLine();
        }

        /// <summary>
        /// This demonstrates what a generic API request helper method would look like.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        static async Task<TaskStatus> CallCyberSourceAPI(String request)
        {
            TaskStatus responseCode;
            // HTTP get request
            using (var client = new HttpClient())
            {

                string resource = "/reporting/v3/reports?startTime=2018-10-01T00:00:00.0Z&endTime=2018-10-30T23:59:59.0Z&timeQueryType=executedTime&reportMimeType=application/xml";

                /* Add Request Header :: "v-c-merchant-id" set value to Cybersource Merchant ID or v-c-merchant-id
                 * This ID can be found on EBC portal */
                client.DefaultRequestHeaders.Add("v-c-merchant-id", merchantID);

                /* Add Request Header :: "Date" The date and time that the message was originated from.
                 * "HTTP-date" format as defined by RFC7231. */
                String gmtDateTime = DateTime.Now.ToUniversalTime().ToString("r");
                client.DefaultRequestHeaders.Add("Date", gmtDateTime);

                /* Add Request Header :: "Host"
                 * Sandbox Host: apitest.cybersource.com
                 * Production Host: api.cybersource.com */
                client.DefaultRequestHeaders.Add("Host", requestHost);

                /* Add Request Header :: "Signature"
                 * Signature header contains keyId, algorithm, headers and signature as paramters
                 * method getSignatureHeader() has more details */
                StringBuilder signature = GenerateSignature(request, "", "", gmtDateTime, "get", resource);
                client.DefaultRequestHeaders.Add("Signature", signature.ToString());

                Console.Write("\n Sample1: GET call - CyberSource Reporting API");
                Console.Write("\n RequestURL -- ");
                Console.Write("\nURL : " + "https://" + requestHost + resource);
                Console.Write("\nMethod:: " + "get");
                Console.Write("\n\n -- HTTP Header -- ");
                Console.Write("\nv-c-merchant-id :" + merchantID);
                Console.Write("\nDate :" + gmtDateTime);
                Console.Write("\nHost :" + requestHost);
                Console.Write("\nSignature :" + signature.ToString());
                Console.Write("\n\n -- Response Message -- ");

                using (var r = await client.GetAsync(new Uri("https://" + requestHost + resource)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    Console.Write(result);
                    responseCode = (TaskStatus)r.StatusCode;
                }
            }

            //POST Call
            using (var client = new HttpClient())
            {
                string resource = "/pts/v2/payments";
                StringContent content = new StringContent(request);
                Console.WriteLine("REQUEST2::" + await content.ReadAsStringAsync());

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); // content-type header

                /* Add Request Header :: "v-c-merchant-id" set value to Cybersource Merchant ID or v-c-merchant-id
                 * This ID can be found on EBC portal */
                client.DefaultRequestHeaders.Add("v-c-merchant-id", merchantID);

                /* Add Request Header :: "Date" The date and time that the message was originated from.
                 * "HTTP-date" format as defined by RFC7231. */
                String gmtDateTime = DateTime.Now.ToUniversalTime().ToString("r");
                client.DefaultRequestHeaders.Add("Date", gmtDateTime);

                /* Add Request Header :: "Host"
                 * Sandbox Host: apitest.cybersource.com
                 * Production Host: api.cybersource.com */
                client.DefaultRequestHeaders.Add("Host", requestHost);

                /* Add Request Header :: "Digest"
                 * Digest is SHA-256 hash of payload that is BASE64 encoded */
                var digest = GenerateDigest(request);
                client.DefaultRequestHeaders.Add("Digest", digest);


                /* Add Request Header :: "Signature"
                 * Signature header contains keyId, algorithm, headers and signature as paramters
                 * method getSignatureHeader() has more details */
                StringBuilder signature = GenerateSignature(request, digest, "", gmtDateTime, "post", resource);
                client.DefaultRequestHeaders.Add("Signature", signature.ToString());

                Console.Write("\n\n\n Sample2: POST call - CyberSource Payments API - Authorize a Credit Card");
             
                Console.Write("\n RequestURL -- ");
                Console.Write("\nURL : " + "https://" + requestHost + resource);
                Console.Write("\nMethod:: " + "post");
                Console.Write("\nRequest Payload:: \n" + request);
                Console.Write("\n\n -- HTTP Header -- ");
                Console.Write("\nv-c-merchant-id :" + merchantID);
                Console.Write("\nDate :" + gmtDateTime);
                Console.Write("\nHost :" + requestHost);
                Console.Write("\nDigest :" + digest);
                Console.Write("\nSignature :" + signature.ToString());
                Console.Write("\n\n -- Response Message -- ");

                var response = await client.PostAsync("https://" + requestHost + resource,
                    content);
                responseCode = (TaskStatus)response.StatusCode;
                string responsecontent = await response.Content.ReadAsStringAsync();
                Console.Write(responsecontent);
            }
            return responseCode;
        }


        /// <summary>
        /// This method return Digest value which is SHA-256 hash of payload that is BASE64 encoded 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="method"></param> 
        /// <returns></returns>

        static String GenerateDigest(String request)
        {
            String digest = "DIGEST_PLACEHOLDER";
   
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
                Console.WriteLine("Oops : " + ex.ToString());
            }

            return digest;
        }

        /* This method returns value for paramter Signature which is then passed to Signature header
         * paramter 'Signature' is calucated based on below key values and then signed with SECRET KEY -
         * host: Sandbox (apitest.cybersource.com) or Production (api.cybersource.com) hostname
         * date: "HTTP-date" format as defined by RFC7231.
         * (request-target): Should be in format of httpMethod: path
              Example: "post /pts/v2/payments"
         * Digest: Only needed for POST calls.
              digestString = BASE64( HMAC-SHA256 ( Payload ));
              Digest: “SHA-256=“ + digestString;
         * v-c-merchant-id: set value to Cybersource Merchant ID
              This ID can be found on EBC portal*/

        static StringBuilder GenerateSignature(String request, String digest, String keyid, String gmtDateTime,  String method, string resource)
        {
            StringBuilder signatureHeaderValue = new StringBuilder();
            String algorithm = "HmacSHA256";
            String postHeaders = "host date (request-target) digest v-c-merchant-id";
            String getHeaders = "host date (request-target) v-c-merchant-id";
            String url = "https://"+ requestHost + resource;
            String getRequestTarget = method + " "+resource;
            String postRequestTarget = method + " " +resource;
            
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
                signatureString.Append("(request-target)");
                signatureString.Append(": ");
                if (method.Equals("post")) {
                    signatureString.Append(postRequestTarget);
                    signatureString.Append('\n');
                    signatureString.Append("digest");
                    signatureString.Append(": ");
                    signatureString.Append(digest);
                }
                else
                    signatureString.Append(getRequestTarget);
                signatureString.Append('\n');
                signatureString.Append("v-c-merchant-id");
                signatureString.Append(": ");
                signatureString.Append(merchantID);
                signatureString.Remove(0, 1);
                
                byte[] signatureByteString = System.Text.Encoding.UTF8.GetBytes(signatureString.ToString());

                byte[] decodedKey = Convert.FromBase64String(merchantsecretKey);

                HMACSHA256 aKeyId = new HMACSHA256(decodedKey);

                byte[] hashmessage  = aKeyId.ComputeHash(signatureByteString);
                String base64EncodedSignature = Convert.ToBase64String(hashmessage);
        
                signatureHeaderValue.Append("keyid=\"" + merchantKeyId + "\"");
                signatureHeaderValue.Append(", algorithm=\""+ algorithm + "\"");
                if (method.Equals("post")){
                    signatureHeaderValue.Append(", headers=\"" + postHeaders + "\"");
                }
                else if (method.Equals("get"))
                {
                    signatureHeaderValue.Append(", headers=\"" + getHeaders + "\"");
                }
                signatureHeaderValue.Append(", signature=\"" + base64EncodedSignature + "\"");

                
                // Writing Generated Token to file.    
                File.WriteAllText("..\\signatureHeaderValue.txt", signatureHeaderValue.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops : " + ex.ToString());
            }

            return signatureHeaderValue;
        }

   
        /*converts byte to encrypted string*/
        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
    }
}
