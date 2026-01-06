using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cybersource_rest_samples_dotnet.Samples.Payments;

namespace Cybersource_rest_samples_dotnet
{
    class ConfigurationWithMLE
    {
        // initialize dictionary object
        private readonly Dictionary<string, string> _configurationDictionary = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _configurationDictionaryforMLE = new Dictionary<string, string>();

        public Dictionary<string, string> GetMapToControlMLE()
        {
            _configurationDictionaryforMLE.Add("CreatePayment", "true::false");         //CreatePayment function will have Request MLE=true and Response MLE=false i.e. (/pts/v2/payments POST API)      
            _configurationDictionaryforMLE.Add("CapturePayment", "false::false");       //CapturePayment function will have Request MLE=false and Response MLE=false i.e. (/pts/v2/payments/{id}/captures POST API)

            return _configurationDictionaryforMLE;
        }

        public Dictionary<string, string> GetMapToControlMLEForRequestAndResponse()
        {
            Dictionary<string, string> mleMap = new Dictionary<string, string>();
            mleMap.Add("CreatePayment", "true::false");         //CreatePayment function will have Request MLE=true and Response MLE=false i.e. (/pts/v2/payments POST API)
            mleMap.Add("EnrollCard", "true::true");             //EnrollCard function will have Request MLE=true and Response MLE=true i.e. (/acp/v1/tokens POST API)

            return mleMap;
        }

        public Dictionary<string, string> GetConfiguration1()
        {
            _configurationDictionary.Add("authenticationType", "JWT"); //mle only supoort with JWT Auth Type
            _configurationDictionary.Add("merchantID", "testrest"); 
            _configurationDictionary.Add("merchantsecretKey", "yBJxy6LjM2TmcPGu+GaJrHtkke25fPpUX+UY6/L/1tE=");
            _configurationDictionary.Add("merchantKeyId", "08c94330-f618-42a3-b09d-e1e43be5efda");
            _configurationDictionary.Add("keysDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource"));
            _configurationDictionary.Add("keyFilename", "testrest");
            _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");
            _configurationDictionary.Add("keyAlias", "testrest");
            _configurationDictionary.Add("keyPass", "testrest");

            //Set Request MLE Settings in Merchant Configuration
            _configurationDictionary.Add("enableRequestMLEForOptionalApisGlobally", "true");     //Enables request MLE globally for all APIs that have optional MLE support //same as older deprecated variable "useMLEGlobally" //APIs that has MLE Request mandatory is default has MLE support in SDK without any configuration but support with JWT auth type.
            _configurationDictionary.Add("requestMleKeyAlias", "CyberSource_SJC_US");      //this is optional parameter, not required to set the parameter if custom value is not required for MLE key alias. Default value is "CyberSource_SJC_US". //same as older deprecated variable "mleKeyAlias"

            //Set Response MLE Settings in Merchant Configuration
            _configurationDictionary.Add("enableResponseMleGlobally", "false");     //Enables/Disable response MLE globally for all APIs that support MLE responses
            _configurationDictionary.Add("responseMlePrivateKeyFilePath", "");      //Path to the Response MLE private key file. Supported formats: .p12, .pfx, .pem, .key, .p8. Recommendation use encrypted private Key (password protection) for MLE response.
            _configurationDictionary.Add("responseMlePrivateKeyFilePassword", "");  //Password for the private key file (required for .p12/.pfx files or encrypted private keys).
            _configurationDictionary.Add("responseMleKID", "");                     //This parameter is optional when responseMlePrivateKeyFilePath points to a CyberSource-generated P12 file. If not provided, the SDK will automatically fetch the Key ID from the P12 file. If provided, the SDK will use the user-provided value instead of the auto-fetched value.
                                                                                     //Required when using PEM format files (.pem, .key, .p8) or when providing responseMlePrivateKey object directly.

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

            //Set Request MLE Settings in Merchant Configuration
            _configurationDictionary.Add("enableRequestMLEForOptionalApisGlobally", "false");     //Disabled request MLE globally for all APIs that have optional MLE support //same as older deprecated variable "useMLEGlobally"
            _configurationDictionary.Add("requestMleKeyAlias", "CyberSource_SJC_US");      //this is optional parameter, not required to set the parameter if custom value is not required for MLE key alias. Default value is "CyberSource_SJC_US". //same as older deprecated variable "mleKeyAlias"

            //Set Response MLE Settings in Merchant Configuration
            _configurationDictionary.Add("enableResponseMleGlobally", "false");     //Enables/Disable response MLE globally for all APIs that support MLE responses
            _configurationDictionary.Add("responseMlePrivateKeyFilePath", "");      //Path to the Response MLE private key file. Supported formats: .p12, .pfx, .pem, .key, .p8. Recommendation use encrypted private Key (password protection) for MLE response.
            _configurationDictionary.Add("responseMlePrivateKeyFilePassword", "");  //Password for the private key file (required for .p12/.pfx files or encrypted private keys).
            _configurationDictionary.Add("responseMleKID", "");                     //This parameter is optional when responseMlePrivateKeyFilePath points to a CyberSource-generated P12 file. If not provided, the SDK will automatically fetch the Key ID from the P12 file. If provided, the SDK will use the user-provided value instead of the auto-fetched value.
                                                                                     //Required when using PEM format files (.pem, .key, .p8) or when providing responseMlePrivateKey object directly.

            // Configs related to meta key
            _configurationDictionary.Add("portfolioID", string.Empty);
            _configurationDictionary.Add("useMetaKey", "false");

            /*
             * Add the property if required to override the cybs default developerId in all request body 
            */
            _configurationDictionary.Add("defaultDeveloperId", "");

            return _configurationDictionary;
        }

        public Dictionary<string, string> GetMerchantDetailsWithRequestAndResponseMLE1()
        {
            _configurationDictionary.Add("authenticationType", "JWT"); //MLE only support with JWT Auth Type
            _configurationDictionary.Add("merchantID", "agentic_mid_091225001");
            _configurationDictionary.Add("keysDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource"));
            _configurationDictionary.Add("keyFilename", "agentic_mid_091225001");
            _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");
            _configurationDictionary.Add("keyAlias", "agentic_mid_091225001");
            _configurationDictionary.Add("keyPass", "Changeit@123");

            //Set Request MLE Settings in Merchant Configuration
            _configurationDictionary.Add("enableRequestMLEForOptionalApisGlobally", "true");     //Enables request MLE globally for all APIs that have optional MLE support //same as older deprecated variable "useMLEGlobally" //APIs that has MLE Request mandatory is default has MLE support in SDK without any configuration but support with JWT auth type.

            //Set Response MLE Settings in Merchant Configuration
            _configurationDictionary.Add("enableResponseMleGlobally", "true");                                              //Enables response MLE globally for all APIs that support MLE responses
            _configurationDictionary.Add("responseMlePrivateKeyFilePath", "..\\..\\..\\Source\\Resource\\agentic_mid_091225001_new_generated_mle.p12");      //Path to the Response MLE private key file. Supported formats: .p12, .pfx, .pem, .key, .p8. Recommendation use encrypted private Key (password protection) for MLE response.
            _configurationDictionary.Add("responseMlePrivateKeyFilePassword", "Changeit@123");                              //Password for the private key file (required for .p12/.pfx files or encrypted private keys).
            _configurationDictionary.Add("responseMleKID", "1764104507829324018353");                                       //Optional since p12 is Cybs Generated.
                                                                                                                             //This parameter is optional when responseMlePrivateKeyFilePath points to a CyberSource-generated P12 file. If not provided, the SDK will automatically fetch the Key ID from the P12 file. If provided, the SDK will use the user-provided value instead of the auto-fetched value.
                                                                                                                             //Required when using PEM format files (.pem, .key, .p8) or when providing responseMlePrivateKey object directly.
            return _configurationDictionary;
        }

        public Dictionary<string, string> GetMerchantDetailsWithRequestAndResponseMLE2()
        {
            _configurationDictionary.Add("authenticationType", "JWT"); //MLE only support with JWT Auth Type
            _configurationDictionary.Add("merchantID", "agentic_mid_091225001");
            _configurationDictionary.Add("keysDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource"));
            _configurationDictionary.Add("keyFilename", "agentic_mid_091225001");
            _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");
            _configurationDictionary.Add("keyAlias", "agentic_mid_091225001");
            _configurationDictionary.Add("keyPass", "Changeit@123");

            //Set Request MLE Settings in Merchant Configuration
            _configurationDictionary.Add("enableRequestMLEForOptionalApisGlobally", "false");    //Disable request MLE globally for all APIs that have optional MLE support //same as older deprecated variable "useMLEGlobally" //APIs that has MLE Request mandatory is default has MLE support in SDK without any configuration but support with JWT auth type.

            //Set Response MLE Settings in Merchant Configuration
            _configurationDictionary.Add("enableResponseMleGlobally", "false");                  //Disable response MLE globally for all APIs that support MLE responses

            //Set Request & Response MLE Settings in Merchant Configuration through MAP for API control level
            //Since one of the API has Response MLE true, below fields are required for Response MLE
            _configurationDictionary.Add("responseMlePrivateKeyFilePath", "..\\..\\..\\Source\\Resource\\agentic_mid_091225001_mle.p12");      //Path to the Response MLE private key file. Supported formats: .p12, .pfx, .pem, .key, .p8. Recommendation use encrypted private Key (password protection) for MLE response.
            _configurationDictionary.Add("responseMlePrivateKeyFilePassword", "Changeit@123");                              //Password for the private key file (required for .p12/.pfx files or encrypted private keys).
            _configurationDictionary.Add("responseMleKID", "1757970970891045729358");                                       //Optional since p12 is Cybs Generated.
                                                                                                                             //This parameter is optional when responseMlePrivateKeyFilePath points to a CyberSource-generated P12 file. If not provided, the SDK will automatically fetch the Key ID from the P12 file. If provided, the SDK will use the user-provided value instead of the auto-fetched value.
                                                                                                                             //Required when using PEM format files (.pem, .key, .p8) or when providing responseMlePrivateKey object directly.
            return _configurationDictionary;
        }
    }
}

       