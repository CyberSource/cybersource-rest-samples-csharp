# C# Sample Code for the CyberSource SDK

[![Travis CI Status](https://travis-ci.org/CyberSource/cybersource-rest-samples-csharp.svg?branch=master)](https://travis-ci.org/CyberSource/cybersource-rest-samples-csharp)

This repository contains working code samples which demonstrate C#/.NET integration with the CyberSource REST APIs through the [CyberSource .NET SDK](https://github.com/CyberSource/cybersource-rest-client-dotnet).

## Using the Sample Code

The samples are all completely independent and self-contained. You can analyze them to get an understanding of how a particular method works, or you can use the snippets as a starting point for your own project.

### Requirements

* .NET Framework 4.6.1
* [CyberSource Account](https://developer.cybersource.com/api/developer-guides/dita-gettingstarted/registration.html)
* [CyberSource API Keys](https://developer.cybersource.com/api/developer-guides/dita-gettingstarted/registration/createCertSharedKey.html)

The samples are organized into categories and common usage examples.

### Running the Samples

* Clone this repository.

    ```bash
    git clone https://github.com/CyberSource/cybersource-rest-samples-csharp.git
    ```

* Open the solution `cybersource-rest-samples-csharp.sln` in Visual Studio and perform a clean build.

* Run the console app and select a sample to execute.

  The console app can be executed from the `Debug` menu in Visual Studio.

  Alternatively, the console app can also be executed from `command prompt`, run the following command.

    ```bash
    bin\Debug\net461\SampleCode.exe
    ```

## Setting Your API Credentials

To set your API credentials for an API request, configure the following information in `Source\Configuration.cs` file:

* Http (**Deprecated** — migrate to JWT with Shared Secret below)

    ```lang-none
      authenticationType  = http_Signature
      merchantID          = your_merchant_id
      merchantKeyId       = your_key_serial_number
      merchantsecretKey   = your_key_shared_secret
      useMetaKey          = false
      enableClientCert    = false
    ```

* Jwt (with P12 certificate)

    ```lang-none
      authenticationType  = Jwt
      merchantID          = your_merchant_id
      keyAlias            = your_merchant_id
      keyPassword         = your_merchant_id
      keyFileName         = your_merchant_id
      keysDirectory       = Resource
      useMetaKey          = false
      enableClientCert    = false
    ```

* Jwt with Shared Secret (**Recommended migration path from Http Signature**)

  Uses the **same** `merchantKeyId` and `merchantsecretKey` credentials as Http Signature, but authenticates via JWT. This enables MLE (Message Level Encryption) support for both request and response payloads, which Http Signature does not support.

  For detailed migration guide, configuration, and sample code, see the [JWT Shared Secret Auth samples](Source/Samples/JwtSharedSecretAuth/README.md).

    ```lang-none
      authenticationType  = Jwt
      jwtKeyType          = SHARED_SECRET
      merchantID          = your_merchant_id
      merchantKeyId       = your_key_serial_number
      merchantsecretKey   = your_key_shared_secret
    ```

* MetaKey Http (**Deprecated** — migrate to MetaKey JWT with Shared Secret below)

  ```lang-none
    authenticationType  = http_Signature
    merchantID          = your_transacting_merchant_id
    merchantKeyId       = your_metakey_serial_number
    merchantsecretKey   = your_metakey_shared_secret
    portfolioId         = your_portfolio_id
    useMetaKey          = true
    enableClientCert    = false
  ```

* MetaKey JWT (P12)

  ```lang-none
    authenticationType  = Jwt
    merchantID          = your_transacting_merchant_id
    keyAlias            = your_child_merchant_id
    keyPassword         = your_portfolio_id
    keyFileName         = your_portfolio_id
    keysDirectory       = Resource
    useMetaKey          = true
    enableClientCert    = false
  ```

* MetaKey JWT with Shared Secret (**Recommended migration from MetaKey Http**)

  Uses the same MetaKey credentials as MetaKey Http but authenticates via JWT, enabling MLE support.

  ```lang-none
    authenticationType  = Jwt
    jwtKeyType          = SHARED_SECRET
    merchantID          = your_transacting_merchant_id
    merchantKeyId       = your_metakey_serial_number
    merchantsecretKey   = your_metakey_shared_secret
    portfolioId         = your_portfolio_id
    useMetaKey          = true
  ```

* Response MLE with MetaKey

  When Response MLE is enabled (`enableResponseMleGlobally=true`) and MetaKey is in use (`useMetaKey=true`), the Response MLE configuration must use the **portfolio's** response MLE key — not the transacting merchant's. Specifically:

  - `responseMlePrivateKeyFilePath` (or `responseMlePrivateKey` object) must point to the **portfolio's** response MLE private key.
  - `responseMleKID` — the KID value associated with the **portfolio's** response MLE certificate.
    - **Optional** when `responseMlePrivateKeyFilePath` points to a CyberSource-generated P12 file (SDK auto-fetches from P12).
    - **Required** when using PEM format files (`.pem`, `.key`, `.p8`) or when providing `responseMlePrivateKey` object directly.

  ```lang-none
    enableResponseMleGlobally          = true
    responseMlePrivateKeyFilePath      = \path\to\portfolio\response\mle\private\key.p12
    responseMlePrivateKeyFilePassword  = portfolio_private_key_password
    // responseMleKID is optional when using a CyberSource-generated P12 file (auto-fetched from P12)
    // Required when using PEM files or responseMlePrivateKey object
    // responseMleKID                  = your_portfolio_response_mle_kid
  ```

  > **Important:** The response MLE private key (and KID, if applicable) must belong to the portfolio (parent account), since in MetaKey mode the portfolio is the transaction submitter and the response is encrypted using the portfolio's MLE certificate.

* OAuth

  CyberSource OAuth uses mutual authentication. A Client Certificate is required to authenticate against the OAuth API. 

  Refer to [Supporting Mutual Authentication](https://developer.cybersource.com/api/developer-guides/OAuth/cybs_extend_intro/Supporting-Mutual-Authentication.html) to get information on how to generate Client certificate.

  If the certificate (Public Key) and Private Key are in 2 different files, merge them into a single .p12 file using `openssl`.

    ```bash
    openssl pkcs12 -export -out certificate.p12 -inkey privateKey.key -in certificate.crt
    ```

  Set the run environment to OAuth enabled URLs. OAuth only works in these run environments.

    ```csharp
    // For TESTING use
    _configurationDictionary.Add("runEnvironment", "api-matest.cybersource.com")
    // For PRODUCTION use
    // _configurationDictionary.Add("runEnvironment", "api-ma.cybersource.com")
    ```

  To generate tokens, an Auth Code is required. The Auth Code can be generated by following the instructions given in [Integrating OAuth](https://developer.cybersource.com/api/developer-guides/OAuth/cybs_extend_intro/integrating_OAuth.html).

  This generated Auth Code can then be used to create the Access Token and Refresh Token.

  In `Source/Configuration.cs` file, set the following properties.
  
  Note that `authenticationType` is set to `MutualAuth` only to generate the Access Token and the Refresh Token.

    ```lang-none
    authenticationType  = MutualAuth
    enableClientCert    = true
    clientCertDirectory = resources
    clientCertFile      = your_client_cert in .p12 format
    clientCertPassword  = password_for_client_cert
    clientId            = your_client_id
    clientSecret        = your_client_secret
    ```

  Once the tokens are obtained, the `authenticationType` can then be set to `OAuth` to use the generated Access Token to send requests to other APIs.

    ```lang-none
    authenticationType  = OAuth
    enableClientCert    = true
    clientCertDirectory = resources
    clientCertFile      = your_client_cert - .p12 format
    clientCertPassword  = password_for_client_cert
    clientId            = your_client_id
    clientSecret        = your_client_secret
    accessToken         = generated_access_token
    refreshToken        = generated_refresh_token
    ```

  The Access Token is valid for 15 mins, whereas the Refresh Token is valid for 1 year.

  Once the Access Token expires, use the Refresh Token to generate another Access Token.

  Refer to [StandAloneOAuth.cs](https://github.com/CyberSource/cybersource-rest-samples-csharp/tree/master/Source/Samples/Authentication/StandaloneOAuth.cs) to understand how to consume OAuth.

  For further information, refer to the documentation at [Cybersource OAuth 2.0](https://developer.cybersource.com/api/developer-guides/OAuth/cybs_extend_intro.html).

## Switching between the sandbox environment and the production environment

CyberSource maintains a complete sandbox environment for testing and development purposes. This sandbox environment is an exact duplicate of our production environment with the transaction authorization and settlement process simulated. By default, this SDK is configured to communicate with the sandbox environment. To switch to the production environment, set the appropriate environment constant in `Source\Configuration.cs` file.  For example:

```csharp
    // For TESTING use
    _configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");

    // For PRODUCTION use
    // _configurationDictionary.Add("runEnvironment", "api.cybersource.com");
```

To use OAuth, switch to OAuth enabled URLs

```csharp
   // For TESTING use
   _configurationDictionary.Add("runEnvironment", "api-matest.cybersource.com")
   // For PRODUCTION use
   // _configurationDictionary.Add("runEnvironment", "api-ma.cybersource.com")
```

The [API Reference Guide](https://developer.cybersource.com/api/reference/api-reference.html) provides examples of what information is needed for a particular request and how that information would be formatted. Using those examples, you can easily determine what methods would be necessary to include that information in a request using this SDK.

### Logging

[![Generic badge](https://img.shields.io/badge/LOGGING-NEW-GREEN.svg)](https://shields.io/)

Since v0.0.1.14, a new logging framework has been introduced in the SDK. This new logging framework makes use of NLog, and standardizes the logging so that it can be integrated with the logging in the client application.

More information about this new logging framework can be found in this file : [Logging_Net461.md](Logging_Net461.md)

## Disclaimer

Cybersource may allow Customer to access, use, and/or test a Cybersource product or service that may still be in development or has not been market-tested (“Beta Product”) solely for the purpose of evaluating the functionality or marketability of the Beta Product (a “Beta Evaluation”). Notwithstanding any language to the contrary, the following terms shall apply with respect to Customer’s participation in any Beta Evaluation (and the Beta Product(s)) accessed thereunder): The Parties will enter into a separate form agreement detailing the scope of the Beta Evaluation, requirements, pricing, the length of the beta evaluation period (“Beta Product Form”). Beta Products are not, and may not become, Transaction Services and have not yet been publicly released and are offered for the sole purpose of internal testing and non-commercial evaluation. Customer’s use of the Beta Product shall be solely for the purpose of conducting the Beta Evaluation. Customer accepts all risks arising out of the access and use of the Beta Products. Cybersource may, in its sole discretion, at any time, terminate or discontinue the Beta Evaluation. Customer acknowledges and agrees that any Beta Product may still be in development and that Beta Product is provided “AS IS” and may not perform at the level of a commercially available service, may not operate as expected and may be modified prior to release. CYBERSOURCE SHALL NOT BE RESPONSIBLE OR LIABLE UNDER ANY CONTRACT, TORT (INCLUDING NEGLIGENCE), OR OTHERWISE RELATING TO A BETA PRODUCT OR THE BETA EVALUATION (A) FOR LOSS OR INACCURACY OF DATA OR COST OF PROCUREMENT OF SUBSTITUTE GOODS, SERVICES OR TECHNOLOGY, (B) ANY CLAIM, LOSSES, DAMAGES, OR CAUSE OF ACTION ARISING IN CONNECTION WITH THE BETA PRODUCT; OR (C) FOR ANY INDIRECT, INCIDENTAL OR CONSEQUENTIAL DAMAGES INCLUDING, BUT NOT LIMITED TO, LOSS OF REVENUES AND LOSS OF PROFITS.


## License

This repository is distributed under a proprietary license.
