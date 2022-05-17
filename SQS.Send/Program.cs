using Amazon.SQS;
using Amazon.SQS.Model;

Console.WriteLine("Send - SQS");

var client = new AmazonSQSClient(Amazon.RegionEndpoint.USEast1);

var url = "https://sqs.us-east-1.amazonaws.com/296256985399/TestSQS";
var body = "Cotoco";
var request = new SendMessageRequest(url, body);

await client.SendMessageAsync(request);
