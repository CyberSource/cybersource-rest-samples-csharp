using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
	public class CreateSubscription
	{
		public static CreateSubscriptionResponse Run()
		{
			string clientReferenceInformationCode = "TC501713";
			string clientReferenceInformationPartnerDeveloperId = "ABCD1234";
			string clientReferenceInformationPartnerSolutionId = "GEF1234";
			Riskv1decisionsClientReferenceInformationPartner clientReferenceInformationPartner = new Riskv1decisionsClientReferenceInformationPartner(
				DeveloperId: clientReferenceInformationPartnerDeveloperId,
				SolutionId: clientReferenceInformationPartnerSolutionId
			);

			string clientReferenceInformationApplicationName = "CYBS-SDK";
			string clientReferenceInformationApplicationVersion = "v1";
			Rbsv1subscriptionsClientReferenceInformation clientReferenceInformation = new Rbsv1subscriptionsClientReferenceInformation(
				Code: clientReferenceInformationCode,
				Partner: clientReferenceInformationPartner,
				ApplicationName: clientReferenceInformationApplicationName,
				ApplicationVersion: clientReferenceInformationApplicationVersion
			);

			string processingInformationCommerceIndicator = "recurring";
			string processingInformationAuthorizationOptionsInitiatorType = "merchant";
			Rbsv1subscriptionsProcessingInformationAuthorizationOptionsInitiator processingInformationAuthorizationOptionsInitiator = new Rbsv1subscriptionsProcessingInformationAuthorizationOptionsInitiator(
				Type: processingInformationAuthorizationOptionsInitiatorType
			);

			Rbsv1subscriptionsProcessingInformationAuthorizationOptions processingInformationAuthorizationOptions = new Rbsv1subscriptionsProcessingInformationAuthorizationOptions(
				Initiator: processingInformationAuthorizationOptionsInitiator
			);

			Rbsv1subscriptionsProcessingInformation processingInformation = new Rbsv1subscriptionsProcessingInformation(
				CommerceIndicator: processingInformationCommerceIndicator,
				AuthorizationOptions: processingInformationAuthorizationOptions
			);

			string subscriptionInformationPlanId = "6868912495476705603955";
			string subscriptionInformationName = "Subscription with PlanId";
			string subscriptionInformationStartDate = "2030-06-11";
			Rbsv1subscriptionsSubscriptionInformation subscriptionInformation = new Rbsv1subscriptionsSubscriptionInformation(
				PlanId: subscriptionInformationPlanId,
				Name: subscriptionInformationName,
				StartDate: subscriptionInformationStartDate
			);

			string paymentInformationCustomerId = "C24F5921EB870D99E053AF598E0A4105";
			Rbsv1subscriptionsPaymentInformationCustomer paymentInformationCustomer = new Rbsv1subscriptionsPaymentInformationCustomer(
				Id: paymentInformationCustomerId
			);

			Rbsv1subscriptionsPaymentInformation paymentInformation = new Rbsv1subscriptionsPaymentInformation(
				Customer: paymentInformationCustomer
			);

			var requestObj = new CreateSubscriptionRequest(
				ClientReferenceInformation: clientReferenceInformation,
				ProcessingInformation: processingInformation,
				SubscriptionInformation: subscriptionInformation,
				PaymentInformation: paymentInformation
			);

            CreateSubscriptionResponse response = null;
			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new SubscriptionsApi(clientConfig);
				response = apiInstance.CreateSubscription(requestObj);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
			return response;
		}
	}
}