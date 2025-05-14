using CyberSource.Api;
using CyberSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet.Samples.Invoicing
{
    public class UpdateInvoice
    {
        public static InvoicingV2InvoicesPut200Response Run()
        {
            var invoiceId = CreateDraftInvoice.Run().Id;

            string customerInformationName = "New Customer Name";
            string customerInformationEmail = "new_email@my-email.world";
            Invoicingv2invoicesCustomerInformation customerInformation = new Invoicingv2invoicesCustomerInformation(
                Name: customerInformationName,
                Email: customerInformationEmail
            );

            string invoiceInformationDescription = "This is after updating invoice";
            DateTime invoiceInformationDueDate = DateTime.Parse("2019-07-11");
            bool invoiceInformationAllowPartialPayments = true;
            string invoiceInformationDeliveryMode = "none";
            Invoicingv2invoicesidInvoiceInformation invoiceInformation = new Invoicingv2invoicesidInvoiceInformation(
                Description: invoiceInformationDescription,
                DueDate: invoiceInformationDueDate,
                AllowPartialPayments: invoiceInformationAllowPartialPayments,
                DeliveryMode: invoiceInformationDeliveryMode
            );

            string orderInformationAmountDetailsTotalAmount = "2623.64";
            string orderInformationAmountDetailsCurrency = "USD";
            string orderInformationAmountDetailsDiscountAmount = "126.08";
            decimal orderInformationAmountDetailsDiscountPercent = 5.00M;
            decimal orderInformationAmountDetailsSubAmount = 2749.72M;
            decimal orderInformationAmountDetailsMinimumPartialAmount = 20.00M;
            string orderInformationAmountDetailsTaxDetailsType = "State Tax";
            string orderInformationAmountDetailsTaxDetailsAmount = "208.00";
            string orderInformationAmountDetailsTaxDetailsRate = "8.25";
            Invoicingv2invoicesOrderInformationAmountDetailsTaxDetails orderInformationAmountDetailsTaxDetails = new Invoicingv2invoicesOrderInformationAmountDetailsTaxDetails(
                Type: orderInformationAmountDetailsTaxDetailsType,
                Amount: orderInformationAmountDetailsTaxDetailsAmount,
                Rate: orderInformationAmountDetailsTaxDetailsRate
            );

            string orderInformationAmountDetailsFreightAmount = "20.00";
            bool orderInformationAmountDetailsFreightTaxable = true;
            Invoicingv2invoicesOrderInformationAmountDetailsFreight orderInformationAmountDetailsFreight = new Invoicingv2invoicesOrderInformationAmountDetailsFreight(
                Amount: orderInformationAmountDetailsFreightAmount,
                Taxable: orderInformationAmountDetailsFreightTaxable
            );

            Invoicingv2invoicesOrderInformationAmountDetails orderInformationAmountDetails = new Invoicingv2invoicesOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency,
                DiscountAmount: orderInformationAmountDetailsDiscountAmount,
                DiscountPercent: orderInformationAmountDetailsDiscountPercent.ToString(),
                SubAmount: orderInformationAmountDetailsSubAmount.ToString(),
                MinimumPartialAmount: orderInformationAmountDetailsMinimumPartialAmount.ToString(),
                TaxDetails: orderInformationAmountDetailsTaxDetails,
                Freight: orderInformationAmountDetailsFreight
            );

            List<Invoicingv2invoicesOrderInformationLineItems> orderInformationLineItems = new List<Invoicingv2invoicesOrderInformationLineItems>();
            string orderInformationLineItemsProductSku1 = "P653727383";
            string orderInformationLineItemsProductName1 = "First line item's name";
            int orderInformationLineItemsQuantity1 = 21;
            string orderInformationLineItemsUnitPrice1 = "120.08";
            orderInformationLineItems.Add(new Invoicingv2invoicesOrderInformationLineItems(
                ProductSku: orderInformationLineItemsProductSku1,
                ProductName: orderInformationLineItemsProductName1,
                Quantity: orderInformationLineItemsQuantity1,
                UnitPrice: orderInformationLineItemsUnitPrice1
            ));

            Invoicingv2invoicesOrderInformation orderInformation = new Invoicingv2invoicesOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                LineItems: orderInformationLineItems
            );

            var requestObj = new UpdateInvoiceRequest(
                CustomerInformation: customerInformation,
                InvoiceInformation: invoiceInformation,
                OrderInformation: orderInformation
            );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InvoicesApi(clientConfig);
                InvoicingV2InvoicesPut200Response result = apiInstance.UpdateInvoice(invoiceId, requestObj);
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
