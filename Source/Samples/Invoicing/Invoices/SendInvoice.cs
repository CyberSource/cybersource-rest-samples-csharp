using CyberSource.Api;
using CyberSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet.Samples.Invoicing
{
    public class SendInvoice
    {
        public static async System.Threading.Tasks.Task<InvoicingV2InvoicesSend200Response> RunAsync()
        {
            try
            {
                var invoiceId = (await CreateDraftInvoice.RunAsync()).Id;
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InvoicesApi(clientConfig);
                InvoicingV2InvoicesSend200Response result = await apiInstance.PerformSendActionAsync(invoiceId);
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
