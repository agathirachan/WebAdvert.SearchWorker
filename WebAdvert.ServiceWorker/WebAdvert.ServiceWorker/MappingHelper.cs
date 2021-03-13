using AdvertApi.Models.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using WebAdvert.ServiceWorker.Models;

namespace WebAdvert.ServiceWorker
{
    public class MappingHelper
    {
        public static AdvertType Map(AdvertConfirmedMessage message)
        {
            var doc = new AdvertType
            {
                Id = message.Id,
                Title = message.Title,
                CreationDateTime = DateTime.Now
            };
            return doc;
        }
    }
}
