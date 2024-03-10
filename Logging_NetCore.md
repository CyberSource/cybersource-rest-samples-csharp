[![Generic badge](https://img.shields.io/badge/LOGGING-NEW-GREEN.svg)](https://shields.io/)

# Logging in CyberSource REST Client SDK (.NET Standard)

Since v0.0.1.7, a new logging framework has been introduced in the SDK. This new logging framework makes use of NLog, and standardizes the logging so that it can be integrated with the logging in the client application. The decision to use NLog for building this logging framework has been taken based on benchmark studies that have been made on various logging platforms supported for C#/.NET.

[One such study](https://www.loggly.com/blog/benchmarking-5-popular-net-logging-libraries/) performed benchmarking of five logging frameworks on the market &mdash; Log4Net, ELMAH, NLog, Microsoft Enterprise Library, and NSpring. In this study,

> _For heavy-hitting applications that require file logging and speed, NLog was clearly the winner. NLog also has good support from the community with integrationsfor log management solutions._

## NLog Configuration

NLog is a flexible and free logging platform for various .NET platforms, including .NET standard. NLog makes it easy to write to several targets (database, file, console) and change the logging configuration on-the-fly.

Refer this [document of NLog Configuration](https://nlog-project.org/config/) for a complete and detailed description of all the configuration options.

## Setup

In order to leverage the new logging framework, it is required to install the **`NLog.Config`** package into the .NET project. This can be done using the Package Manager, steps for which can be found on the [NuGet page for the package](https://www.nuget.org/packages/NLog.Config/).

When the **`NLog.Config`** package is installed, it will add two new files to the project &mdash; **`NLog.config`** and **`NLog.xsd`**.

<span style="color: red;">**Note that the package name is `NLog.Config` and the name of the newly added file is `NLog.config`.**</span>

The **`Copy To Output Directory`** property of this `NLog.config` file needs to be set to **`Copy Always`**.

## Sample NLog.config File

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      autoReload="true"
      throwExceptions="false"
      throwConfigExceptions="true"
      globalThreshold="Trace"
      internalLogLevel="Off" internalLogFile="">

  <!-- Keeping `globalThreshold` at `Trace` because no log events below `globalThreshold` will be logged, regardless of any rules. -->

  <variable name="enableMasking" value="true"/>

  <targets>
    <target name="file"
            xsi:type="File"
            layout="[${longdate:universalTime=true}] [${level:uppercase=true}] [${logger:shortName=true}] : ${message}"
            fileName="C:\path\to\logs\Application.log"
            keepFileOpen="false"
            archiveAboveSize="5242880"
            archiveNumbering="Date"
            archiveDateFormat="yyyymmddhhmmss"/>
    <target name="logConsole" xsi:type="Console"
            layout="[${longdate:universalTime=true}] [${level:uppercase=true}] [${logger:shortName=true}] : ${message}" />
  </targets>
  <rules>
    <logger name="*" minlevel="Trace" writeTo="file" />
    <logger name="*" minlevel="Trace" writeTo="logconsole" />
  </rules>
</nlog>
```

### Important Notes

* The logger name in the rule must match the **'Logger name of the Logger object'**. It can include wildcard characters (`*`, `?`).
* The logger name can be the namespace from which logging statements should be honored.
  * In case `name="*"` is used, all logging statements from all namespaces will be written to log. This will include logging statements from inside the SDK as well.
  * If logging statements from inside the SDK should not be logged, provide specific namespaces in the rules.
* The `minlevel` field denotes the minimum level to log. In a production environment, this may be set to `Warn`.
* The variable `enableMasking` needs to be set to `true` if sensitive data in the request/response should be hidden/masked.
  * Sensitive data fields are listed below:
    * Card Security Code
    * Card Number
    * Any field with `number` in the name
    * Card Expiration Month
    * Card Expiration Year
    * Account
    * Routing Number
    * Email
    * First Name & Last Name
    * Phone Number
    * Type
    * Token
    * Signature
