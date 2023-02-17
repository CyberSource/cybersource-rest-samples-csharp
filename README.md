# C# Sample Code for the CyberSource SDK

[![Travis CI Status](https://travis-ci.org/CyberSource/cybersource-rest-samples-csharp.svg?branch=master)](https://travis-ci.org/CyberSource/cybersource-rest-samples-csharp)

This repository contains two applications that demonstrate integration with the CyberSource REST APIs through our SDKs.

## .NET Framework

The application `cybersource-rest-samples-csharp.sln` contains working code samples in a .NET 4.6.1 application which uses the [CyberSource .NET SDK](https://github.com/CyberSource/cybersource-rest-client-dotnet).

For a more detailed explanation of how to use this application, please refer to [README_Net461.md](./README_Net461.md).

## .NET Core

The application `cybersource-rest-samples-netcore.sln` contains working code samples in a .NET Core 3.1 application the [CyberSource .NET Standard SDK](https://github.com/CyberSource/cybersource-rest-client-dotnetstandard).

For a more detailed explanation of how to use this application, please refer to [README_NetCore.md](./README_NetCore.md).

## Run Environments

The run environments that were supported in CyberSource .NET SDK and CyberSource .NET Standard SDK have been deprecated.
Moving forward, the SDKs will only support the direct hostname as the run environment.

For the old run environments previously used, they should be replaced by the following hostnames:

|              Old Run Environment              |               New Hostname Value               |
|-----------------------------------------------|------------------------------------------------|
|`cybersource.environment.sandbox`              |`apitest.cybersource.com`                       |
|`cybersource.environment.production`           |`api.cybersource.com`                           |
|`cybersource.environment.mutualauth.sandbox`   |`api-matest.cybersource.com`                    |
|`cybersource.environment.mutualauth.production`|`api-ma.cybersource.com`                        |
|`cybersource.in.environment.sandbox`           |`apitest.cybersource.com`                       |
|`cybesource.in.environment.production`         |`api.in.cybersource.com`                        |

For example, replace the following code in the Configuration file:

```csharp
// For TESTING use
_configurationDictionary.Add("runEnvironment", "cybersource.environment.sandbox");

// For PRODUCTION use
// _configurationDictionary.Add("runEnvironment", "cybersource.environment.production");
```

with the following code:

```csharp
// For TESTING use
_configurationDictionary.Add("runEnvironment", "apitest.cybersource.com");

// For PRODUCTION use
// _configurationDictionary.Add("runEnvironment", "api.cybersource.com");
```
