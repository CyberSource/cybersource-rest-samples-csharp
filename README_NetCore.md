# .NET Core Sample Code for the CyberSource SDK

<!-- [![Travis CI Status](https://travis-ci.org/CyberSource/cybersource-rest-samples-csharp.svg?branch=master)](https://travis-ci.org/CyberSource/cybersource-rest-samples-csharp) -->

This repository contains working code samples which demonstrate .NET Core integration with the CyberSource REST APIs through the [CyberSource .NET Standard SDK](https://github.com/CyberSource/cybersource-rest-client-dotnetstandard).

## Using the Sample Code

The samples are all completely independent and self-contained. You can analyze them to get an understanding of how a particular method works, or you can use the snippets as a starting point for your own project.

### Requirements

* .NET Core 3.1 / .NET Standard 2.1
* Visual Studio 2019
* [CyberSource Account](https://developer.cybersource.com/api/developer-guides/dita-gettingstarted/registration.html)
* [CyberSource API Keys](https://developer.cybersource.com/api/developer-guides/dita-gettingstarted/registration/createCertSharedKey.html)

The samples are organized into categories and common usage examples.

#### Caveats

* Remember to add the installation path for the .NET Core/.NET Standard to the PATH environment variable.

### Running the Samples

#### Windows OS

* Clone this repository

    ```bash
    git clone https://github.com/CyberSource/cybersource-rest-samples-csharp.git
    ```

* Open the solution `cybersource-rest-samples-netcore.sln` in Visual Studio 2019 and perform a clean build.

* Run the console app and select a sample to execute.

  The console app can be executed from the `Debug` menu in Visual Studio 2019.

  Alternatively, the console app can also be executed from `command prompt`, run the following command.

    ```bash
    dotnet bin\Debug\netcoreapp3.1\SampleCodeNetCore.dll
    ```

#### Linux / Mac OS

* Clone this repository.

    ```bash
    git clone https://github.com/CyberSource/cybersource-rest-samples-csharp.git
    ```

* Change directory to `cybersource-rest-samples-netcore` folder.

    ```bash
    cd cybersource-rest-samples-netcore
    ```

* Clean the `bin` folder to remove any previous build (if applicable).

    ```bash
    rm -r -f bin/*
    ```

* From the root directory of the repository, run the following command:

    ```bash
    dotnet publish -c <configuration> -r <RID> --self-contained
    ```

* In this command,

  * For `<configuration>`, accepted values are `Debug` and `Release`.

  * For `<RID>`, refer to [.NET Core RID Catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) to find the proper **Runtime Identifier (RID)**.

  * This determines the location of the output files ( `bin/<configuration>/netcoreapp3.1/<RID>/publish` ).

* Move the output files from `bin/<configuration>/netcoreapp3.1/<RID>/publish` to `bin/<configuration>/netcoreapp3.1`.

    ```bash
    mv bin/<configuration>/netcoreapp3.1/<RID>/publish/* bin/<configuration>/netcoreapp3.1
    ```

* Linux : Provide execute permissions for the DLL.

    ```bash
    chmod 777 bin/<configuration>/netcoreapp3.1/SampleCodeNetCore.dll
    ```

* Execute the console app and select a sample to execute.

  * Linux

    ```bash
    ./bin/<configuration>/netcoreapp3.1/SampleCodeNetCore.dll
    ```

  * Mac OS

    ```bash
    dotnet bin/<configuration>/netcoreapp3.1/SampleCodeNetCore.dll
    ```

## Setting Your API Credentials

To set your API credentials for an API request, configure the following information in `Source\Configuration.cs` file:
  
* Http

    ```lang-none
    authenticationType  = http_Signature
    merchantID          = your_merchant_id
    merchantKeyId       = your_key_serial_number
    merchantsecretKey   = your_key_shared_secret
    useMetaKey          = false
    enableClientCert    = false
    ```

* Jwt

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

* MetaKey Http

  ```lang-none
    authenticationType  = http_Signature
    merchantID          = your_child_merchant_id
    merchantKeyId       = your_metakey_serial_number
    merchantsecretKey   = your_metakey_shared_secret
    portfolioId         = your_portfolio_id
    useMetaKey          = true
    enableClientCert    = false
  ```

* MetaKey JWT

  ```lang-none
    authenticationType  = Jwt
    merchantID          = your_child_merchant_id
    keyAlias            = your_child_merchant_id
    keyPassword         = your_portfolio_id
    keyFileName         = your_portfolio_id
    keysDirectory       = Resource
    useMetaKey          = true
    enableClientCert    = false
  ```

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

Since v0.0.1.7, a new logging framework has been introduced in the SDK. This new logging framework makes use of NLog, and standardizes the logging so that it can be integrated with the logging in the client application.

More information about this new logging framework can be found in this file : [Logging_NetCore.md](Logging_NetCore.md)

## Disclaimer

Cybersource may allow Customer to access, use, and/or test a Cybersource product or service that may still be in development or has not been market-tested (“Beta Product”) solely for the purpose of evaluating the functionality or marketability of the Beta Product (a “Beta Evaluation”). Notwithstanding any language to the contrary, the following terms shall apply with respect to Customer’s participation in any Beta Evaluation (and the Beta Product(s)) accessed thereunder): The Parties will enter into a separate form agreement detailing the scope of the Beta Evaluation, requirements, pricing, the length of the beta evaluation period (“Beta Product Form”). Beta Products are not, and may not become, Transaction Services and have not yet been publicly released and are offered for the sole purpose of internal testing and non-commercial evaluation. Customer’s use of the Beta Product shall be solely for the purpose of conducting the Beta Evaluation. Customer accepts all risks arising out of the access and use of the Beta Products. Cybersource may, in its sole discretion, at any time, terminate or discontinue the Beta Evaluation. Customer acknowledges and agrees that any Beta Product may still be in development and that Beta Product is provided “AS IS” and may not perform at the level of a commercially available service, may not operate as expected and may be modified prior to release. CYBERSOURCE SHALL NOT BE RESPONSIBLE OR LIABLE UNDER ANY CONTRACT, TORT (INCLUDING NEGLIGENCE), OR OTHERWISE RELATING TO A BETA PRODUCT OR THE BETA EVALUATION (A) FOR LOSS OR INACCURACY OF DATA OR COST OF PROCUREMENT OF SUBSTITUTE GOODS, SERVICES OR TECHNOLOGY, (B) ANY CLAIM, LOSSES, DAMAGES, OR CAUSE OF ACTION ARISING IN CONNECTION WITH THE BETA PRODUCT; OR (C) FOR ANY INDIRECT, INCIDENTAL OR CONSEQUENTIAL DAMAGES INCLUDING, BUT NOT LIMITED TO, LOSS OF REVENUES AND LOSS OF PROFITS.


## License

This repository is distributed under a proprietary license.
