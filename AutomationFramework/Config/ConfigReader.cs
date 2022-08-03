namespace AutomationFramework
{
    using System.IO;
    using AutomationFramework.Config;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Class used to read config files and set up neccessary test data.
    /// </summary>
    public class ConfigReader
    {
        // Variable to store executing directory of the test.
        private static string executingDirectory = Directory.GetCurrentDirectory().Replace(@"\bin\Debug\netcoreapp3.1", string.Empty);

        /// <summary>
        /// Read appconfig files and gather browser and variable data.
        /// </summary>
        public void SetTestSettings()
        {
            // Gets the current directory, adds the file "appconfig.json" and builds into json object.
            var builder = new ConfigurationBuilder()
                .SetBasePath(executingDirectory)
                .AddJsonFile("appconfig.json", optional: false, reloadOnChange: true)
                .Build();

            if (executingDirectory.Contains("UI"))
            {
                ConfigVariables.BROWSER = builder.GetSection("TestSetting")
                    .Get<ConfigCapture>().Browser
                    .ToString();
                ConfigVariables.TESTLOCATION = builder.GetSection("TestSetting")
                    .Get<ConfigCapture>().TestLocation
                    .ToString();
            }
            else
            {
                ConfigVariables.APIURL = builder.GetSection("TestSetting")
                    .Get<ConfigCapture>().APIUrl
                    .ToString();
                ConfigVariables.STUBAPIURL = builder.GetSection("TestSetting")
                    .Get<ConfigCapture>().StubAPIUrl
                    .ToString();
            }
        }
    }
}
