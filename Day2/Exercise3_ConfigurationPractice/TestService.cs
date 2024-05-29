using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_ConfigurationPractice
{
    internal class TestService
    {
        private readonly IConfiguration _configuration;
        private readonly EmailServiceSettings _emailServiceSettings;
        private readonly LayoutSettings _layoutSettings;

        public TestService(IConfiguration configuration, IOptions<EmailServiceSettings> options)
        {
            _configuration = configuration;
            _layoutSettings = new LayoutSettings();
            _configuration.Bind("Layout", _layoutSettings);

            _emailServiceSettings = options.Value;
        }
        public void Check()
        {
            string title = _configuration["Features:HomePage:Title"];
            Console.BackgroundColor = _layoutSettings.BackgroundColor;
            Console.ForegroundColor = _layoutSettings.Color;
            Console.WriteLine(title);
            Console.WriteLine("Host:{0}", _emailServiceSettings.Host);

        }
    }
}
