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

* Http

    ```lang-none
      authenticationType  = http_Signature
      merchantID          = your_merchant_id
      merchantKeyId       = your_key_serial_number
      merchantsecretKey   = your_key_shared_secret
    ```

* Jwt

    ```lang-none
      authenticationType  = Jwt
      merchantID          = your_merchant_id
      keyAlias            = your_merchant_id
      keyPassword         = your_merchant_id
      keyFileName         = your_merchant_id
      keysDirectory       = Resource
    ```

## Switching between the sandbox environment and the production environment

CyberSource maintains a complete sandbox environment for testing and development purposes. This sandbox environment is an exact duplicate of our production environment with the transaction authorization and settlement process simulated. By default, this SDK is configured to communicate with the sandbox environment. To switch to the production environment, set the appropriate environment constant in `Source\Configuration.cs` file.  For example:

```csharp
// For TESTING use
_configurationDictionary.Add("runEnvironment", "cybersource.environment.sandbox");

// For PRODUCTION use
// _configurationDictionary.Add("runEnvironment", "cybersource.environment.production");
```

The [API Reference Guide](https://developer.cybersource.com/api/reference/api-reference.html) provides examples of what information is needed for a particular request and how that information would be formatted. Using those examples, you can easily determine what methods would be necessary to include that information in a request using this SDK.

## License

This repository is distributed under a proprietary license.
