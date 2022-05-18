using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQS.Domain.Entities
{
    [DynamoDBTable("usuario")]
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
