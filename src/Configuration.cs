using System.Collections.Generic;

namespace CybsPayments
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
            _configurationDictionary.Add("keysDirectory", "..\\..\\Resource");
            _configurationDictionary.Add("keyFilename", "testrest");
            _configurationDictionary.Add("runEnvironment", "cybersource.environment.sandbox");
            _configurationDictionary.Add("keyAlias", "testrest");
            _configurationDictionary.Add("keyPass", "testrest");
            _configurationDictionary.Add("enableLog", "TRUE");
            _configurationDictionary.Add("logDirectory", string.Empty);
            _configurationDictionary.Add("logFileName", string.Empty);
            _configurationDictionary.Add("logFileMaxSize", "5242880");
            _configurationDictionary.Add("timeout", "1000");
            _configurationDictionary.Add("proxyAddress", string.Empty);
            _configurationDictionary.Add("proxyPort", string.Empty);

            return _configurationDictionary;
        }
    }
}
