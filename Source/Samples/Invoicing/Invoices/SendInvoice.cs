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
        public static InvoicingV2InvoicesPost201Response Run()
        {
            try
            {
                var invoiceId = CreateDraftInvoice.Run().Id;
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InvoicesApi(clientConfig);
                InvoicingV2InvoicesPost201Response result = apiInstance.PerformSendAction(invoiceId);
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
