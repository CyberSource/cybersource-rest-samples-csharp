using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RiskManagement
{
    public class AddressMatchNotFound
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static RiskV1AddressVerificationsPost201Response Run()
        {
            string clientReferenceInformationCode = "addressEg";
            string clientReferenceInformationComments = "dav-error response check";
            Riskv1liststypeentriesClientReferenceInformation clientReferenceInformation = new Riskv1liststypeentriesClientReferenceInformation(
                Code: clientReferenceInformationCode,
                Comments: clientReferenceInformationComments
           );

            string orderInformationBillToAddress1 = "Apt C ";
            string orderInformationBillToAddress2 = "";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToLocality = "Glendale";
            string orderInformationBillToPostalCode = "91204";
            Riskv1addressverificationsOrderInformationBillTo orderInformationBillTo = new Riskv1addressverificationsOrderInformationBillTo(
                Address1: orderInformationBillToAddress1,
                Address2: orderInformationBillToAddress2,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                Country: orderInformationBillToCountry,
                Locality: orderInformationBillToLocality,
                PostalCode: orderInformationBillToPostalCode
           );

            Riskv1addressverificationsOrderInformation orderInformation = new Riskv1addressverificationsOrderInformation(
                BillTo: orderInformationBillTo
           );

            var requestObj = new VerifyCustomerAddressRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new VerificationApi(clientConfig);
                RiskV1AddressVerificationsPost201Response result = apiInstance.VerifyCustomerAddress(requestObj);
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
