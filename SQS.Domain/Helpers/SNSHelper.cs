using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using SQS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SQS.Domain.Helpers
{
    public static class SNSHelper
    {
        public static async Task SendSNS<T>(string topicArn, T obj)
        {
            var json = JsonSerializer.Serialize(obj);

            var client = new AmazonSimpleNotificationServiceClient(RegionEndpoint.USEast1);

            var request = new PublishRequest(topicArn, json);

            await client.PublishAsync(request);
        }
    }
}
