using System;
using System.Collections.Generic;
using System.IO;

namespace Cybersource_rest_samples_dotnet
{
    /// <summary>
    /// Configuration for JWT authentication with Shared Secret (symmetric / HS256).
    ///
    /// <para><b>Why JWT with Shared Secret?</b></para>
    /// <list type="bullet">
    /// <item><b>HTTP Signature is being deprecated.</b> JWT with Shared Secret provides a
    /// seamless migration path — it uses the <b>same</b> merchantKeyId and
    /// merchantsecretKey credentials you already have for HTTP Signature.</item>
    /// <item><b>Enables MLE (Message Level Encryption).</b> MLE requires JWT authentication.
    /// By switching to JWT with Shared Secret, you can enable MLE without managing
    /// a P12 certificate file.</item>
    /// <item><b>Zero credential changes.</b> Your existing Key ID and Shared Secret from the
    /// CyberSource Business Center work as-is.</item>
    /// </list>
    ///
    /// <para><b>Credentials</b></para>
    /// <para>The merchantKeyId and merchantsecretKey are the same credentials
    /// used for HTTP Signature authentication. You can obtain them from the CyberSource
    /// Business Center:</para>
    /// <list type="bullet">
    /// <item>Test: https://businesscentertest.cybersource.com/ebc2</item>
    /// <item>Production: https://businesscenter.cybersource.com/ebc2</item>
    /// </list>
    /// </summary>
    public class JwtSharedSecretConfiguration
    {
        /// <summary>
        /// Returns merchant configuration for JWT authentication with Shared Secret.
        ///
        /// <para>This is a drop-in replacement for HTTP Signature authentication.
        /// The only changes from a typical HTTP Signature configuration are:</para>
        /// <list type="number">
        /// <item>authenticationType = JWT (instead of HTTP_SIGNATURE)</item>
        /// <item>jwtKeyType = SHARED_SECRET (new property)</item>
        /// </list>
        ///
        /// <para>The merchantKeyId and merchantsecretKey remain the same.</para>
        /// </summary>
        public static Dictionary<string, string> GetMerchantDetails()
        {
            var configurationDictionary = new Dictionary<string, string>();

            // Authentication: JWT with Shared Secret (HS256)
            configurationDictionary.Add("authenticationType", "JWT");
            configurationDictionary.Add("jwtKeyType", "SHARED_SECRET");

            configurationDictionary.Add("merchantID", "testrest");
            configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");

            // Shared Secret credentials — same as HTTP Signature credentials
            configurationDictionary.Add("merchantKeyId", "08c94330-f618-42a3-b09d-e1e43be5efda");
            configurationDictionary.Add("merchantsecretKey", "yBJxy6LjM2TmcPGu+GaJrHtkke25fPpUX+UY6/L/1tE=");

            // Configs related to meta key
            configurationDictionary.Add("portfolioID", string.Empty);
            configurationDictionary.Add("useMetaKey", "false");

            return configurationDictionary;
        }

        /// <summary>
        /// Returns merchant configuration for JWT with Shared Secret + MLE enabled.
        ///
        /// <para>This configuration enables Message Level Encryption (MLE) for request payloads.
        /// Response MLE is also supported — set enableResponseMleGlobally to true
        /// and provide the response MLE private key settings.</para>
        ///
        /// <para>When using jwtKeyType=SHARED_SECRET, Request MLE requires the public certificate
        /// to be provided via mleForRequestPublicCertPath because there is no P12 file
        /// to auto-extract it from.</para>
        ///
        /// <para>Download the MLE public certificate from the CyberSource Business Center:</para>
        /// <list type="bullet">
        /// <item>Test: https://businesscentertest.cybersource.com/ebc2</item>
        /// <item>Production: https://businesscenter.cybersource.com/ebc2</item>
        /// </list>
        /// </summary>
        public static Dictionary<string, string> GetMerchantDetailsWithMLE()
        {
            var configurationDictionary = new Dictionary<string, string>();

            // Authentication: JWT with Shared Secret (HS256)
            configurationDictionary.Add("authenticationType", "JWT");
            configurationDictionary.Add("jwtKeyType", "SHARED_SECRET");

            configurationDictionary.Add("merchantID", "testrest");
            configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");

            // Shared Secret credentials — same as HTTP Signature credentials
            configurationDictionary.Add("merchantKeyId", "08c94330-f618-42a3-b09d-e1e43be5efda");
            configurationDictionary.Add("merchantsecretKey", "yBJxy6LjM2TmcPGu+GaJrHtkke25fPpUX+UY6/L/1tE=");

            // --- Request MLE Configuration ---
            // When using SHARED_SECRET, the MLE certificate must be provided separately.
            // Download from CyberSource Business Center:
            //   Test: https://businesscentertest.cybersource.com/ebc2
            //   Prod: https://businesscenter.cybersource.com/ebc2
            configurationDictionary.Add("enableRequestMLEForOptionalApisGlobally", "true");
            configurationDictionary.Add("mleForRequestPublicCertPath", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource\\MLE_PublicCert.pem"));
            // configurationDictionary.Add("requestMleKeyAlias", "CyberSource_SJC_US"); // Optional — defaults to CyberSource_SJC_US

            // --- Response MLE Configuration ---
            // Set to "true" to enable response MLE (encrypted responses from CyberSource).
            // Requires a private key for decryption.
            configurationDictionary.Add("enableResponseMleGlobally", "false");
            // Provide a private key file path for decryption.
            // Supported formats: .p12, .pfx, .pem, .key, .p8
            configurationDictionary.Add("responseMlePrivateKeyFilePath", "");     // e.g., "..\\..\\..\\Source\\Resource\\your_mle_private_key.p12"
            configurationDictionary.Add("responseMlePrivateKeyFilePassword", ""); // Required for .p12/.pfx or encrypted keys
            // responseMleKID: Optional for CyberSource-generated P12 files (auto-extracted).
            // Required for PEM/KEY files or when providing PrivateKey object directly.
            configurationDictionary.Add("responseMleKID", "");

            // Configs related to meta key
            configurationDictionary.Add("portfolioID", string.Empty);
            configurationDictionary.Add("useMetaKey", "false");

            return configurationDictionary;
        }
    }
}
