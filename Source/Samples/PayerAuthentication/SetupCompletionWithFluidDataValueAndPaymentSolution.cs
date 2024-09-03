using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication
{
    public class SetupCompletionWithFluidDataValueAndPaymentSolution
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static RiskV1AuthenticationSetupsPost201Response Run()
        {
            string clientReferenceInformationCode = "cybs_test";
            Riskv1authenticationsetupsClientReferenceInformation clientReferenceInformation = new Riskv1authenticationsetupsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationFluidDataValue = "eyJkYXRhIjoiOFJTK2o1a2ZLRjZkTnkzNVwvOTluR3ZEVis0WUVlaStBb2VmUUNMXC9SNTN0TnVMeHJxTzh4b1g2SnBScm9WWUVUOUNvUkhIWFZMRjJNSVNIZlVtM25UczltdGFPTUdqcW1oeWdjTFpWVWI3OHhxYVVUT2JwWUxLelY0dFR1QmhvRkV4UVJ1d2lvTmo2bXJsRlRjUm5LNzdcL2lCR01yYVlZcXZTVnhGK3ViK1JXK3BGeTRDNUVUOVhmcHBkS2xHYXVpODdzcTBtYVlYVk9qOGFaNTFMWjZvS1NKZkR1clhvWEtLNHRqd1wvaDVRK1dcL0x2dnJxSUhmZmVhK21MZXVRY3RHK0k3UUN6MTRpVmdROUFEMW1oWFUrbVdwZXRUQWZ5WXhoVituZlh1NlpISGRDWFV1cUp6djQydHg4UlwvN0lvdld5OWx6Z0N3YnpuclVsY3pUcThkb3JtV3A4eXhYQklDNnJHRTdlTVJrS3oxZFwvUFFDXC9DS2J1NDhNK0R4XC9VejNoUFwvZ1NnRGoxakJNcUllUUZiRWFzcTRWTUV1ZG9FNUh1UjBcLzRQMXJmdG9EVlpwNnhFdnF1STY5dkt2YnZHcXpmTkpUNjVnPT0iLCJ2ZXJzaW9uIjoiRUNfdjEiLCJoZWFkZXIiOnsiYXBwbGljYXRpb25EYXRhIjoiNzQ2NTczNzQ2MTcwNzA2QzY5NjM2MTc0Njk2RjZFNjQ2MTc0NjEiLCJ0cmFuc2FjdGlvbklkIjoiNzQ2NTczNzQ3NDcyNjE2RTczNjE2Mzc0Njk2RjZFNjk2NCIsImVwaGVtZXJhbFB1YmxpY0tleSI6Ik1JSUJTekNDQVFNR0J5cUdTTTQ5QWdFd2dmY0NBUUV3TEFZSEtvWkl6ajBCQVFJaEFQXC9cL1wvXC84QUFBQUJBQUFBQUFBQUFBQUFBQUFBXC9cL1wvXC9cL1wvXC9cL1wvXC9cL1wvXC9cL1wvXC9NRnNFSVBcL1wvXC9cLzhBQUFBQkFBQUFBQUFBQUFBQUFBQUFcL1wvXC9cL1wvXC9cL1wvXC9cL1wvXC9cL1wvXC84QkNCYXhqWFlxanFUNTdQcnZWVjJtSWE4WlIwR3NNeFRzUFk3emp3K0o5SmdTd01WQU1TZE5naUc1d1NUYW1aNDRST2RKcmVCbjM2UUJFRUVheGZSOHVFc1FrZjR2T2JsWTZSQThuY0RmWUV0NnpPZzlLRTVSZGlZd3BaUDQwTGlcL2hwXC9tNDduNjBwOEQ1NFdLODR6VjJzeFhzN0x0a0JvTjc5UjlRSWhBUFwvXC9cL1wvOEFBQUFBXC9cL1wvXC9cL1wvXC9cL1wvXC8rODV2cXRweGVlaFBPNXlzTDhZeVZSQWdFQkEwSUFCQmJHK2xtTHJIWWtKSVwvSUUwcTU3dEN0bE5jK2pBWHNudVMrSnFlOFVcLzc0cSs5NVRnbzVFRjBZNks3b01LTUt5cTMwY3VQbmtIenkwMjVpU1BGdWczRT0iLCJwdWJsaWNLZXlIYXNoIjoieCtQbUhHMzdUNjdBWUFIenVqbGJyaW1JdzZZaFlYaVpjYjV3WnJCNGpRdz0ifSwic2lnbmF0dXJlIjoiTUlJRFFnWUpLb1pJaHZjTkFRY0NvSUlETXpDQ0F5OENBUUV4Q3pBSkJnVXJEZ01DR2dVQU1Bc0dDU3FHU0liM0RRRUhBYUNDQWlzd2dnSW5NSUlCbEtBREFnRUNBaEJjbCtQZjMrVTRwazEzblZEOW53UVFNQWtHQlNzT0F3SWRCUUF3SnpFbE1DTUdBMVVFQXg0Y0FHTUFhQUJ0QUdFQWFRQkFBSFlBYVFCekFHRUFMZ0JqQUc4QWJUQWVGdzB4TkRBeE1ERXdOakF3TURCYUZ3MHlOREF4TURFd05qQXdNREJhTUNjeEpUQWpCZ05WQkFNZUhBQmpBR2dBYlFCaEFHa0FRQUIyQUdrQWN3QmhBQzRBWXdCdkFHMHdnWjh3RFFZSktvWklodmNOQVFFQkJRQURnWTBBTUlHSkFvR0JBTkM4K2tndGdtdldGMU96amdETnJqVEVCUnVvXC81TUt2bE0xNDZwQWY3R3g0MWJsRTl3NGZJWEpBRDdGZk83UUtqSVhZTnQzOXJMeXk3eER3YlwvNUlrWk02MFRaMmlJMXBqNTVVYzhmZDRmek9wazNmdFphUUdYTkxZcHRHMWQ5VjdJUzgyT3VwOU1NbzFCUFZyWFRQSE5jc005OUVQVW5QcWRiZUdjODdtMHJBZ01CQUFHalhEQmFNRmdHQTFVZEFRUlJNRStBRUhaV1ByV3RKZDdZWjQzMWhDZzdZRlNoS1RBbk1TVXdJd1lEVlFRREhod0FZd0JvQUcwQVlRQnBBRUFBZGdCcEFITUFZUUF1QUdNQWJ3QnRnaEJjbCtQZjMrVTRwazEzblZEOW53UVFNQWtHQlNzT0F3SWRCUUFEZ1lFQWJVS1lDa3VJS1M5UVEybUZjTVlSRUltMmwrWGc4XC9KWHYrR0JWUUprT0tvc2NZNGlOREZBXC9iUWxvZ2Y5TExVODRUSHdOUm5zdlYzUHJ2N1JUWTgxZ3EwZHRDOHpZY0FhQWtDSElJM3lxTW5KNEFPdTZFT1c5a0prMjMyZ1NFN1dsQ3RIYmZMU0tmdVNnUVg4S1hRWXVaTGsyUnI2M044QXBYc1h3QkwzY0oweGdlQXdnZDBDQVFFd096QW5NU1V3SXdZRFZRUURIaHdBWXdCb0FHMEFZUUJwQUVBQWRnQnBBSE1BWVFBdUFHTUFid0J0QWhCY2wrUGYzK1U0cGsxM25WRDlud1FRTUFrR0JTc09Bd0lhQlFBd0RRWUpLb1pJaHZjTkFRRUJCUUFFZ1lBMG9MXC9KSWFTN0tra1RFNG1pOGRmU2tQVVwvdlp2cVwva2NYZ1pUdGJZbENtTFM4YzNuS2VZNVE0c2s4MXJnZkI1ampBMWJRZldhUHBKc05tVWNSS3gzS0FGUEtpNzE0WWVYdGUrcmc2V1k4MnVxcnlwRERiTkhqSWVpNjVqV0dvcGRZUEx6TEk5c1Z3NDh5OHlqSXY3SjFaQVlycnp6YjBwNzUzcUJUQ0ZEN1p3PT0ifQ==";
            Riskv1authenticationsetupsPaymentInformationFluidData paymentInformationFluidData = new Riskv1authenticationsetupsPaymentInformationFluidData(
                Value: paymentInformationFluidDataValue
           );

            Riskv1authenticationsetupsPaymentInformation paymentInformation = new Riskv1authenticationsetupsPaymentInformation(
                FluidData: paymentInformationFluidData
           );

            string processingInformationPaymentSolution = "001";
            Riskv1authenticationsetupsProcessingInformation processingInformation = new Riskv1authenticationsetupsProcessingInformation(
                PaymentSolution: processingInformationPaymentSolution
           );

            var requestObj = new PayerAuthSetupRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation,
                ProcessingInformation: processingInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PayerAuthenticationApi(clientConfig);
                RiskV1AuthenticationSetupsPost201Response result = apiInstance.PayerAuthSetup(requestObj);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
