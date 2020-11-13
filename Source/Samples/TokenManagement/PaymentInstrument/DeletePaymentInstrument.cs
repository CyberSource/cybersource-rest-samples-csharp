using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class DeletePaymentInstrument
    {
        public static void Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = CreatePaymentInstrumentCard.Run().Id;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentInstrumentApi(clientConfig);
                apiInstance.DeletePaymentInstrument(tokenId, profileid);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}
