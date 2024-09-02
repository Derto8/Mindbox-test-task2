using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Helpers
{
    public static class ConfigurationHelper
    {
        private const string APP_SETTINGS_CONF = "appsettings.json";

        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile(APP_SETTINGS_CONF)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
