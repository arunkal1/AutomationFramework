// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AutomationAPI.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Assignment3")]
    public partial class Assignment3Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Assignment3.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Assignment3", "\tAssignment 3: API Test Automation", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("01_APITestAutomation_CurrencyConversionRates")]
        [NUnit.Framework.CategoryAttribute("Assignment3")]
        [NUnit.Framework.TestCaseAttribute("USD", null)]
        [NUnit.Framework.TestCaseAttribute("GBP", null)]
        [NUnit.Framework.TestCaseAttribute("AED", null)]
        [NUnit.Framework.TestCaseAttribute("CZK", null)]
        [NUnit.Framework.TestCaseAttribute("HUF", null)]
        public void _01_APITestAutomation_CurrencyConversionRates(string baseCurrency, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Assignment3"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("baseCurrency", baseCurrency);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01_APITestAutomation_CurrencyConversionRates", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table1.AddRow(new string[] {
                            "requestType",
                            "GET"});
                table1.AddRow(new string[] {
                            "baseUrl",
                            "{{APIUrl}}"});
                table1.AddRow(new string[] {
                            "pathUrl",
                            "/latest"});
                table1.AddRow(new string[] {
                            "queryParams",
                            string.Format("base={0}", baseCurrency)});
#line 6
 testRunner.Given("the user send the following API Request", ((string)(null)), table1, "Given ");
#line hidden
#line 12
 testRunner.When("the request is completed and a response is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.Then("the response status returned should be \'OK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02_APITestAutomation_StubReturnsResponse")]
        [NUnit.Framework.CategoryAttribute("Assignment3")]
        [NUnit.Framework.TestCaseAttribute("USD", null)]
        [NUnit.Framework.TestCaseAttribute("GBP", null)]
        public void _02_APITestAutomation_StubReturnsResponse(string baseCurrency, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Assignment3"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("baseCurrency", baseCurrency);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02_APITestAutomation_StubReturnsResponse", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table2.AddRow(new string[] {
                            "requestType",
                            "GET"});
                table2.AddRow(new string[] {
                            "baseUrl",
                            "{{APIUrl}}"});
                table2.AddRow(new string[] {
                            "pathUrl",
                            "/latest"});
                table2.AddRow(new string[] {
                            "queryParams",
                            string.Format("base={0}", baseCurrency)});
#line 25
 testRunner.Given("the user send the following API Request", ((string)(null)), table2, "Given ");
#line hidden
#line 31
 testRunner.When("the request is completed and a response is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 32
 testRunner.Then("the response status returned should be \'OK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 33
 testRunner.And("the response content is stored in the database json file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.And("the stub server is started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table3.AddRow(new string[] {
                            "requestType",
                            "POST"});
                table3.AddRow(new string[] {
                            "baseUrl",
                            "{{StubAPIUrl}}"});
                table3.AddRow(new string[] {
                            "pathUrl",
                            "/auth/login"});
                table3.AddRow(new string[] {
                            "requestBody",
                            "{\"email\": \"nilson@email.com\",\"password\":\"nilson\"}"});
#line 35
 testRunner.And("the user send the following API Request", ((string)(null)), table3, "And ");
#line hidden
#line 41
 testRunner.And("the request is completed and a response is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.And("the response status returned should be \'OK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 43
 testRunner.And("the authentication token is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table4.AddRow(new string[] {
                            "requestType",
                            "GET"});
                table4.AddRow(new string[] {
                            "baseUrl",
                            "{{StubAPIUrl}}"});
                table4.AddRow(new string[] {
                            "pathUrl",
                            "/exchangerates"});
                table4.AddRow(new string[] {
                            "authenticated",
                            "Yes"});
#line 44
 testRunner.And("the user send the following API Request", ((string)(null)), table4, "And ");
#line hidden
#line 50
 testRunner.And("the request is completed and a response is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 51
 testRunner.And("the response status returned should be \'OK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
 testRunner.And("the stub server is ended", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
