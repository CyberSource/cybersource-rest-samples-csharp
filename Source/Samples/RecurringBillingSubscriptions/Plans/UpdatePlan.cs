using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
	public class UpdatePlan
	{
		public static void Run()
		{
			string planInformationName = "Gold Plan NA";
			string planInformationDescription = "Updated Gold Plan";
			string planInformationBillingPeriodLength = "2";
			string planInformationBillingPeriodUnit = "W";
            GetAllPlansResponsePlanInformationBillingPeriod planInformationBillingPeriod = new GetAllPlansResponsePlanInformationBillingPeriod(
				Length: planInformationBillingPeriodLength,
				Unit: planInformationBillingPeriodUnit
			);

			string planInformationBillingCyclesTotal = "11";
			Rbsv1plansPlanInformationBillingCycles planInformationBillingCycles = new Rbsv1plansPlanInformationBillingCycles(
				Total: planInformationBillingCyclesTotal
			);

			Rbsv1plansidPlanInformation planInformation = new Rbsv1plansidPlanInformation(
				Name: planInformationName,
				Description: planInformationDescription,
				BillingPeriod: planInformationBillingPeriod,
				BillingCycles: planInformationBillingCycles
			);

			string processingInformationSubscriptionBillingOptionsApplyTo = "ALL";
			Rbsv1plansidProcessingInformationSubscriptionBillingOptions processingInformationSubscriptionBillingOptions = new Rbsv1plansidProcessingInformationSubscriptionBillingOptions(
				ApplyTo: processingInformationSubscriptionBillingOptionsApplyTo
			);

			Rbsv1plansidProcessingInformation processingInformation = new Rbsv1plansidProcessingInformation(
				SubscriptionBillingOptions: processingInformationSubscriptionBillingOptions
			);

			string orderInformationAmountDetailsCurrency = "USD";
			string orderInformationAmountDetailsBillingAmount = "11";
			string orderInformationAmountDetailsSetupFee = "2";
            GetAllPlansResponseOrderInformationAmountDetails orderInformationAmountDetails = new GetAllPlansResponseOrderInformationAmountDetails(
				Currency: orderInformationAmountDetailsCurrency,
				BillingAmount: orderInformationAmountDetailsBillingAmount,
				SetupFee: orderInformationAmountDetailsSetupFee
			);

            GetAllPlansResponseOrderInformation orderInformation = new GetAllPlansResponseOrderInformation(
				AmountDetails: orderInformationAmountDetails
			);

			var requestObj = new UpdatePlanRequest(
				PlanInformation: planInformation,
				ProcessingInformation: processingInformation,
				OrderInformation: orderInformation
			);

			try
			{
				var id = CreatePlan.Run().Id;
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new PlansApi(clientConfig);
				apiInstance.UpdatePlan(id, requestObj);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
		}
	}
}