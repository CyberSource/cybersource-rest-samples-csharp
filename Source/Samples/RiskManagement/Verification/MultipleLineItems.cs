using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RiskManagement
{
    public class MultipleLineItems
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
            string clientReferenceInformationComments = "dav-All fields";
            Riskv1liststypeentriesClientReferenceInformation clientReferenceInformation = new Riskv1liststypeentriesClientReferenceInformation(
                Code: clientReferenceInformationCode,
                Comments: clientReferenceInformationComments
           );

            string orderInformationBillToAddress1 = "12301 research st";
            string orderInformationBillToAddress2 = "1";
            string orderInformationBillToAddress3 = "2";
            string orderInformationBillToAddress4 = "3";
            string orderInformationBillToAdministrativeArea = "TX";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToLocality = "Austin";
            string orderInformationBillToPostalCode = "78759";
            Riskv1addressverificationsOrderInformationBillTo orderInformationBillTo = new Riskv1addressverificationsOrderInformationBillTo(
                Address1: orderInformationBillToAddress1,
                Address2: orderInformationBillToAddress2,
                Address3: orderInformationBillToAddress3,
                Address4: orderInformationBillToAddress4,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                Country: orderInformationBillToCountry,
                Locality: orderInformationBillToLocality,
                PostalCode: orderInformationBillToPostalCode
           );

            string orderInformationShipToAddress1 = "PO Box 9088";
            string orderInformationShipToAddress2 = "";
            string orderInformationShipToAddress3 = "";
            string orderInformationShipToAddress4 = "";
            string orderInformationShipToAdministrativeArea = "CA";
            string orderInformationShipToCountry = "US";
            string orderInformationShipToLocality = "San Jose";
            string orderInformationShipToPostalCode = "95132";
            Riskv1addressverificationsOrderInformationShipTo orderInformationShipTo = new Riskv1addressverificationsOrderInformationShipTo(
                Address1: orderInformationShipToAddress1,
                Address2: orderInformationShipToAddress2,
                Address3: orderInformationShipToAddress3,
                Address4: orderInformationShipToAddress4,
                AdministrativeArea: orderInformationShipToAdministrativeArea,
                Country: orderInformationShipToCountry,
                Locality: orderInformationShipToLocality,
                PostalCode: orderInformationShipToPostalCode
           );


            List<Riskv1addressverificationsOrderInformationLineItems> orderInformationLineItems = new List<Riskv1addressverificationsOrderInformationLineItems>();
            string orderInformationLineItemsUnitPrice1 = "120.50";
            int orderInformationLineItemsQuantity1 = 3;
            string orderInformationLineItemsProductSKU1 = "9966223";
            string orderInformationLineItemsProductName1 = "headset";
            string orderInformationLineItemsProductCode1 = "electronix";
            orderInformationLineItems.Add(new Riskv1addressverificationsOrderInformationLineItems(
                UnitPrice: orderInformationLineItemsUnitPrice1,
                Quantity: orderInformationLineItemsQuantity1,
                ProductSKU: orderInformationLineItemsProductSKU1,
                ProductName: orderInformationLineItemsProductName1,
                ProductCode: orderInformationLineItemsProductCode1
           ));

            string orderInformationLineItemsUnitPrice2 = "10.50";
            int orderInformationLineItemsQuantity2 = 2;
            string orderInformationLineItemsProductSKU2 = "9966226";
            string orderInformationLineItemsProductName2 = "wwrdf";
            string orderInformationLineItemsProductCode2 = "electronic";
            orderInformationLineItems.Add(new Riskv1addressverificationsOrderInformationLineItems(
                UnitPrice: orderInformationLineItemsUnitPrice2,
                Quantity: orderInformationLineItemsQuantity2,
                ProductSKU: orderInformationLineItemsProductSKU2,
                ProductName: orderInformationLineItemsProductName2,
                ProductCode: orderInformationLineItemsProductCode2
           ));

            Riskv1addressverificationsOrderInformation orderInformation = new Riskv1addressverificationsOrderInformation(
                BillTo: orderInformationBillTo,
                ShipTo: orderInformationShipTo,
                LineItems: orderInformationLineItems
           );

            string buyerInformationMerchantCustomerId = "QWERTY";
            Riskv1addressverificationsBuyerInformation buyerInformation = new Riskv1addressverificationsBuyerInformation(
                MerchantCustomerId: buyerInformationMerchantCustomerId
           );

            var requestObj = new VerifyCustomerAddressRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation,
                BuyerInformation: buyerInformation
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
