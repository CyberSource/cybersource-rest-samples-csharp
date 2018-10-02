using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Model;
using Newtonsoft.Json;
using RestSharp;

namespace CybsPayments
{
    public class Collated
    {
        public RestClient RestClient { get; set; }

        public void Run()
        {
            // string postBody;
            // using (var r = new StreamReader(@"Z:\Desktop\sampleJson.json"))
            // {
            //     postBody = r.ReadToEnd();
            // }
            var clientReferenceInformationObj = new V2paymentsClientReferenceInformation { Code = "1234567890" };

            var pointOfSaleInformationObj = new V2paymentsPointOfSaleInformation
            {
                CardPresent = false,
                CatLevel = 6,
                TerminalCapability = 4
            };

            var orderInformationObj = new V2paymentsOrderInformation();

            var billToObj = new V2paymentsOrderInformationBillTo
            {
                Country = "US",
                FirstName = "RTS",
                LastName = "VDP",
                Address1 = "901 Metro Center Blvd",
                PostalCode = "40500",
                Locality = "Foster City",
                AdministrativeArea = "CA",
                Email = "test@cybs.com"
            };

            orderInformationObj.BillTo = billToObj;

            var amountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "100.00",
                Currency = "USD"
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            var paymentInformationObj = new V2paymentsPaymentInformation();

            var cardObj = new V2paymentsPaymentInformationCard
            {
                ExpirationYear = "2031",
                Number = "4111111111111111",
                SecurityCode = "123",
                ExpirationMonth = "12"
            };

            paymentInformationObj.Card = cardObj;

            var requestObj = new CreatePaymentRequest
            {
                PaymentInformation = paymentInformationObj,
                ClientReferenceInformation = clientReferenceInformationObj,
                PointOfSaleInformation = pointOfSaleInformationObj,
                OrderInformation = orderInformationObj
            };

            var merchantConfig = new MerchantConfig(new Configuration().GetConfiguration())
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payments",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            var authenticationHeaders = new Dictionary<string, string>();

            var authorize = new Authorize(merchantConfig);

            if (merchantConfig.IsJwtTokenAuthType)
            {
                // generate token and set JWT token headers
                var jwtToken = authorize.GetToken();
                authenticationHeaders.Add("Authorization", jwtToken.BearerToken);
            }
            else if (merchantConfig.IsHttpSignAuthType)
            {
                // generate signature and set HTTP Signature headers
                var httpSign = authorize.GetSignature();
                authenticationHeaders.Add("v-c-merchant-id", httpSign.MerchantId);
                authenticationHeaders.Add("Date", httpSign.GmtDateTime);
                authenticationHeaders.Add("Host", httpSign.HostName);
                authenticationHeaders.Add("Signature", httpSign.SignatureParam);

                if (merchantConfig.IsPostRequest || merchantConfig.IsPutRequest)
                {
                    authenticationHeaders.Add("Digest", httpSign.Digest);
                }
            }

            var request = new RestRequest("/pts/v2/payments", Method.POST);

            foreach (var param in authenticationHeaders)
            {
                if (param.Key == "Authorization")
                {
                    request.AddParameter("Authorization", string.Format("Bearer " + param.Value), ParameterType.HttpHeader);
                }
                else
                {
                    request.AddHeader(param.Key, param.Value);
                }
            }

            request.AddParameter("application/json", JsonConvert.SerializeObject(requestObj), ParameterType.RequestBody);

            RestClient = new RestClient("https://apitest.cybersource.com")
            {
                Timeout = 100000,
                UserAgent = "Swagger-Codegen/1.0.0/csharp"
            };

            RestClient.ClearHandlers();

            var response = RestClient.Execute(request);

            Console.WriteLine((int)response.StatusCode);
            Console.WriteLine(response.StatusCode);

            // AuthorizationOnly.Run(new Configuration().GetConfiguration());
            //var request = new RestRequest("/v2/payments", Method.POST);

            //foreach (var param in headerParams)
            //{
            //    request.AddHeader(param.Key, param.Value);
            //}

            //request.AddParameter("application/json", postBody, ParameterType.RequestBody);

            /*
             case "GetPayment":
                    GetPaymentSample.Run(ConfigDictionary);
                    break;
                case "GetCapture":
                    GetCaptureSample.Run(ConfigDictionary);
                    break;
                case "GetReversal":
                    GetReversalSample.Run(ConfigDictionary);
                    break;
                case "GetCredit":
                    GetCreditSample.Run(ConfigDictionary);
                    break;
                case "GetRefund":
                    GetRefundSample.Run(ConfigDictionary);
                    break;
                case "GetVoid":
                    GetVoidSample.Run(ConfigDictionary);
                    break;
                case "CapturePayment":
                    CapturePaymentSample.Run(ConfigDictionary);
                    break;
                case "RefundCapture":
                    RefundCaptureSample.Run(ConfigDictionary);
                    break;
                case "RefundPayment":
                    RefundPaymentSample.Run(ConfigDictionary);
                    break;

            // switch (methodName)
            // {
            //    // Payments
            //    case "AuthorizationOnly":
            //        AuthorizationOnly.Run(ConfigDictionary);
            //        break;
            //    case "AuthReversal":
            //        AuthReversalSample.Run(ConfigDictionary);
            //        break;
            //    default:
            //        Console.WriteLine("No Sample Code Found with the name: {0}", methodName);
            //        break;
            //}
             * */
        }
    }
}
