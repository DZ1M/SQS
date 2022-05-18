using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using SQS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQS.Domain.Helpers
{
    public static class DynamoHelper
    {
        public static T ToObject<T>(this Dictionary<string, AttributeValue> dictionary)
        {
            var client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast1);
            var context = new DynamoDBContext(client);

            var doc = Document.FromAttributeMap(dictionary);
            return context.FromDocument<T>(doc);
        }

        public static async Task Save(this Contato obj)
        {
            var client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast1);
            var context = new DynamoDBContext(client);
            await context.SaveAsync(obj);
        }
    }
}
