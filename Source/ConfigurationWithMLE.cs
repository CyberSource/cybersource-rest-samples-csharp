using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cybersource_rest_samples_dotnet.Samples.Payments;

namespace SampleCodeNetCore.Source
{
    class ConfigurationWithMLE
    {
        // initialize dictionary object
        private readonly Dictionary<string, string> _configurationDictionary = new Dictionary<string, string>();
        private readonly Dictionary<string, bool> _configurationDictionaryforMLE = new Dictionary<string, bool>();

        public Dictionary<string, bool> GetMapToControlMLE()
        {
            _configurationDictionaryforMLE.Add("CreatePayment", true);         //CreatePayment function will have MLE=true i.e. (/pts/v2/payments POST API)      
            _configurationDictionaryforMLE.Add("CapturePayment", false);       //capturePayment function will have MLE=false i.e.  (/pts/v2/payments/{id}/captures POST API)

            return _configurationDictionaryforMLE;
        }

        public Dictionary<string, string> GetConfiguration1()
        {
            _configurationDictionary.Add("authenticationType", "JWT");
            _configurationDictionary.Add("merchantID", "testrest");
            _configurationDictionary.Add("merchantsecretKey", "yBJxy6LjM2TmcPGu+GaJrHtkke25fPpUX+UY6/L/1tE=");
            _configurationDictionary.Add("merchantKeyId", "08c94330-f618-42a3-b09d-e1e43be5efda");
            _configurationDictionary.Add("keysDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource"));
            _configurationDictionary.Add("keyFilename", "testrest");
            _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");
            _configurationDictionary.Add("keyAlias", "testrest");
            _configurationDictionary.Add("keyPass", "testrest");
            _configurationDictionary.Add("useMLEGlobally", "true");     //globally MLE will be enabled for all the MLE supported APIs by Cybs in SDK
            _configurationDictionary.Add("mleKeyAlias", "CyberSource_SJC_US");      //this is optional paramter, not required to set the parameter/value if custom value is not required for MLE key alias. Default value is "CyberSource_SJC_US".


            // Configs related to meta key
            _configurationDictionary.Add("portfolioID", string.Empty);
            _configurationDictionary.Add("useMetaKey", "false");

            /*
             * Add the property if required to override the cybs default developerId in all request body 
            */
            _configurationDictionary.Add("defaultDeveloperId", "");

            return _configurationDictionary;
        }


        public Dictionary<string, string> GetConfiguration2()
        {
            _configurationDictionary.Add("authenticationType", "JWT");
            _configurationDictionary.Add("merchantID", "testrest");
            _configurationDictionary.Add("merchantsecretKey", "yBJxy6LjM2TmcPGu+GaJrHtkke25fPpUX+UY6/L/1tE=");
            _configurationDictionary.Add("merchantKeyId", "08c94330-f618-42a3-b09d-e1e43be5efda");
            _configurationDictionary.Add("keysDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource"));
            _configurationDictionary.Add("keyFilename", "testrest");
            _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");
            _configurationDictionary.Add("keyAlias", "testrest");
            _configurationDictionary.Add("keyPass", "testrest");
            _configurationDictionary.Add("useMLEGlobally", "false");     //globally MLE will be disabled for all the MLE supported APIs by Cybs in SDK
            _configurationDictionary.Add("mleKeyAlias", "CyberSource_SJC_US");      //this is optional paramter, not required to set the parameter/value if custom value is not required for MLE key alias. Default value is "CyberSource_SJC_US".


            // Configs related to meta key
            _configurationDictionary.Add("portfolioID", string.Empty);
            _configurationDictionary.Add("useMetaKey", "false");

            /*
             * Add the property if required to override the cybs default developerId in all request body 
            */
            _configurationDictionary.Add("defaultDeveloperId", "");

            return _configurationDictionary;
        }
    }
}

       