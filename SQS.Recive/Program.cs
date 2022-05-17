
using Amazon.SQS;
using Amazon.SQS.Model;

Console.WriteLine("Recive - SQS");

var client = new AmazonSQSClient(Amazon.RegionEndpoint.USEast1);
var url = $"https://sqs.us-east-1.amazonaws.com/296256985399/TestSQS";
var request = new ReceiveMessageRequest(url);

while (true)
{
    var messages = await client.ReceiveMessageAsync(request);
    foreach (var item in messages.Messages)
    {
        Console.WriteLine(item.Body);
        await client.DeleteMessageAsync(url, item.ReceiptHandle);
    }
}
