using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using WebAdvert.ServiceWorker.Models;

namespace WebAdvert.ServiceWorker
{
    public static class ElasticSearchHelper
    {
        private static IElasticClient _client;
        //public static IElasticClient GetInstance(IConfiguration _config)
        //{
        //    if(_client == null)
        //    {
        //        var url = _config.GetSection("ES").GetValue<string>("url");
        //        //  var settings = new ConnectionSettings(new Uri(url)).DefaultIndex("adverts");
        //        var settings = new ConnectionSettings(new Uri(url))
        //                        .DefaultIndex("adverts")
        //                            .DefaultMappingFor<AdvertType>(m => m.IdProperty(x => x.Id));
        //        //Default property of id is _id 
        //        _client = new ElasticClient(settings);
        //    }
        //    return _client;       
        //}

        public static IElasticClient GetInstance()
        {
            if (_client == null)
            {
                var url = System.Environment.GetEnvironmentVariable("ES_URL");
                //  var settings = new ConnectionSettings(new Uri(url)).DefaultIndex("adverts");
                var settings = new ConnectionSettings(new Uri(url))
                                .DefaultIndex("adverts")
                                    .DefaultMappingFor<AdvertType>(m => m.IdProperty(x => x.Id));
                //Default property of id is _id 
                _client = new ElasticClient(settings);
            }
            return _client;
        }
    }
}
