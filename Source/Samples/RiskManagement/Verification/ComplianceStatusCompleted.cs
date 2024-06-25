using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RiskManagement
{
    public class ComplianceStatusCompleted
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
            Riskv1liststypeentriesClientReferenceInformation clientReferenceInformation = new Riskv1liststypeentriesClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string orderInformationBillToAddress1 = "901 Metro Centre Blvd";
            string orderInformationBillToAddress2 = "2";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToLocality = "Foster City";
            string orderInformationBillToPostalCode = "94404";
            string orderInformationBillToFirstName = "Suman";
            string orderInformationBillToLastName = "Kumar";
            string orderInformationBillToEmail = "donewithhorizon@test.com";
            Riskv1exportcomplianceinquiriesOrderInformationBillTo orderInformationBillTo = new Riskv1exportcomplianceinquiriesOrderInformationBillTo(
                Address1: orderInformationBillToAddress1,
                Address2: orderInformationBillToAddress2,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                Country: orderInformationBillToCountry,
                Locality: orderInformationBillToLocality,
                PostalCode: orderInformationBillToPostalCode,
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                Email: orderInformationBillToEmail
           );

            string orderInformationShipToCountry = "be";
            string orderInformationShipToFirstName = "DumbelDore";
            string orderInformationShipToLastName = "Albus";
            Riskv1exportcomplianceinquiriesOrderInformationShipTo orderInformationShipTo = new Riskv1exportcomplianceinquiriesOrderInformationShipTo(
                Country: orderInformationShipToCountry,
                FirstName: orderInformationShipToFirstName,
                LastName: orderInformationShipToLastName
           );


            List<Riskv1exportcomplianceinquiriesOrderInformationLineItems> orderInformationLineItems = new List<Riskv1exportcomplianceinquiriesOrderInformationLineItems>();
            string orderInformationLineItemsUnitPrice1 = "19.00";
            orderInformationLineItems.Add(new Riskv1exportcomplianceinquiriesOrderInformationLineItems(
                UnitPrice: orderInformationLineItemsUnitPrice1
           ));

            Riskv1exportcomplianceinquiriesOrderInformation orderInformation = new Riskv1exportcomplianceinquiriesOrderInformation(
                BillTo: orderInformationBillTo,
                ShipTo: orderInformationShipTo,
                LineItems: orderInformationLineItems
           );

            string buyerInformationMerchantCustomerId = "87789";
            Riskv1addressverificationsBuyerInformation buyerInformation = new Riskv1addressverificationsBuyerInformation(
                MerchantCustomerId: buyerInformationMerchantCustomerId
           );

            string exportComplianceInformationAddressOperator = "and";
            string exportComplianceInformationWeightsAddress = "abc";
            string exportComplianceInformationWeightsCompany = "def";
            string exportComplianceInformationWeightsName = "adb";
            Ptsv2paymentsWatchlistScreeningInformationWeights exportComplianceInformationWeights = new Ptsv2paymentsWatchlistScreeningInformationWeights(
                Address: exportComplianceInformationWeightsAddress,
                Company: exportComplianceInformationWeightsCompany,
                Name: exportComplianceInformationWeightsName
           );


            List<string> exportComplianceInformationSanctionLists = new List<string>();
            exportComplianceInformationSanctionLists.Add("abc");
            exportComplianceInformationSanctionLists.Add("acc");
            exportComplianceInformationSanctionLists.Add("bac");
            Riskv1exportcomplianceinquiriesExportComplianceInformation exportComplianceInformation = new Riskv1exportcomplianceinquiriesExportComplianceInformation(
                AddressOperator: exportComplianceInformationAddressOperator,
                Weights: exportComplianceInformationWeights,
                SanctionLists: exportComplianceInformationSanctionLists
           );

            var requestObj = new ValidateExportComplianceRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation,
                BuyerInformation: buyerInformation,
                ExportComplianceInformation: exportComplianceInformation
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
