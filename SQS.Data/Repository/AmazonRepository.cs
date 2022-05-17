using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using SQS.Domain.Interfaces;

namespace SQS.Data.Repository
{
    public class AmazonRepository<TEntity> : IAmazonRepository<TEntity> where TEntity : class
    {
        public async Task Save(TEntity obj)
        {
            var client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast1);
            var context = new DynamoDBContext(client);
            await context.SaveAsync(obj);
        }
    }
}
