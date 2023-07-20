using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
	public class CreatePlan
	{
		public static InlineResponse201 Run()
		{
            // Required to make the sample code ActivatePlan.cs work
            string planStatus = "DRAFT";

			string planInformationName = "Gold Plan";
			string planInformationDescription = "New Gold Plan";
			string planInformationBillingPeriodLength = "1";
			string planInformationBillingPeriodUnit = "M";
			InlineResponse200PlanInformationBillingPeriod planInformationBillingPeriod = new InlineResponse200PlanInformationBillingPeriod(
				Length: planInformationBillingPeriodLength,
				Unit: planInformationBillingPeriodUnit
			);

			string planInformationBillingCyclesTotal = "12";
			Rbsv1plansPlanInformationBillingCycles planInformationBillingCycles = new Rbsv1plansPlanInformationBillingCycles(
				Total: planInformationBillingCyclesTotal
			);

			Rbsv1plansPlanInformation planInformation = new Rbsv1plansPlanInformation(
				Name: planInformationName,
				Description: planInformationDescription,
				BillingPeriod: planInformationBillingPeriod,
				BillingCycles: planInformationBillingCycles,
				Status: planStatus
			);

			string orderInformationAmountDetailsCurrency = "USD";
			string orderInformationAmountDetailsBillingAmount = "10";
			string orderInformationAmountDetailsSetupFee = "2";
			Rbsv1plansOrderInformationAmountDetails orderInformationAmountDetails = new Rbsv1plansOrderInformationAmountDetails(
				Currency: orderInformationAmountDetailsCurrency,
				BillingAmount: orderInformationAmountDetailsBillingAmount,
				SetupFee: orderInformationAmountDetailsSetupFee
			);

			Rbsv1plansOrderInformation orderInformation = new Rbsv1plansOrderInformation(
				AmountDetails: orderInformationAmountDetails
			);

			var requestObj = new CreatePlanRequest(
				PlanInformation: planInformation,
				OrderInformation: orderInformation
			);
			InlineResponse201 response = null;
			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new PlansApi(clientConfig);
				response = apiInstance.CreatePlan(requestObj);
				Console.WriteLine(response);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
			return response;
		}
	}
}