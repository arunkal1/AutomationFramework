namespace AutomationAPI.Steps
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using AutomationFramework.Config;
    using AutomationFramework.Utils;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using RestSharp;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Step Definition file for all the API Steps.
    /// </summary>
    [Binding]
    public class StepDefs
    {
        /// <summary>
        /// Gets or sets string to store the authentication token.
        /// </summary>
        private string AuthenticationToken { get; set; }

        /// <summary>
        /// Gets or sets the API Response Time.
        /// </summary>
        private double ResponseTimeSeconds { get; set; }

        /// <summary>
        /// Method to create the Base URL.
        /// </summary>
        /// <param name="requestBaseUrl">Value passed from user dictionary.</param>
        /// <returns>Base URL String.</returns>
        public string DetermineBaseUrl(string requestBaseUrl)
        {
            switch (requestBaseUrl)
            {
                case "{{APIUrl}}":
                    return ConfigVariables.APIURL;
                case "{{StubAPIUrl}}":
                    return ConfigVariables.STUBAPIURL;
                default:
                    return requestBaseUrl;
            }
        }

        /// <summary>
        /// When the user sends the desired request with the requestType, baseUrl, pathUrl, queryParams and/or Body.
        /// </summary>
        /// <param name="table">Gherkin feature file table.</param>
        [StepDefinition(@"the user send the following API Request")]
        public void GivenTheUserSendTheFollowingAPIRequest(Table table)
        {
            // Obtain data from Gherkin table.
            var dictionary = TableExtensions.ToDictionary(table);

            // Set's up the request URL.
            var client = new RestClient(DetermineBaseUrl(dictionary["baseUrl"]) + dictionary["pathUrl"]);

            // Passes in the request type - converted from 'String' to 'RestRequest'.
            var request = new RestRequest(RestSharpHelper.DetermineRestRequestMethod(dictionary["requestType"]));

            // Add's a RequestBody if the value is populated in the feature file.
            if (dictionary.ContainsKey("requestBody"))
            {
                // Adding Content-Type header to request to let it know it's a JSON body.
                request.AddHeader("Content-type", "application/json");
                request.AddJsonBody(dictionary["requestBody"]);
            }

            // Add's query parameters if the value is populated in the feature file.
            if (dictionary.ContainsKey("queryParams"))
            {
                // Splits the query parameters into a string array.
                string[] queryParamsToAdd = dictionary["queryParams"].Split(",");

                // If there is only one item to add to the request.QueryParams then no need to foreach element as there is only one.
                if (queryParamsToAdd.Count().Equals(1))
                {
                    // Split's each parameter from format Key=Value into two seperate values. Get's overiden each time so it's doesnt keep adding the same parameter.
                    var keyValueSplit = queryParamsToAdd[0].Split(new[] { '=' }, 2);

                    // Add's Key, Value to Query Parameter.
                    request.AddQueryParameter(keyValueSplit[0], keyValueSplit[1]);
                }
                else
                {
                    foreach (var param in queryParamsToAdd)
                    {
                        // Split's each parameter from format Key=Value into two seperate values. Get's overiden each time so it's doesnt keep adding the same parameter.
                        string[] keyValueSplit = param.Split("=");

                        // Add's Key, Value to Query Parameter.
                        request.AddQueryParameter(keyValueSplit[0], keyValueSplit[1]);
                    }
                }
            }

            if (dictionary.ContainsKey("authenticated"))
            {
                // Add's the authorization token to the request.
                request.AddHeader("Authorization", AuthenticationToken);
            }

            // Executes the request with the given URL, Method and Data.
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            IRestResponse response = client.Execute(request);
            stopWatch.Stop();
            Console.WriteLine("================================");
            Console.WriteLine("Request URL: " + client.BaseUrl);
            Console.WriteLine("================================");
            Console.WriteLine("Response Code: " + response.StatusCode.ToString());
            Console.WriteLine("================================");
            Console.WriteLine("Response Body: " + response.Content);
            Console.WriteLine("================================");
            Console.WriteLine("Elapsed Response Time: " + stopWatch.Elapsed.TotalSeconds + "(S)");
            Console.WriteLine("================================");
            ResponseTimeSeconds = stopWatch.Elapsed.TotalSeconds;
            stopWatch.Reset();

            // Set's the return response in the Helper class to use for future assertions and checks.
            RestSharpHelper.ResponseBody = response;
        }

        /// <summary>
        /// Confirms that the sent request has returned a completed response.
        /// </summary>
        [StepDefinition(@"the request is completed and a response is returned")]
        public void WhenTheRequestIsCompletedAndAResponseIsReturned()
        {
            RestSharpHelper.CheckRequestCompleted();
        }

        /// <summary>
        /// Confirms the response status returned is as expected.
        /// </summary>
        /// <param name="responseStatus">Status to confirm is returned.</param>
        [StepDefinition(@"the response status returned should be '(.*)'")]
        public void ThenTheResponseStatusReturnedShouldBe(string responseStatus)
        {
            RestSharpHelper.AssertResponseStatus(responseStatus);
        }

        /// <summary>
        /// Captures the returned authentication token, which returned from the stub login response.
        /// </summary>
        [StepDefinition(@"the authentication token is returned")]
        public void GivenTheAuthenticationTokenIsReturned()
        {
            var parsedJson = JObject.Parse(RestSharpHelper.ResponseBody.Content);
            AuthenticationToken = "Bearer " + parsedJson.Property("access_token").Value.ToString();
        }

        /// <summary>
        /// The response returned from the API is stored in the database.json file so the subsequent stub can return the content from the API.
        /// </summary>
        [StepDefinition(@"the response content is stored in the database json file")]
        public void GivenTheResponseContentIsStoredInTheDb_JsonFile()
        {
            // Location for the database.json file.
            var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, solutionDir, "../../..", "StubJSONServer", "StubJSONServer");
            var path2 = Directory.CreateDirectory(path + "/");
            string fileName = path2.ToString() + "database.json";

            // Captures the current contents of the database.json file to replace with new API response.
            string capturedFileContents = File.ReadAllText(fileName);

            // Get's the starting index of the second { bracket in the JSON
            var startIndex = capturedFileContents.IndexOf('{', capturedFileContents.IndexOf('{') + 1);

            // Stores the first part of the JSON to keep.
            var output = string.Concat(capturedFileContents.Substring(0, startIndex));

            // Stores the last part of the JSON to keep. This will keep the Array end which is required for the format.
            var output2 = string.Concat(capturedFileContents.Substring(capturedFileContents.Length - 3, 3));

            // JSON Response is stored in JObject variable.
            string jsonResponse = JObject.Parse(RestSharpHelper.ResponseBody.Content).ToString();

            // In between both peices of JSON to keep, the API Response is inserted into the stub to get our desired response.
            var newString = output.Insert(output.Length, jsonResponse) + output2;

            // Writes the new API response to the database.json file so it can be stubbed for further api requests.
            File.WriteAllText(fileName, newString);
        }

        /// <summary>
        /// The stub server is started.
        /// </summary>
        [StepDefinition(@"the stub server is started")]
        public void ThenTheStubSeverIsStarted()
        {
            // Location for the database.json file.
            var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, solutionDir, "../../..", "StubJSONServer", "StubJSONServer");
            var path2 = Directory.CreateDirectory(path + "/");

            var p = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    WorkingDirectory = path2.ToString(),
                    Arguments = "/C npm run start-auth",
                },
            }.Start();

            Thread.Sleep(30000);
        }

        /// <summary>
        /// The stub server is ended.
        /// </summary>
        [StepDefinition(@"the stub server is ended")]
        public static void ThenTheStubServerIsEnded()
        {
            // Looks for all node running processes.
            Process[] workers = Process.GetProcessesByName("node");
            foreach (Process worker in workers)
            {
                // For each of the node processes it kills, waits for exit and disposes of them.
                worker.Kill();
                worker.WaitForExit();
                worker.Dispose();
            }
        }
    }
}
