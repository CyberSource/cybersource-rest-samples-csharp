using CyberSource.Api;
using CyberSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet.Samples.Invoicing
{
    public class GetListOfInvoices
    {
        public static InvoicingV2InvoicesAllGet200Response Run()
        {
            int offset = 0;
            int limit = 10;
            string query = null;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InvoicesApi(clientConfig);
                InvoicingV2InvoicesAllGet200Response result = apiInstance.GetAllInvoices(offset, limit, query);
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
