using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class UpdateCustomer
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static PatchCustomerRequest Run()
        {
            string customerTokenId = "AB695DA801DD1BB6E05341588E0A3BDC";
            string buyerInformationMerchantCustomerID = "Your customer identifier";
            string buyerInformationEmail = "test@cybs.com";
            Tmsv2customersBuyerInformation buyerInformation = new Tmsv2customersBuyerInformation(
                MerchantCustomerID: buyerInformationMerchantCustomerID,
                Email: buyerInformationEmail
           );

            string clientReferenceInformationCode = "TC50171_3";
            Tmsv2customersClientReferenceInformation clientReferenceInformation = new Tmsv2customersClientReferenceInformation(
                Code: clientReferenceInformationCode
           );


            List<Tmsv2customersMerchantDefinedInformation> merchantDefinedInformation = new List<Tmsv2customersMerchantDefinedInformation>();
            string merchantDefinedInformationName1 = "data1";
            string merchantDefinedInformationValue1 = "Your customer data";
            merchantDefinedInformation.Add(new Tmsv2customersMerchantDefinedInformation(
                Name: merchantDefinedInformationName1,
                Value: merchantDefinedInformationValue1
           ));

            var requestObj = new PatchCustomerRequest(
                BuyerInformation: buyerInformation,
                ClientReferenceInformation: clientReferenceInformation,
                MerchantDefinedInformation: merchantDefinedInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CustomerApi(clientConfig);
                PatchCustomerRequest result = apiInstance.PatchCustomer(customerTokenId, requestObj);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
