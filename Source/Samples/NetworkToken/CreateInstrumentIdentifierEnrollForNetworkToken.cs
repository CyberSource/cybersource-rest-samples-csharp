﻿using CyberSource.Api;
using CyberSource.Model;
using System;

namespace Cybersource_rest_samples_dotnet.Samples.NetworkToken
{
    public class CreateInstrumentIdentifierEnrollForNetworkToken
    {
        public static PostInstrumentIdentifierRequest Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            string type = "enrollable card";
            string cardNumber = "5204245750003216";
            string cardExpirationMonth = "12";
            string cardExpirationYear = "2025";
            TmsEmbeddedInstrumentIdentifierCard card = new TmsEmbeddedInstrumentIdentifierCard(
                    Number: cardNumber,
                    ExpirationMonth: cardExpirationMonth,
                    ExpirationYear: cardExpirationYear
                );
            var requestObj = new PostInstrumentIdentifierRequest(
                    Type: type,
                    Card: card
                );
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                PostInstrumentIdentifierRequest result = apiInstance.PostInstrumentIdentifier(requestObj, profileid);
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
