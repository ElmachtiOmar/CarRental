using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Entities
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Model { get; set; }

        public string ImageUrl {  get; set; }

        public int Seat { get; set; }

        public int Door { get; set; }

        public int Baggege { get; set; }

        public string Type {  get; set; }
    }
}
