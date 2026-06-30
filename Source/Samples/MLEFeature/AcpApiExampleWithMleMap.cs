using System;
using System.Collections.Generic;
using System.Text;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.MLEFeature
{
    /// <summary>
    /// ACP API example with MLE controlled via mapToControlMLEonAPI for API-level control.
    ///
    /// <para><b>Note:</b> MLE also works with JWT using Shared Secret credentials
    /// (jwtKeyType=SHARED_SECRET), allowing merchants to migrate from HTTP Signature
    /// and gain MLE support (both Request and Response MLE) using the same merchantKeyId
    /// and merchantsecretKey — no P12 file needed.</para>
    ///
    /// <para>See <c>Samples.JwtSharedSecretAuth.MLEPaymentWithJwtSharedSecret</c> and
    /// <see cref="JwtSharedSecretConfiguration.GetMerchantDetailsWithMLE"/> for an example.</para>
    /// </summary>
    public class AcpApiExampleWithMleMap
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }
        public static async System.Threading.Tasks.Task<AgenticCardEnrollmentResponse200> RunAsync()
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
            Iccv1tokensDeviceInformationDeviceData deviceInformationDeviceData = new Iccv1tokensDeviceInformationDeviceData(
                Type: deviceInformationDeviceDataType,
                Manufacturer: deviceInformationDeviceDataManufacturer,
                Brand: deviceInformationDeviceDataBrand,
                Model: deviceInformationDeviceDataModel
            );

            string deviceInformationIpAddress = "192.168.0.100";
            string deviceInformationClientDeviceId = "000b2767814e4416999f4ee2b099491d2087";
            Iccv1tokensDeviceInformation deviceInformation = new Iccv1tokensDeviceInformation(
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

            List<Iccv1tokensBuyerInformationPersonalIdentification> buyerInformationPersonalIdentification = new List<Iccv1tokensBuyerInformationPersonalIdentification>();
            string buyerInformationPersonalIdentificationType1 = "The identification type";
            string buyerInformationPersonalIdentificationId1 = "1";
            buyerInformationPersonalIdentification.Add(new Iccv1tokensBuyerInformationPersonalIdentification(
                Type: buyerInformationPersonalIdentificationType1,
                Id: buyerInformationPersonalIdentificationId1
            ));

            Iccv1tokensBuyerInformation buyerInformation = new Iccv1tokensBuyerInformation(
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
            Iccv1tokensBillTo billTo = new Iccv1tokensBillTo(
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
            Iccv1tokensConsumerIdentity consumerIdentity = new Iccv1tokensConsumerIdentity(
                IdentityType: consumerIdentityIdentityType,
                IdentityValue: consumerIdentityIdentityValue,
                IdentityProvider: consumerIdentityIdentityProvider,
                IdentityProviderUrl: consumerIdentityIdentityProviderUrl
            );

            string paymentInformationCustomerId = "";
            Iccv1tokensPaymentInformationCustomer paymentInformationCustomer = new Iccv1tokensPaymentInformationCustomer(
                Id: paymentInformationCustomerId
            );

            string paymentInformationPaymentInstrumentId = "";
            Iccv1tokensPaymentInformationPaymentInstrument paymentInformationPaymentInstrument = new Iccv1tokensPaymentInformationPaymentInstrument(
                Id: paymentInformationPaymentInstrumentId
            );

            string paymentInformationInstrumentIdentifierId = "4044EB915C613A82E063AF598E0AE6EF";
            Iccv1tokensPaymentInformationInstrumentIdentifier paymentInformationInstrumentIdentifier = new Iccv1tokensPaymentInformationInstrumentIdentifier(
                Id: paymentInformationInstrumentIdentifierId
            );

            Iccv1tokensPaymentInformation paymentInformation = new Iccv1tokensPaymentInformation(
                Customer: paymentInformationCustomer,
                PaymentInstrument: paymentInformationPaymentInstrument,
                InstrumentIdentifier: paymentInformationInstrumentIdentifier
            );

            string enrollmentReferenceDataEnrollmentReferenceType = "TOKEN_REFERENCE_ID";
            string enrollmentReferenceDataEnrollmentReferenceProvider = "VTS";
            Iccv1tokensEnrollmentReferenceData enrollmentReferenceData = new Iccv1tokensEnrollmentReferenceData(
                EnrollmentReferenceType: enrollmentReferenceDataEnrollmentReferenceType,
                EnrollmentReferenceProvider: enrollmentReferenceDataEnrollmentReferenceProvider
            );


            List<Iccv1tokensAssuranceData> assuranceData = new List<Iccv1tokensAssuranceData>();
            string assuranceDataVerificationType1 = "DEVICE";
            string assuranceDataVerificationEntity1 = "10";

            List<string> assuranceDataVerificationEvents = new List<string>();
            assuranceDataVerificationEvents.Add("01");
            string assuranceDataVerificationMethod1 = "02";
            string assuranceDataVerificationResults1 = "01";
            string assuranceDataVerificationTimestamp1 = "1735690745";
            string assuranceDataAuthenticationContextAction1 = "AUTHENTICATE";
            Iccv1tokensAuthenticationContext assuranceDataAuthenticationContext1 = new Iccv1tokensAuthenticationContext(
                Action: assuranceDataAuthenticationContextAction1
            );

            string assuranceDataAuthenticatedIdentitiesData1 = "authenticatedData";
            string assuranceDataAuthenticatedIdentitiesProvider1 = "VISA_PAYMENT_PASSKEY";
            string assuranceDataAuthenticatedIdentitiesId1 = "f48ac10b-58cc-4372-a567-0e02b2c3d489";
            Iccv1tokensAuthenticatedIdentities assuranceDataAuthenticatedIdentities1 = new Iccv1tokensAuthenticatedIdentities(
                Data: assuranceDataAuthenticatedIdentitiesData1,
                Provider: assuranceDataAuthenticatedIdentitiesProvider1,
                Id: assuranceDataAuthenticatedIdentitiesId1
            );

            string assuranceDataAdditionalData1 = "";
            assuranceData.Add(new Iccv1tokensAssuranceData(
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


            List<Iccv1tokensConsentData> consentData = new List<Iccv1tokensConsentData>();
            string consentDataId1 = "550e8400-e29b-41d4-a716-446655440000";
            string consentDataType1 = "PERSONALIZATION";
            string consentDataSource1 = "CLIENT";
            string consentDataAcceptedTime1 = "1719169800";
            string consentDataEffectiveUntil1 = "1750705800";
            consentData.Add(new Iccv1tokensConsentData(
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
                var configDictionary = new ConfigurationWithMLE().GetMerchantDetailsWithRequestAndResponseMLE2();
                var mapToControlMLE = new ConfigurationWithMLE().GetMapToControlMLEForRequestAndResponse();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary, mapToControlMLEonAPI : mapToControlMLE);
                var apiInstance = new AgentCapabilitiesApi(clientConfig);
                AgenticCardEnrollmentResponse200 result = await apiInstance.EnrollCardAsync(requestObj);
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
