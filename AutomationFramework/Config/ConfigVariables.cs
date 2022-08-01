namespace AutomationFramework.Config
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Variables for values obtained in appconfig.json.
    /// </summary>
    public static class ConfigVariables
    {
        /// <summary>
        /// Gets or sets variable for Browser Type.
        /// </summary>
        public static string BROWSER { get; set; }

        /// <summary>
        /// Gets or sets variable for Test Run Location.
        /// </summary>
        public static string TESTLOCATION { get; set; }
    }
}
