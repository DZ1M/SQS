using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;
using SQS.Domain.Helpers;
using SQS.Domain.Entities;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using SQS.Domain.Enums;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SQS.Contatos.DynamoDB;

public class Function
{
    public async void FunctionHandler(DynamoDBEvent dynamoEvent, ILambdaContext context)
    {
        foreach (var record in dynamoEvent.Records)
        {
            if (record.EventName == "INSERT")
            {
                var contato = record.Dynamodb.NewImage.ToObject<Contato>();
                contato.Status = Domain.Enums.StatusContato.enviado;

                try
                {
                    await SQSHelper.SendSQS(SQSFilaEnum.contato, contato);
                }
                catch
                {
                    await SNSHelper.SendSNS(SNSFilaEnum.falha, contato);
                    contato.Status = Domain.Enums.StatusContato.erro;
                }
                finally
                {
                    await contato.Save();
                }

            }
        }
    }
    private async Task<Usuario> BuscarUsuarioPorId(Guid id)
    {
        var client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast1);
        var request = new QueryRequest
        {
            TableName = "usuario",
            KeyConditionExpression = "Id = :v_id", // evita inject
            ExpressionAttributeValues = new Dictionary<string, AttributeValue> { { ":v_id", new AttributeValue { S = id.ToString() } } }
        };

        var response = await client.QueryAsync(request);
        var item = response.Items.FirstOrDefault();
        if (item is null) return null;

        return item.ToObject<Usuario>();
    }

    
}