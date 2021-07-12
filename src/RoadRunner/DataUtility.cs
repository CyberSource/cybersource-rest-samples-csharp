using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace RoadRunner
{
    class DataUtility
    {
        static JToken Find(JObject response, string field)
        {
            var split = field.Split('.');
            foreach (var s in split)
            {
                bool accessingArrayField = s.Contains("[");
                var temp = s.Split('[')[0];
                if (accessingArrayField)
                {
                    if (response[temp][0] is JObject)
                    {
                        response = response[temp][0].ToObject<JObject>();
                    }
                }
                else if (response[temp] is JObject)
                {
                    response = response[temp].ToObject<JObject>();
                }
                else
                {
                    return response[temp];
                }
            }
            return null;
        }


        public static List<AssertionData> GetTestAssertionDataFromRoads(JToken road, Dictionary<string, string> globalMap, string uniqueName, Assembly assembly)
        {
            List<AssertionData> data = new List<AssertionData>();

            try
            {
                string sampleCodeName = road["sampleClassNames"]["csharp"].ToString();
                var storedFields = road["storedResponseFields"].ToObject<List<string>>();

                // remove the old input fields from map.
                foreach (var field in storedFields)
                {
                    globalMap.Remove(uniqueName + field);
                }

                var dependentSampleCode = road["prerequisiteRoad"].ToString();

                var dependentFields = road["dependentFieldMapping"].ToObject<List<string>>();

                List<object> inputFields = new List<object>();

                bool callSampleCode = true;

                if(sampleCodeName.Contains("Token_Management"))
                {
                    inputFields.Add("93B32398-AD51-4CC2-A682-EA3E93614EB1");
                }
                else if(sampleCodeName.Contains("GetReportDefinition"))
                {
                    inputFields.Add("TransactionRequestClass");
                }

                // check if required i/p fields are present in the map.
                foreach (var field in dependentFields)
                {
                    if (globalMap.ContainsKey(dependentSampleCode + field))
                    {
                        inputFields.Add(globalMap[dependentSampleCode + field]);
                    }
                    else
                    {
                        data.Add(new AssertionData(true, false, "Sample code wasn't executed as the dependent field \"" + field + "\" wasn't passed."));
                        callSampleCode = false;
                    }
                }

                if ((sampleCodeName.Contains("Retrieve") || sampleCodeName.Contains("Delete")) && dependentSampleCode != "")
                {
                    Thread.Sleep(15000);
                }

                // sample code isn't run if the required i/p fields aren't provided.
                if (callSampleCode)
                {
                    var className = "Cybersource_rest_samples_dotnet." + sampleCodeName;
                    Type type = assembly.GetType(className);
                    object result = null;

                    if (type != null)
                    {
                        MethodInfo mInfo = type.GetMethod("Run");

                        if (mInfo != null)
                        {
                            ParameterInfo[] parameters = mInfo.GetParameters();
                            object classInstance = Activator.CreateInstance(type, null);

                            // run the method.
                            if (parameters.Length == 0)
                            {
                                result = mInfo.Invoke(classInstance, null);
                            }
                            else
                            {
                                result = mInfo.Invoke(classInstance, inputFields.ToArray());
                            }

                            if (result != null)
                            {
                                try
                                {
                                    var resultJson = JsonConvert.SerializeObject(result);
                                    var jsonResponse = JObject.Parse(resultJson);

                                    // Convert the response to json, this is to parse it.
                                    foreach (var field in storedFields)
                                    {
                                        var value = Find(jsonResponse, field);
                                        if (value != null)
                                        {
                                            globalMap.Add(uniqueName + field, value.ToString());
                                        }
                                    }

                                    if (road["Assertions"]["httpStatus"] != null && string.IsNullOrEmpty(road["Assertions"]["httpStatus"].ToString()))
                                    {
                                        // get http status from sample code
                                    }

                                    if (storedFields != null)
                                    {
                                        // check the assertions and build the test data.
                                        foreach (var field in storedFields)
                                        {
                                            var actualValue = Find(jsonResponse, field.ToString());
                                            data.Add(new AssertionData(true, actualValue != null, field + " - is a required field, but not present in the response."));
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    data.Add(new AssertionData(true, false, "Sample Code was run, but an exception occured in road runner. Exception is - " + ex.Message));
                                }
                            }
                            else
                            {
                                data.Add(new AssertionData(true, false, "Sample Code was run, but an exception occured during sample code execution."));
                            }
                        }
                        else
                        {
                            data.Add(new AssertionData(true, false, "Run method wasn't found in the sample code."));
                        }
                    }
                    else
                    {
                        data.Add(new AssertionData(true, false, "Sample Code wasn't found / Class name in Sample code is wrong."));
                    }
                }
            }
            catch (Exception ex)
            {
                data.Add(new AssertionData(true, false, "Sample Code wasn't run as an exception occured in road runner. Exception is - " + ex.Message));
            }

            // return the data which has the assertions.
            return data;
        }
    }
}
