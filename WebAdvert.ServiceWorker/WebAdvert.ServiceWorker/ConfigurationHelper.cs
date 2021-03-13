using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebAdvert.ServiceWorker
{
    public static class ConfigurationHelper
    {
        private static IConfiguration _configuration = null;
        public static IConfiguration Instance
        {
            get
            {
                if(_configuration == null)
                {
                    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json").Build();
                    _configuration = builder;
                }
                return _configuration;
            }
        }
    }
}
