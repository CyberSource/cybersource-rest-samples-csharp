using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
	public class EBTMerchandiseReturnCreditVoucherFromSNAP
	{
		public static PtsV2CreditsPost201Response Run()
		{
			string clientReferenceInformationCode = "Merchandise Return / Credit Voucher from SNAP";
			Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
				Code: clientReferenceInformationCode
			);

			string processingInformationCommerceIndicator = "retail";
			bool processingInformationPurchaseOptionsIsElectronicBenefitsTransfer = true;
			Ptsv2creditsProcessingInformationPurchaseOptions processingInformationPurchaseOptions = new Ptsv2creditsProcessingInformationPurchaseOptions(
				IsElectronicBenefitsTransfer: processingInformationPurchaseOptionsIsElectronicBenefitsTransfer
			);

			string processingInformationElectronicBenefitsTransferCategory = "FOOD";
			Ptsv2creditsProcessingInformationElectronicBenefitsTransfer processingInformationElectronicBenefitsTransfer = new Ptsv2creditsProcessingInformationElectronicBenefitsTransfer(
				Category: processingInformationElectronicBenefitsTransferCategory
			);

			Ptsv2creditsProcessingInformation processingInformation = new Ptsv2creditsProcessingInformation(
				CommerceIndicator: processingInformationCommerceIndicator,
				PurchaseOptions: processingInformationPurchaseOptions,
				ElectronicBenefitsTransfer: processingInformationElectronicBenefitsTransfer
			);

			string paymentInformationCardType = "001";
			Ptsv2paymentsidrefundsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsidrefundsPaymentInformationCard(
				Type: paymentInformationCardType
			);

			string paymentInformationPaymentTypeName = "CARD";
			string paymentInformationPaymentTypeSubTypeName = "DEBIT";
			Ptsv2paymentsidrefundsPaymentInformationPaymentType paymentInformationPaymentType = new Ptsv2paymentsidrefundsPaymentInformationPaymentType(
				Name: paymentInformationPaymentTypeName,
				SubTypeName: paymentInformationPaymentTypeSubTypeName
			);

			Ptsv2paymentsidrefundsPaymentInformation paymentInformation = new Ptsv2paymentsidrefundsPaymentInformation(
				Card: paymentInformationCard,
				PaymentType: paymentInformationPaymentType
			);

			string orderInformationAmountDetailsTotalAmount = "204.00";
			string orderInformationAmountDetailsCurrency = "USD";
			Ptsv2paymentsidcapturesOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsidcapturesOrderInformationAmountDetails(
				TotalAmount: orderInformationAmountDetailsTotalAmount,
				Currency: orderInformationAmountDetailsCurrency
			);

			Ptsv2paymentsidrefundsOrderInformation orderInformation = new Ptsv2paymentsidrefundsOrderInformation(
				AmountDetails: orderInformationAmountDetails
			);

			int merchantInformationCategoryCode = 5411;
			Ptsv2paymentsidrefundsMerchantInformation merchantInformation = new Ptsv2paymentsidrefundsMerchantInformation(
				CategoryCode: merchantInformationCategoryCode
			);

			string pointOfSaleInformationEntryMode = "swiped";
			int pointOfSaleInformationTerminalCapability = 4;
			string pointOfSaleInformationTrackData = "%B4111111111111111^JONES/JONES ^3112101976110000868000000?;4111111111111111=16121019761186800000?";
			int pointOfSaleInformationPinBlockEncodingFormat = 1;
			string pointOfSaleInformationEncryptedPin = "52F20658C04DB351";
			string pointOfSaleInformationEncryptedKeySerialNumber = "FFFF1B1D140000000005";
			Ptsv2paymentsPointOfSaleInformation pointOfSaleInformation = new Ptsv2paymentsPointOfSaleInformation(
				EntryMode: pointOfSaleInformationEntryMode,
				TerminalCapability: pointOfSaleInformationTerminalCapability,
				TrackData: pointOfSaleInformationTrackData,
				PinBlockEncodingFormat: pointOfSaleInformationPinBlockEncodingFormat,
				EncryptedPin: pointOfSaleInformationEncryptedPin,
				EncryptedKeySerialNumber: pointOfSaleInformationEncryptedKeySerialNumber
			);

			var requestObj = new CreateCreditRequest(
				ClientReferenceInformation: clientReferenceInformation,
				ProcessingInformation: processingInformation,
				PaymentInformation: paymentInformation,
				OrderInformation: orderInformation,
				MerchantInformation: merchantInformation,
				PointOfSaleInformation: pointOfSaleInformation
			);

			try
			{
				var configDictionary = new Configuration().GetAlternativeConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new CreditApi(clientConfig);
				PtsV2CreditsPost201Response result = apiInstance.CreateCredit(requestObj);
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