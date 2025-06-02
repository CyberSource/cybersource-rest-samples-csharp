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
    internal class MerchantBoardingBinLookUp
    {



        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static InlineResponse2012 Run()
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
            selectedProducts.Payments = payments;

            RiskProducts risk = new RiskProducts();
            selectedProducts.Risk = risk;

            CommerceSolutionsProducts commerceSolutions = new CommerceSolutionsProducts();
            CommerceSolutionsProductsBinLookup binLookup = new CommerceSolutionsProductsBinLookup();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //    Enabled = true
            //};

            //binLookup.SubscriptionInformation = subscriptionInformation;

            CommerceSolutionsProductsBinLookupConfigurationInformation configurationInformation = new CommerceSolutionsProductsBinLookupConfigurationInformation();
            CommerceSolutionsProductsBinLookupConfigurationInformationConfigurations configurations = new CommerceSolutionsProductsBinLookupConfigurationInformationConfigurations
            {
                IsPayoutOptionsEnabled = false,
                IsAccountPrefixEnabled = true
            };

            configurationInformation.Configurations = configurations;
            binLookup.ConfigurationInformation = configurationInformation;
            commerceSolutions.BinLookup = binLookup;

            selectedProducts.CommerceSolutions = commerceSolutions;

            ValueAddedServicesProducts valueAddedServices = new ValueAddedServicesProducts();
            selectedProducts.ValueAddedServices = valueAddedServices;

            productInformation.SelectedProducts = selectedProducts;
            reqObj.ProductInformation = productInformation;



            try
            {
                var configDictionary = new MerchantBoardingConfiguration().GetMerchantBoardingConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new MerchantBoardingApi(clientConfig);
                InlineResponse2012 result = apiInstance.PostRegistration(reqObj);
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
