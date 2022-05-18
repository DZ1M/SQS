using Amazon.SQS;
using Amazon.SQS.Model;
using SQS.Domain.Enums;
using System.Text.Json;

namespace SQS.Domain.Helpers
{
    public static class SQSHelper
    {
        public static async Task SendSQS<T>(SQSFilaEnum fila, T obj)
        {
            var json = JsonSerializer.Serialize(obj);
            var client = new AmazonSQSClient(Amazon.RegionEndpoint.USEast1);
            var request = new SendMessageRequest
            {
                QueueUrl = $"https://sqs.us-east-1.amazonaws.com/296256985399/{fila}",
                MessageBody = json
            };
            await client.SendMessageAsync(request);
        }
    }
}
