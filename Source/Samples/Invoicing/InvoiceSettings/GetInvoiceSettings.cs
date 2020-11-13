using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Invoicing
{
    public class GetInvoiceSettings
    {
        public static InvoicingV2InvoiceSettingsGet200Response Run()
        {
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InvoiceSettingsApi(clientConfig);
                InvoicingV2InvoiceSettingsGet200Response result = apiInstance.GetInvoiceSettings();
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
