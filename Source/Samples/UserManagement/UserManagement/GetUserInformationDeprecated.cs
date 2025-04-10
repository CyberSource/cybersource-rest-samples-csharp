using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.UserManagement
{
    public class GetUserInformationDeprecated
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static UmsV1UsersGet200Response Run()
        {
            string organizationId = "testrest";
            string userName = null;
            string permissionId = "CustomerProfileViewPermission";
            string roleId = null;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new UserManagementApi(clientConfig);
                UmsV1UsersGet200Response result = apiInstance.GetUsers(organizationId, userName, permissionId, roleId);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
