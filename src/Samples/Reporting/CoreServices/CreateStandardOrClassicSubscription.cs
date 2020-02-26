using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class CreateStandardOrClassicSubscription
    {
        public static void Run()
        {
            string reportDefinitionName = "TransactionRequestClass";
            string subscriptionType = "CLASSIC";
            var requestObj = new PredefinedSubscriptionRequestBean(
                ReportDefinitionName: reportDefinitionName,
                SubscriptionType: subscriptionType
           );

            string organizationId = null;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReportSubscriptionsApi(clientConfig);
                apiInstance.CreateStandardOrClassicSubscription(requestObj, organizationId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}
