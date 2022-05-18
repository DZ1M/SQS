using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SQS.Contatos.Collector;

public class Function
{
    
    public void FunctionHandler(DynamoDBEvent eventdb, ILambdaContext context)
    {
        foreach (var record in eventdb.Records)
        {

        }
    }
}
