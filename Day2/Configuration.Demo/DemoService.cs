using Configuration.Demo.Settings;
using Microsoft.Extensions.Configuration;

namespace Configuration.Demo
{
    internal class DemoService
    {


        private readonly IConfiguration _configuration;

        public DemoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //private readonly IOptionsMonitor<FeaturesSettings> _optionsMonitor;
        //public DemoService(IOptionsMonitor<FeaturesSettings> optionsMonitor)
        //{
        //    _optionsMonitor = optionsMonitor;
        //}

        public string GetValue()
        {
            return _configuration.GetValue<string>("Key1");
        }

        public string GetObjValues()
        {
            //  return _configuration.GetValue<string>("GeneralSettings:Subsection:Suboption1");
            var generalSettings = new GeneralSettings();
            _configuration.Bind("GeneralSettings", generalSettings);
            return generalSettings.Subsection.Suboption1;

            //  return _configuration.GetValue<int>("GeneralSettings:Subsection:Suboption2");
        }

        //public void PrintConfig()
        //{
        //    while (true)
        //    {
        //        var featuresSettings = _optionsMonitor.CurrentValue;
        //        Console.WriteLine($"FeatureA:{featuresSettings.FeatureA}");
        //        Thread.Sleep(1000);
        //    }
        //}
    }
}
