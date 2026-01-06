using System;
using System.Collections.Generic;
using System.Text;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.MLEFeature
{
    public class AcpApiExample
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }
        public static AgenticCardEnrollmentResponse200 Run()
        {
            string clientCorrelationId = "3e1b7943-6567-4965-a32b-5aa93d057d35";
            string deviceInformationUserAgent = "SampleUserAgent";
            string deviceInformationApplicationName = "My Magic App";
            string deviceInformationFingerprintSessionId = "finSessionId";
            string deviceInformationCountry = "US";
            string deviceInformationDeviceDataType = "Mobile";
            string deviceInformationDeviceDataManufacturer = "Apple";
            string deviceInformationDeviceDataBrand = "Apple";
            string deviceInformationDeviceDataModel = "iPhone 16 Pro Max";
            Acpv1tokensDeviceInformationDeviceData deviceInformationDeviceData = new Acpv1tokensDeviceInformationDeviceData(
                Type: deviceInformationDeviceDataType,
                Manufacturer: deviceInformationDeviceDataManufacturer,
                Brand: deviceInformationDeviceDataBrand,
                Model: deviceInformationDeviceDataModel
            );

            string deviceInformationIpAddress = "192.168.0.100";
            string deviceInformationClientDeviceId = "000b2767814e4416999f4ee2b099491d2087";
            Acpv1tokensDeviceInformation deviceInformation = new Acpv1tokensDeviceInformation(
                UserAgent: deviceInformationUserAgent,
                ApplicationName: deviceInformationApplicationName,
                FingerprintSessionId: deviceInformationFingerprintSessionId,
                Country: deviceInformationCountry,
                DeviceData: deviceInformationDeviceData,
                IpAddress: deviceInformationIpAddress,
                ClientDeviceId: deviceInformationClientDeviceId
            );

            string buyerInformationLanguage = "en";
            string buyerInformationMerchantCustomerId = "3e1b7943-6567-4965-a32b-5aa93d057d35";

            List<Acpv1tokensBuyerInformationPersonalIdentification> buyerInformationPersonalIdentification = new List<Acpv1tokensBuyerInformationPersonalIdentification>();
            string buyerInformationPersonalIdentificationType1 = "The identification type";
            string buyerInformationPersonalIdentificationId1 = "1";
            buyerInformationPersonalIdentification.Add(new Acpv1tokensBuyerInformationPersonalIdentification(
                Type: buyerInformationPersonalIdentificationType1,
                Id: buyerInformationPersonalIdentificationId1
            ));

            Acpv1tokensBuyerInformation buyerInformation = new Acpv1tokensBuyerInformation(
                Language: buyerInformationLanguage,
                MerchantCustomerId: buyerInformationMerchantCustomerId,
                PersonalIdentification: buyerInformationPersonalIdentification
            );

            string billToFirstName = "John";
            string billToLastName = "Doe";
            string billToFullName = "John Michael Doe";
            string billToEmail = "john.doe@example.com";
            string billToCountryCallingCode = "1";
            string billToPhoneNumber = "5551234567";
            bool billToNumberIsVoiceOnly = false;
            string billToCountry = "US";
            Acpv1tokensBillTo billTo = new Acpv1tokensBillTo(
                FirstName: billToFirstName,
                LastName: billToLastName,
                FullName: billToFullName,
                Email: billToEmail,
                CountryCallingCode: billToCountryCallingCode,
                PhoneNumber: billToPhoneNumber,
                NumberIsVoiceOnly: billToNumberIsVoiceOnly,
                Country: billToCountry
            );

            string consumerIdentityIdentityType = "EMAIL_ADDRESS";
            string consumerIdentityIdentityValue = "john.doe@example.com";
            string consumerIdentityIdentityProvider = "PARTNER";
            string consumerIdentityIdentityProviderUrl = "https://identity.partner.com";
            Acpv1tokensConsumerIdentity consumerIdentity = new Acpv1tokensConsumerIdentity(
                IdentityType: consumerIdentityIdentityType,
                IdentityValue: consumerIdentityIdentityValue,
                IdentityProvider: consumerIdentityIdentityProvider,
                IdentityProviderUrl: consumerIdentityIdentityProviderUrl
            );

            string paymentInformationCustomerId = "";
            Acpv1tokensPaymentInformationCustomer paymentInformationCustomer = new Acpv1tokensPaymentInformationCustomer(
                Id: paymentInformationCustomerId
            );

            string paymentInformationPaymentInstrumentId = "";
            Acpv1tokensPaymentInformationPaymentInstrument paymentInformationPaymentInstrument = new Acpv1tokensPaymentInformationPaymentInstrument(
                Id: paymentInformationPaymentInstrumentId
            );

            string paymentInformationInstrumentIdentifierId = "4044EB915C613A82E063AF598E0AE6EF";
            Acpv1tokensPaymentInformationInstrumentIdentifier paymentInformationInstrumentIdentifier = new Acpv1tokensPaymentInformationInstrumentIdentifier(
                Id: paymentInformationInstrumentIdentifierId
            );

            Acpv1tokensPaymentInformation paymentInformation = new Acpv1tokensPaymentInformation(
                Customer: paymentInformationCustomer,
                PaymentInstrument: paymentInformationPaymentInstrument,
                InstrumentIdentifier: paymentInformationInstrumentIdentifier
            );

            string enrollmentReferenceDataEnrollmentReferenceType = "TOKEN_REFERENCE_ID";
            string enrollmentReferenceDataEnrollmentReferenceProvider = "VTS";
            Acpv1tokensEnrollmentReferenceData enrollmentReferenceData = new Acpv1tokensEnrollmentReferenceData(
                EnrollmentReferenceType: enrollmentReferenceDataEnrollmentReferenceType,
                EnrollmentReferenceProvider: enrollmentReferenceDataEnrollmentReferenceProvider
            );


            List<Acpv1tokensAssuranceData> assuranceData = new List<Acpv1tokensAssuranceData>();
            string assuranceDataVerificationType1 = "DEVICE";
            string assuranceDataVerificationEntity1 = "10";

            List<string> assuranceDataVerificationEvents = new List<string>();
            assuranceDataVerificationEvents.Add("01");
            string assuranceDataVerificationMethod1 = "02";
            string assuranceDataVerificationResults1 = "01";
            string assuranceDataVerificationTimestamp1 = "1735690745";
            string assuranceDataAuthenticationContextAction1 = "AUTHENTICATE";
            Acpv1tokensAuthenticationContext assuranceDataAuthenticationContext1 = new Acpv1tokensAuthenticationContext(
                Action: assuranceDataAuthenticationContextAction1
            );

            string assuranceDataAuthenticatedIdentitiesData1 = "authenticatedData";
            string assuranceDataAuthenticatedIdentitiesProvider1 = "VISA_PAYMENT_PASSKEY";
            string assuranceDataAuthenticatedIdentitiesId1 = "f48ac10b-58cc-4372-a567-0e02b2c3d489";
            Acpv1tokensAuthenticatedIdentities assuranceDataAuthenticatedIdentities1 = new Acpv1tokensAuthenticatedIdentities(
                Data: assuranceDataAuthenticatedIdentitiesData1,
                Provider: assuranceDataAuthenticatedIdentitiesProvider1,
                Id: assuranceDataAuthenticatedIdentitiesId1
            );

            string assuranceDataAdditionalData1 = "";
            assuranceData.Add(new Acpv1tokensAssuranceData(
                VerificationType: assuranceDataVerificationType1,
                VerificationEntity: assuranceDataVerificationEntity1,
                VerificationEvents: assuranceDataVerificationEvents,
                VerificationMethod: assuranceDataVerificationMethod1,
                VerificationResults: assuranceDataVerificationResults1,
                VerificationTimestamp: assuranceDataVerificationTimestamp1,
                AuthenticationContext: assuranceDataAuthenticationContext1,
                AuthenticatedIdentities: assuranceDataAuthenticatedIdentities1,
                AdditionalData: assuranceDataAdditionalData1
            ));


            List<Acpv1tokensConsentData> consentData = new List<Acpv1tokensConsentData>();
            string consentDataId1 = "550e8400-e29b-41d4-a716-446655440000";
            string consentDataType1 = "PERSONALIZATION";
            string consentDataSource1 = "CLIENT";
            string consentDataAcceptedTime1 = "1719169800";
            string consentDataEffectiveUntil1 = "1750705800";
            consentData.Add(new Acpv1tokensConsentData(
                Id: consentDataId1,
                Type: consentDataType1,
                Source: consentDataSource1,
                AcceptedTime: consentDataAcceptedTime1,
                EffectiveUntil: consentDataEffectiveUntil1
            ));

            var requestObj = new AgenticCardEnrollmentRequest(
                ClientCorrelationId: clientCorrelationId,
                DeviceInformation: deviceInformation,
                BuyerInformation: buyerInformation,
                BillTo: billTo,
                ConsumerIdentity: consumerIdentity,
                PaymentInformation: paymentInformation,
                EnrollmentReferenceData: enrollmentReferenceData,
                AssuranceData: assuranceData,
                ConsentData: consentData
            );

            try
            {
                var configDictionary = new ConfigurationWithMLE().GetMerchantDetailsWithRequestAndResponseMLE1();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new EnrollmentApi(clientConfig);
                AgenticCardEnrollmentResponse200 result = apiInstance.EnrollCard(requestObj);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
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
