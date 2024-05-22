using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Core.Entities
{
    public class Offer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Car Car { get; set; }

        public double Price { get; set; }

        public string Location { get; set; }

        public string Supplier {  get; set; }
    }
}
