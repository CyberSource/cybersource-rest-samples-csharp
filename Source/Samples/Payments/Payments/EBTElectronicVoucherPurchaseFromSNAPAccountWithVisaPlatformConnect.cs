using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.Payments
{
	public class EBTElectronicVoucherPurchaseFromSNAPAccountWithVisaPlatformConnect
	{
		public static PtsV2PaymentsPost201Response Run()
		{
			string clientReferenceInformationCode = "EBT - Voucher Purchase From SNAP Account";
			Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
				Code: clientReferenceInformationCode
			);

			bool processingInformationCapture = false;
			string processingInformationCommerceIndicator = "retail";
			bool processingInformationPurchaseOptionsIsElectronicBenefitsTransfer = true;
			Ptsv2paymentsProcessingInformationPurchaseOptions processingInformationPurchaseOptions = new Ptsv2paymentsProcessingInformationPurchaseOptions(
				IsElectronicBenefitsTransfer: processingInformationPurchaseOptionsIsElectronicBenefitsTransfer
			);

			string processingInformationElectronicBenefitsTransferCategory = "FOOD";
			string processingInformationElectronicBenefitsTransferVoucherSerialNumber = "123451234512345";
			Ptsv2paymentsProcessingInformationElectronicBenefitsTransfer processingInformationElectronicBenefitsTransfer = new Ptsv2paymentsProcessingInformationElectronicBenefitsTransfer(
				Category: processingInformationElectronicBenefitsTransferCategory,
				VoucherSerialNumber: processingInformationElectronicBenefitsTransferVoucherSerialNumber
			);

			Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
				Capture: processingInformationCapture,
				CommerceIndicator: processingInformationCommerceIndicator,
				PurchaseOptions: processingInformationPurchaseOptions,
				ElectronicBenefitsTransfer: processingInformationElectronicBenefitsTransfer
			);

			string paymentInformationCardNumber = "4012002000013007";
			string paymentInformationCardExpirationMonth = "12";
			string paymentInformationCardExpirationYear = "25";
			Ptsv2paymentsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsPaymentInformationCard(
				Number: paymentInformationCardNumber,
				ExpirationMonth: paymentInformationCardExpirationMonth,
				ExpirationYear: paymentInformationCardExpirationYear
			);

			string paymentInformationPaymentTypeName = "CARD";
			string paymentInformationPaymentTypeSubTypeName = "DEBIT";
			Ptsv2paymentsPaymentInformationPaymentType paymentInformationPaymentType = new Ptsv2paymentsPaymentInformationPaymentType(
				Name: paymentInformationPaymentTypeName,
				SubTypeName: paymentInformationPaymentTypeSubTypeName
			);

			Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
				Card: paymentInformationCard,
				PaymentType: paymentInformationPaymentType
			);

			string orderInformationAmountDetailsTotalAmount = "103.00";
			string orderInformationAmountDetailsCurrency = "USD";
			Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
				TotalAmount: orderInformationAmountDetailsTotalAmount,
				Currency: orderInformationAmountDetailsCurrency
			);

			Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
				AmountDetails: orderInformationAmountDetails
			);

			string pointOfSaleInformationEntryMode = "keyed";
			int pointOfSaleInformationTerminalCapability = 4;
			string pointOfSaleInformationTrackData = "%B4111111111111111^JONES/JONES ^3112101976110000868000000?;4111111111111111=16121019761186800000?";
			Ptsv2paymentsPointOfSaleInformation pointOfSaleInformation = new Ptsv2paymentsPointOfSaleInformation(
				EntryMode: pointOfSaleInformationEntryMode,
				TerminalCapability: pointOfSaleInformationTerminalCapability,
				TrackData: pointOfSaleInformationTrackData
			);

			var requestObj = new CreatePaymentRequest(
				ClientReferenceInformation: clientReferenceInformation,
				ProcessingInformation: processingInformation,
				PaymentInformation: paymentInformation,
				OrderInformation: orderInformation,
				PointOfSaleInformation: pointOfSaleInformation
			);

			try
			{
				var configDictionary = new Configuration().GetAlternativeConfiguration();
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