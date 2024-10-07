using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.Payments
{
	public class CITInitiatingInstalmentSubscriptionUK
	{
		public static PtsV2PaymentsPost201Response Run()
		{
			string clientReferenceInformationCode = "TC50171_3";
			Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
				Code: clientReferenceInformationCode
			);

			bool processingInformationCapture = false;
			string processingInformationCommerceIndicator = "vbv";
			bool processingInformationAuthorizationOptionsIgnoreAvsResult = false;
			bool processingInformationAuthorizationOptionsIgnoreCvResult = false;
			bool processingInformationAuthorizationOptionsInitiatorCredentialStoredOnFile = true;
			Ptsv2paymentsProcessingInformationAuthorizationOptionsInitiator processingInformationAuthorizationOptionsInitiator = new Ptsv2paymentsProcessingInformationAuthorizationOptionsInitiator(
				CredentialStoredOnFile: processingInformationAuthorizationOptionsInitiatorCredentialStoredOnFile
			);

			Ptsv2paymentsProcessingInformationAuthorizationOptions processingInformationAuthorizationOptions = new Ptsv2paymentsProcessingInformationAuthorizationOptions(
				IgnoreAvsResult: processingInformationAuthorizationOptionsIgnoreAvsResult,
				IgnoreCvResult: processingInformationAuthorizationOptionsIgnoreCvResult,
				Initiator: processingInformationAuthorizationOptionsInitiator
			);

			bool processingInformationRecurringOptionsLoanPayment = false;
			bool processingInformationRecurringOptionsFirstRecurringPayment = true;
			Ptsv2paymentsProcessingInformationRecurringOptions processingInformationRecurringOptions = new Ptsv2paymentsProcessingInformationRecurringOptions(
				LoanPayment: processingInformationRecurringOptionsLoanPayment,
				FirstRecurringPayment: processingInformationRecurringOptionsFirstRecurringPayment
			);

			Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
				Capture: processingInformationCapture,
				CommerceIndicator: processingInformationCommerceIndicator,
				AuthorizationOptions: processingInformationAuthorizationOptions,
				RecurringOptions: processingInformationRecurringOptions
			);

			string paymentInformationCardNumber = "4111111111111111";
			string paymentInformationCardExpirationMonth = "12";
			string paymentInformationCardExpirationYear = "2031";
			Ptsv2paymentsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsPaymentInformationCard(
				Number: paymentInformationCardNumber,
				ExpirationMonth: paymentInformationCardExpirationMonth,
				ExpirationYear: paymentInformationCardExpirationYear
			);

			Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
				Card: paymentInformationCard
			);

			string orderInformationAmountDetailsTotalAmount = "102.21";
			string orderInformationAmountDetailsCurrency = "GBP";
			Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
				TotalAmount: orderInformationAmountDetailsTotalAmount,
				Currency: orderInformationAmountDetailsCurrency
			);

			string orderInformationBillToFirstName = "John";
			string orderInformationBillToLastName = "Doe";
			string orderInformationBillToAddress1 = "1 Market St";
			string orderInformationBillToLocality = "san francisco";
			string orderInformationBillToAdministrativeArea = "CA";
			string orderInformationBillToPostalCode = "94105";
			string orderInformationBillToCountry = "US";
			string orderInformationBillToEmail = "test@cybs.com";
			string orderInformationBillToPhoneNumber = "4158880000";
			Ptsv2paymentsOrderInformationBillTo orderInformationBillTo = new Ptsv2paymentsOrderInformationBillTo(
				FirstName: orderInformationBillToFirstName,
				LastName: orderInformationBillToLastName,
				Address1: orderInformationBillToAddress1,
				Locality: orderInformationBillToLocality,
				AdministrativeArea: orderInformationBillToAdministrativeArea,
				PostalCode: orderInformationBillToPostalCode,
				Country: orderInformationBillToCountry,
				Email: orderInformationBillToEmail,
				PhoneNumber: orderInformationBillToPhoneNumber
			);

			Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
				AmountDetails: orderInformationAmountDetails,
				BillTo: orderInformationBillTo
			);

			string consumerAuthenticationInformationCavv = "EHuWW9PiBkWvqE5juRwDzAUFBAk=";
			Ptsv2paymentsConsumerAuthenticationInformation consumerAuthenticationInformation = new Ptsv2paymentsConsumerAuthenticationInformation(
				Cavv: consumerAuthenticationInformationCavv
			);

			var requestObj = new CreatePaymentRequest(
				ClientReferenceInformation: clientReferenceInformation,
				ProcessingInformation: processingInformation,
				PaymentInformation: paymentInformation,
				OrderInformation: orderInformation,
				ConsumerAuthenticationInformation: consumerAuthenticationInformation
			);

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new PaymentsApi(clientConfig);
				PtsV2PaymentsPost201Response result = apiInstance.CreatePayment(requestObj);
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