using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet
{
    internal class MerchantBoardingConfiguration
    {

        private readonly Dictionary<string, string> _configurationDictionary = new Dictionary<string, string>();

        public Dictionary<string, string> GetMerchantBoardingConfiguration()
        {
            _configurationDictionary.Add("authenticationType", "jwt");
            _configurationDictionary.Add("merchantID", "<Enter merchant id here>");
            _configurationDictionary.Add("merchantsecretKey", "");
            _configurationDictionary.Add("merchantKeyId", "");
            _configurationDictionary.Add("keysDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource"));
            _configurationDictionary.Add("keyFilename", "<Enter p12 filename without the extension>");
            _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");
            _configurationDictionary.Add("keyAlias", "<Enter keyalis/merchant id here>");
            _configurationDictionary.Add("keyPass", "<Enter password for p12 file>");
            _configurationDictionary.Add("timeout", "300000");

            // Configs related to meta key
            _configurationDictionary.Add("portfolioID", string.Empty);
            _configurationDictionary.Add("useMetaKey", "false");

        
            return _configurationDictionary;
        }

       
    }
}
