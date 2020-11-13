using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.ValueAddedService
{
    public class TaxRefundRequest
    {
        public static VasV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "TAX_TC001";
            Vasv2taxClientReferenceInformation clientReferenceInformation = new Vasv2taxClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string taxInformationShowTaxPerLineItem = "Yes";
            bool taxInformationRefundIndicator = true;
            Vasv2taxTaxInformation taxInformation = new Vasv2taxTaxInformation(
                ShowTaxPerLineItem: taxInformationShowTaxPerLineItem,
                RefundIndicator: taxInformationRefundIndicator
           );

            string orderInformationAmountDetailsCurrency = "USD";
            RiskV1DecisionsPost201ResponseOrderInformationAmountDetails orderInformationAmountDetails = new RiskV1DecisionsPost201ResponseOrderInformationAmountDetails(
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToAddress1 = "1 Market St";
            string orderInformationBillToLocality = "San Francisco";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToPostalCode = "94105";
            string orderInformationBillToCountry = "US";
            Vasv2taxOrderInformationBillTo orderInformationBillTo = new Vasv2taxOrderInformationBillTo(
                Address1: orderInformationBillToAddress1,
                Locality: orderInformationBillToLocality,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                PostalCode: orderInformationBillToPostalCode,
                Country: orderInformationBillToCountry
           );

            string orderInformationShippingDetailsShipFromLocality = "Cambridge Bay";
            string orderInformationShippingDetailsShipFromCountry = "CA";
            string orderInformationShippingDetailsShipFromPostalCode = "A0G 1T0";
            string orderInformationShippingDetailsShipFromAdministrativeArea = "NL";
            Vasv2taxOrderInformationShippingDetails orderInformationShippingDetails = new Vasv2taxOrderInformationShippingDetails(
                ShipFromLocality: orderInformationShippingDetailsShipFromLocality,
                ShipFromCountry: orderInformationShippingDetailsShipFromCountry,
                ShipFromPostalCode: orderInformationShippingDetailsShipFromPostalCode,
                ShipFromAdministrativeArea: orderInformationShippingDetailsShipFromAdministrativeArea
           );

            string orderInformationShipToCountry = "US";
            string orderInformationShipToAdministrativeArea = "FL";
            string orderInformationShipToLocality = "Panama City";
            string orderInformationShipToPostalCode = "32401";
            string orderInformationShipToAddress1 = "123 Russel St.";
            Vasv2taxOrderInformationShipTo orderInformationShipTo = new Vasv2taxOrderInformationShipTo(
                Country: orderInformationShipToCountry,
                AdministrativeArea: orderInformationShipToAdministrativeArea,
                Locality: orderInformationShipToLocality,
                PostalCode: orderInformationShipToPostalCode,
                Address1: orderInformationShipToAddress1
           );


            List<Vasv2taxOrderInformationLineItems> orderInformationLineItems = new List<Vasv2taxOrderInformationLineItems>();
            string orderInformationLineItemsProductSKU1 = "07-12-00657";
            string orderInformationLineItemsProductCode1 = "50161815";
            int orderInformationLineItemsQuantity1 = 1;
            string orderInformationLineItemsProductName1 = "Chewing Gum";
            string orderInformationLineItemsUnitPrice1 = "1200";
            orderInformationLineItems.Add(new Vasv2taxOrderInformationLineItems(
                ProductSKU: orderInformationLineItemsProductSKU1,
                ProductCode: orderInformationLineItemsProductCode1,
                Quantity: orderInformationLineItemsQuantity1,
                ProductName: orderInformationLineItemsProductName1,
                UnitPrice: orderInformationLineItemsUnitPrice1
           ));

            string orderInformationLineItemsProductSKU2 = "07-12-00659";
            string orderInformationLineItemsProductCode2 = "50181905";
            int orderInformationLineItemsQuantity2 = 1;
            string orderInformationLineItemsProductName2 = "Sugar Cookies";
            string orderInformationLineItemsUnitPrice2 = "1240";
            orderInformationLineItems.Add(new Vasv2taxOrderInformationLineItems(
                ProductSKU: orderInformationLineItemsProductSKU2,
                ProductCode: orderInformationLineItemsProductCode2,
                Quantity: orderInformationLineItemsQuantity2,
                ProductName: orderInformationLineItemsProductName2,
                UnitPrice: orderInformationLineItemsUnitPrice2
           ));

            string orderInformationLineItemsProductSKU3 = "07-12-00658";
            string orderInformationLineItemsProductCode3 = "5020.11";
            int orderInformationLineItemsQuantity3 = 1;
            string orderInformationLineItemsProductName3 = "Carbonated Water";
            string orderInformationLineItemsUnitPrice3 = "9001";
            orderInformationLineItems.Add(new Vasv2taxOrderInformationLineItems(
                ProductSKU: orderInformationLineItemsProductSKU3,
                ProductCode: orderInformationLineItemsProductCode3,
                Quantity: orderInformationLineItemsQuantity3,
                ProductName: orderInformationLineItemsProductName3,
                UnitPrice: orderInformationLineItemsUnitPrice3
           ));

            Vasv2taxOrderInformation orderInformation = new Vasv2taxOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo,
                ShippingDetails: orderInformationShippingDetails,
                ShipTo: orderInformationShipTo,
                LineItems: orderInformationLineItems
           );

            string merchantInformationVatRegistrationNumber = "abcdef";
            Vasv2taxMerchantInformation merchantInformation = new Vasv2taxMerchantInformation(
                VatRegistrationNumber: merchantInformationVatRegistrationNumber
           );

            var requestObj = new TaxRequest(
                ClientReferenceInformation: clientReferenceInformation,
                TaxInformation: taxInformation,
                OrderInformation: orderInformation,
                MerchantInformation: merchantInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TaxesApi(clientConfig);
                VasV2PaymentsPost201Response result = apiInstance.CalculateTax(requestObj);
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
