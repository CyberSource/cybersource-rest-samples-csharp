using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.MerchantBoarding
{
    internal class MerchantBoardingEFTPOS
    {



        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static InlineResponse2013 Run()
        {


            
            PostRegistrationBody reqObj = new PostRegistrationBody();

            Boardingv1registrationsOrganizationInformation organizationInformation = new Boardingv1registrationsOrganizationInformation
            {
            ParentOrganizationId = "apitester00",
            Type = "MERCHANT",
            Configurable = true
            };

            Boardingv1registrationsOrganizationInformationBusinessInformation businessInformation = new Boardingv1registrationsOrganizationInformationBusinessInformation
            {
            Name = "StuartWickedFastEatz"
            };

            Boardingv1registrationsOrganizationInformationBusinessInformationAddress address = new Boardingv1registrationsOrganizationInformationBusinessInformationAddress
            {
            Country = "US",
            Address1 = "123456 SandMarket",
            Locality = "ORMOND BEACH",
            AdministrativeArea = "FL",
            PostalCode = "32176"
            };

            businessInformation.Address = address;
            businessInformation.WebsiteUrl = "https://www.StuartWickedEats.com";
            businessInformation.PhoneNumber = "6574567813";

            Boardingv1registrationsOrganizationInformationBusinessInformationBusinessContact businessContact = new Boardingv1registrationsOrganizationInformationBusinessInformationBusinessContact
            {
            FirstName = "Stuart",
            LastName = "Stuart",
            PhoneNumber = "6574567813",
            Email = "svc_email_bt@corpdev.visa.com"
            };

            businessInformation.BusinessContact = businessContact;
            businessInformation.MerchantCategoryCode = "5999";
            organizationInformation.BusinessInformation = businessInformation;

            reqObj.OrganizationInformation = organizationInformation;

            Boardingv1registrationsProductInformation productInformation = new Boardingv1registrationsProductInformation();
            Boardingv1registrationsProductInformationSelectedProducts selectedProducts = new Boardingv1registrationsProductInformationSelectedProducts();

            PaymentsProducts payments = new PaymentsProducts();
            PaymentsProductsCardProcessing cardProcessing = new PaymentsProductsCardProcessing();
            PaymentsProductsCardProcessingSubscriptionInformation subscriptionInformation = new PaymentsProductsCardProcessingSubscriptionInformation
            {
            Enabled = true,
            Features = new Dictionary<string, PaymentsProductsCardProcessingSubscriptionInformationFeatures>
            {
            { "cardNotPresent", new PaymentsProductsCardProcessingSubscriptionInformationFeatures { Enabled = true } },
            { "cardPresent", new PaymentsProductsCardProcessingSubscriptionInformationFeatures { Enabled = false } }
            }
            };

            cardProcessing.SubscriptionInformation = subscriptionInformation;

            PaymentsProductsCardProcessingConfigurationInformation configurationInformation = new PaymentsProductsCardProcessingConfigurationInformation();

            CardProcessingConfig configurations = new CardProcessingConfig();
            CardProcessingConfigCommon common = new CardProcessingConfigCommon
            {
            MerchantCategoryCode = "5999",
            PreferCobadgedSecondaryBrand = true,
            Processors = new Dictionary<string, CardProcessingConfigCommonProcessors>
            {
            {
            "EFTPOS",
            new CardProcessingConfigCommonProcessors
            {
            Acquirer = new CardProcessingConfigCommonAcquirer
            {
            CountryCode = "344_hongkong",
            InstitutionId = "22344"
            },
            Currencies = new Dictionary<string, CardProcessingConfigCommonCurrencies1>
            {
            { "AUD", new CardProcessingConfigCommonCurrencies1 { Enabled = true, MerchantId = "12345612344", TerminalId = "12121212" } }
            },
            PaymentTypes = new Dictionary<string, CardProcessingConfigCommonPaymentTypes>
            {
            { "EFTPOS", new CardProcessingConfigCommonPaymentTypes { Enabled = true } }
            },
            EnableCVVResponseIndicator = true,
            EnableLeastCostRouting = true,
            MerchantTier = "000"
            }
            }
            }
            };

            configurations.Common = common;
            configurations.Features = new CardProcessingConfigFeatures();
            configurationInformation.Configurations = configurations;
            configurationInformation.TemplateId = Guid.Parse("1F9B7F6E-F0DB-44C8-BF8E-5013E34C0F87");
            Console.WriteLine("Template id........" + Guid.Parse("1F9B7F6E-F0DB-44C8-BF8E-5013E34C0F87"));
            cardProcessing.ConfigurationInformation = configurationInformation;
            payments.CardProcessing = cardProcessing;
            selectedProducts.Payments = payments;

            productInformation.SelectedProducts = selectedProducts;
            reqObj.ProductInformation = productInformation;



            try
            {
                var configDictionary = new MerchantBoardingConfiguration().GetMerchantBoardingConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new MerchantBoardingApi(clientConfig);
                InlineResponse2013 result = apiInstance.PostRegistration(reqObj);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
