using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.UserManagement.CoreServices
{
    public class GetUserInformation
    {
        public static void Run()
        {
            try
            {
                var organizationId = "testrest";
                var permissionId = "CustomerProfileViewPermission";
                var roleId = "admin";
                var username = "tesrest";

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new UserManagementApi(clientConfig);

                var result = apiInstance.GetUsers(organizationId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
