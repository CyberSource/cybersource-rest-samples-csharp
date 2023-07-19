using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
	public class EBTReversalOfPurchaseFromSNAPAccount
	{
		public static PtsV2PaymentsVoidsPost201Response Run()
		{
			var id = EBTMerchandiseReturnCreditVoucherFromSNAP.Run().Id;
			string clientReferenceInformationCode = "Reversal of Purchase from SNAP Account";
			Ptsv2paymentsidreversalsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsidreversalsClientReferenceInformation(
				Code: clientReferenceInformationCode
			);

			string paymentInformationPaymentTypeName = "CARD";
			string paymentInformationPaymentTypeSubTypeName = "DEBIT";
			Ptsv2paymentsidrefundsPaymentInformationPaymentType paymentInformationPaymentType = new Ptsv2paymentsidrefundsPaymentInformationPaymentType(
				Name: paymentInformationPaymentTypeName,
				SubTypeName: paymentInformationPaymentTypeSubTypeName
			);

			Ptsv2paymentsidvoidsPaymentInformation paymentInformation = new Ptsv2paymentsidvoidsPaymentInformation(
				PaymentType: paymentInformationPaymentType
			);

			string orderInformationAmountDetailsTotalAmount = "204.00";
			string orderInformationAmountDetailsCurrency = "USD";
			Ptsv2paymentsidreversalsReversalInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsidreversalsReversalInformationAmountDetails(
				TotalAmount: orderInformationAmountDetailsTotalAmount,
				Currency: orderInformationAmountDetailsCurrency
			);

			Ptsv2paymentsidvoidsOrderInformation orderInformation = new Ptsv2paymentsidvoidsOrderInformation(
				AmountDetails: orderInformationAmountDetails
			);

			var requestObj = new VoidPaymentRequest(
				ClientReferenceInformation: clientReferenceInformation,
				PaymentInformation: paymentInformation,
				OrderInformation: orderInformation
			);

			try
			{
				var configDictionary = new Configuration().GetAlternativeConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new VoidApi(clientConfig);
				PtsV2PaymentsVoidsPost201Response result = apiInstance.VoidPayment(requestObj, id);
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