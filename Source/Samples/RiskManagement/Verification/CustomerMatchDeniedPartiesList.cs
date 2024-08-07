using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RiskManagement
{
    public class CustomerMatchDeniedPartiesList
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static RiskV1ExportComplianceInquiriesPost201Response Run()
        {
            string clientReferenceInformationCode = "verification example";
            string clientReferenceInformationComments = "Export-basic";
            string clientReferenceInformationPartnerDeveloperId = "7891234";
            string clientReferenceInformationPartnerSolutionId = "89012345";
            Riskv1decisionsClientReferenceInformationPartner clientReferenceInformationPartner = new Riskv1decisionsClientReferenceInformationPartner(
                DeveloperId: clientReferenceInformationPartnerDeveloperId,
                SolutionId: clientReferenceInformationPartnerSolutionId
           );

            Riskv1liststypeentriesClientReferenceInformation clientReferenceInformation = new Riskv1liststypeentriesClientReferenceInformation(
                Code: clientReferenceInformationCode,
                Comments: clientReferenceInformationComments,
                Partner: clientReferenceInformationPartner
           );

            string orderInformationBillToAddress1 = "901 Metro Centre Blvd";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToLocality = "Foster City";
            string orderInformationBillToPostalCode = "94404";
            string orderInformationBillToCompanyName = "A & C International Trade, Inc";
            Riskv1exportcomplianceinquiriesOrderInformationBillToCompany orderInformationBillToCompany = new Riskv1exportcomplianceinquiriesOrderInformationBillToCompany(
                Name: orderInformationBillToCompanyName
           );

            string orderInformationBillToFirstName = "ANDREE";
            string orderInformationBillToLastName = "AGNESE";
            string orderInformationBillToEmail = "test@domain.com";
            Riskv1exportcomplianceinquiriesOrderInformationBillTo orderInformationBillTo = new Riskv1exportcomplianceinquiriesOrderInformationBillTo(
                Address1: orderInformationBillToAddress1,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                Country: orderInformationBillToCountry,
                Locality: orderInformationBillToLocality,
                PostalCode: orderInformationBillToPostalCode,
                Company: orderInformationBillToCompany,
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                Email: orderInformationBillToEmail
           );

            string orderInformationShipToCountry = "IN";
            string orderInformationShipToFirstName = "DumbelDore";
            string orderInformationShipToLastName = "Albus";
            Riskv1exportcomplianceinquiriesOrderInformationShipTo orderInformationShipTo = new Riskv1exportcomplianceinquiriesOrderInformationShipTo(
                Country: orderInformationShipToCountry,
                FirstName: orderInformationShipToFirstName,
                LastName: orderInformationShipToLastName
           );


            List<Riskv1exportcomplianceinquiriesOrderInformationLineItems> orderInformationLineItems = new List<Riskv1exportcomplianceinquiriesOrderInformationLineItems>();
            string orderInformationLineItemsUnitPrice1 = "120.50";
            int orderInformationLineItemsQuantity1 = 3;
            string orderInformationLineItemsProductSKU1 = "123456";
            string orderInformationLineItemsProductName1 = "Qwe";
            string orderInformationLineItemsProductCode1 = "physical_software";
            orderInformationLineItems.Add(new Riskv1exportcomplianceinquiriesOrderInformationLineItems(
                UnitPrice: orderInformationLineItemsUnitPrice1,
                Quantity: orderInformationLineItemsQuantity1,
                ProductSKU: orderInformationLineItemsProductSKU1,
                ProductName: orderInformationLineItemsProductName1,
                ProductCode: orderInformationLineItemsProductCode1
           ));

            Riskv1exportcomplianceinquiriesOrderInformation orderInformation = new Riskv1exportcomplianceinquiriesOrderInformation(
                BillTo: orderInformationBillTo,
                ShipTo: orderInformationShipTo,
                LineItems: orderInformationLineItems
           );

            var requestObj = new ValidateExportComplianceRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new VerificationApi(clientConfig);
                RiskV1ExportComplianceInquiriesPost201Response result = apiInstance.ValidateExportCompliance(requestObj);
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
