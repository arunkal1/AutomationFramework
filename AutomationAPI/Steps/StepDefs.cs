namespace AutomationAPI.Steps
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using AutomationFramework.Config;
    using AutomationFramework.Utils;
    using RestSharp;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Step Definition file for all the API Steps.
    /// </summary>
    [Binding]
    public class StepDefs
    {
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
    }
}
