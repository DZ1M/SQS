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
        public static async Task SendSNS<T>(SNSFilaEnum fila, T obj)
        {
            //var json = JsonSerializer.Serialize(obj);
            //var client = new AmazonSNSClient(Amazon.RegionEndpoint.USEast1);
            //var request = new SendMessageRequest
            //{
            //    QueueUrl = $"https://sqs.us-east-1.amazonaws.com/296256985399/{fila}",
            //    MessageBody = json
            //};
            //await client.SendMessageAsync(request);
            await Task.CompletedTask;
        }
    }
}
