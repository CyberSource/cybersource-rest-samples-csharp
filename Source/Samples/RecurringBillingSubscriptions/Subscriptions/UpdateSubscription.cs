using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
	public class UpdateSubscription
	{
		public static void Run()
		{
			string clientReferenceInformationCode = "APGHU";
			string clientReferenceInformationPartnerDeveloperId = "ABCD1234";
			string clientReferenceInformationPartnerSolutionId = "GEF1234";
			//Rbsv1subscriptionsClientReferenceInformationPartner clientReferenceInformationPartner = new Rbsv1subscriptionsClientReferenceInformationPartner(
			//	DeveloperId: clientReferenceInformationPartnerDeveloperId,
			//	SolutionId: clientReferenceInformationPartnerSolutionId
			//);

			//Rbsv1subscriptionsClientReferenceInformation clientReferenceInformation = new Rbsv1subscriptionsClientReferenceInformation(
			//	Code: clientReferenceInformationCode,
			//	Partner: clientReferenceInformationPartner
			//);

			string processingInformationAuthorizationOptionsInitiatorType = "merchant";
			Rbsv1subscriptionsProcessingInformationAuthorizationOptionsInitiator processingInformationAuthorizationOptionsInitiator = new Rbsv1subscriptionsProcessingInformationAuthorizationOptionsInitiator(
				Type: processingInformationAuthorizationOptionsInitiatorType
			);

			Rbsv1subscriptionsProcessingInformationAuthorizationOptions processingInformationAuthorizationOptions = new Rbsv1subscriptionsProcessingInformationAuthorizationOptions(
				Initiator: processingInformationAuthorizationOptionsInitiator
			);

			Rbsv1subscriptionsProcessingInformation processingInformation = new Rbsv1subscriptionsProcessingInformation(
				AuthorizationOptions: processingInformationAuthorizationOptions
			);

			string subscriptionInformationPlanId = "424242442";
			string subscriptionInformationName = "Gold subs";
			string subscriptionInformationStartDate = "2024-06-15";
			Rbsv1subscriptionsidSubscriptionInformation subscriptionInformation = new Rbsv1subscriptionsidSubscriptionInformation(
				PlanId: subscriptionInformationPlanId,
				Name: subscriptionInformationName,
				StartDate: subscriptionInformationStartDate
			);

			string orderInformationAmountDetailsBillingAmount = "10";
			string orderInformationAmountDetailsSetupFee = "5";
			Rbsv1subscriptionsidOrderInformationAmountDetails orderInformationAmountDetails = new Rbsv1subscriptionsidOrderInformationAmountDetails(
				BillingAmount: orderInformationAmountDetailsBillingAmount,
				SetupFee: orderInformationAmountDetailsSetupFee
			);

			Rbsv1subscriptionsidOrderInformation orderInformation = new Rbsv1subscriptionsidOrderInformation(
				AmountDetails: orderInformationAmountDetails
			);

			var requestObj = new CyberSource.Model.UpdateSubscription(
				//ClientReferenceInformation: clientReferenceInformation,
				ProcessingInformation: processingInformation,
				SubscriptionInformation: subscriptionInformation,
				OrderInformation: orderInformation
			);

			try
			{
				var id = CreateSubscription.Run().Id;
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new SubscriptionsApi(clientConfig);
				apiInstance.UpdateSubscription(id, requestObj);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
		}
	}
}