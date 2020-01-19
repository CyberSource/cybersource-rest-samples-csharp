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
            _configurationDictionary.Add("logDirectory", string.Empty);
            _configurationDictionary.Add("logFileName", string.Empty);
            _configurationDictionary.Add("proxyAddress", string.Empty);
            _configurationDictionary.Add("proxyPort", string.Empty);

            string[] input = File.ReadAllLines("Configuration.txt");
            string[] keyValueArray;
            foreach (string i in input)
            {
                keyValueArray = i.Split(',');
                _configurationDictionary.Add(keyValueArray[0], keyValueArray[1]);
            }

            return _configurationDictionary;
        }
    }
}
