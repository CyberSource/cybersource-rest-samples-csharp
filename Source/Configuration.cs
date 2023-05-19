using System;
using System.Collections.Generic;
using System.IO;

namespace Cybersource_rest_samples_dotnet
{
    public class Configuration
    {
        // initialize dictionary object
        private readonly Dictionary<string, string> _configurationDictionary = new Dictionary<string, string>();

        public Dictionary<string, string> GetConfiguration()
        {
            _configurationDictionary.Add("authenticationType", "HTTP_SIGNATURE");
            _configurationDictionary.Add("merchantID", "testrest");
            _configurationDictionary.Add("merchantsecretKey", "yBJxy6LjM2TmcPGu+GaJrHtkke25fPpUX+UY6/L/1tE=");
            _configurationDictionary.Add("merchantKeyId", "08c94330-f618-42a3-b09d-e1e43be5efda");
            _configurationDictionary.Add("keysDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource"));
            _configurationDictionary.Add("keyFilename", "testrest");
            _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");
            _configurationDictionary.Add("keyAlias", "testrest");
            _configurationDictionary.Add("keyPass", "testrest");
            _configurationDictionary.Add("timeout", "300000");

            // Configs related to meta key
            _configurationDictionary.Add("portfolioID", string.Empty);
            _configurationDictionary.Add("useMetaKey", "false");

            // Configs related to OAuth
            _configurationDictionary.Add("enableClientCert", "false");
            _configurationDictionary.Add("clientCertDirectory", "Resource");
            _configurationDictionary.Add("clientCertFile", "");
            _configurationDictionary.Add("clientCertPassword", "");
            _configurationDictionary.Add("clientId", "");
            _configurationDictionary.Add("clientSecret", "");

            // _configurationDictionary.Add("proxyAddress", string.Empty);
            // _configurationDictionary.Add("proxyPort", string.Empty);
            // _configurationDictionary.Add("proxyUsername", string.Empty);
            // _configurationDictionary.Add("proxyPassword", string.Empty);
            return _configurationDictionary;
        }

        public Dictionary<string, string> GetAlternativeConfiguration()
        {
            _configurationDictionary.Add("authenticationType", "HTTP_SIGNATURE");
            _configurationDictionary.Add("merchantID", "testrest_cpctv");
            _configurationDictionary.Add("merchantsecretKey", "zXKpCqMQPmOR/JRldSlkQUtvvIzOewUVqsUP0sBHpxQ=");
            _configurationDictionary.Add("merchantKeyId", "964f2ecc-96f0-4432-a742-db0b44e6a73a");
            _configurationDictionary.Add("keysDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource"));
            _configurationDictionary.Add("keyFilename", "testrest_cpctv");
            _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");
            _configurationDictionary.Add("keyAlias", "testrest_cpctv");
            _configurationDictionary.Add("keyPass", "testrest_cpctv");
            _configurationDictionary.Add("timeout", "300000");
            // _configurationDictionary.Add("proxyAddress", string.Empty);
            // _configurationDictionary.Add("proxyPort", string.Empty);
            // _configurationDictionary.Add("proxyUsername", string.Empty);
            // _configurationDictionary.Add("proxyPassword", string.Empty);

            // Configs related to meta key
            _configurationDictionary.Add("portfolioID", string.Empty);
            _configurationDictionary.Add("useMetaKey", "false");

            // Configs related to OAuth
            _configurationDictionary.Add("enableClientCert", "false");
            _configurationDictionary.Add("clientCertDirectory", "Resource");
            _configurationDictionary.Add("clientCertFile", "");
            _configurationDictionary.Add("clientCertPassword", "");
            _configurationDictionary.Add("clientId", "");
            _configurationDictionary.Add("clientSecret", "");


            return _configurationDictionary;
        }

        public Dictionary<string, string> GetIntermediateConfiguration()
        {
            _configurationDictionary.Add("authenticationType", "HTTP_SIGNATURE");
            _configurationDictionary.Add("merchantID", "testrest");
            _configurationDictionary.Add("merchantsecretKey", "yBJxy6LjM2TmcPGu+GaJrHtkke25fPpUX+UY6/L/1tE=");
            _configurationDictionary.Add("merchantKeyId", "08c94330-f618-42a3-b09d-e1e43be5efda");
            _configurationDictionary.Add("keysDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource"));
            _configurationDictionary.Add("keyFilename", "testrest");
            _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");
            //new property has been added for user to configure the base path so that request can route the API calls via Azure Management URL.
            //Example: If intermediate url is https://manage.windowsazure.com then in property input can be same url or manage.windowsazure.com.
            _configurationDictionary.Add("intermediateHost", "https://manage.windowsazure.com");
            _configurationDictionary.Add("keyAlias", "testrest");
            _configurationDictionary.Add("keyPass", "testrest");
            _configurationDictionary.Add("timeout", "300000");

            // Configs related to meta key
            _configurationDictionary.Add("portfolioID", string.Empty);
            _configurationDictionary.Add("useMetaKey", "false");

            // Configs related to OAuth
            _configurationDictionary.Add("enableClientCert", "false");
            _configurationDictionary.Add("clientCertDirectory", "Resource");
            _configurationDictionary.Add("clientCertFile", "");
            _configurationDictionary.Add("clientCertPassword", "");
            _configurationDictionary.Add("clientId", "");
            _configurationDictionary.Add("clientSecret", "");

            // _configurationDictionary.Add("proxyAddress", string.Empty);
            // _configurationDictionary.Add("proxyPort", string.Empty);
            // _configurationDictionary.Add("proxyUsername", string.Empty);
            // _configurationDictionary.Add("proxyPassword", string.Empty);
            return _configurationDictionary;
        }
    }
}
