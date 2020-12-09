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
    ```

* MetaKey Http

  ```
    authenticationType  = http_Signature
    merchantID          = your_child_merchant_id
    merchantKeyId       = your_metakey_serial_number
    merchantsecretKey   = your_metakey_shared_secret
    portfolioId         = your_portfolio_id
    useMetaKey          = true
  ```

* MetaKey JWT

  ```
    authenticationType  = Jwt
    merchantID          = your_child_merchant_id
    keyAlias            = your_child_merchant_id
    keyPassword         = your_portfolio_id
    keyFileName         = your_portfolio_id
    keysDirectory       = Resource
    useMetaKey          = true
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
