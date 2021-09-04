using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertApi.Models.Messages;
using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Nest;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace WebAdvert.ServiceWorker
{
    public class SearchWorker
    {
        //SingleTon Instance will be passed to the client
        //public SearchWorker() : this(ElasticSearchHelper.GetInstance(ConfigurationHelper.Instance))
        //{

        //}
        public SearchWorker() : this(ElasticSearchHelper.GetInstance())
        {

        }

        private readonly IElasticClient _client;
        public SearchWorker(IElasticClient client)
        {
            _client = client;
        }
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task FunctionHandler(SNSEvent snsEvent, ILambdaContext context)
        {
            foreach(var record in snsEvent.Records)
            {
                context.Logger.LogLine(record.Sns.Message);
                var message = JsonConvert.DeserializeObject<AdvertConfirmedMessage>(record.Sns.Message);
                var advertDocument = MappingHelper.Map(message);
                //When Lamvda Reeives messages it puts it into elastic search
                await _client.IndexDocumentAsync(advertDocument);

            }
        }
    }
}
