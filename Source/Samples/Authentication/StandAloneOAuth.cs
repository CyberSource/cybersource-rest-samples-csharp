using System;
using System.Collections.Generic;
using CyberSource.Model;
using CyberSource.Api;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet.Samples.Authentication
{
    public class StandAloneOAuth
    {
        private static string code = "";
        private static string grantType = "";
        private static string refreshToken = "";
        private static string accessToken = "";
        private static Dictionary<string, string> configDictionary;
        public static bool createUsingAuthCode = false;

        public static void Run()
        {
            CallOAuthAPI(null);
        }

        public static void CallOAuthAPI(string[] args)
        {
            AccessTokenResponse result ;            
            if(createUsingAuthCode)
            {
                // Create Access Token using Auth Code
                code = "fHA73z";
                grantType = "authorization_code";
                result = postAccessTokenFromAuthCode();
            }
            else {
                // Create Access Token using Refresh Token
                grantType = "refresh_token";
                refreshToken = "eyJraWQiOiIxMGM2MTYxNzg2MzE2ZWMzMGJjZmI5ZDcyZGU4MzFjOSIsImFsZyI6IlJTMjU2In0.eyJqdGkiOiJmODFiM2M3ZC00YWMzLTQ2MDctYTIyYi00YzUwZjgyMjQwMDkiLCJzY29wZXMiOlsicGF5bWVudHNfd2l0aF9zdGFuZGFsb25lX2NyZWRpdCIsInBheW1lbnRzX3dpdGhvdXRfc3RhbmRhbG9uZV9jcmVkaXQiLCJ0cmFuc2FjdGlvbnMiXSwiaWF0IjoxNjExODE4NjQzNDUwLCJhc3NvY2lhdGVkX2lkIjoiZWJjMl9jYXNfb2F1dGh0cDIiLCJjbGllbnRfaWQiOiJCeW94NGp4VWk2IiwibWVyY2hhbnRfaWQiOiJjZ2syX3B1c2hfdGVzdHMiLCJleHBpcmVzX2luIjoxNjQzMzU0NjQzNDUwLCJ0b2tlbl90eXBlIjoicmVmcmVzaF90b2tlbiIsImdyYW50X3R5cGUiOiJhdXRob3JpemF0aW9uX2NvZGUiLCJncmFudF90aW1lIjoiMjAyMTAxMjcyMzIzIn0.SYZ62TFuukxrPqjiGVPBzs7BHaiTkDOO-Rqjzfl4rZi_hP0pkHSTograBFgLZ3GnWxNUzgXsU5zTGqF2nllI_j0kvMIWuST6xAoDyXRHlDfcM8MQYDI7CaJGVTFbJh1U_qzN6sUUlVhKpk_BXt_4LH03_11HiQHIwnZfTcNCoDrvlnO_xkRonrEipPJb6iMO3ZEv6Z8UBc0Q-L_nR6DhHlL5M3U-S-Fi7pusq5bOyUi38CW9nwAQo9A0F3PG8n0Scji2LatjGUB4Y5hTCiRWEbIoa49fQwq0hroi11o32YriQQnMqGaaH_bCq8NgLQabRv1I73I37443lW4w0Hoy-A";
                result = postAccessTokenFromRefreshToken();
            }

            if(result != null) {
                refreshToken = result.RefreshToken;
                accessToken = result.AccessToken;

                // Save accessToken and refreshToken before making API calls
                configDictionary["accessToken"] = accessToken;
                configDictionary["refreshToken"] = refreshToken;

                // Set Authentication to OAuth
                configDictionary["authenticationType"] = "OAuth";

                //Call Payments SampleCode using OAuth, Set Authentication to OAuth in Sample Code Configuration
                SimpleAuthorizationInternet();
            }

        }

        public static AccessTokenResponse postAccessTokenFromAuthCode()
        {
            AccessTokenResponse result = null;
            try
            {
                configDictionary = new Configuration().GetConfiguration();
                configDictionary["authenticationType"] = "Mutual_Auth";
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var requestObj = new CreateAccessTokenRequest(
                Code: code,
                GrantType: grantType,
                ClientId: configDictionary["clientId"],
                ClientSecret: configDictionary["clientSecret"]
                );

                var apiInstance = new OAuthApi(clientConfig);
                result = apiInstance.PostAccessTokenRequest(requestObj);
                Console.WriteLine(result);
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                return null;
            }
        }

        public static AccessTokenResponse postAccessTokenFromRefreshToken()
        {
            AccessTokenResponse result = null;
            try
            {
                configDictionary = new Configuration().GetConfiguration();
                configDictionary["authenticationType"] = "Mutual_Auth";
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var requestObj = new CreateAccessTokenRequest(
                RefreshToken: refreshToken,
                GrantType: grantType,
                ClientId: configDictionary["clientId"],
                ClientSecret: configDictionary["clientSecret"]
                );

                var apiInstance = new OAuthApi(clientConfig);
                result = apiInstance.PostAccessTokenRequest(requestObj);
                Console.WriteLine(result);
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                return null;
            }
        }

        public static PtsV2PaymentsPost201Response SimpleAuthorizationInternet()
        {
            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = false;

            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                Capture: processingInformationCapture
           );

            string paymentInformationCardNumber = "4111111111111111";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2031";
            Ptsv2paymentsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsPaymentInformationCard(
                Number: paymentInformationCardNumber,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                Card: paymentInformationCard
           );

            string orderInformationAmountDetailsTotalAmount = "102.21";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Doe";
            string orderInformationBillToAddress1 = "1 Market St";
            string orderInformationBillToLocality = "san francisco";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToPostalCode = "94105";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToEmail = "test@cybs.com";
            string orderInformationBillToPhoneNumber = "4158880000";
            Ptsv2paymentsOrderInformationBillTo orderInformationBillTo = new Ptsv2paymentsOrderInformationBillTo(
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                Address1: orderInformationBillToAddress1,
                Locality: orderInformationBillToLocality,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                PostalCode: orderInformationBillToPostalCode,
                Country: orderInformationBillToCountry,
                Email: orderInformationBillToEmail,
                PhoneNumber: orderInformationBillToPhoneNumber
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentsApi(clientConfig);
                PtsV2PaymentsPost201Response result = apiInstance.CreatePayment(requestObj);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                return null;
            }
        }
    }
}
