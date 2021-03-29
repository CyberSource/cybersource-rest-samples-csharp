using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RiskManagement
{
    public class AddDataToList
    {
        public static RiskV1UpdatePost201Response Run()
        {
            string type = "negative";
            string orderInformationAddressAddress1 = "1234 Sample St.";
            string orderInformationAddressAddress2 = "Mountain View";
            string orderInformationAddressLocality = "California";
            string orderInformationAddressCountry = "US";
            string orderInformationAddressAdministrativeArea = "CA";
            string orderInformationAddressPostalCode = "94043";
            Riskv1liststypeentriesOrderInformationAddress orderInformationAddress = new Riskv1liststypeentriesOrderInformationAddress(
                Address1: orderInformationAddressAddress1,
                Address2: orderInformationAddressAddress2,
                Locality: orderInformationAddressLocality,
                Country: orderInformationAddressCountry,
                AdministrativeArea: orderInformationAddressAdministrativeArea,
                PostalCode: orderInformationAddressPostalCode
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Doe";
            string orderInformationBillToEmail = "test@example.com";
            Riskv1liststypeentriesOrderInformationBillTo orderInformationBillTo = new Riskv1liststypeentriesOrderInformationBillTo(
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                Email: orderInformationBillToEmail
           );

            Riskv1liststypeentriesOrderInformation orderInformation = new Riskv1liststypeentriesOrderInformation(
                Address: orderInformationAddress,
                BillTo: orderInformationBillTo
           );

            Riskv1liststypeentriesPaymentInformation paymentInformation = new Riskv1liststypeentriesPaymentInformation(
           );

            string clientReferenceInformationCode = "54323007";
            string clientReferenceInformationPartnerDeveloperId = "7891234";
            string clientReferenceInformationPartnerSolutionId = "89012345";
            Riskv1decisionsClientReferenceInformationPartner clientReferenceInformationPartner = new Riskv1decisionsClientReferenceInformationPartner(
                DeveloperId: clientReferenceInformationPartnerDeveloperId,
                SolutionId: clientReferenceInformationPartnerSolutionId
           );

            Riskv1decisionsClientReferenceInformation clientReferenceInformation = new Riskv1decisionsClientReferenceInformation(
                Code: clientReferenceInformationCode,
                Partner: clientReferenceInformationPartner
           );

            string riskInformationMarkingDetailsAction = "add";
            Riskv1liststypeentriesRiskInformationMarkingDetails riskInformationMarkingDetails = new Riskv1liststypeentriesRiskInformationMarkingDetails(
                Action: riskInformationMarkingDetailsAction
           );

            Riskv1liststypeentriesRiskInformation riskInformation = new Riskv1liststypeentriesRiskInformation(
                MarkingDetails: riskInformationMarkingDetails
           );

            var requestObj = new AddNegativeListRequest(
                OrderInformation: orderInformation,
                PaymentInformation: paymentInformation,
                ClientReferenceInformation: clientReferenceInformation,
                RiskInformation: riskInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new DecisionManagerApi(clientConfig);
                RiskV1UpdatePost201Response result = apiInstance.AddNegative(type, requestObj);
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
