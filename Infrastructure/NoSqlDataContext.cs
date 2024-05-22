using Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class NoSqlDataContext
    {
        private readonly IMongoDatabase _database;

        public NoSqlDataContext(IMongoClient client, string databaseName)
        {
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Car> Cars => _database.GetCollection<Car>("Cars");
        public IMongoCollection<Offer> Offers => _database.GetCollection<Offer>("Offers");

    }
}
