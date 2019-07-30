using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class CreateAdhocReport
    {
        public static void Run()
        {
            try
            {
                var requestObj = new RequestBody
                {
                    ReportDefinitionName = "TransactionRequestClass",
                    ReportFields = new List<string>()
                    {
                        "Request.RequestID",
                        "Request.TransactionDate",
                        "Request.MerchantID"
                    },
                    ReportMimeType = "application/xml",
                    ReportName = Utilities.RandomString(17),
                    Timezone = "GMT",
                    ReportStartTime = DateTime.ParseExact("2018-09-01T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture),
                    ReportEndTime = DateTime.ParseExact("2018-09-02T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)
                };

                var reportPreferencesObj = new Reportingv3reportsReportPreferences()
                {
                    SignedAmounts = true,
                    FieldNameConvention = "SOAPI"
                };

                requestObj.ReportPreferences = reportPreferencesObj;

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportsApi(clientConfig);

                apiInstance.CreateReport(requestObj);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
