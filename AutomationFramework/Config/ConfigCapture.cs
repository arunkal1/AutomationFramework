namespace AutomationFramework
{
    using Newtonsoft.Json;

    /// <summary>
    /// Captures JSON properties from appconfig.json.
    /// </summary>
    [JsonObject("TestSetting")]
    public class ConfigCapture
    {
        /// <summary>
        /// Gets or sets the Browser Type.
        /// </summary>
        [JsonProperty("Browser")]
        public string Browser { get; set; }

        /// <summary>
        /// Gets or sets the Test Run Location.
        /// </summary>
        [JsonProperty("TestLocation")]
        public string TestLocation { get; set; }

        /// <summary>
        /// Gets or sets the API Base URL.
        /// </summary>
        [JsonProperty("APIUrl")]
        public string APIUrl { get; set; }

        /// <summary>
        /// Gets or sets the Stub API Base URL.
        /// </summary>
        [JsonProperty("StubAPIUrl")]
        public string StubAPIUrl { get; set; }
    }
}