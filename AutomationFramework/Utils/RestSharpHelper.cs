namespace AutomationFramework.Utils
{
    using NUnit.Framework;
    using RestSharp;

    /// <summary>
    /// Class used to aid when sending Rest API Request.
    /// </summary>
    public class RestSharpHelper
    {
        /// <summary>
        /// Gets or sets global Response Body.
        /// </summary>
        public static IRestResponse ResponseBody { get; set; }

        /// <summary>
        /// Passes in a string and converts to a RestSharp.Method.
        /// </summary>
        /// <param name="requestType">Type of request to send.</param>
        /// <returns>Rest Method.</returns>
        public static Method DetermineRestRequestMethod(string requestType)
        {
            switch (requestType.ToUpper())
            {
                case "GET":
                    return Method.GET;
                case "POST":
                    return Method.POST;
                case "DELETE":
                    return Method.DELETE;
                case "PATCH":
                    return Method.PATCH;
                case "PUT":
                    return Method.PUT;
                default:
                    return Method.GET;
            }
        }

        /// <summary>
        /// Checks to see if the request has been completed before any further validation.
        /// </summary>
        public static void CheckRequestCompleted()
        {
            Assert.AreEqual("Completed", ResponseBody.ResponseStatus.ToString());
        }

        /// <summary>
        /// Asserts the response is as expected.
        /// </summary>
        /// <param name="expectedResponse">Response you are expecting to be returned.</param>
        public static void AssertResponseStatus(string expectedResponse)
        {
            Assert.AreEqual(expectedResponse, ResponseBody.StatusDescription);
        }
    }
}
