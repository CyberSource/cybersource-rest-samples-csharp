using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RiskManagement
{
    public class CanadianBillingDetails
    {
        public static RiskV1AddressVerificationsPost201Response Run()
        {
            string clientReferenceInformationCode = "addressEg";
            string clientReferenceInformationComments = "dav-All fields";
            Riskv1addressverificationsClientReferenceInformation clientReferenceInformation = new Riskv1addressverificationsClientReferenceInformation(
                Code: clientReferenceInformationCode,
                Comments: clientReferenceInformationComments
           );

            string orderInformationBillToAddress1 = "1650 Burton Ave";
            string orderInformationBillToAddress2 = "";
            string orderInformationBillToAddress3 = "";
            string orderInformationBillToAddress4 = "";
            string orderInformationBillToAdministrativeArea = "BC";
            string orderInformationBillToCountry = "CA";
            string orderInformationBillToLocality = "VICTORIA";
            string orderInformationBillToPostalCode = "V8T 2N6";
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


            List <Riskv1addressverificationsOrderInformationLineItems> orderInformationLineItems = new List <Riskv1addressverificationsOrderInformationLineItems>();
            string orderInformationLineItemsUnitPrice1 = "120.50";
            int orderInformationLineItemsQuantity1 = 3;
            string orderInformationLineItemsProductSKU1 = "9966223";
            string orderInformationLineItemsProductName1 = "headset";
            string orderInformationLineItemsProductCode1 = "electronic";
            orderInformationLineItems.Add(new Riskv1addressverificationsOrderInformationLineItems(
                UnitPrice: orderInformationLineItemsUnitPrice1,
                Quantity: orderInformationLineItemsQuantity1,
                ProductSKU: orderInformationLineItemsProductSKU1,
                ProductName: orderInformationLineItemsProductName1,
                ProductCode: orderInformationLineItemsProductCode1
           ));

            Riskv1addressverificationsOrderInformation orderInformation = new Riskv1addressverificationsOrderInformation(
                BillTo: orderInformationBillTo,
                LineItems: orderInformationLineItems
           );

            string buyerInformationMerchantCustomerId = "ABCD";
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
