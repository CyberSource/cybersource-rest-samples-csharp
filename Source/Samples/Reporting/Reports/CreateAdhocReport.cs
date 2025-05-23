using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class CreateAdhocReport
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static void Run()
        {
            string reportDefinitionName = "TransactionRequestClass";

            List<string> reportFields = new List<string>();
            reportFields.Add("Request.RequestID");
            reportFields.Add("Request.TransactionDate");
            reportFields.Add("Request.MerchantID");
            string reportMimeType = "application/xml";
            string reportName = "testrest_v2";
            string timezone = "GMT";
            var reportStartTime = DateTime.Parse("2025-02-01T17:30:00.000+05:30");
            var reportEndTime = DateTime.Parse("2025-02-02T17:30:00.000+05:30");
            bool reportPreferencesSignedAmounts = true;
            string reportPreferencesFieldNameConvention = "SOAPI";
            Reportingv3reportsReportPreferences reportPreferences = new Reportingv3reportsReportPreferences(
                SignedAmounts: reportPreferencesSignedAmounts,
                FieldNameConvention: reportPreferencesFieldNameConvention
           );

            var requestObj = new CreateAdhocReportRequest(
                ReportDefinitionName: reportDefinitionName,
                ReportFields: reportFields,
                ReportMimeType: reportMimeType,
                ReportName: reportName,
                Timezone: timezone,
                ReportStartTime: reportStartTime,
                ReportEndTime: reportEndTime,
                ReportPreferences: reportPreferences
           );

            string organizationId = "testrest";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReportsApi(clientConfig);
                apiInstance.CreateReport(requestObj, organizationId);
                WriteLogAudit(apiInstance.GetStatusCode());
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
            }
        }
    }
}
