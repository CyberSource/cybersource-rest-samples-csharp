using System.Collections.Generic;

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
            _configurationDictionary.Add("keysDirectory", "Resource");
            _configurationDictionary.Add("keyFilename", "testrest");
            _configurationDictionary.Add("runEnvironment", "cybersource.environment.sandbox");
            _configurationDictionary.Add("keyAlias", "testrest");
            _configurationDictionary.Add("keyPass", "testrest");
            _configurationDictionary.Add("enableLog", "FALSE");
            _configurationDictionary.Add("logDirectory", string.Empty);
            _configurationDictionary.Add("logFileName", string.Empty);
            _configurationDictionary.Add("logFileMaxSize", "5242880");
            _configurationDictionary.Add("timeout", "300000");

            // Configs related to meta key
            _configurationDictionary.Add("portfolioID", string.Empty);
            _configurationDictionary.Add("useMetaKey", "false");
			
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
            _configurationDictionary.Add("merchantsecretKey", "JXm4dqKYIxWofM1TIbtYY9HuYo7Cg1HPHxn29f6waRo=");
            _configurationDictionary.Add("merchantKeyId", "e547c3d3-16e4-444c-9313-2a08784b906a");
            _configurationDictionary.Add("keysDirectory", "Resource");
            _configurationDictionary.Add("keyFilename", "testrest_cpctv");
            _configurationDictionary.Add("runEnvironment", "cybersource.environment.sandbox");
            _configurationDictionary.Add("keyAlias", "testrest_cpctv");
            _configurationDictionary.Add("keyPass", "testrest_cpctv");
            _configurationDictionary.Add("enableLog", "FALSE");
            _configurationDictionary.Add("logDirectory", string.Empty);
            _configurationDictionary.Add("logFileName", string.Empty);
            _configurationDictionary.Add("logFileMaxSize", "5242880");
            _configurationDictionary.Add("timeout", "300000");
            // _configurationDictionary.Add("proxyAddress", string.Empty);
            // _configurationDictionary.Add("proxyPort", string.Empty);
            // _configurationDictionary.Add("proxyUsername", string.Empty);
            // _configurationDictionary.Add("proxyPassword", string.Empty);

            // Configs related to meta key
            _configurationDictionary.Add("portfolioID", string.Empty);
            _configurationDictionary.Add("useMetaKey", "false");


            return _configurationDictionary;
        }
    }
}
