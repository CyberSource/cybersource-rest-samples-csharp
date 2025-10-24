using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cybersource_rest_samples_dotnet.Samples.Payments;

namespace Cybersource_rest_samples_dotnet
{
    class BankAccountValidationConfiguration
    {
        // initialize dictionary object
        private readonly Dictionary<string, string> _configurationDictionary = new Dictionary<string, string>();

        public Dictionary<string, string> GetConfiguration()
        {
            _configurationDictionary.Add("authenticationType", "JWT"); //mle only support with JWT Auth Type
            _configurationDictionary.Add("merchantID", "testcasmerchpd01001");
            //_configurationDictionary.Add("merchantsecretKey", "yBJxy6LjM2TmcPGu+GaJrHtkke25fPpUX+UY6/L/1tE=");
            //_configurationDictionary.Add("merchantKeyId", "08c94330-f618-42a3-b09d-e1e43be5efda");
            _configurationDictionary.Add("keysDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource"));
            _configurationDictionary.Add("keyFilename", "testcasmerchpd01001");
            _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");
            _configurationDictionary.Add("keyAlias", "testcasmerchpd01001");
            _configurationDictionary.Add("keyPass", "Authnet101!");


            return _configurationDictionary;
        }

    }
}

