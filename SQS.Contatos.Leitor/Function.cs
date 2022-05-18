using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SQS.Contatos.Leitor;

public class Function
{
    private AmazonDynamoDBClient amazonDynamoDBClient { get; }
    public Function()
    {
        amazonDynamoDBClient = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast1);
    }

    /// <summary>
    /// This method is called for every Lambda invocation. This method takes in an SQS event object and can be used 
    /// to respond to SQS messages.
    /// </summary>
    /// <param name="evnt"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {
        if (evnt.Records.Count > 1) throw new InvalidOperationException("Permitido apenas 1 mensagem por vez.");

        var message = evnt.Records.FirstOrDefault();

        if (message is null) return;
        
        await ProcessMessageAsync(message, context);
        
    }

    private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        context.Logger.LogInformation($"Processed message {message.Body}");

        try
        {
            //log
            // alguma acao
            // proxima fila
        }
        catch
        {
            // log
            // devolver com erro
            // adicionar na fila de falha
        }

        // TODO: Do interesting work based on the new message
        await Task.CompletedTask;
    }
}