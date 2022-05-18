using Amazon.DynamoDBv2.DataModel;
using SQS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SQS.Domain.Entities
{
    [DynamoDBTable("contato")]
    public class Contato
    {
        public Guid Id { get;  set; }
        public Guid IdUsuario { get;  set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Data { get;  set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusContato Status { get; set; }
    }
}
