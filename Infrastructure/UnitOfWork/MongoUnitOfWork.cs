using Infrastructure.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class MongoUnitOfWork : IDisposable
    {
        
        public CarRepository CarRepository { get; }
        public OfferRepository OfferRepository { get; }

        public MongoUnitOfWork(NoSqlDataContext context)
        {
            CarRepository = new CarRepository(context);
            OfferRepository = new OfferRepository(context);
        }

        public void Dispose()
        {
            
        }
    }
}
