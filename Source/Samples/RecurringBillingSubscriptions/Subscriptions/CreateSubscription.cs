using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
	public class CreateSubscription
	{
		public static async System.Threading.Tasks.Task<CreateSubscriptionResponse> RunAsync()
		{
			string clientReferenceInformationCode = "TC501713";
			//GetAllSubscriptionsResponseClientReferenceInformation clientReferenceInformation = new GetAllSubscriptionsResponseClientReferenceInformation(
			//	Code: clientReferenceInformationCode
			//);

			string processingInformationCommerceIndicator = "recurring";
			string processingInformationAuthorizationOptionsInitiatorType = "merchant";
			RbsAuthorizationOptionsInitiator processingInformationAuthorizationOptionsInitiator = new RbsAuthorizationOptionsInitiator(
				Type: processingInformationAuthorizationOptionsInitiatorType
			);

			RbsAuthorizationOptions processingInformationAuthorizationOptions = new RbsAuthorizationOptions(
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
				//ClientReferenceInformation: clientReferenceInformation,
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
				response = await apiInstance.CreateSubscriptionAsync(requestObj);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
			return response;
		}
	}
}