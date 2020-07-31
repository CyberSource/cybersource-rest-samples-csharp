using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class AuthorizationForIncrementalAuthorizationFlow
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            bool processingInformationCapture = false;
            string processingInformationIndustryDataType = "lodging";
            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                Capture: processingInformationCapture,
                IndustryDataType: processingInformationIndustryDataType
           );

            string paymentInformationCardNumber = "4111111111111111";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2021";
            string paymentInformationCardType = "001";
            Ptsv2paymentsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsPaymentInformationCard(
                Number: paymentInformationCardNumber,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear,
                Type: paymentInformationCardType
           );

            string paymentInformationTokenizedCardSecurityCode = "123";
            Ptsv2paymentsPaymentInformationTokenizedCard paymentInformationTokenizedCard = new Ptsv2paymentsPaymentInformationTokenizedCard(
                SecurityCode: paymentInformationTokenizedCardSecurityCode
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                Card: paymentInformationCard,
                TokenizedCard: paymentInformationTokenizedCard
           );

            string orderInformationAmountDetailsTotalAmount = "20";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Smith";
            string orderInformationBillToAddress1 = "201 S. Division St.";
            string orderInformationBillToAddress2 = "Suite 500";
            string orderInformationBillToLocality = "Ann Arbor";
            string orderInformationBillToAdministrativeArea = "MI";
            string orderInformationBillToPostalCode = "12345";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToEmail = "null@cybersource.com";
            string orderInformationBillToPhoneNumber = "514-670-8700";
            Ptsv2paymentsOrderInformationBillTo orderInformationBillTo = new Ptsv2paymentsOrderInformationBillTo(
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                Address1: orderInformationBillToAddress1,
                Address2: orderInformationBillToAddress2,
                Locality: orderInformationBillToLocality,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                PostalCode: orderInformationBillToPostalCode,
                Country: orderInformationBillToCountry,
                Email: orderInformationBillToEmail,
                PhoneNumber: orderInformationBillToPhoneNumber
           );

            string orderInformationShipToFirstName = "Olivia";
            string orderInformationShipToLastName = "White";
            string orderInformationShipToAddress1 = "1295 Charleston Rd";
            string orderInformationShipToAddress2 = "Cube 2386";
            string orderInformationShipToLocality = "Mountain View";
            string orderInformationShipToAdministrativeArea = "CA";
            string orderInformationShipToPostalCode = "94041";
            string orderInformationShipToCountry = "AE";
            string orderInformationShipToPhoneNumber = "650-965-6000";
            Ptsv2paymentsOrderInformationShipTo orderInformationShipTo = new Ptsv2paymentsOrderInformationShipTo(
                FirstName: orderInformationShipToFirstName,
                LastName: orderInformationShipToLastName,
                Address1: orderInformationShipToAddress1,
                Address2: orderInformationShipToAddress2,
                Locality: orderInformationShipToLocality,
                AdministrativeArea: orderInformationShipToAdministrativeArea,
                PostalCode: orderInformationShipToPostalCode,
                Country: orderInformationShipToCountry,
                PhoneNumber: orderInformationShipToPhoneNumber
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo,
                ShipTo: orderInformationShipTo
           );

            string merchantInformationMerchantDescriptorContact = "965-6000";
            Ptsv2paymentsMerchantInformationMerchantDescriptor merchantInformationMerchantDescriptor = new Ptsv2paymentsMerchantInformationMerchantDescriptor(
                Contact: merchantInformationMerchantDescriptorContact
           );

            Ptsv2paymentsMerchantInformation merchantInformation = new Ptsv2paymentsMerchantInformation(
                MerchantDescriptor: merchantInformationMerchantDescriptor
           );

            string consumerAuthenticationInformationCavv = "ABCDEabcde12345678900987654321abcdeABCDE";
            string consumerAuthenticationInformationXid = "12345678909876543210ABCDEabcdeABCDEF1234";
            Ptsv2paymentsConsumerAuthenticationInformation consumerAuthenticationInformation = new Ptsv2paymentsConsumerAuthenticationInformation(
                Cavv: consumerAuthenticationInformationCavv,
                Xid: consumerAuthenticationInformationXid
           );

            string installmentInformationAmount = "1200";
            string installmentInformationFrequency = "W";
            int installmentInformationSequence = 34;
            string installmentInformationTotalAmount = "2000";
            int installmentInformationTotalCount = 12;
            Ptsv2paymentsInstallmentInformation installmentInformation = new Ptsv2paymentsInstallmentInformation(
                Amount: installmentInformationAmount,
                Frequency: installmentInformationFrequency,
                Sequence: installmentInformationSequence,
                TotalAmount: installmentInformationTotalAmount,
                TotalCount: installmentInformationTotalCount
           );

            string travelInformationDuration = "3";
            string travelInformationLodgingCheckInDate = "11062019";
            string travelInformationLodgingCheckOutDate = "11092019";

            List<Ptsv2paymentsTravelInformationLodgingRoom> travelInformationLodgingRoom = new List<Ptsv2paymentsTravelInformationLodgingRoom>();
            string travelInformationLodgingRoomDailyRate1 = "1.50";
            int travelInformationLodgingRoomNumberOfNights1 = 5;
            travelInformationLodgingRoom.Add(new Ptsv2paymentsTravelInformationLodgingRoom(
                DailyRate: travelInformationLodgingRoomDailyRate1,
                NumberOfNights: travelInformationLodgingRoomNumberOfNights1
           ));

            string travelInformationLodgingRoomDailyRate2 = "11.50";
            int travelInformationLodgingRoomNumberOfNights2 = 5;
            travelInformationLodgingRoom.Add(new Ptsv2paymentsTravelInformationLodgingRoom(
                DailyRate: travelInformationLodgingRoomDailyRate2,
                NumberOfNights: travelInformationLodgingRoomNumberOfNights2
           ));

            string travelInformationLodgingSmokingPreference = "yes";
            int travelInformationLodgingNumberOfRooms = 1;
            int travelInformationLodgingNumberOfGuests = 3;
            string travelInformationLodgingRoomBedType = "king";
            string travelInformationLodgingRoomTaxType = "tourist";
            string travelInformationLodgingRoomRateType = "sr citizen";
            string travelInformationLodgingGuestName = "Tulasi";
            string travelInformationLodgingCustomerServicePhoneNumber = "+13304026334";
            string travelInformationLodgingCorporateClientCode = "HDGGASJDGSUY";
            string travelInformationLodgingAdditionalDiscountAmount = "99.123456781";
            string travelInformationLodgingRoomLocation = "seaview";
            string travelInformationLodgingSpecialProgramCode = "2";
            string travelInformationLodgingTotalTaxAmount = "99.1234567891";
            string travelInformationLodgingPrepaidCost = "9999999999.99";
            string travelInformationLodgingFoodAndBeverageCost = "9999999999.99";
            string travelInformationLodgingRoomTaxAmount = "9999999999.99";
            string travelInformationLodgingAdjustmentAmount = "9999999999.99";
            string travelInformationLodgingPhoneCost = "9999999999.99";
            string travelInformationLodgingRestaurantCost = "9999999999.99";
            string travelInformationLodgingRoomServiceCost = "9999999999.99";
            string travelInformationLodgingMiniBarCost = "9999999999.99";
            string travelInformationLodgingLaundryCost = "9999999999.99";
            string travelInformationLodgingMiscellaneousCost = "9999999999.99";
            string travelInformationLodgingGiftShopCost = "9999999999.99";
            string travelInformationLodgingMovieCost = "9999999999.99";
            string travelInformationLodgingHealthClubCost = "9999999999.99";
            string travelInformationLodgingValetParkingCost = "9999999999.99";
            string travelInformationLodgingCashDisbursementCost = "9999999999.99";
            string travelInformationLodgingNonRoomCost = "9999999999.99";
            string travelInformationLodgingBusinessCenterCost = "9999999999.99";
            string travelInformationLodgingLoungeBarCost = "9999999999.99";
            string travelInformationLodgingTransportationCost = "9999999999.99";
            string travelInformationLodgingGratuityAmount = "9999999999.99";
            string travelInformationLodgingConferenceRoomCost = "9999999999.99";
            string travelInformationLodgingAudioVisualCost = "9999999999.99";
            string travelInformationLodgingNonRoomTaxAmount = "9999999999.99";
            string travelInformationLodgingEarlyCheckOutCost = "9999999999.99";
            string travelInformationLodgingInternetAccessCost = "9999999999.99";
            Ptsv2paymentsTravelInformationLodging travelInformationLodging = new Ptsv2paymentsTravelInformationLodging(
                CheckInDate: travelInformationLodgingCheckInDate,
                CheckOutDate: travelInformationLodgingCheckOutDate,
                Room: travelInformationLodgingRoom,
                SmokingPreference: travelInformationLodgingSmokingPreference,
                NumberOfRooms: travelInformationLodgingNumberOfRooms,
                NumberOfGuests: travelInformationLodgingNumberOfGuests,
                RoomBedType: travelInformationLodgingRoomBedType,
                RoomTaxType: travelInformationLodgingRoomTaxType,
                RoomRateType: travelInformationLodgingRoomRateType,
                GuestName: travelInformationLodgingGuestName,
                CustomerServicePhoneNumber: travelInformationLodgingCustomerServicePhoneNumber,
                CorporateClientCode: travelInformationLodgingCorporateClientCode,
                AdditionalDiscountAmount: travelInformationLodgingAdditionalDiscountAmount,
                RoomLocation: travelInformationLodgingRoomLocation,
                SpecialProgramCode: travelInformationLodgingSpecialProgramCode,
                TotalTaxAmount: travelInformationLodgingTotalTaxAmount,
                PrepaidCost: travelInformationLodgingPrepaidCost,
                FoodAndBeverageCost: travelInformationLodgingFoodAndBeverageCost,
                RoomTaxAmount: travelInformationLodgingRoomTaxAmount,
                AdjustmentAmount: travelInformationLodgingAdjustmentAmount,
                PhoneCost: travelInformationLodgingPhoneCost,
                RestaurantCost: travelInformationLodgingRestaurantCost,
                RoomServiceCost: travelInformationLodgingRoomServiceCost,
                MiniBarCost: travelInformationLodgingMiniBarCost,
                LaundryCost: travelInformationLodgingLaundryCost,
                MiscellaneousCost: travelInformationLodgingMiscellaneousCost,
                GiftShopCost: travelInformationLodgingGiftShopCost,
                MovieCost: travelInformationLodgingMovieCost,
                HealthClubCost: travelInformationLodgingHealthClubCost,
                ValetParkingCost: travelInformationLodgingValetParkingCost,
                CashDisbursementCost: travelInformationLodgingCashDisbursementCost,
                NonRoomCost: travelInformationLodgingNonRoomCost,
                BusinessCenterCost: travelInformationLodgingBusinessCenterCost,
                LoungeBarCost: travelInformationLodgingLoungeBarCost,
                TransportationCost: travelInformationLodgingTransportationCost,
                GratuityAmount: travelInformationLodgingGratuityAmount,
                ConferenceRoomCost: travelInformationLodgingConferenceRoomCost,
                AudioVisualCost: travelInformationLodgingAudioVisualCost,
                NonRoomTaxAmount: travelInformationLodgingNonRoomTaxAmount,
                EarlyCheckOutCost: travelInformationLodgingEarlyCheckOutCost,
                InternetAccessCost: travelInformationLodgingInternetAccessCost
           );

            Ptsv2paymentsTravelInformation travelInformation = new Ptsv2paymentsTravelInformation(
                Duration: travelInformationDuration,
                Lodging: travelInformationLodging
           );

            string promotionInformationAdditionalCode = "9999999999.99";
            Ptsv2paymentsPromotionInformation promotionInformation = new Ptsv2paymentsPromotionInformation(
                AdditionalCode: promotionInformationAdditionalCode
           );

            var requestObj = new CreatePaymentRequest(
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation,
                MerchantInformation: merchantInformation,
                ConsumerAuthenticationInformation: consumerAuthenticationInformation,
                InstallmentInformation: installmentInformation,
                TravelInformation: travelInformation,
                PromotionInformation: promotionInformation
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
