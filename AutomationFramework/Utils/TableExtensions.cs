namespace AutomationFramework.Utils
{
    using System.Collections.Generic;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class to convert Gherkin tables into dictionaries.
    /// </summary>
    public class TableExtensions
    {
        /// <summary>
        /// Use System.Collections.Generic to convert a table into a dictionary.
        /// Will accept table data.
        /// </summary>
        /// <param name="table">Pass in the data to convert.</param>
        /// <returns>Dictionary with [Key,Value].</returns>
        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }

            return dictionary;
        }
    }
}
