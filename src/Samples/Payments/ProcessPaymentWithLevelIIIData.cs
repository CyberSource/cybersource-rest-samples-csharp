using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class ProcessPaymentWithLevelIIIData
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "TC50171_14";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = false;
            string processingInformationCommerceIndicator = "internet";
            string processingInformationPurchaseLevel = "3";
            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                Capture: processingInformationCapture,
                CommerceIndicator: processingInformationCommerceIndicator,
                PurchaseLevel: processingInformationPurchaseLevel
           );

            string paymentInformationCardNumber = "4111111111111111";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2031";
            string paymentInformationCardType = "001";
            string paymentInformationCardSecurityCode = "123";
            Ptsv2paymentsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsPaymentInformationCard(
                Number: paymentInformationCardNumber,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear,
                Type: paymentInformationCardType,
                SecurityCode: paymentInformationCardSecurityCode
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                Card: paymentInformationCard
           );

            string orderInformationAmountDetailsTotalAmount = "100.00";
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


            List <Ptsv2paymentsOrderInformationLineItems> orderInformationLineItems = new List <Ptsv2paymentsOrderInformationLineItems>();
            string orderInformationLineItemsProductCode1 = "default";
            int orderInformationLineItemsQuantity1 = 10;
            string orderInformationLineItemsUnitPrice1 = "10.00";
            string orderInformationLineItemsTotalAmount1 = "100";
            bool orderInformationLineItemsAmountIncludesTax1 = false;
            bool orderInformationLineItemsDiscountApplied1 = false;
            orderInformationLineItems.Add(new Ptsv2paymentsOrderInformationLineItems(
                ProductCode: orderInformationLineItemsProductCode1,
                Quantity: orderInformationLineItemsQuantity1,
                UnitPrice: orderInformationLineItemsUnitPrice1,
                TotalAmount: orderInformationLineItemsTotalAmount1,
                AmountIncludesTax: orderInformationLineItemsAmountIncludesTax1,
                DiscountApplied: orderInformationLineItemsDiscountApplied1
           ));

            string orderInformationInvoiceDetailsPurchaseOrderNumber = "LevelIII Auth Po";
            Ptsv2paymentsOrderInformationInvoiceDetails orderInformationInvoiceDetails = new Ptsv2paymentsOrderInformationInvoiceDetails(
                PurchaseOrderNumber: orderInformationInvoiceDetailsPurchaseOrderNumber
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo,
                LineItems: orderInformationLineItems,
                InvoiceDetails: orderInformationInvoiceDetails
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
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
