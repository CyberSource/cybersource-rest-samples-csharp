using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Token_Management
{
    public class CreateInstrumentIdentifierBankAccount
    {
        public static TmsV1InstrumentIdentifiersPost200Response Run(string profileid)
        {
            string bankAccountNumber = "4100";
            string bankAccountRoutingNumber = "071923284";
            Tmsv1instrumentidentifiersBankAccount bankAccount = new Tmsv1instrumentidentifiersBankAccount(
                Number: bankAccountNumber,
                RoutingNumber: bankAccountRoutingNumber
           );

            var requestObj = new CreateInstrumentIdentifierRequest(
                BankAccount: bankAccount
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                TmsV1InstrumentIdentifiersPost200Response result = apiInstance.CreateInstrumentIdentifier(profileid, requestObj);
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
