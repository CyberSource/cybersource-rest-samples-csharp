using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Risk_Management
{
    public class MultipleSanctionLists
    {
        public static RiskV1ExportComplianceInquiriesPost201Response Run()
        {
            string clientReferenceInformationCode = "verification example";
            string clientReferenceInformationComments = "All fields";
            Riskv1addressverificationsClientReferenceInformation clientReferenceInformation = new Riskv1addressverificationsClientReferenceInformation(
                Code: clientReferenceInformationCode,
                Comments: clientReferenceInformationComments
           );

            string orderInformationBillToAddress1 = "901 Metro Centre Blvd";
            string orderInformationBillToAddress2 = " ";
            string orderInformationBillToAddress3 = "";
            string orderInformationBillToAddress4 = "Foster City";
            string orderInformationBillToAdministrativeArea = "NH";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToLocality = "CA";
            string orderInformationBillToPostalCode = "03055";
            string orderInformationBillToCompanyName = "A & C International Trade, Inc.";
            Riskv1exportcomplianceinquiriesOrderInformationBillToCompany orderInformationBillToCompany = new Riskv1exportcomplianceinquiriesOrderInformationBillToCompany(
                Name: orderInformationBillToCompanyName
           );

            string orderInformationBillToFirstName = "Suman";
            string orderInformationBillToLastName = "Kumar";
            string orderInformationBillToEmail = "test@domain.com";
            Riskv1exportcomplianceinquiriesOrderInformationBillTo orderInformationBillTo = new Riskv1exportcomplianceinquiriesOrderInformationBillTo(
                Address1: orderInformationBillToAddress1,
                Address2: orderInformationBillToAddress2,
                Address3: orderInformationBillToAddress3,
                Address4: orderInformationBillToAddress4,
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


            List <Riskv1exportcomplianceinquiriesOrderInformationLineItems> orderInformationLineItems = new List <Riskv1exportcomplianceinquiriesOrderInformationLineItems>();
            string orderInformationLineItemsUnitPrice1 = "120.50";
            int orderInformationLineItemsQuantity1 = 3;
            string orderInformationLineItemsProductSKU1 = "610009";
            string orderInformationLineItemsProductName1 = "Xer";
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

            string buyerInformationMerchantCustomerId = "Export1";
            Riskv1addressverificationsBuyerInformation buyerInformation = new Riskv1addressverificationsBuyerInformation(
                MerchantCustomerId: buyerInformationMerchantCustomerId
           );

            string deviceInformationIpAddress = "127.0.0.1";
            string deviceInformationHostName = "www.cybersource.ir";
            Riskv1exportcomplianceinquiriesDeviceInformation deviceInformation = new Riskv1exportcomplianceinquiriesDeviceInformation(
                IpAddress: deviceInformationIpAddress,
                HostName: deviceInformationHostName
           );

            string exportComplianceInformationAddressOperator = "and";
            string exportComplianceInformationWeightsAddress = "low";
            string exportComplianceInformationWeightsCompany = "exact";
            string exportComplianceInformationWeightsName = "exact";
            Riskv1exportcomplianceinquiriesExportComplianceInformationWeights exportComplianceInformationWeights = new Riskv1exportcomplianceinquiriesExportComplianceInformationWeights(
                Address: exportComplianceInformationWeightsAddress,
                Company: exportComplianceInformationWeightsCompany,
                Name: exportComplianceInformationWeightsName
           );


            List <string> exportComplianceInformationSanctionLists = new List <string>();
            exportComplianceInformationSanctionLists.Add("Bureau Of Industry and Security");
            exportComplianceInformationSanctionLists.Add("DOS_DTC");
            exportComplianceInformationSanctionLists.Add("AUSTRALIA");
            Riskv1exportcomplianceinquiriesExportComplianceInformation exportComplianceInformation = new Riskv1exportcomplianceinquiriesExportComplianceInformation(
                AddressOperator: exportComplianceInformationAddressOperator,
                Weights: exportComplianceInformationWeights,
                SanctionLists: exportComplianceInformationSanctionLists
           );

            var requestObj = new ValidateExportComplianceRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation,
                BuyerInformation: buyerInformation,
                DeviceInformation: deviceInformation,
                ExportComplianceInformation: exportComplianceInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new VerificationApi(clientConfig);
                RiskV1ExportComplianceInquiriesPost201Response result = apiInstance.ValidateExportCompliance(requestObj);
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
